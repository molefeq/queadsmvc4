
angular.module('sharedServices').service('ValidationErrorService', function () {
    this.angularErrors = {};
    var that = this;

    this.getValidationErrors = function (errors) {
        var summaryErrors = [];

        that.angularErrors = {};

        if (errors) {

            for (var i = 0; i < errors.length ; i++) {
                if (errors[i].FieldName && errors[i].FieldName != '') {
                    this.angularErrors[errors[i].FieldName] = errors[i].Message;
                }
                else {
                    summaryErrors.push(errors[i].Message);
                }
            }

            if (summaryErrors.length > 0) {
                this.angularErrors.summaryerrors = summaryErrors;
            }
        }

        return this.angularErrors;
    };

    this.getMessage = function (fieldname) {
        this.angularErrors[fieldname];
    };

    this.getSummaryErrors = function () {
        this.angularErrors['summaryerrors'];
    };

});