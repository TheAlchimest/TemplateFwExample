var formHelper = {
    onSuccess: null,

    objectifyForm: function ($form) {
        var formArray = $form.serializeAll();
        return formHelper.objectifyArray(formArray);
    },
    objectifyDiv: function ($div) {
        var formArray = $div.find(':input').serializeAll();
        return formHelper.objectifyArray(formArray);
    },
    objectifyArray: function (formArray) {
        //serialize data function
        var propertiesArray = {};
        var name = '';
        var indexOfArrFirst = -2;
        var indexOfArrLast = -2;
        var childIndex = -2;
        var childPropertyName = '';
        for (var i = 0; i < formArray.length; i++) {
            name = formArray[i]['name'];
            indexOfArrFirst = name.indexOf('[');
            if (indexOfArrFirst < 0) {
                if ((typeof propertiesArray[name] === "undefined")) {
                    propertiesArray[name] = formArray[i]['value'];
                }
                else {
                    //objectify master detail form data
                    if (!Array.isArray(propertiesArray[name])) {
                        let oldValue = propertiesArray[name];
                        propertiesArray[name] = [];
                        propertiesArray[name].push(oldValue);
                    }
                    propertiesArray[name].push(formArray[i]['value']);
                }
            }
            else {//array
                var childItemName = name.split("[")[0];
                indexOfArrLast = name.indexOf(']');
                childIndex = name.substr(indexOfArrFirst + 1, ((indexOfArrLast - 1) - indexOfArrFirst));
                childPropertyName = name.split(".")[1];
                if ((typeof propertiesArray[childItemName] === "undefined")) {
                    propertiesArray[childItemName] = [];
                }
                while (propertiesArray[childItemName].length <= childIndex) {
                    propertiesArray[childItemName].push({});
                }
                propertiesArray[childItemName][childIndex][childPropertyName] = formArray[i]['value'];
            }
        }
        //remove null values
        $.each(propertiesArray, function (key, value) {
            if (value === "" || value === null) {
                delete propertiesArray[key];
            }
        });

        return propertiesArray;
    },
    bindFormWithJson: function bindFromWithJson($formOrContainer, json) {
        //$formOrContainer.find("input[type=radio],input[type=checkbox]").removeAttr('checked');
        $formOrContainer.find("input[type=radio],input[type=checkbox]").prop("checked", false).trigger("click");
        $formOrContainer.find("input").not(':input[type=button], :input[type=submit], :input[type=reset]').each(function () {
            let $input = $(this);
            let name = $input.attr('name');
            let val = json[name];
            let type = $input.attr('type');
            if (type == 'radio') {

                let inputVal = $input.val();
                if (inputVal.toLowerCase() == val.toString().toLowerCase()) {
                    $input.prop("checked", true).trigger("click");
                }
            }
            else {
                $input.val(val);
            }
        });

    },


    runAction: function (btn, event) {

        let $form = $(btn.form);
        let url = $(btn).attr('data-action-Url');
        let actionName = $(btn).attr('data-action-name');
        $form.attr('action', url);
        let $actionNameElement = $('#ActionName');
        if ($actionNameElement.length > 0) {
            $actionNameElement.val(actionName);
        }
        formHelper.submit(btn, event);
    },
    submit: function (btn, event) {
        let helper = formHelper;
        event.preventDefault();
        let $btn = $(btn);
        let $form = $(btn.form);
        let isValid = helper.validateForm($form);
        if (!isValid) {
            return false;
        }
        try {
            //disable btn
            $btn.prop('disabled', true);
            var post = null;

            let actionUrl = $form.attr('action');
            if (!$form[0].hasAttribute("enctype")) {
                let json = helper.objectifyForm($form);
                helper.postJson(actionUrl, json, $form, $btn);
            }
            else {
                var formData = new FormData(btn.form);
                post = helper.postFormData(actionUrl, formData, $form, $btn);
            }
        }
        catch (err) {
            $btn.prop('disabled', false);
        }
    },
    resetForm: function ($form) {

        // Se obtienen todos los inputs
        var inputs = $form.find(':input:not(:button)');

        // Se recorren todos los inputs del formulario
        inputs.each(function (k, v) {

            // Se eliminan los mensajes de error
            $.smkRemoveError(v);

            // Si el input no contiene el attr data-smk-noclear
            if ($(v).attr('data-smk-noclear') === undefined) {
                //Se obtiene el type y el tag del input
                var type = this.type;
                var tag = this.tagName.toLowerCase();
                //Si el tag trae el valor 'input' se sustituye por el valor type
                if (tag == 'input') {
                    tag = type;
                } 
                //Se compara el type y se limpia
                switch (type) {
                    case 'text':
                    case 'password':
                    case 'email':
                    case 'number':
                    //case 'hidden':
                    case 'date':
                    case 'datetime':
                    case 'datetime-local':
                    case 'month':
                    case 'week':
                    case 'time':
                    case 'tel':
                    case 'url':
                    case 'file':
                    case 'search':
                    case 'range':
                    case 'color':
                        this.value = '';
                        break;
                    case 'checkbox':
                    case 'radio':
                        this.checked = false;
                        break;
                }
                //Se compara el tag y se limpia
                switch (tag) {
                    case 'textarea':
                        this.value = '';
                        break;
                    case 'select':
                        this.selectedIndex = 0;
                        if ($(this).hasClass('select2')) {
                            //$(this).select2('val', '');
                            // new version
                            $(this).val('').trigger("change.select2");
                        }
                        break;
                }
            }
        });
    },
    validateForm: function ($form) {
        let isValid = true;
        if (!$form[0].hasAttribute("without-validation")) {
            isValid = $form.smkValidate();
        }
        return isValid;
    },
    postFormData: function (actionUrl, formData, $form, $btn) {
        let helper = formHelper;
        let post = helper.postAjaxWithFiles(actionUrl, formData);
        helper.handlePostResult(post, $form, $btn);

    },
    postJson: function (actionUrl, json, $form, $btn) {
        let helper = formHelper;
        let stringJson = JSON.stringify(json);
        let post = helper.postAjax(actionUrl, stringJson);
        helper.handlePostResult(post, $form, $btn);
    },
    handlePostResult: function (post, $form, $btn) {
        let helper = formHelper;
        post.done(function (data, status, xhr) {
            if (typeof helper.onSuccess !== "undefined" && helper.onSuccess != null) {
                helper.onSuccess(data, status, xhr);
                return;
            }
            alertHelper.showResponse(data, status, xhr, helper.onSuccess);
            if (data.Status) {
                let isUpdateMode = $btn.attr('data-is-update-mode');
                if (isUpdateMode != "true") {
                    helper.resetForm($form);
                }
                else {
                    let redirectURL = $btn.attr('on-sccess-redirect-url');
                    if (redirectURL) {
                        window.location = redirectURL;
                    }
                }
            }
        });
        post.fail(function (xhr, status, error) {
            //(webResponse, status, xhr, onsuccess)
            alertHelper.showResponse(xhr.responseJSON, status, xhr);
        })
        post.always(function () {
            $btn.prop('disabled', false);
        });
    },

    postAjax: function (url, data) {
        return $.ajax({
            url: url,
            type: 'POST',
            data: data,
            cache: false,
            contentType: 'application/json',
            processData: false
        });
    },
    postAjaxWithFiles: function (url, data) {
        return $.ajax({
            url: url,
            type: 'POST',
            data: data,
            cache: false,
            contentType: false,
            processData: false
        });
    }

};
//extensions 
(function ($) {
    $.fn.serializeAll = function () {
        var data = $(this).serializeArray();
        var newData = data.map(function (obj) {
            var value;

            if (obj.value === 'true') {
                value = true;
            } else if (obj.value === 'false') {
                value = false;
            } /*else if (!isNaN(obj.value)) {
                value = parseInt(obj.value);
            }*/
            else if (obj.value === '') {
                value = null;
            }
            else {
                value = obj.value;
            }

            return {
                name: obj.name,
                value: value
            };
        });
        $(':disabled[name]', this).each(function () {
            newData.push({ name: this.name, value: $(this).val() });
        });

        return newData;
    }
})(jQuery);