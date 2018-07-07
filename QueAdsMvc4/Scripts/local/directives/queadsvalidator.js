'use strict'

angular.module('sharedServices').directive("queAdsValidator", function () {
    function inputControlValidate(formController, inputElement)
    {
        var inputName = $(inputElement).attr('name');
        if (formController[inputName] && formController[inputName].$invalid) {
            for (var key in formController[inputName].$error) {
                var errorMessage = $(inputElement).attr('data-' + key + '-msg');

                if (errorMessage) {
                    $(inputElement).siblings('p[data-val-for="' + inputName + '"]').first().text(errorMessage);
                }

                $(inputElement).closest('div.form-element').toggleClass('has-error', formController[inputName].$invalid);
                break;
            }
        }
    }

    var linkFunction = function (scope, element, attributes, formController) {

        scope.$on('formInvalid', function (event, data) {
            angular.forEach(element.find('input[type="password"]'), function (inputElement, key) {
                inputControlValidate(formController, inputElement);
            });

            angular.forEach(element.find('input[type="text"]'), function (inputElement, key) {
                inputControlValidate(formController, inputElement);
            });

            angular.forEach(element.find('textarea'), function (inputElement, key) {
                inputControlValidate(formController, inputElement);
            });
        });

        element.on('change', 'select', function (e) {
            var selectName = $(this).attr('name');
            if (formController[selectName]) {
                formController[selectName].$setValidity('custom', true);
                $(this).closest('div.form-element').toggleClass('has-error', formController[selectName].$invalid);
            }
        });

        element.on('keyup', 'input[type="password"]', function (e) {
            var inputElement = $(this);
            var inputName = inputElement.attr('name');

            if (formController[inputName] && (formController[inputName].$error.custom || formController[inputName].$valid)) {
                formController[inputName].$setValidity('custom', true);
                inputElement.closest('div.form-element').removeClass('has-error');
            }
        });

        element.on('blur', 'input[type="password"]', function (e) {
            inputControlValidate(formController, $(this));
        });

        element.on('keyup', 'input[type="text"]', function (e) {
            var inputElement = $(this);
            var inputName = inputElement.attr('name');

            if (formController[inputName] && (formController[inputName].$error.custom || formController[inputName].$valid)) {
                formController[inputName].$setValidity('custom', true);
                inputElement.closest('div.form-element').removeClass('has-error');
            }
        });

        element.on('blur', 'input[type="text"]', function (e) {
            inputControlValidate(formController, $(this));
        });

        element.on('keyup', 'textarea', function (e) {
            var inputElement = $(this);
            var inputName = inputElement.attr('name');

            if (formController[inputName] && (formController[inputName].$error.custom || formController[inputName].$valid)) {
                formController[inputName].$setValidity('custom', true);
                inputElement.closest('div.form-element').removeClass('has-error');
            }
        });

        element.on('blur', 'textarea', function (e) {
            inputControlValidate(formController, $(this));
        });

        scope.$on('server-side-validation-errors', function (events, serverSideErrors) {
            angular.forEach(serverSideErrors, function (error, key) {
                if (formController[error.FieldName] && error.FieldName && error.FieldName != '') {
                    var inputElement = element.find('input[name="' + error.FieldName + '"]').first();
                    var selectElement = element.find('select[name="' + error.FieldName + '"]').first();

                    formController[error.FieldName].$setValidity('custom', false);

                    if (inputElement && inputElement.length > 0) {
                        $(inputElement).closest('div.form-element').toggleClass('has-error', formController[error.FieldName].$invalid);
                        $(inputElement).siblings('p[data-val-for="' + error.FieldName + '"]').first().text(error.Message);
                    }

                    if (selectElement && selectElement.length > 0) {
                        $(selectElement).closest('div.form-element').toggleClass('has-error', formController[error.FieldName].$invalid);
                        $(selectElement).siblings('p[data-val-for="' + error.FieldName + '"]').first().text(error.Message);
                    }
                }

            });
        });
    };

    return {
        restrict: "EA",
        link: linkFunction,
        require: 'form'
    };
});