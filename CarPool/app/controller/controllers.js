var secureController = require("./secure-controller");

module.exports = {
    init: function(app) {
        app.controller('secureController', ['$scope', '$http', secureController]);
    }
};