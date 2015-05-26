define(["angular", "Q", "jquery", "app/controller/controllers","angular-route"],
  function (angular, Q, $, controllers) {
      var init = function () {
          var app = angular.module('CarPool', ["ngRoute"]);
          controllers.init(app);
       
          app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
              $routeProvider.
                when('/hello', { templateUrl: '/templates/hello.html', controller: 'helloController' }).
                otherwise({ redirectTo: '/hello' });

              $locationProvider.html5Mode(true);
          }]);
        
          return app;
      };

      var bootstrap = function(app) {
          var deferred = Q.defer();
          var injector = angular.bootstrap($('#CarPoolApp'), ['CarPool']);
          deferred.resolve([injector, app]);

          return deferred.promise;

      };
      return { init: init, bootstrap: bootstrap };
  });