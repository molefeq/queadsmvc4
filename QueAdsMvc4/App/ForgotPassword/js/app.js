var forgotPasswordApp = angular.module("forgotPasswordApp", ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'ui.bootstrap', 'sharedServices']);

forgotPasswordApp.run(['$rootScope', '$templateCache', function ($rootScope, $location, $log, $templateCache) {
    $rootScope.$on('$routeChangeStart', function () {
    });
}]);

forgotPasswordApp.config(['$routeProvider', '$httpProvider', '$locationProvider', 'TemplateViewBase', function ($routeProvider, $httpProvider, $locationProvider, TemplateViewBase) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push('HttpInterceptorFactory');

    $routeProvider
            .when('/', {
                redirectTo: '/ForgotPassword'
            })
            .when('/ForgotPassword', {
                templateUrl: TemplateViewBase + 'App/ForgotPassword/views/forgotpassword.html',
                controller: 'forgotpasswordcontroller'
            })
            .otherwise({
                redirectTo: '/ForgotPassword'
            });
    $locationProvider.html5Mode(true);

}]);
