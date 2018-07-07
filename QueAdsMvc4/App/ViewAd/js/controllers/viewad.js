'use strict'

angular.module('viewAdApp').controller('viewadcontroller', function ($scope, $window, $routeParams, $rootScope, PolicyService, AppSettings, Utils) {

    var policyId = $routeParams.policyId;

    $scope.policy = {};
    $scope.policyreply = {};
    $scope.postreplied = false;
    $scope.viewInitialised = false;

    $scope.setCurrentImage = function (policyImage) {
        $scope.currentimage = policyImage;
    };

    $scope.displayImages = function () {
        return $scope.policy.PolicyImages && $scope.policy.PolicyImages.length > 0;
    };

    $scope.postReply = function () {
        $rootScope.$broadcast('actionStart');

        if (!$scope.frmAdReply.$valid) {
            $rootScope.$broadcast('actionComplate');
            $rootScope.$broadcast('formInvalid');
            return 0;
        }

        PolicyService.replyPolicy($scope.policyreply).then(function (data) {
            $scope.postreplied = true;
        });
    };

    $scope.viewSubCategoryAds = function (category, subCategory) {
        Utils.setLocalStoreObject('province', null);
        Utils.setLocalStoreObject('city', null);
        Utils.setLocalStoreObject('category', category);
        Utils.setLocalStoreObject('subCategory', subCategory);

        $window.location.href = AppSettings.getMvcUrl('ViewAds', null, null, null);
    };

    $scope.viewCityAds = function (province, city) {
        Utils.setLocalStoreObject('province', province);
        Utils.setLocalStoreObject('city', city);
        Utils.setLocalStoreObject('category', null);
        Utils.setLocalStoreObject('subCategory', null);

        $window.location.href = AppSettings.getMvcUrl('ViewAds', null, null, null);
    };

    $scope.viewProvinceAds = function (province) {
        Utils.setLocalStoreObject('province', province);
        Utils.setLocalStoreObject('city', null);
        Utils.setLocalStoreObject('category', null);
        Utils.setLocalStoreObject('subCategory', null);
        $window.location.href = AppSettings.getMvcUrl('ViewAds', null, null, null);
    };

    $scope.viewCategoryAds = function (category) {
        Utils.setLocalStoreObject('province', null);
        Utils.setLocalStoreObject('city', null);
        Utils.setLocalStoreObject('category', category);
        Utils.setLocalStoreObject('subCategory', null);

        $window.location.href = AppSettings.getMvcUrl('ViewAds', null, null, null);
    };

    $scope.shareOnFacebook = function (event) {
        event.preventDefault();
        PolicyService.shareAdOnFacebook($scope.policy, $scope.currentimage, $window.location.href);
    };

    initialise();

    function initialise() {
        PolicyService.getPolicy(policyId).then(function (data) {
            $scope.policy = data.Policy;

            if (data.Policy.PolicyImages && data.Policy.PolicyImages.length > 0) {
                $scope.currentimage = data.Policy.PolicyImages[0];
            }

            $scope.emailUrl = "mailto:?subject=This may interest you! " + $scope.policy.Subject + "&body=Hello! I found this ad on Que Ads and thought you might be interested. Go to this link for more information: " + $window.location.href;

            $scope.policyreply = {
                Policy_Id: $scope.policyId,
                Policy_Create_EmailAddress: $scope.policy.CreateUser.EmailAddress,
                Policy_Create_User: $scope.policy.CreateUser.Firstnames,
                Subject: $scope.policy.Subject
            };

            $scope.viewInitialised = true;
        });
    };
});