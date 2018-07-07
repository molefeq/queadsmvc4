'use strict';

angular.module('sharedServices').directive('loadingModal', function ($uibModal) {
    return {
        restrict: 'EA',
        link: function link(scope, element, attributes) {
            scope.$on("loading-started", function (e) {
                element.css({ "display": "" });
            });

            scope.$on("loading-complete", function (e) {
                element.css({ "display": "none" });
            });

        }
    };
});
