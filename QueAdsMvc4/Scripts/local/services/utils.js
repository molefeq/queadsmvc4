'use strict';

angular.module('sharedServices').constant('ApplicationName', '');//'/QueAdsMvc4');//
angular.module('sharedServices').constant('TemplateViewBase', '');//'/');//
angular.module('sharedServices').constant('ServerBaseUrl', 'api/');//'http://localhost/QueAdsMvc4/');//'http://www.queads.co.za/api/');//

angular.module('sharedServices').service('Utils', function Utils() {

    var utilities = {};

    utilities.setLocalStoreObject = function (keyObject, valueObject) {
        if (valueObject) {
            localStorage[keyObject] = JSON.stringify(valueObject);
        }
        else if (localStorage[keyObject] !== undefined && localStorage[keyObject] !== null && !valueObject) {
            localStorage.removeItem(keyObject);
        }
    };

    utilities.getLocalStoreObject = function (keyObject) {
        if (localStorage[keyObject] === null || localStorage[keyObject] === undefined)
            return null;

        return JSON.parse(localStorage[keyObject]);
    };

    return utilities;
});