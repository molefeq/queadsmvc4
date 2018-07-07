'use strict';

angular.module('sharedServices').directive('actionControl', function () {
    return {
        restrict: 'EA',
        link: function link(scope, element, attributes) {
            scope.$on('actionStart', function (event, data) {
                $(element).prop("disabled", true);
                $(element).val(attributes.actionInProgressValue);
            });

            scope.$on('actionComplate', function (event, data) {
                $(element).removeAttr("disabled");
                $(element).val(attributes.actionValue);
            });

        }
    };
});
