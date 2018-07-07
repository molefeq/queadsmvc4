var app = angular.module("QueAdsApp", ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'angularFileUpload', 'ui.bootstrap', 'sharedServices']);

app.factory('myHttpInterceptor', function ($q, $rootScope) {
    return {
        'request': function (config) {
            return config;
        },
        'requestError': function (rejection) {
            return $q.reject(rejection);
        },
        'response': function (response) {
            $rootScope.$broadcast('actionComplate');
            return response;
        },
        'responseError': function (rejection) {
            return $q.reject(rejection);
        }
    };
});

app.run(['$rootScope', '$templateCache', function ($rootScope, $location, $log, $templateCache) {
    $rootScope.$on('$routeChangeStart', function () {
    });
}]);

app.config(['$routeProvider', '$httpProvider', '$locationProvider', function ($routeProvider, $httpProvider, $locationProvider) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push('HttpInterceptorFactory');

   // $httpProvider.interceptors.push('myHttpInterceptor');
}]);
