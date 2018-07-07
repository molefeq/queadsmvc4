var contactUsApp = angular.module("contactUsApp", ['ngRoute', 'ngSanitize', 'ngAnimate', 'ngCookies', 'ui.bootstrap', 'sharedServices', 'angularFileUpload']);

contactUsApp.run(['$rootScope', '$templateCache', function ($rootScope, $location, $log, $templateCache) {
    $rootScope.$on('$routeChangeStart', function () {
    });
}]);

contactUsApp.config(['$routeProvider', '$httpProvider', '$locationProvider', 'TemplateViewBase', function ($routeProvider, $httpProvider, $locationProvider, TemplateViewBase) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.useXDomain = true;

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push('HttpInterceptorFactory');

    $routeProvider
            .when('/', {
                redirectTo: '/ContactUs'
            })
            .when('/ContactUs', {
                templateUrl: TemplateViewBase + 'App/ContactUs/views/contactus.html',
                controller: 'contactuscontroller'
            })
            .otherwise({
                redirectTo: '/ContactUs'
            });

    $locationProvider.html5Mode(true);
}]);
