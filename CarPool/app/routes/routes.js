module.exports = function($urlRouterProvider, $stateProvider, $locationProvider) {
    $urlRouterProvider.
        otherwise('/hello');

    $stateProvider
        .state('hello', {
            url: "/hello",
            templateUrl: "/templates/hello.html",
            controller: "helloController"
        });

    $locationProvider.html5Mode(true);
};

