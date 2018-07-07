'use strict';

angular.module('changePasswordApp').controller('changepasswordcontroller', function ($scope, $window, $rootScope, SecurityService, AppSettings, Utils) {
    $scope.model = {};

    $scope.changePassword = function () {
        $rootScope.$broadcast('actionStart');

        if (!$scope.frmChangePassword.$valid) {
            $rootScope.$broadcast('actionComplate');
            $rootScope.$broadcast('formInvalid');
            return;
        }

        SecurityService.changePassword($scope.model).then(function (data) {
            if (data.Response.errors) {
                $rootScope.$broadcast('server-side-validation-errors', data.Response.errors);
                return;
            }

            Utils.setLocalStoreObject('username', null);
            $window.location.href = AppSettings.getMvcUrl('Home', null, null, null);
        });
    };

    initialise();

    function initialise() {
        var username = Utils.getLocalStoreObject('username');

        if (username) {
            $scope.model.UserName = username;
        }
    }
});
