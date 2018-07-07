'use strict';


angular.module('sharedServices').service('AppSettings', function ($location, $rootScope, ApplicationName, ServerBaseUrl) {
    var that = this;

    this.ApiUrls = {
        'GetProvinces': 'List/GetProvinces',
        'GeCategories': 'List/GeCategories',
        'SetUserSearchPreferences': 'Policy/SetUserSearchPreferences',
        'GetUserSearchPreferences': 'Policy/GetUserSearchPreferences',
        'SearchUserPolicies': 'Policy/SearchUserPolicies',
        'SearchPolicies': 'Policy/SearchPolicies',
        'GetRecentPolicies': 'Policy/GetRecentPolicies',
        'GetPolicy': 'Policy/GetPolicy',
        'PolicyReply': 'Policy/PolicyReply',
        'GetPolicyAdditionalData': 'Policy/GetPolicyAdditionalData',
        'UploadPolicyImage': 'Policy/UploadPolicyImage',
        'SavePolicy': 'Policy/SavePolicy',
        'Login': 'Security/Login',
        'RegisterUser': 'Security/RegisterUser',
        'ResetPassword': 'Security/ResetPassword',
        'ChangePassword': 'Security/ChangePassword',
        'Logoff': 'Security/Logoff',
        'EditUser': 'Security/EditUser',
        'GetUser': 'Security/GetUser',
        'SendContactUsMessage': 'ContactUs/SendContactUsMessage'
    };

    this.MvcUrls = {
        'ViewAds': '/Ads',
        'Home': '/',
        'ViewAd': '/Ad',
        'EditAd': '/EditAd',
        'UserAds': '/UserAds',
        'ForgotPassword': '/ForgotPassword',
        'Login': '/Login',
        'ChangePassword': '/ChangePassword'
    };

    this.getApiUrl = function (serviceName, params) {
        var serviceLocation = that.ApiUrls[serviceName];
        var ret = ServerBaseUrl + serviceLocation + '/';
        var separator = '?';

        if (params !== null) {
            for (var obj in params) {
                if (params.hasOwnProperty(obj)) {
                    ret = ret + separator + obj + "=" + params[obj];
                    separator = '&';
                }
            }
        }

        return ret;
    };

    this.getMvcUrl = function (urlName, areaName, paramsSeparator, params) {
        var url = ApplicationName + that.MvcUrls[urlName];

        if (areaName) {
            url = areaName + '/' + url;
        }

        if (params !== null) {
            for (var obj in params) {
                if (params.hasOwnProperty(obj)) {
                    if (paramsSeparator == '/') {
                        url = url + paramsSeparator + params[obj];
                    }
                    else {
                        url = url + '?' + obj + "=" + params[obj];
                        paramsSeparator = '&';
                    }
                }
            }
        }

        return url;
    };

});
