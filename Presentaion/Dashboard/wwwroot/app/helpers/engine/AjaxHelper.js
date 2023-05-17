/******************************
 * AjaxHelper
 * 
 ******************************/
var AjaxHelper = {

    showPreloader: function () {
        $("#preloader").show('fast');
    },
    hideePreloader: function () {
        $("#preloader").hide('fast');
    },
    ajaxPost: function (url, data) {
        return $.post('/Form/Create', data);
    },
    ajaxPost: function (url, data) {
        return $.ajax({
            url: url,
            type: 'POST',
            data: data,
            cache: false,
            contentType: 'application/json',
            processData: false
        });
    },
    postFormHasFiles: function (url, data) {
        return $.ajax({
            url: url,
            type: 'POST',
            data: data,
            cache: false,
            contentType: false,
            processData: false
        });
    },
    ajaxGet: function (url) {

        return $.ajax({
            url: url,
            type: 'GET',
            cache: false,
            contentType: false,
            processData: false
        });


    },
    ajaxLoadContent: function ($element, url, callBackFunction) {

        $element.load(url, callBackFunction);

    }
};

