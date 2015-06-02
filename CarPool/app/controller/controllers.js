var helloController = require("./hello-controller");
var secureController = require("./secure-controller");

module.exports = {
    init: function(app) {
        app.controller('helloController', ['$scope', '$location', helloController]);
        app.controller('secureController', ['$scope', '$http', secureController]);
    }
};