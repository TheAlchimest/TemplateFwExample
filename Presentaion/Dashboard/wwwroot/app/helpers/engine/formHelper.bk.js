var formHelper = {
  onSuccess: null,
  validateForm: function(formJson, form, options) {
    console.log("formJson", formJson);
    console.log("form", form);
    console.log("options", options);
      let isValid = $(form).smkValidate();
      formJson = jsonHelper.objectifyMultiLanguageFormArray(formJson);
        return isValid;
    },
  showResponse: function(webResponse, status, xhr) {
    console.log("webResponse", webResponse);
    console.log("status", status);
    console.log("xhr", xhr);
    console.log(webResponse);
      if (webResponse.status) {
          if (webResponse.message != null && webResponse.message.length > 0) {
              alertHelper.success(webResponse.message, "");
          }
          // additions 
          if (formHelper.onSuccess) {
              formHelper.onSuccess();
          }

      } else {
          if ((webResponse.errorMessages.length > 1) && (webResponse.message != null && webResponse.message.length > 0)) {
              alertHelper.error(webResponse.message, webResponse.errorMessages.join());

          } else if (webResponse.errorMessages.length > 0) {
              alertHelper.error(webResponse.errorMessages.join(), "");
          } else if (webResponse.message != null && webResponse.message.length > 0) {
              alertHelper.error(webResponse.message, "");
          }
      }
  },
  errorResponse: function (webResponse, status, xhr) {
        console.log("webResponse", webResponse);
        console.log("status", status);
        console.log("xhr", xhr);
        console.log(webResponse);v
        alertHelper.error(webResponse.message || "error", "");
    },

    runAction: function (btn) {
        
        let $form = $(btn.form);
        let url = $(btn).attr('data-action-Url');
        let actionName = $(btn).attr('data-action-name');
        let isLingual = $form.attr('data-is-lingual');
        if (isLingual !== null && isLingual !== '' && isLingual !== undefined) {
            isLingual = $form.attr('data-is-lingual').toLowerCase();
        }
        $form.attr('action', url);
        $('#ActionName').val(actionName);
        if (isLingual==='true') {
            formHelper.bindAjaxForm($form);
            $form.submit();
        }
        else {
            formHelper.submit(btn, event, actionName, url);
        }
    },

    bindAjaxForm: function($form,url) {
    const options = {
      beforeSubmit: formHelper.validateForm, // pre-submit callback
      success: formHelper.showResponse, // post-submit callback
      error: formHelper.errorResponse,
      // other available options:
      //url:       url         // override for form's 'action' attribute
      //type:      type        // 'get' or 'post', override for form's 'method' attribute
      dataType: 'json',        // 'xml', 'script', or 'json' (expected server response type)
      clearForm: true, // clear all form fields after successful submit
      resetForm: false, // reset the form after successful submit

      // $.ajax options can be used here too, for example:
      //timeout:   3000
    };
    // bind form using 'ajaxForm'
    $form.ajaxForm(options);
  },
    /*
    collectRadios: function ($form, formData) {
        let $radios = $form.find("input:radio");
        $radios.each(function (index) {
            let radioName = $(this).attr('name');
            delete formData[radioName];
        });

        $radios.each(function (index) {
            let radioName = $(this).attr('name');
            let radioval = null;
            if ($(this).is(':checked')) {
                radioval = $(this).val();
                if ($(this).attr('data-type') == 'boolean') {
                    if (radioval.toLowerCase() === "true") radioval = true;
                    else if (radioval.toLowerCase() === "false") radioval = false;
                }

                formData[radioName] = radioval;
            }
        });


    },
    collectCheckBoxes: function ($form, formData) {

        let $checkBoxs = $form.find("input:checkbox");
        let checkBoxsNames = [];
        $checkBoxs.each(function (index) {
            let radioName = $(this).attr('name');
            if (!checkBoxsNames.includes(radioName)) {
                checkBoxsNames.push(radioName);
            }
        });
        checkBoxsNames.forEach(function (element) {
            let $checkBoxes = $form.find("input:checkbox[name='" + element + "']");
            if ($checkBoxes.length > 0) {
                formData[element] = [];
                $checkBoxes.each(function (index) {
                    if ($(this).is(':checked')) {
                        formData[element].push($(this).val());
                    }
                });
            }
            else {
                if ($(this).is(':checked')) {
                    $(this).val('true');
                }
            }
        });

    },
    collectMultiSelect: function ($form, formData) {

        let $select = $form.find("select[multiple]");
        let names = [];
        $select.each(function (index) {
            let name = $(this).attr('name');
            formData[name] = $(this).val();
        });
    },
    collectFormData: function ($form) {
        var formDataAsArray = $form.serializeArray();
        var formDataAsObject = jsonHelper.objectifyArray(formDataAsArray);

    },
    submit: function (btn, event, actionName, actionUrl) {
        let vm = formHelper;
        let $form = $(btn.form);
        event.preventDefault();
        if (!$form[0].hasAttribute("no-needs-validation")) {
            let validationResult = $form.smkValidate();
            if (!validationResult) {
                return false;
            }
        }
        //loading ....
        //vm.showLoading($targetSection);
        var formData = null;
        var posting = null;
        //

        if ($form[0].hasAttribute("enctype")) {
            formData = new FormData(formObjectThis);
            vm.collectRadios($form, formData);
            vm.collectCheckBoxes($form, formData);
            vm.collectMultiSelect($form, formData);
            console.log('formData', formData);
            posting = AjaxManager.postWithFiles(actionUrl, formData);
        }
        else {

            var disabled = $form.find(':input:disabled').removeAttr('disabled');
            formData = $form.serializeJSON();
            vm.collectRadios($form, formData);
            vm.collectCheckBoxes($form, formData);
            vm.collectMultiSelect($form, formData);
            console.log('formData', formData);
            disabled.attr('disabled', 'disabled');
            let data = JSON.stringify(formData);
            // let obj = { "Data": data };
            posting = $.ajax({
                url: actionUrl,
                type: 'POST',
                data: data,
                cache: false,
                contentType: 'application/json',
                processData: false
            });
        }
        posting.done(function (data, status, xhr) {
            $form.removeClass('was-validated');
            if (xhr.responseJSON != null) {
                var genericResult = xhr.responseJSON;
                if (genericResult.status == true) {

                    showSuccess(genericResult.message);
                    $form[0].reset();
                }
                else {
                    showError(genericResult.Message);
                }
            }
            else {

            }
            preLoader.hide();

        });
        posting.fail(function (xhr, status, error) {
            vm.handleServerError(null, xhr, status, error);
            //showError(xhr.responseText);
            preLoader.hide();
        })
        posting.always(function () {
            // alert("finished");
        });
        return posting;
    },
    submitAction: function (btn, event, actionName, actionUrl) {
        let vm = formHelper;
        let $form = $(btn.form);
        event.preventDefault();
        $('#ActionName').val(actionName);
        if (!$form[0].hasAttribute("no-needs-validation")) {
            let validationResult = $form.smkValidate();
            if (!validationResult) {
                return false;
            }
        }
        if (actionUrl === null || actionUrl === '' || actionUrl === undefined) {
            actionUrl = $form.attr('action');
        }
        //loading ....
        //vm.showLoading($targetSection);
        var formData = null;
        var posting = null;
        //

        if ($form[0].hasAttribute("enctype")) {
            formData = new FormData(formObjectThis);
            vm.collectRadios($form, formData);
            vm.collectCheckBoxes($form, formData);
            vm.collectMultiSelect($form, formData);
            console.log('formData', formData);
            posting = AjaxManager.postWithFiles(actionUrl, formData);
        }
        else {

            var disabled = $form.find(':input:disabled').removeAttr('disabled');
            formData = $form.serializeJSON();
            vm.collectRadios($form, formData);
            vm.collectCheckBoxes($form, formData);
            vm.collectMultiSelect($form, formData);
            console.log('formData', formData);
            disabled.attr('disabled', 'disabled');
            let data = JSON.stringify(formData);
            // let obj = { "Data": data };
            posting = $.ajax({
                url: actionUrl,
                type: 'POST',
                data: data,
                cache: false,
                contentType: 'application/json',
                processData: false
            });
        }
        posting.done(function (data, status, xhr) {
            $form.removeClass('was-validated');
            if (xhr.responseJSON != null) {
                var genericResult = xhr.responseJSON;
                if (genericResult.status == true) {

                    showSuccess(genericResult.message);
                    $form[0].reset();
                }
                else {
                    showError(genericResult.Message);
                }
            }
            else {
               
            }
            preLoader.hide();

        });
        posting.fail(function (xhr, status, error) {
            vm.handleServerError(null, xhr, status, error);
            //showError(xhr.responseText);
            preLoader.hide();
        })
        posting.always(function () {
            // alert("finished");
        });
        return posting;
    }
    */

};
