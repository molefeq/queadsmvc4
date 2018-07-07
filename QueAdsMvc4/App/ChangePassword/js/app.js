var changePasswordApp = angular.module("changePasswordApp", ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'ui.bootstrap', 'sharedServices']);

changePasswordApp.run(['$rootScope', '$templateCache', function ($rootScope, $location, $log, $templateCache) {
    $rootScope.$on('$routeChangeStart', function () {
    });
}]);

changePasswordApp.config(['$routeProvider', '$httpProvider', '$locationProvider', 'TemplateViewBase', function ($routeProvider, $httpProvider, $locationProvider, TemplateViewBase) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push('HttpInterceptorFactory');

    $routeProvider
            .when('/', {
                redirectTo: '/ChangePassword'
            })
            .when('/ChangePassword', {
                templateUrl: TemplateViewBase + 'App/ChangePassword/views/changepassword.html',
                controller: 'changepasswordcontroller'
            })
            .otherwise({
                redirectTo: '/ChangePassword'
            });

    $locationProvider.html5Mode(true);
}]);
