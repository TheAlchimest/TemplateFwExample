/******************************
 * handle cascade values
 ******************************/
var lookupHelper = {
    lookupUrl: '',
    
    run: function () {
        let helper = lookupHelper;
        helper.loadLookupSelect();
        helper.loadLookupRadios();
        helper.loadLookupCheckboxes();
    },
    clearSelectOptions: function () {
        $("select[data-source]").find('option').remove();
    },
    getLookupUrl: function (apiUurl) {
        return lookupHelper.lookupUrl + apiUurl;
    },
    loadLookupSelect: function () {
        let helper = lookupHelper;

        $(".select-manual").each(function () {
            let value = $(this).attr('data-value');
            let options = $(this).children();
            options.each(function () {
                let optionValue = $(this).attr('value');
                if (optionValue == value)
                    $(this).attr('selected', 'selected');
            });
            $(this).select2("destroy");
            $(this).select2();
        });

        //clearSelectOptions();
        $(".select-dynamic").each(function () {

            let apiUrl = $(this).attr('data-api-url');
            /* //chech is cascade child
             //let $baseElementId = $(this).attr('data-cascade-with');
             //let $parentCascadeElement = ($baseElementId != null && $baseElementId  !== 'undefined' )? $('#' + $baseElementId):null;*/
            if (typeof apiUrl !== 'undefined' && apiUrl != null) {
                helper.loadSelectDataFromApi($(this), apiUrl);
            }
        });
    },
    loadLookupRadios: function () {
        let helper = lookupHelper;

        //clearSelectOptions();
        $(".radio-list-dynamic").each(function () {
            let apiUrl = $(this).attr('data-api-url');
            helper.loadRadiosDataFromApi($(this), apiUrl);
        });
    },
    loadLookupCheckboxes: function () {
        let helper = lookupHelper;

        //clearSelectOptions();
        $(".checkbox-list-dynamic").each(function () {
            let apiUrl = $(this).attr('data-api-url');
            helper.loadCheckboxDataFromApi($(this), apiUrl);
        });
    },


    loadSelectDataFromApi: function ($element, apiUrl) {
        let helper = lookupHelper;
        if ($element.hasClass("select2")) {
            $element.parent().find(".select2-container").addClass("partial-loading-box");
        }
        else {
            $element.parent().addClass("partial-loading-box");
        }
        let get = $.ajax({
            url: helper.getLookupUrl(apiUrl),
            type: 'GET',
            cache: false,
            contentType: false,
            processData: false
        });
        get.done(function (data, status, xhr) {
            if (xhr.responseJSON != null) {
                var jsonOptions = xhr.responseJSON.Data;
                console.log(xhr.responseJSON);
                $element.find('option').remove();
                let selectedValue = null;

                if (typeof $element.attr('data-value') !== 'undefined') {
                    selectedValue = $element.attr('data-value');
                }

                if (typeof $element.attr('data-default-text') !== 'undefined') {
                    if (typeof $element.attr('data-default-val') !== 'undefined') {
                        $element.append(`<option value="${$element.attr('data-default-val')}" >${$element.attr('data-default-text')}</option>`);
                    }
                    else {
                        $element.append(`<option>${$element.attr('data-default-text')}</option>`);

                    }
                }
                //loop throw json and add options 
                let valAttr = '';
                $.each(jsonOptions, function (index, element) {
                    if (element.Id !== 'undefined' && element.Id !== null) {
                        var isValueExists = false;
                        if ($element.attr('data-multi-select') == 'true' && selectedValue !== null) {
                            var ids = selectedValue.split(",");                           
                            ids.forEach(function (currentValue, index, arr) {
                                if (currentValue == element.Id)
                                    isValueExists = true;
                            });
                        }
                        else {                           
                            if (selectedValue !== null && element.Id == selectedValue) {
                                isValueExists = true;
                            }
                        }

                        if (isValueExists) {
                            $element.append(`<option value="${element.Id}" selected>${element.Text}</option>`);
                        }
                        else {
                            $element.append(`<option value="${element.Id}">${element.Text}</option>`);
                        }
                    }
                    else {
                        $element.append(`<option>${element.Text}</option>`);

                    }
                });
                //fire onParentCascadeValueChange if the current element is a parent for cascade child elements
                app.cVal.fireOnParentCascadeChange($element);
                if ($element.attr('data-multi-select') == 'true') {
                    $element.multipleSelect('refreshOptions', {});
                }
            }
            else {
            }
            if ($element.hasClass("select2")) {
                $element.parent().find(".select2-container").removeClass("partial-loading-box");
            }
            else {
                $element.parent().removeClass("partial-loading-box");
            }

        });
    },

    loadRadiosDataFromApi: function ($element, apiUrl) {
        let helper = lookupHelper;

        let get = $.ajax({
            url: helper.getLookupUrl(apiUrl),
            type: 'GET',
            cache: false,
            contentType: false,
            processData: false
        });
        get.done(function (data, status, xhr) {

            if (xhr.responseJSON != null) {
                var jsonOptions = xhr.responseJSON.Data;
                console.log(xhr.responseJSON);
                $element.find('radio').remove();
                let selectedValue = null;

                if (typeof $element.attr('data-value') !== 'undefined') {
                    selectedValue = $element.attr('data-value');
                }
                let index = 0;
                let name = $element.attr('data-model-name');
                let id = null;
                let checked = null;
                $.each(jsonOptions, function (index, element) {
                    if (selectedValue !== null && element.Id == selectedValue) {
                        checked = 'checked';
                    }
                    else {
                        checked = '';
                    }
                    ++index;
                    id = name + index;
                    $element.append(app.template.returnRadio(name, id, element.Id, element.Text, checked));
                });
            }
            else {
            }
        });
    },

    loadCheckboxDataFromApi: function ($element, apiUrl) {
        let helper = lookupHelper;

        let get = $.ajax({
            url: helper.getLookupUrl(apiUrl),
            type: 'GET',
            cache: false,
            contentType: false,
            processData: false
        });
        get.done(function (data, status, xhr) {

            if (xhr.responseJSON != null) {
                var jsonOptions = xhr.responseJSON.Data;
                console.log(xhr.responseJSON);
                $element.find('radio').remove();
                let selectedValue = null;

                if (typeof $element.attr('data-value') !== 'undefined') {
                    selectedValue = $element.attr('data-value');
                }
                let index = 0;
                let name = $element.attr('data-model-name');
                let id = null;
                let checked = null;
                $.each(jsonOptions, function (index, element) {
                    if (selectedValue !== null && element.Id == selectedValue) {
                        checked = 'checked';
                    }
                    else {
                        checked = '';
                    }
                    ++index;
                    id = name + index;
                    $element.append(app.template.returnCheckbox(name, id, element.Id, element.Text, checked));
                });
            }
            else {
            }
        });
    },


};
