var carpoolApp = require("./app");
carpoolApp.bootstrap(carpoolApp.init()).then(function () {
    console.log("app initialized");
});
