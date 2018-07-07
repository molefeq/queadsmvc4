'use strict'

angular.module('sharedServices').directive("additionalField", function ($compile) {

    var linkFunction = function (scope, element, attributes, formController) {
    };

    return {
        restrict: "E",
        link: linkFunction,
        require: '^form',
        replace: true,
        templateUrl: 'additionalfield.html',
        scope: {
            policyAdditionalField: '=policysubcategoryadditionalfield',
            policyAdditionalFieldOptions: '=policysubcategoryadditionalfieldoptions',
            formsubmitted: '=formsubmitted',
            controlname: '@controlname',
            setchildadditionalfield: '&setchildadditionalfield'
        }
    };
});