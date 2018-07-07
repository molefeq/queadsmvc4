'use strict';

angular.module('homeApp').controller('homecontroller', function ($scope, $window, ListService, PolicyService, AppSettings, Utils) {

    $scope.initialise = function () {
        setSearchCriteria();

        $scope.initialiseCategories();
        $scope.initialiseProvinces();
        $scope.initialiseRecentPolicies();
    };

    $scope.initialiseCategories = function () {
        ListService.getCategories().then(function (data) {
            $scope.categories = data.Categories;
        });
    };

    $scope.initialiseProvinces = function () {
        ListService.getProvinces().then(function (data) {
            $scope.provinces = data.Provinces;
        });
    };

    $scope.initialiseRecentPolicies = function () {
        var categoryId = $scope.category && $scope.category.Id ? $scope.category.Id : '';
        var cityId = $scope.city && $scope.city.Id ? $scope.city.Id : '';
        var provinceId = $scope.province && $scope.province.Id ? $scope.province.Id : '';

        PolicyService.searchPolicies(categoryId, '', provinceId, cityId, '', '', 1, 30).then(function (data) {
            $scope.recentPolicies = data.Policies;
        });
    };

    $scope.viewProvinces = function () {
        $scope.city = {};
        $scope.province = {};

        Utils.setLocalStoreObject('province', null);
        Utils.setLocalStoreObject('city', null);

        $scope.initialiseRecentPolicies();
    };

    $scope.viewProvinceCities = function (province) {
        $scope.province = province;

        Utils.setLocalStoreObject('province', province);
        Utils.setLocalStoreObject('city', null);

        $scope.initialiseRecentPolicies();
    };

    $scope.viewCityAds = function (province, city) {
        Utils.setLocalStoreObject('province', province);
        Utils.setLocalStoreObject('city', city);

        $window.location.href = AppSettings.getMvcUrl('ViewAds', null, null, null);
    };

    $scope.viewCategoryAds = function (category) {
        Utils.setLocalStoreObject('category', category);
        Utils.setLocalStoreObject('subCategory', null);

        $window.location.href = AppSettings.getMvcUrl('ViewAds', null, null, null);
    };

    $scope.viewSubCategoryAds = function (category, subCategory) {
        Utils.setLocalStoreObject('category', category);
        Utils.setLocalStoreObject('subCategory', subCategory);

        $window.location.href = AppSettings.getMvcUrl('ViewAds', null, null, null);
        return;
    };

    $scope.displayCities = function () {
        return $scope.province && $scope.province.Id;
    };

    $scope.viewPolicy = function (policyId) {
        $window.location.href = AppSettings.getMvcUrl('ViewAd', null, '/', { policyId: policyId });
    };

    $scope.searchPolicies = function () {
        localStorage.searchText = $scope.searchText ? $scope.searchText : '';
        $window.location.href = AppSettings.getMvcUrl('ViewAds', null, null, null);
    };

    $scope.getCityClass = function (city) {
        if (city && city.Id && $scope.city && $scope.city.Id) {

            return city.Id == $scope.city.Id ? 'current-item' : '';
        }

        return '';
    };

    $scope.initialise();

    function setSearchCriteria() {
        var province = Utils.getLocalStoreObject('province');
        var city = Utils.getLocalStoreObject('city');

        Utils.setLocalStoreObject('category', null);
        Utils.setLocalStoreObject('subCategory', null);

        $scope.province = province ? province : {};
        $scope.city = city ? city : {};
    }
});
