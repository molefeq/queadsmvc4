var homeApp = angular.module("homeApp", ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'sharedServices', 'ui.bootstrap', 'angularFileUpload']);

homeApp.run(['$rootScope', '$templateCache', function ($rootScope, $location, $log, $templateCache) {
    $rootScope.$on('$routeChangeStart', function () {
    });
}]);

homeApp.config(['$routeProvider', '$httpProvider', '$locationProvider', 'TemplateViewBase', function ($routeProvider, $httpProvider, $locationProvider, TemplateViewBase) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push('HttpInterceptorFactory');

    $routeProvider
            .when('/', {
                templateUrl: TemplateViewBase + 'App/Home/views/home.html',
                controller: 'homecontroller'
            })
            .when('/home', {
                redirectTo: '/'
            })
            .otherwise({
                redirectTo: '/'
            });

    $locationProvider.html5Mode(true);

}]);
