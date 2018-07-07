'use strict';

angular.module('loginApp').controller('logincontroller', function ($scope, $window, $rootScope, SecurityService, AppSettings, Utils) {
    $scope.model = {};

    $scope.login = function () {
        $rootScope.$broadcast('actionStart');

        if (!$scope.frmLogin.$valid) {
            $rootScope.$broadcast('actionComplate');
            $rootScope.$broadcast('formInvalid');
            return;
        }

        SecurityService.login($scope.model).then(function (data) {
            if (data.Response.errors) {
                $rootScope.$broadcast('server-side-validation-errors', data.Response.errors);
                return;
            }

            if (data.Response.FirstTimeLogIn) {
                Utils.setLocalStoreObject('username', data.Response.Username);
                $window.location.href = AppSettings.getMvcUrl('ChangePassword', null, null, null);
                return;
            }

            $window.location.href = AppSettings.getMvcUrl('Home', null, null, null);
        });
    };

    $scope.goToPasswordReset = function (e) {
        e.preventDefault();

        $window.location.href = AppSettings.getMvcUrl('ForgotPassword', null, null, null);
    };

});
