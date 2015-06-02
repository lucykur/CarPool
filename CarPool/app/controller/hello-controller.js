module.exports = function ($scope, $location) {
    $scope.name = "hello";
    $scope.navigateToSecurePage = function() {
        $location.path("/secure");
    };

};