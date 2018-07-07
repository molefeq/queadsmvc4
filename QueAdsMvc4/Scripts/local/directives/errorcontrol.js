'use strict';

angular.module('sharedServices').directive('errorControl', function ($uibModal) {
    return {
        restrict: 'EA',
        link: function link(scope, element, attributes) {

            scope.$on('ServerErrorOccurredNew', function (event, data) {
                var test = 'tets';
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: 'App/views/errormodal.html',
                    controller: 'errorcontroller',
                    size: 'sm',
                    resolve: {
                        errorcontent: function () {
                            return data;
                        }
                    }
                });

                modalInstance.result.then(function () {

                }, function () {
                    console.log('Modal dismissed at: ' + new Date());
                });
            });
        }
    };
});
