'use strict'

angular.module('sharedServices').directive('custom', function () {

    return {
        require: 'ngModel',
        restrict: 'A',
        link: function (scope, elm, attrs, ctrl) {
            //ctrl.$setValidity('custom', true);

            //scope.$watch("modelErrors", function (newValue, oldValue) {
            //    if (newValue && newValue[attrs['name']]) {
            //        ctrl.$setValidity('custom', false);
            //    }
            //    else {
            //        ctrl.$setValidity('custom', true);
            //    }
            //});

            //ctrl.$parsers.unshift(function (viewValue) {
            //    if (scope.modelErrors && scope.modelErrors[attrs['name']]) {
            //        delete scope.modelErrors[attrs['name']];
            //        ctrl.$setValidity('custom', true);
            //    }
            //    return viewValue;
            //});
        }
    };
});