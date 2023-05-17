var actionsController = {
    prepareForm: function (formId) {
        let $frm = $("#" + formId);
        $frm.find("input,select,textarea").change(function () {
            $frm.data("changed", true);
        });
    },
    submit: function (formId, obj, event) {
        let $frm = $("#" + formId);
        if ($frm.data("changed") ) {
            app.form.submit(obj, event)
        }
        else {
            swal.fire("الغاء العملية", "لم يتم ادخال أي بيانات", "info");
            if ($("#backActionBtn").length > 0) {
                window.location = $("#backActionBtn").attr("href");
            }
        }
    },
    colectActionData: function (element, baseMsg) {
        let action = {};
        action.$element = $(element);
        let title = action.$element.attr('data-title');
        let dataString = action.$element.attr('data-to-post');
        action.actionUrl = action.$element.attr('data-action-url');
        action.itemId = action.$element.attr('data-item-id');
        action.searchURL = action.$element.attr('data-search-url');
        if (dataString) {
            action.data = JSON.parse(dataString);
        }
        action.text = '';
        if (typeof (title) !== undefined && title.trim().length > 0) {
            action.text = baseMsg.replace("##", title);
        }
        return action;
    },
    delete: function (element,event) {
        
        if (typeof event !== 'undefined') {
            event.preventDefault();
        }
        let action = actionsController.colectActionData(element, messages.deleteItemText)
        confirmationHelper.confimDeleting(action)
    },
    runTimeDelete: function (element, event, callbackFunction) {
        event.preventDefault();
        let action = actionsController.colectActionData(element, messages.deleteItemText);
        action.actionFunction = callbackFunction;
        confirmationHelper.confimRunTimeDeleting(action);
    },
    activate: function (element) {

        let action = actionsController.colectActionData(element, messages.activationItemText);
        confirmationHelper.confimActivation(action);
    },
    deactivate: function (element) {
        let action = actionsController.colectActionData(element, messages.deactivationItemText);
        confirmationHelper.confimDeactivation(action);
    },
    setdefault: function (element) {
        let action = actionsController.colectActionData(element, messages.setDefautItemText);
        confirmationHelper.confimSetDefault(action);
    },
    setEnable: function (element) {
        let action = actionsController.colectActionData(element, messages.setEnableItemText);
        confirmationHelper.confimSetEnable(action);
    },
    setDisable: function (element) {
        let action = actionsController.colectActionData(element, messages.setDisableItemText);
        confirmationHelper.confimSetDisable(action);
    },

    search: function (form, event) {
        event.preventDefault()
        let $form = $(form);
        let filterData = $("#grid-filter").serialize();
        let url = $form.attr("action") + '?' + filterData;
        let containerId = $form.attr("data-container-id");
        let $container = $("#" + containerId);
        let $loaderBox = $('.loader-box');
        //window.location = url;
        $loaderBox.css("visibility", "visible");
        $.ajax({
            url: url,
            method: "Get",
            success: function (result, status, xhr) {
                $loaderBox.css("visibility", "hidden");
                $container.html(result);
                //$("#" + options.spTotalCountId).html("( " + $("#" + options.hfTotalCountId).val() + " )");
                //$("#" + options.spItemsCountId).html("( " + $("#" + options.hfItemsCountId).val() + " )");
            },
            error: function (xhr, status, error) {
                $loaderBox.css("visibility", "hidden");
            }
        });
    },

    paginate: function (no) {
        $("#PageNumber").val(no);
        $("#grid-filter").trigger('submit');
    },

    removePaginatedTr: function ($tr) {
        $tr.css("background-color", "#ffe8e8").hide("slow", function () {
            $(this).remove();
            let rowsCount = $(".table-responsive-md").find("tbody>tr").length;
            console.log('rowsCount', rowsCount);
            if (rowsCount === 0) {
                let pageNumber = parseInt($('#PageNumber').val());
                if (pageNumber > 1) {
                    $("#PageNumber").val(--pageNumber);
                }
            }
            //status
            $('#grid-filter').trigger('submit');
        });

    },
    removeNonPaginatedTr: function ($tr) {
        $tr.css("background-color", "#ffe8e8").hide("slow", function () {
            $(this).remove();
            let rowsCount = $(".table-responsive-md").find("tbody>tr").length;
            console.log('rowsCount', rowsCount);
            if (rowsCount === 0) {
                let pageNumber = parseInt($('#PageNumber').val());
                if (pageNumber > 1) {
                    $("#PageNumber").val(--pageNumber);
                }
            }
        });

    }
}
var confirmationHelper = {
    confimDeleting: function (action) {
        let options = {
            icon: 'question',
            title: messages.deleteConfirmation,
            text: action.text,
            actionUrl: action.actionUrl,
            data: action.data,
            onsuccess: function () {

                let $tr = action.$element.closest('tr');
                let $table = action.$element.closest('table');
                if ($table.find('tbody').find('tr').length == 1) {
                    let pageNumber = parseInt($('#PageNumber').val());
                    if (pageNumber > 1) {
                        actionsController.paginate(--pageNumber);
                    }
                }
                //remove tr
                $tr.css("background-color", "#ffe8e8").hide("slow").remove();
            }
        };
        confirmationHelper.confimWithAjaxCall(options);
    },
    confimRunTimeDeleting: function (action) {

        let options = {
            icon: 'question',
            title: messages.deleteConfirmation,
            text: action.text,
            actionUrl: action.actionUrl,
            actionFunction: action.actionFunction,
            data: action.data,
            $element: action.$element //,
            //onsuccess: function () {
            //    action.$element.closest('tr').css("background-color", "#ffe8e8").hide("slow").remove();
            //}
        };
        confirmationHelper.confim(options, function () {
            options.actionFunction(options.$element);
            options.onsuccess();
        });
    },
    confimActivation: function (action) {
        let options = {
            icon: 'question',
            title: messages.activationConfirmation,
            text: action.text,
            actionUrl: action.actionUrl,
            data: action.data,
            onsuccess: function () {
                action.$element.closest('tr').css("background-color", "#ffe8e8").hide("slow");
            }
        };
        confirmationHelper.confimWithAjaxCall(options);
    },
    confimDeactivation: function (action) {
        let options = {
            icon: 'question',
            title: messages.deactivationConfirmation,
            text: action.text,
            actionUrl: action.actionUrl,
            data: action.data,
            onsuccess: function () {
                action.$element.closest('tr').css("background-color", "#ffe8e8").hide("slow");
            }
        };
        confirmationHelper.confimWithAjaxCall(options);
    },
    confimSetDefault: function (action) {
        let options = {
            icon: 'question',
            title: messages.setDefautConfirmation,
            text: action.text,
            actionUrl: action.actionUrl,
            data: action.data,
            onsuccess: function () {
                $(".isdefault_link").hide();
                $(".isnotdefault_link").show();
                $("#isdefault" + action.itemId).show();
                $("#isnotdefault" + action.itemId).hide();

            }
        };
        confirmationHelper.confimWithAjaxCall(options);
    },
    confimSetEnable: function (action) {
        let options = {
            icon: 'question',
            title: messages.setDefautConfirmation,
            text: action.text,
            actionUrl: action.actionUrl,
            data: action.data,
            onsuccess: function () {
                $("#isEnable" + action.itemId).show();
                $("#isDisable" + action.itemId).hide();
            }
        };
        confirmationHelper.confimWithAjaxCall(options);
    },
    confimSetDisable: function (action) {
        let options = {
            icon: 'question',
            title: messages.setDefautConfirmation,
            text: action.text,
            actionUrl: action.actionUrl,
            data: action.data,
            onsuccess: function () {
                $("#isEnable" + action.itemId).hide();
                $("#isDisable" + action.itemId).show();
            }
        };
        confirmationHelper.confimWithAjaxCall(options);
    },
    confimWithAjaxCall: function (options) {
        confirmationHelper.confim(options, function () {
            $.ajax({
                url: options.actionUrl,
                method: "POST",
                data: options.data,
                success: function (result, status, xhr) {

                    alertHelper.showResponse(result, status, xhr, options.onsuccess);
                },
                error: function (xhr, status, error) {
                    alertHelper.showResponse(xhr.responseJSON, status, xhr);
                }
            });
        });
    },
    confim: function (options, calback) {
        swal.fire({
            title: options.title,
            text: options.text,
            icon: options.icon,
            showCancelButton: true,
            showDenyButton: false,
            showCancelButton: true,
            confirmButtonText: messages.confirmButtonText,
            cancelButtonText: messages.cancelButtonText,
            denyButtonText: messages.denyButtonText,
            closeOnConfirm: true
        }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                if (calback) {
                    calback();
                }
            }
        });
    },
    confimWithLoaderAction: function (options) {
        swal.fire({
            title: options.title,
            text: options.text,
            icon: options.icon,
            showCancelButton: true,
            showDenyButton: false,
            showCancelButton: true,
            confirmButtonText: messages.confirmButtonText,
            cancelButtonText: messages.cancelButtonText,
            denyButtonText: messages.denyButtonText,
            closeOnConfirm: true,
            showLoaderOnConfirm: true,
            preConfirm: (login) => {
                return fetch(options.actionUrl, {
                    method: 'POST', // *GET, POST, PUT, DELETE, etc.
                    mode: 'cors', // no-cors, *cors, same-origin
                    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
                    credentials: 'same-origin', // include, *same-origin, omit
                    headers: {
                        'Content-Type': 'application/json'
                        // 'Content-Type': 'application/x-www-form-urlencoded',
                    },
                    redirect: 'follow', // manual, *follow, error
                    referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
                    body: JSON.stringify(options.data) // body data type must match "Content-Type" header
                })
                    .then(response => {
                        if (!response.ok) {
                            throw new Error(response.statusText)
                        }
                        return response;
                    })
                    .catch(error => {
                        alertHelper.error(messages.errorDelete, status, xhr);
                        Swal.showValidationMessage(
                            `Request failed: ${error}`
                        )
                    })
            },
            allowOutsideClick: () => !Swal.isLoading()
        }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {

                alertHelper.showResponse(result.value, status, null, options.onsuccess);
            }
        });
    }
};











