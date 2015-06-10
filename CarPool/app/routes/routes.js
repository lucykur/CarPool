module.exports = function($urlRouterProvider, $stateProvider, $locationProvider) {
    $urlRouterProvider.
        otherwise('/hello');

    $stateProvider
        .state('secure', {
            url: "/secure",
            templateUrl: "/templates/secure.html",
            controller: "secureController"
        });

    $locationProvider.html5Mode(true);
};

