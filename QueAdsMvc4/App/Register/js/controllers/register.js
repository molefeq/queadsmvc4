'use strict'

var modeldata = {
    //"Firstnames": "test",
    //"Lastname": "etst",
    //"UserName": "testuser1",
    //"Password": "testuser",
    //"ConfirmPassword": "testuser",
    //"EmailAddress": "molfefegmail.com",
    //"MobileNumber": ""
};

angular.module('registerUserApp').controller('registercontroller', function ($scope, $window, $rootScope, SecurityService, AppSettings) {
    $scope.model = modeldata;
    
    $scope.registerUser = function () {
        $rootScope.$broadcast('actionStart');

        if (!$scope.frmRegister.$valid) {
            $rootScope.$broadcast('actionComplate');
            $rootScope.$broadcast('formInvalid');
            return 0;
        }

        SecurityService.registerUser($scope.model).then(function (data) {
            if (data.Response.errors) {
                $rootScope.$broadcast('server-side-validation-errors', data.Response.errors);
                return;
            }

            $window.location.href = AppSettings.getMvcUrl('Home', null, null, null);
        });

    };

});