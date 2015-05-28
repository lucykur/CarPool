require.config({
    baseUrl: "/",
    paths: {
        "angular": "node_modules/angular/angular",
        "Q": "node_modules/q/q",
        "jquery": "node_modules/jquery/dist/jquery.min",
        //Libs
        "lodash": "node_modules/lodash/lodash",
        "angular-route": "node_modules/angular-route/angular-route",

        //Controllers
        "hello-controller": "app/controller/hello-controller",
    },
    shim: {
        'angular': { exports: 'angular' },
        'lodash': {exports: '_'},
        'jquery': { exports: '$' },
        'angular-route': { deps: ["angular"], exports: 'angular_route' }
    }
});
console.log("Config is complete");