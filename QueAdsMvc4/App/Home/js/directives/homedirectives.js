'use strict';

angular.module('homeApp').directive('categoryItem', function () {
    return {
        restrict: 'EA',
        link: function link(scope, element, attributes) {
            var categoryId = attributes['id'];

            $(element).on('click', function () {
                var subCategoryElement = $('div[data-parent-id="' + categoryId + '"]')[0];

                if (subCategoryElement != null && $(subCategoryElement).length > 0) {
                    $(subCategoryElement).animate({
                        top: 0
                    }, 800, 'swing');
                    $(subCategoryElement).show();
                    $('.category-container').hide();
                }


                $(subCategoryElement).on('click', 'h3', function () {
                    $('.category-container').animate({
                        top: 0
                    }, 800, 'swing');
                    $(subCategoryElement).hide();
                    $('.category-container').show();
                });
            });
        }
    };
});
