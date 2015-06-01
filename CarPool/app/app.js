var angular = require("angular");
var Q = require("q");
var $ = require("jquery");
require("ui-router");
var controllers = require("./controller/controllers");
var routes = require("./routes/routes");


module.exports = {
    init: function() {
        var app = angular.module('CarPool', ['ui.router']);
        controllers.init(app);

        app.config(['$urlRouterProvider', '$stateProvider', '$locationProvider', routes]);
        return app;
    },

    bootstrap: function(app) {
        var deferred = Q.defer();
        angular.element(document).ready(function () {
            var injector = angular.bootstrap(document, ['CarPool']);
            deferred.resolve([injector, app]);
        });

        return deferred.promise;
    }
};