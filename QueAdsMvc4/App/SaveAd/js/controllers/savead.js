'use strict';

var createpolicydata = {
    "Category":
        {
            "Id": 6,
            "Name": "Community",
            "PolicyCount": 33,
            "SubCategories": [
                { "Id": 147, "Categories_Id": 6, "Name": "Carpool", "PolicyCount": 16 },
                { "Id": 148, "Categories_Id": 6, "Name": "Community Activities", "PolicyCount": 4 },
                { "Id": 149, "Categories_Id": 6, "Name": "Events", "PolicyCount": 4 },
                { "Id": 152, "Categories_Id": 6, "Name": "Lost & Found", "PolicyCount": 7 },
                { "Id": 150, "Categories_Id": 6, "Name": "Musicians & Artists & Bands", "PolicyCount": 0 },
                { "Id": 151, "Categories_Id": 6, "Name": "Volunteers", "PolicyCount": 2 }
            ]
        }, "SubCategory": {
            "Id": 147,
            "Categories_Id": 6,
            "Name": "Carpool",
            "PolicyCount": 16
        },
    "PolicySubCategoryAdditionalFields": [],
    "Province": {
        "Id": 37,
        "Name": "Eastern Cape",
        "Cities":
            [{ "Id": 1, "Provinces_Id": 37, "Name": "Adelaide" }, { "Id": 2, "Provinces_Id": 37, "Name": "Alice" }, { "Id": 3, "Provinces_Id": 37, "Name": "Aliwal North" }, { "Id": 4, "Provinces_Id": 37, "Name": "Barkly East" }, { "Id": 5, "Provinces_Id": 37, "Name": "Bhisho" }, { "Id": 6, "Provinces_Id": 37, "Name": "Bizana" }, { "Id": 7, "Provinces_Id": 37, "Name": "Burgersdorp" }, { "Id": 8, "Provinces_Id": 37, "Name": "Butterworth" }, { "Id": 9, "Provinces_Id": 37, "Name": "Coffee Bay" }, { "Id": 10, "Provinces_Id": 37, "Name": "Cradock" }, { "Id": 11, "Provinces_Id": 37, "Name": "East London" }, { "Id": 12, "Provinces_Id": 37, "Name": "Elliot" }, { "Id": 13, "Provinces_Id": 37, "Name": "Flagstaff" }, { "Id": 14, "Provinces_Id": 37, "Name": "Fort Beaufort" }, { "Id": 15, "Provinces_Id": 37, "Name": "Graaff-Reinet" }, { "Id": 16, "Provinces_Id": 37, "Name": "Grahamstown" }, { "Id": 17, "Provinces_Id": 37, "Name": "Jansenville" }, { "Id": 18, "Provinces_Id": 37, "Name": "Jeffreys Bay" }, { "Id": 19, "Provinces_Id": 37, "Name": "Kareedouw" }, { "Id": 20, "Provinces_Id": 37, "Name": "Kirkwood" }, { "Id": 21, "Provinces_Id": 37, "Name": "Mdantsane" }, { "Id": 22, "Provinces_Id": 37, "Name": "Middelburg" }, { "Id": 23, "Provinces_Id": 37, "Name": "Other Eastern Cape" }, { "Id": 24, "Provinces_Id": 37, "Name": "Port Alfred" }, { "Id": 25, "Provinces_Id": 37, "Name": "Port Elizabeth" }, { "Id": 26, "Provinces_Id": 37, "Name": "Port St Johns" }, { "Id": 27, "Provinces_Id": 37, "Name": "Queenstown" }, { "Id": 28, "Provinces_Id": 37, "Name": "Somerset East" }, { "Id": 29, "Provinces_Id": 37, "Name": "Stutterheim" }, { "Id": 30, "Provinces_Id": 37, "Name": "Uitenhage" }, { "Id": 31, "Provinces_Id": 37, "Name": "Umtata / Mthatha" }, { "Id": 32, "Provinces_Id": 37, "Name": "Willowmore" }, { "Id": 33, "Provinces_Id": 37, "Name": "Willowvale" }]
    }, "City": { "Id": 1, "Provinces_Id": 37, "Name": "Adelaide" }, "Subject": "ljlk", "Description": "jkljkkjlk", "Price": "4", "NegotiableInd": true,
    "RegisterUser": {
        "Firstnames": "test",
        "Lastname": "etst",
        "UserName": "testuser1",
        "Password": "testuser",
        "ConfirmPassword": "testuser",
        "EmailAddress": "molfefe@gmail.com",
        "MobileNumber": ""
    }
};

angular.module('saveAdApp').controller('saveadcontroller', function ($scope, $window, $routeParams, $rootScope, ListService, PolicyService, AppSettings, ValidationErrorService) {
    $scope.policyId = $routeParams.policyId;
    $scope.submitted = false;
    $scope.policy = {};

    $scope.initialise = function () {
        $scope.initialiseCategories();
        $scope.initialiseProvinces();
        $scope.initialisePolicy();
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

    $scope.initialisePolicy = function () {
        PolicyService.getPolicy($scope.policyId).then(function (data) {
            if ($scope.policyId) {
                PolicyService.getPolicyAdditionalData(data.Policy.SubCategory.Id).then(function (additionalfieldsdata) {
                    $scope.policyAdditionalFieldOptions = additionalfieldsdata.AdditionalFieldOptions;
                    $scope.policy = data.Policy;
                });

                return;
            }

            $scope.policy = data.Policy;
        });
    };

    $scope.showCategory = function () {
        return !$scope.policy.Category || !$scope.policy.Category.Id;
    };

    $scope.showSubCategory = function () {
        return ($scope.policy.Category && $scope.policy.Category.Id) && (!$scope.policy.SubCategory || !$scope.policy.SubCategory.Id);
    };

    $scope.categoryClick = function (e, category) {
        e.preventDefault();

        $scope.policy.Category = category;
        $scope.subCategories = category.SubCategories;
    };

    $scope.subCategoryClick = function (e, subCategory) {
        e.preventDefault();

        $scope.policy.SubCategory = subCategory;
        PolicyService.getPolicyAdditionalData(subCategory.Id).then(function (data) {
            $scope.policy.PolicySubCategoryAdditionalFields = data.AdditionalFields;
            $scope.policyAdditionalFieldOptions = data.AdditionalFieldOptions;
        });
    };

    $scope.unSelectCategory = function (e) {
        e.preventDefault();

        $scope.policy.Category = {};
        $scope.policy.SubCategory = {};
        $scope.subcategeories = {};
        $scope.policy.Province = {};
        $scope.policy.City = {};
        $scope.cities = {};
        $scope.policy.PolicySubCategoryAdditionalFields = [];
    };

    $scope.provinceClick = function (e, province) {
        e.preventDefault();

        $scope.policy.Province = province;
        $scope.cities = province.Cities;
    };

    $scope.cityClick = function (e, city) {
        e.preventDefault();

        $scope.policy.City = city;
    };

    $scope.unSelectProvince = function (e) {
        e.preventDefault();

        $scope.policy.Province = {};
        $scope.policy.City = {};
        $scope.cities = {};
    };

    $scope.showCity = function () {
        return ($scope.policy.Province && $scope.policy.Province.Id) && (!$scope.policy.City || !$scope.policy.City.Id);
    };

    $scope.showProvince = function () {
        return !$scope.policy.Province || !$scope.policy.Province.Id;
    };

    $scope.$watch('files', function () {
        $scope.upload($scope.files);
    });

    $scope.upload = function (files) {
        var isInvalidFileFound = false;

        $scope.imageuploading = true;

        if (!files || files.length == 0) {
            $scope.imageuploading = false;
            return;
        }

        angular.forEach(files, function (file, key) {
            if (file.type.indexOf('image') < 0) {
                isInvalidFileFound = true;
                return;
            }
        });

        if (isInvalidFileFound) {
            alert('Only image files can be uploaded for an ad');
            $scope.imageuploading = false;
            return;
        }

        if (!$scope.policy.PolicyImages) {
            $scope.policy.PolicyImages = [];
        }

        PolicyService.uploadPolicyImage(files[0]).then(function (data) {
            $scope.policy.PolicyImages.push(data.PolicyImage);
            $scope.imageuploading = false;
        });
    };

    $scope.savePolicy = function () {
        $rootScope.$broadcast('actionStart');

        if (!$scope.frmSaveAd.$valid) {
            $rootScope.$broadcast('actionComplate');
            $rootScope.$broadcast('formInvalid');
            return 0;
        }

        PolicyService.savePolicy($scope.policy).then(function (data) {

            if (data.Errors) {
                $rootScope.$broadcast('server-side-validation-errors', data.Errors);
                return;
            }

            $scope.policy = data.Policy;
            $scope.policysaved = true;

        });
    };

    $scope.removeImage = function (e, policyimage) {
        e.preventDefault();

        var policyImageIndex = getIndexOfElement($scope.policy.PolicyImages, policyimage.Id);
        $scope.policy.PolicyImages.splice(policyImageIndex, 1);
    };

    $scope.viewAd = function () {
        $window.location.href = AppSettings.getMvcUrl('ViewAd', null, '/', { 'policyId': $scope.policy.Id });
    }

    $scope.editAd = function () {
        $window.location.href = AppSettings.getMvcUrl('EditAd', null, '/', { 'policyId': $scope.policy.Id });
    }

    $scope.initialise();

    function getIndexOfElement(array, Id) {

        for (var i = 0; i < array.length; i++) {
            if (array[i].Id == Id) {
                return i;
            }
        }

        return -1;
    };

});