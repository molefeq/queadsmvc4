'use strict';

angular.module('editUserApp').controller('editusercontroller', function ($scope, $window, $rootScope, SecurityService, AppSettings) {
    $scope.user = {};
    $scope.editUserSuccess = false;
    
    $scope.editUser = function () {
        $rootScope.$broadcast('actionStart');

        if (!$scope.frmEditUser.$valid) {
            $rootScope.$broadcast('actionComplate');
            $rootScope.$broadcast('formInvalid');
            return 0;
        }

        SecurityService.editUser($scope.user).then(function (data) {
            if (data.Response.errors) {
                $rootScope.$broadcast('server-side-validation-errors', data.Response.errors);
                return;
            }

            $scope.editUserSuccess = true;
        });

    };

    $scope.goToUserAds = function (e) {
        e.preventDefault();

        $window.location.href = AppSettings.getMvcUrl('UserAds', null, null, null);
    };

    initialise();

    function initialise() {
        SecurityService.getUser().then(function (data) {
            $scope.user = data.User;
        });
    }
});
