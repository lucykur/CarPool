module.exports = function($urlRouterProvider, $stateProvider, $locationProvider) {
    $urlRouterProvider.
        otherwise('/hello');

    $stateProvider
        .state('hello', {
            url: "/hello",
            templateUrl: "/templates/hello.html",
            controller: "helloController"
        })
        .state('secure', {
            url: "/secure",
            templateUrl: "/templates/secure.html",
            controller: "secureController"
        });

    $locationProvider.html5Mode(true);
};

