var viewAdsApp = angular.module("viewAdsApp", ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'sharedServices', 'angularFileUpload', 'ui.bootstrap', 'angularFileUpload']);

viewAdsApp.run(['$rootScope', '$templateCache', function ($rootScope, $location, $log, $templateCache) {
    $rootScope.$on('$routeChangeStart', function () {
    });
}]);

viewAdsApp.config(['$routeProvider', '$httpProvider', '$locationProvider', 'TemplateViewBase', function ($routeProvider, $httpProvider, $locationProvider, TemplateViewBase) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push('HttpInterceptorFactory');

    $routeProvider
            .when('/', {
                redirectTo: '/Ads'
            })
            .when('/Ads', {
                templateUrl: TemplateViewBase + 'App/ViewAds/views/ads.html',
                controller: 'viewadscontroller'
            })
            .otherwise({
                redirectTo: '/Ads'
            });
    $locationProvider.html5Mode(true);
}]);
