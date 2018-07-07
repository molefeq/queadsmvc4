var saveAdApp = angular.module("saveAdApp", ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'sharedServices', 'ui.bootstrap', 'angularFileUpload']);

saveAdApp.run(['$rootScope', '$templateCache', function ($rootScope, $location, $log, $templateCache) {
    $rootScope.$on('$routeChangeStart', function () {
    });
}]);

saveAdApp.config(['$routeProvider', '$httpProvider', '$locationProvider', 'TemplateViewBase', function ($routeProvider, $httpProvider, $locationProvider, TemplateViewBase) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push('HttpInterceptorFactory');

    $routeProvider
            .when('/', {
                redirectTo: '/CreateAd'
            })
            .when('/CreateAd', {
                templateUrl: TemplateViewBase + 'App/SaveAd/views/ad.html',
                controller: 'saveadcontroller'
            })
            .when('/EditAd/:policyId', {
                templateUrl: TemplateViewBase + 'App/SaveAd/views/ad.html',
                controller: 'saveadcontroller'
            })
            .otherwise({
                redirectTo: '/CreateAd'
            });

    $locationProvider.html5Mode(true);
}]);
