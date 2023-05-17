var formHtmlHelper = {
    /* ******************************
     * download form as html
     * *****************************/
    downloadHtml: function () {
        $(".select-dynamic").find('option').remove();
        $(".radio-list-dynamic").empty();
        $(".checkbox-list-dynamic").empty();

        var a = $('<a style="display:none"></a>');
        $("body").append(a);
        a.attr('id', 'downloadJson');
        var dataStr = "data:text/html;charset=utf-8," + encodeURIComponent($('#RequestContent').html());
        var dlAnchorElem = document.getElementById('downloadJson');
        dlAnchorElem.setAttribute("href", dataStr);
        dlAnchorElem.setAttribute("download", "Form.html");
        dlAnchorElem.click();
    }
};
