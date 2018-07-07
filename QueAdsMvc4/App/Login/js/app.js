var loginApp = angular.module("loginApp", ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'sharedServices', 'ui.bootstrap', 'angularFileUpload']);

loginApp.run(['$rootScope', '$templateCache', function ($rootScope, $location, $log, $templateCache) {
    $rootScope.$on('$routeChangeStart', function () {
    });
}]);

loginApp.config(['$routeProvider', '$httpProvider', '$locationProvider', 'TemplateViewBase', function ($routeProvider, $httpProvider, $locationProvider, TemplateViewBase) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push('HttpInterceptorFactory');

    $routeProvider
            .when('/', {
                redirectTo: '/Login'
            })
            .when('/Login', {
                templateUrl: TemplateViewBase + 'App/Login/views/login.html',
                controller: 'logincontroller'
            })
            .otherwise({
                redirectTo: '/Login'
            });

    $locationProvider.html5Mode(true);
}]);
