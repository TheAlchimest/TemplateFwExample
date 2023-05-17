
var validationHelper = {
    validateBusiness: function ($element, url, msg, errors) {
        $.ajax({
            url: url,
            method: "GET",
            success: function (result, status, xhr) {
                if (result) {
                    $element.removeAttr('data-business-error')
                    $.smkRemoveError($element);
                    $element.removeClass("has-business-error");

                    $.smkAddError($element, msg);
                    $element.addClass('has-business-error')
                    $element.attr('data-business-error', msg)
                    if (errors) {
                        errors.push(msg);
                    }
                    else {
                        swal.fire(msg, '', "error")
                    }
                }
                else {
                    $element.attr('data-business-error', msg)
                    $element.removeAttr('data-business-error')
                    $.smkRemoveError($element);
                    $element.removeClass("has-business-error"); 
                }
            },
            error: function (xhr, status, errorThrown) {
                //alertHelper.error(AccountsValidationMessages.NotUniqueFoundationNo, status, xhr);
            }
        });
    },
    addValidateBusiness: function ($element, msg, errors) {
        $.smkAddError($element, msg);
        $element.addClass('has-business-error');
        $element.attr('data-business-error', msg);
        if (errors) {
            errors.push(msg);
        }
        else {
            swal.fire(msg, '', "error")
        }
    },
    removeValidateBusiness: function ($element, msg) {

        $element.attr('data-business-error', msg)
        $element.removeAttr('data-business-error')
        $.smkRemoveError($element);
        $element.removeClass("has-business-error");
    },
    validateFile: function ($element) {
        let errors = [];

        var files = $element[0].files;
        if (files.length > 0) {
            let extension = "";
            let extensions = $element.attr("data-extensions");
            let maxSize = parseInt($element.attr("data-maxsize"));
            let maxSizeError = $element.attr("data-maxsize-error");
            let extensionError = $element.attr("data-extensions-error");

            const availablExtensions = extensions.split(",");
            for (var i = 0, len = files.length; i < len; i++) {
                let extension = files[i].name.split(".").pop().toLowerCase();
                if ($.inArray(extension, availablExtensions) == -1) {

                    errors.push(extensionError);
                }
                //
                if (files[i].size > maxSize) {
                    errors.push(maxSizeError);
                }
                if (files[i].size == 0) {
                    errors.push(messages.emptyFile);
                }
            }
            if (errors.length > 0) {
                errors.forEach(function (error) { $.smkAddError($element, error); })
            }
            else {
                $.smkRemoveError($element);
            }
        }
        return (errors.length === 0);
    },
    validateFiles: function () {
        $('input:file').change(
            function (e) {
                validationHelper.validateFile($(this));
            });
    }
}