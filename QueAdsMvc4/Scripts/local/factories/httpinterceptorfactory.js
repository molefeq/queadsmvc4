'use strict';

angular.module('sharedServices').factory('HttpInterceptorFactory', function ($q, $rootScope, ErrorFactory) {
    return {
        'request': function (config) {
           // config.withCredentials = true;
            var token = localStorage.getItem('tokenKey');
            if (token) {
                config.headers.Authorization = 'Bearer ' + token;
            }
            //config.timeout = 30000;

            $rootScope.$broadcast('loading-started');

            return config;
        },
        'requestError': function (rejection) {
            return $q.reject(rejection);
        },
        'response': function (response) {
            $rootScope.$broadcast('actionComplate');
            $rootScope.$broadcast('loading-complete');

            return response;
        },
        'responseError': function (rejection) {
            ErrorFactory.handleError(rejection);

            return $q.reject(rejection);
        }
    };
});