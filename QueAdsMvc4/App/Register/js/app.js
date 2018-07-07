var registerUserApp = angular.module("registerUserApp", ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'sharedServices', 'ui.bootstrap', 'angularFileUpload']);

registerUserApp.run(['$rootScope', '$templateCache', function ($rootScope, $location, $log, $templateCache) {
    $rootScope.$on('$routeChangeStart', function () {
    });
}]);

registerUserApp.config(['$routeProvider', '$httpProvider', '$locationProvider', 'TemplateViewBase', function ($routeProvider, $httpProvider, $locationProvider, TemplateViewBase) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push('HttpInterceptorFactory');

    $routeProvider
            .when('/', {
                redirectTo: '/Register'
            })
            .when('/Register', {
                templateUrl: TemplateViewBase + 'App/Register/views/register.html',
                controller: 'registercontroller'
            })
            .otherwise({
                redirectTo: '/Register'
            });

    $locationProvider.html5Mode(true);
}]);
