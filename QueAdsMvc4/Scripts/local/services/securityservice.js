angular.module('sharedServices').service('SecurityService', function ($http, $q, AppSettings) {
    var that = this;

    that.login = function (loginModel) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Post',
            url: AppSettings.getApiUrl('Login'),
            data: loginModel
        })
        .success(function (data, status, headers, config) {
            deferred.resolve({ 'Response': data });
        })

        return deferred.promise;
    };

    that.registerUser = function (registerModel) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Post',
            url: AppSettings.getApiUrl('RegisterUser'),
            data: registerModel
        })
        .success(function (data, status, headers, config) {
            deferred.resolve({ 'Response': data });
        })

        return deferred.promise;
    };

    that.logOff = function () {
        var deferred = $q.defer();

        $http(
        {
            method: 'Get',
            url: AppSettings.getApiUrl('Logoff')
        })
        .success(function (data, status, headers, config) {

            deferred.resolve({ 'Policies': data.Data, "Total": data.Total });
        })

        return deferred.promise;
    };

    that.editUser = function (userModel) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Post',
            url: AppSettings.getApiUrl('EditUser'),
            data: userModel
        })
        .success(function (data, status, headers, config) {
            deferred.resolve({ 'Response': data });
        })

        return deferred.promise;
    };

    that.getUser = function () {
        var deferred = $q.defer();

        $http(
        {
            method: 'Get',
            url: AppSettings.getApiUrl('GetUser')
        })
        .success(function (data, status, headers, config) {

            deferred.resolve({ 'User': data });
        })

        return deferred.promise;
    };

    that.resetPassword = function (forgotPasswordModel) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Post',
            url: AppSettings.getApiUrl('ResetPassword', { userName: forgotPasswordModel.UserName })
        })
        .success(function (data, status, headers, config) {
            deferred.resolve({ 'Response': data });
        })

        return deferred.promise;
    };

    that.changePassword = function (changePasswordModel) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Post',
            url: AppSettings.getApiUrl('ChangePassword'),
            data: changePasswordModel
        })
        .success(function (data, status, headers, config) {
            deferred.resolve({ 'Response': data });
        })

        return deferred.promise;
    };
});