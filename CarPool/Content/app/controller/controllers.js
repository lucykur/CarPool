define(['hello-controller'], function(helloController) {
    var init = function(app) {
        app.controller('helloController', ['$scope', helloController]);
    };
    return { init: init };
});