var helloController = require("./hello-controller");
module.exports = {
    init: function(app) {
        app.controller('helloController', ['$scope', helloController]);
    }
};