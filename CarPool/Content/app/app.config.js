require.config({
    baseUrl: "/",
    paths: {
        "angular": "bower_components/angular/angular",
        "Q": "bower_components/q/q",
        "jquery": "bower_components/jquery/dist/jquery.min",
        //Libs
        "lodash": "bower_components/lodash/lodash",
        "angular-route": "bower_components/angular-route/angular-route",

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