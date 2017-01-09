(function (app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);
    rootCtrl.$inject = ['$scope', '$location', '$rootScope'];

    function rootCtrl($scope, $location, $rootScope) {
        $scope.userData = {};

        $scope.userData.displayUserInfo = displayUserInfo;
        $scope.logout = logout;

        function displayUserInfo() {

        }
        function logout() {

        }
    }
})(angular.module('homeCinemaNgApi'));