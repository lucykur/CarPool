var angular = require("angular");
var Q = require("q");
var $ = require("jquery");
require("ui-router");
var controllers = require("./controller/controllers");


module.exports = {
    init: function() {
        var app = angular.module('CarPool', ['ui.router']);
        controllers.init(app);
        app.config([
            '$urlRouterProvider', '$stateProvider', '$locationProvider', function($urlRouterProvider, $stateProvider, $locationProvider) {
                $urlRouterProvider.
                    otherwise('/hello');

                $stateProvider
                    .state('hello', {
                        url: "/hello",
                        templateUrl: "/templates/hello.html",
                        controller: "helloController"
                    });

                $locationProvider.html5Mode(true);
            }
        ]);
        return app;
    },

    bootstrap: function(app) {
        var deferred = Q.defer();
        var injector = angular.bootstrap($('#CarPoolApp'), ['CarPool']);
        deferred.resolve([injector, app]);

        return deferred.promise;

    }
};