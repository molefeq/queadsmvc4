angular.module('sharedServices').service('ListService', function ($http, $q, AppSettings) {
    var that = this;

    that.getProvinces = function (userProvince, userCity) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Get',
            url: AppSettings.getApiUrl('GetProvinces')
        })
        .success(function (data, status, headers, config) {
            var province = {};
            var city = {};

            if (userProvince) {
                for (var i = 0; i < data.length; i++) {
                    if (data[i].Id == userProvince.Id) {
                        province = data[i];
                        if (userCity) {
                            for (var j = 0; j < data[i].Cities.length; j++) {
                                if (data[i].Cities[j].Id == userCity.Id) {
                                    city = data[i].Cities[j];
                                }
                            }
                        }
                    }
                }
            }

            deferred.resolve({ 'Provinces': data, 'Province': province, 'City': city });
        });

        return deferred.promise;
    };

    that.getCategories = function (userCategory, userSubCategory) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Get',
            url: AppSettings.getApiUrl('GeCategories')
        })
        .success(function (data, status, headers, config) {
            var category = {};
            var subCategory = {};

            if (userCategory) {

                for (var i = 0; i < data.length; i++) {
                    if (data[i].Id == userCategory.Id) {
                        category = data[i];
                        if (userSubCategory) {
                            for (var j = 0; j < data[i].SubCategories.length; j++) {
                                if (data[i].SubCategories[j].Id == userSubCategory.Id) {
                                    subCategory = data[i].SubCategories[j];
                                }
                            }
                        }
                    }
                }
            }
            deferred.resolve({ 'Categories': data, 'Category': category, 'SubCategory': subCategory });
        })

        return deferred.promise;
    };

});