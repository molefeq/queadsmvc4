'use strict';

angular.module('viewAdApp').directive('contactPane', function () {
    return {
        restrict: 'EA',
        link: function link(scope, element, attributes) {

            //element.siblings('.leftMod').on('click', '#mainLandingPage .option', function () {
            //    if (!($(this).hasClass('disable'))) {
            //        var selectedOptionText = $(this).find(".innerBlock").find("p").text();
            //        var selectedOptionHeader = document.getElementById("selectedOptionHeader");

            //        if (!selectedOptionHeader) {
            //            return;
            //        }

            //        selectedOptionHeader.innerHTML = selectedOptionText;
            //        if (!($(this).hasClass('active'))) {
            //            $(this).parent().find('.option').removeClass('active');
            //            $(this).addClass('active');
            //        }

            //        // if screen on  mobile view, animate the detailed option panel
            //        if ($(window).width() <= 600) {
            //            $(".rightMod").animate({
            //                left: "0"
            //            }, 700, 'easeOutQuint');
            //        }
            //    }
            //});

            element.on('click', '#btnBtnReplyToAdMobile', function () {
                $(".contact-row").animate({
                    left: "0",
                    top:"0",
                }, 700, 'easeOutQuint');
            });

            // function to manage right panel by hiding it
            function updateContactPanel() {
                var windowWidth = $(window).width();

                $(".contact-row").css("position", "absolute");
                $(".contact-row").css("left", "-" + windowWidth + "px");
                $(".contact-row").css("top", "0");
            }

            // hide panel if screen size is 600px or less
            if ($(window).width() <= 480) {
                updateContactPanel();
            }

            $(window).resize(function () {
                if ($(window).width() <= 480) {
                    updateContactPanel();
                }
            });

            // close the details option panel
            element.on('click', '#closeButton', function () {
                updateContactPanel();
            });

        }
    };
});
