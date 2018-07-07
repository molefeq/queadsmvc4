'use strict'

//var modeldata = {
//    "UserDetails": "test",
//    "EmailAddress": "etst",
//    "Message": "testuser1"
//};

angular.module('contactUsApp').controller('contactuscontroller', function ($scope, $window, $rootScope, ContactUsService) {
    $scope.model = {};//modeldata;

    $scope.contactUs = function () {
        $rootScope.$broadcast('actionStart');

        if (!$scope.frmContactUs.$valid) {
            $rootScope.$broadcast('actionComplate');
            $rootScope.$broadcast('formInvalid');
            return 0;
        }

        ContactUsService.contactUs($scope.model).then(function (data) {
            if (data.Response.errors) {
                $rootScope.$broadcast('server-side-validation-errors', data.Response.errors);
                return;
            }
            $scope.messageSent = true
        });

    };

});