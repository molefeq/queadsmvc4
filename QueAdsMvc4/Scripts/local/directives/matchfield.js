'use strict'

angular.module('sharedServices').directive('matchfield', function () {

    return {
        require: 'ngModel',
        scope: {
            otherModelValue: "=matchfield"
        },
        link: function (scope, elm, attrs, ctrl) {

            ctrl.$parsers.unshift(function (viewValue) {
                if (!viewValue) {
                    ctrl.$setValidity('matchfield', true);
                }
                else {
                    ctrl.$setValidity('matchfield', viewValue == scope.otherModelValue);
                }
                return viewValue;
            });

            scope.$watch('otherModelValue', function (newValue, oldValue) {
                if (!newValue) {
                    ctrl.$setValidity('matchfield', true);
                }
                else {
                    ctrl.$setValidity('matchfield', newValue == ctrl.$viewValue);
                }
            });
        }
    };
});