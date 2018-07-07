var userAdsApp = angular.module("userAdsApp", ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'sharedServices', 'ui.bootstrap', 'angularFileUpload']);

userAdsApp.run(['$rootScope', '$templateCache', function ($rootScope, $location, $log, $templateCache) {
    $rootScope.$on('$routeChangeStart', function () {

    });
}]);

userAdsApp.config(['$routeProvider', '$httpProvider', '$locationProvider', 'TemplateViewBase', function ($routeProvider, $httpProvider, $locationProvider, TemplateViewBase) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push('HttpInterceptorFactory');

    $routeProvider
            .when('/', {
                redirectTo: '/UserAds'
            })
            .when('/UserAds', {
                templateUrl: TemplateViewBase + 'App/UserAds/views/userads.html',
                controller: 'useradscontroller'
            })
            .otherwise({
                redirectTo: '/UserAds'
            });

    $locationProvider.html5Mode(true);
}]);
