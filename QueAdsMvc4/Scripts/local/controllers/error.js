'use strict'

sharedApp.controller('errorcontroller', function ($scope, $uibModalInstance, errorcontent) {

    $scope.errorcontent = errorcontent;

    $scope.ok = function () {
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

});
