'use strict';

angular.module('viewAdsApp').controller('viewadscontroller', function ($scope, $window, ListService, PolicyService, AppSettings, GridPager, Utils) {
    $scope.categories = [];
    $scope.subcategories = [];
    $scope.policies = [];
    $scope.provinces = [];
    $scope.isProvincesInitialized = false;
    $scope.isCategoriesInitialized = false;
    $scope.isViewInitialized = false;
    $scope.offerType = '';
    $scope.searchText = '';
    $scope.category = {};
    $scope.subCategory = {};
    $scope.province = {};
    $scope.city = {};
    $scope.gridPage = GridPager;

    $scope.initialise = function () {
        setSearchCriteria();

        $scope.initialiseCategories();
        $scope.initialiseProvinces();
    };

    $scope.initialiseCategories = function () {
        ListService.getCategories().then(function (data) {

            $scope.categories = data.Categories;
            $scope.isCategoriesInitialized = true;
        });
    };

    $scope.initialiseProvinces = function () {
        ListService.getProvinces().then(function (data) {
            $scope.provinces = data.Provinces;
            $scope.isProvincesInitialized = true;
        });
    };

    $scope.searchAds = function (isSearch) {
        var categoryId = $scope.category.Id ? $scope.category.Id : '';
        var subCategoryId = $scope.subCategory.Id ? $scope.subCategory.Id : '';
        var provinceId = $scope.province.Id ? $scope.province.Id : '';
        var cityId = $scope.city.Id ? $scope.city.Id : '';

        PolicyService.searchPolicies(categoryId, subCategoryId, provinceId, cityId, $scope.searchText, $scope.offerType, $scope.gridPage.PageIndex, $scope.gridPage.PageSize).then(function (data) {
            $scope.gridPage.SetPages(data.Total);
            $scope.policies = data.Policies;
            $scope.total = data.Total;
        });
    };

    $scope.setPage = function (pageIndex) {
        $scope.gridPage.PageIndex = pageIndex;
    };

    $scope.prevPage = function () {
        if ($scope.gridPage.PageIndex > 1) {
            $scope.gridPage.PageIndex = $scope.gridPage.PageIndex - 1;
        }
    };

    $scope.nextPage = function () {
        if ($scope.gridPage.PageIndex < $scope.gridPage.TotalPages) {
            $scope.gridPage.PageIndex = $scope.gridPage.PageIndex + 1;
        }
    };

    $scope.prevPageDisabled = function () {
        return $scope.gridPage.IsFirstPage ? "disabled" : "";
    };

    $scope.nextPageDisabled = function () {
        return $scope.gridPage.IsLastPage ? "disabled" : "";
    };

    $scope.$watch("gridPage.PageIndex", function (newValue, oldValue) {
        if ($scope.isProvincesInitialized && $scope.isCategoriesInitialized) {
            $scope.searchAds();
        }
    });

    $scope.$watchGroup(['isCategoriesInitialized', 'isProvincesInitialized'], function (newValue, oldValue) {
        if ($scope.isProvincesInitialized && $scope.isCategoriesInitialized && !$scope.isViewInitialized) {
            $scope.gridPage.PageIndex = 1;
            $scope.gridPage.PageSize = 20;
            $scope.isViewInitialized = true;
        }
    });

    $scope.getProvincePolicies = function (e, province) {
        e.preventDefault();

        Utils.setLocalStoreObject('province', province);
        Utils.setLocalStoreObject('city', null);

        $scope.province = province;
        $scope.city = {};

        $scope.searchPolicies();
    };

    $scope.getCityPolicies = function (e, province, city) {
        e.preventDefault();

        Utils.setLocalStoreObject('province', province);
        Utils.setLocalStoreObject('city', city);

        $scope.province = province;
        $scope.city = city;

        $scope.searchPolicies();
    };

    $scope.getCategoryPolicies = function (e, category) {
        e.preventDefault();

        Utils.setLocalStoreObject('category', category);
        Utils.setLocalStoreObject('subCategory', null);

        $scope.category = category;
        $scope.subCategory = {};

        $scope.searchPolicies();
    };

    $scope.getSubCategoryPolicies = function (e, category, subCategory) {
        e.preventDefault();

        $scope.category = category;
        $scope.subCategory = subCategory;

        Utils.setLocalStoreObject('category', category);
        Utils.setLocalStoreObject('subCategory', subCategory);

        $scope.searchPolicies();
    };

    $scope.searchPolicies = function () {
        if ($scope.gridPage.PageIndex == 1) {
            $scope.searchAds();
        }
        else {
            $scope.gridPage.PageIndex = 1;
        }
    };

    $scope.getAllCategoryPolicies = function (e) {
        e.preventDefault();

        $scope.category = {};
        $scope.subCategory = {};

        if ($scope.gridPage.PageIndex == 1) {
            $scope.searchAds();
        }
        else {
            $scope.gridPage.PageIndex = 1;
        }
    };

    $scope.getAllLocationPolicies = function (e) {
        e.preventDefault();

        $scope.province = {};
        $scope.city = {};

        if ($scope.gridPage.PageIndex == 1) {
            $scope.searchAds();
        }
        else {
            $scope.gridPage.PageIndex = 1;
        }
    };

    $scope.viewCityAds = function (province, city) {
        PolicyService.setSearchPreferences(null, null, province, city).then(function (data) {
            $window.location.href = AppSettings.getMvcUrl('ViewAds', null, null, null);
        });
    };

    $scope.displayCities = function () {
        return $scope.province && $scope.province.Id;
    };

    $scope.getProvinceClass = function (province) {
        if (province && province.Id && $scope.province && $scope.province.Id) {

            return province.Id == $scope.province.Id ? 'current-item' : '';
        }

        return '';
    };

    $scope.getCityClass = function (city) {
        if (city && city.Id && $scope.city && $scope.city.Id) {

            return city.Id == $scope.city.Id ? 'current-item' : '';
        }

        return '';
    };

    $scope.getAllCategoriesClass = function () {
        if (!$scope.subCategory.Id && !$scope.category.Id) {
            return 'current-item';
        }

        return '';
    };

    $scope.getSubCategoryClass = function (subCategory) {
        if (subCategory && subCategory.Id && $scope.subCategory && $scope.subCategory.Id) {

            return subCategory.Id == $scope.subCategory.Id ? 'current-item' : '';
        }

        return '';
    };

    $scope.getCategoryClass = function (category) {
        if (category && category.Id && $scope.category && $scope.category.Id) {

            return category.Id == $scope.category.Id ? 'current-item' : '';
        }

        if (!category && (!$scope.category || !$scope.category.Id)) {
            return 'current-item';
        }
        return '';
    };

    $scope.viewPolicy = function (policyId) {
        $window.location.href = AppSettings.getMvcUrl('ViewAd', null, '/', { policyId: policyId });
    };

    $scope.initialise();

    function setSearchCriteria() {
        var category = Utils.getLocalStoreObject('category');
        var subCategory = Utils.getLocalStoreObject('subCategory');
        var province = Utils.getLocalStoreObject('province');
        var city = Utils.getLocalStoreObject('city');

        $scope.searchText = localStorage.searchText ? localStorage.searchText : '';
        localStorage.searchText = '';

        $scope.category = category ? category : {};
        $scope.subCategory = subCategory ? subCategory : {};
        $scope.province = province ? province : {};
        $scope.city = city ? city : {};
    }
});
