angular.module('sharedServices').service('ContactUsService', function ($http, $q, AppSettings) {
    var that = this;

    that.contactUs = function (contactMessage) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Post',
            url: AppSettings.getApiUrl('SendContactUsMessage'),
            data: contactMessage
        })
        .success(function (data, status, headers, config) {
            deferred.resolve();
        })

        return deferred.promise;
    };
});