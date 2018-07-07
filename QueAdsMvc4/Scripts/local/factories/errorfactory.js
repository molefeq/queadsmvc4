'use strict';

sharedApp.factory('ErrorFactory', function ($rootScope) {

    var _ErrorMessage = '';
    var _ErrorTitle = '';
    var _ErrorDetail = '';
    var _ErrorCode = '';
    var _ErrorMessages = '';

    var error = {};

    var errors = {
        0: 'Internal Error',
        1: 'Invalid Request',
        400: 'Bad Request',
        401: 'User is not authorized to use this resource',
        403: 'User is forbidden from accessing the resource',
        405: 'Method Not Allowed',
        407: 'Proxy Authentication Required',
        408: 'Request Timeout',
        700: 'Facebook Share Error'
    };

    error.handleError = function (data) {
        if (!data) {
            return;
        }

        var errorCode = data.status

        var errorResponse = {
            'errorCode': errorCode,
            'errorMessage': error.getErrorTitle(errorCode),
            'errorDetail': error.getErrorDetail(errorCode, data),
        };
                
        $rootScope.$broadcast('ServerErrorOccurredNew', errorResponse);
        $rootScope.$broadcast('actionComplate');
    };

    error.getErrorTitle = function (errorCode) {
        if (errorCode <= 0 || errorCode >= 500) {
            return errors[0];
        }

        if (errors[errorCode]) {
            return errors[errorCode];
        }

        if (errorCode >= 400) {
            return errors[1];
        }
    };

    error.getErrorDetail = function (errorCode, data) {
        if (errorCode <= 0) {
            return 'You are not online. Please check your connectivity and try again';
        }

        if (data.data && data.data.Message) {
            switch (errorCode) {
                case 405:
                    var errorMessage = data.config.url + ' does not support method ' + data.config.method;
                    return errorMessage;
                default:
                    return data.data.Message;
            }
        }

        return data.statusText;
    };

    return error;
});