'use strict';

angular.module('sharedServices').factory('GridPager', function () {
    var gridPager = {};
    var pagesOffet = 5;

    gridPager.IsFirstPage = false;
    gridPager.IsLastPage = false;
    gridPager.TotalPages = 0;
    gridPager.Pages = [];
    gridPager.PageIndex = 0;
    gridPager.PageSize = 10;
    gridPager.CurrentItemsCount = 10;

    gridPager.SetPages = function (totalRows) {
        gridPager.IsLastPage = false;
        gridPager.Pages = [];
        gridPager.TotalPages = Math.ceil(totalRows / gridPager.PageSize);

        var pageInterval = Math.floor(gridPager.PageIndex / pagesOffet);
        var startPageIndex = pageInterval == 0 ? 1 : pageInterval * pagesOffet;
        var lastPageIndex = pageInterval == 0 ? pagesOffet : startPageIndex + (pagesOffet - 1);
        var currentItemsCount = gridPager.PageIndex * gridPager.PageSize;

        if (lastPageIndex >= gridPager.TotalPages) {
            lastPageIndex = gridPager.TotalPages;
            startPageIndex = startPageIndex == 1 ? 1 : lastPageIndex - 5;
        }

        for (var i = startPageIndex; i <= lastPageIndex; i++) {
            gridPager.Pages.push(i);
        }

        gridPager.IsFirstPage = gridPager.PageIndex === 1;
        gridPager.IsLastPage = gridPager.PageIndex === gridPager.TotalPages;
        gridPager.CurrentItemsCount = currentItemsCount >= totalRows ? totalRows : currentItemsCount;
    };

    return gridPager;
});