angular.module('sharedServices').service('PolicyService', function ($http, $q, AppSettings, $upload) {
    var that = this;

    that.getSearchPreferences = function (category, subCategory, province, city) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Get',
            url: AppSettings.getApiUrl('GetUserSearchPreferences')
        })
        .success(function (data, status, headers, config) {
            deferred.resolve({ 'Category': data.Category, 'SubCategory': data.SubCategory, 'Province': data.Province, 'City': data.City });
        })

        return deferred.promise;
    };

    that.setSearchPreferences = function (category, subCategory, province, city) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Post',
            url: AppSettings.getApiUrl('SetUserSearchPreferences'),
            data: {
                Category: category,
                SubCategory: subCategory,
                Province: province,
                City: city
            }
        })
        .success(function (data, status, headers, config) {

            deferred.resolve();
        })

        return deferred.promise;
    };

    that.searchPolicies = function (categoryId, subCategoryId, provinceId, cityId, searchText, offerType, pageIndex, pageSize) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Get',
            url: AppSettings.getApiUrl('SearchPolicies'),
            params: {
                categoryId: categoryId,
                subCategoryId: subCategoryId,
                provinceId: provinceId,
                cityId: cityId,
                searchText: searchText,
                offerType: offerType,
                pageIndex: pageIndex,
                pageSize: pageSize
            }
        })
        .success(function (data, status, headers, config) {

            deferred.resolve({ 'Policies': data.Data, "Total": data.Total });
        })

        return deferred.promise;
    };

    that.searchUserPolicies = function (categoryId, subCategoryId, provinceId, cityId, searchText, offerType, pageIndex, pageSize) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Get',
            url: AppSettings.getApiUrl('SearchUserPolicies'),
            params: {
                categoryId: categoryId,
                subCategoryId: subCategoryId,
                provinceId: provinceId,
                cityId: cityId,
                searchText: searchText,
                offerType: offerType,
                pageIndex: pageIndex,
                pageSize: pageSize
            }
        })
        .success(function (data, status, headers, config) {

            deferred.resolve({ 'Policies': data.GroupedResults, "Total": data.Total });
        })

        return deferred.promise;
    };

    that.getRecentPolicies = function (categoryId, provinceId) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Get',
            url: AppSettings.getApiUrl('GetRecentPolicies', { categoryId: categoryId, provinceId: provinceId })
        })
        .success(function (data, status, headers, config) {
            deferred.resolve({ 'RecentPolicies': data });
        })

        return deferred.promise;
    };

    that.getPolicy = function (policyId) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Get',
            url: AppSettings.getApiUrl('GetPolicy', { policyId: policyId })
        })
        .success(function (data, status, headers, config) {
            deferred.resolve({ 'Policy': data });
        })

        return deferred.promise;
    };

    that.replyPolicy = function (policyReply) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Post',
            url: AppSettings.getApiUrl('PolicyReply'),
            data: policyReply
        })
        .success(function (data, status, headers, config) {
            deferred.resolve();
        })

        return deferred.promise;
    };

    that.savePolicy = function (policy) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Post',
            url: AppSettings.getApiUrl('SavePolicy'),
            data: policy
        })
        .success(function (data, status, headers, config) {
            deferred.resolve({ Errors: data.errors, Policy: data });
        })

        return deferred.promise;
    };

    that.getPolicyAdditionalData = function (subCategoryId) {
        var deferred = $q.defer();

        $http(
        {
            method: 'Get',
            url: AppSettings.getApiUrl('GetPolicyAdditionalData', { subCategoryId: subCategoryId })
        })
        .success(function (data, status, headers, config) {
            deferred.resolve({ AdditionalFields: data.policysubcategoryadditionalfields, AdditionalFieldOptions: data.policyadditionalfieldoptions });
        })

        return deferred.promise;
    };

    that.uploadPolicyImages = function (files, policyImages) {
        var deferred = $q.defer();

        policyImages = [];

        if (files && files.length) {
            for (var i = 0; i < files.length; i++) {
                var file = files[i];

                that.uploadPolicyImage(file).then(function (data) {
                    policyImages.push(data.PolicyImage)
                });
            }

            deferred.resolve();
        }

        return deferred.promise;
    };

    that.uploadPolicyImage = function (file) {
        var deferred = $q.defer();
        $upload.upload({
            url: AppSettings.getApiUrl('UploadPolicyImage'),
            method: "POST",
            file: file
        }).progress(function (evt) {
            var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
            console.log('progress: ' + progressPercentage + '% ' + evt.config.file.name);
        }).success(function (data, status, headers, config) {
            deferred.resolve({ PolicyImage: data });
        });

        return deferred.promise;
    };

    that.shareAdOnFacebook = function (policy, currentImage, url) {

        var sharObject = {
            method: 'share',
            href: 'http://www.queads.co.za',//url,
            title: policy.Subject,
            caption: 'www.queads.co.za',
            description: policy.Description
        }

        if (currentImage && currentImage.NormalImageUrl) {
            sharObject.image = currentImage.NormalImageUrl;
            sharObject.picture = currentImage.NormalImageUrl;
        }

        FB.ui(sharObject, function (response) {
            //if (response && !response.error_message) {

            //} else {
            //    alert('Error while posting.');
            //}
        });
    }
});