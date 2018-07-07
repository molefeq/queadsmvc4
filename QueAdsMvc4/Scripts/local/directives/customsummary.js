'use strict'

angular.module('sharedServices').directive('customSummary', function () {

    return {
        link: function (scope, elm, attrs, ctrl) {

            scope.$watch("modelErrors['summaryerrors']", function (newValue, oldValue) {
                if (newValue) {
                    elm.empty();
                    for (var i = 0; i < newValue.length; i++) {
                        var error_message = newValue[i];
                        elm.append('<li class="help-block">' + error_message + '</li>');
                    }
                }
            });

        }
    };
});