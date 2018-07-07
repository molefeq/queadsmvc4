var viewAdApp = angular.module("viewAdApp", ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'sharedServices', 'ui.bootstrap', 'angularFileUpload']);

viewAdApp.run(['$rootScope', '$templateCache', '$routeParams', '$location', function ($rootScope, $templateCache, $routeParams, $location) {
    $rootScope.$on('$routeChangeStart', function () {
       
    });
}]);

viewAdApp.config(['$routeProvider', '$httpProvider', '$locationProvider', 'TemplateViewBase', function ($routeProvider, $httpProvider, $locationProvider, TemplateViewBase) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push('HttpInterceptorFactory');

    $routeProvider
            .when('/', {
                redirectTo: '/Ad'
            })
            .when('/Ad', {
                templateUrl: TemplateViewBase + 'App/ViewAd/views/viewad.html',
                controller: 'viewadcontroller'
            })
            .when('/Ad/:policyId', {
                templateUrl: TemplateViewBase + 'App/ViewAd/views/viewad.html',
                controller: 'viewadcontroller'
            })
            .otherwise({
                redirectTo: '/Ad'
            });

    $locationProvider.html5Mode(true);

}]);
