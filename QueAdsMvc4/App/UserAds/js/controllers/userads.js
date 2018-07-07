'use strict'

angular.module('userAdsApp').controller('useradscontroller', function ($scope, $window, $uibModal, PolicyService, AppSettings, GridPager) {
    $scope.groupresults = [];
    $scope.searchtext = '';
    $scope.gridPage = GridPager;

    $scope.initialise = function () {
        $scope.gridPage.PageSize = 20;
        $scope.gridPage.PageIndex = 1;
    };

    $scope.searchAds = function (isSearch) {
        PolicyService.searchUserPolicies(null, null, null, null, $scope.searchText, null, $scope.gridPage.PageIndex, $scope.gridPage.PageSize).then(function (data) {
            $scope.gridPage.SetPages(data.Total);
            $scope.groupresults = data.Policies;
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
        $scope.searchAds();
    });

    $scope.viewpolicy = function (policyId) {
        $window.location.href = AppSettings.getMvcUrl('ViewAd', null, '/', { 'policyId': policyId });
    };

    $scope.editpolicy = function (policyId) {
        $window.location.href = AppSettings.getMvcUrl('EditAd', null, '/', { 'policyId': policyId });
    };

    $scope.deletepolicy = function (policy) {
        policy.CrudOperation = 3;

        PolicyService.savePolicy(policy, 3).then(function (data) {
            $scope.searchAds();
        });
    };
    
    $scope.initialise();
});