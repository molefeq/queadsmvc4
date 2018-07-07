'use strict';

angular.module('forgotPasswordApp').controller('forgotpasswordcontroller', function ($scope, $window, $rootScope, SecurityService, AppSettings) {
    $scope.model = {};

    $scope.resetPassword = function () {
        $rootScope.$broadcast('actionStart');

        if (!$scope.frmLForgotPassword.$valid) {
            $rootScope.$broadcast('actionComplate');
            $rootScope.$broadcast('formInvalid');
            return;
        }

        SecurityService.resetPassword($scope.model).then(function (data) {
            if (data.Response.errors) {
                $rootScope.$broadcast('server-side-validation-errors', data.Response.errors);
                return;
            }

            $scope.resetPasswordSuccessful = true;
        });
    };

    $scope.goToLogin = function (e) {
        e.preventDefault();

        $window.location.href = AppSettings.getMvcUrl('Login', null, null, null);
    };
});
