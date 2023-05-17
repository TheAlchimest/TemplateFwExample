var uiController = {
    $mainContentArea: null,
    run: function () {
        let ctrl = this;
        ctrl.$mainContentArea = $('#allcontent');
        ctrl.refresh();
    },
    refresh: function (html,$content) {
        let ctrl = this;
        if ($content == null) {
            $content = ctrl.$mainContentArea;
        }
        if (html !== null) {
            $content.hide();
            $content.html(html);
            ctrl.applyPlugins($content);
            $content.fadeIn(300, function () {
                ctrl.hidePreloder();
            });
        }
        else {//just refresh plugins
            ctrl.applyPlugins($content);
        }

        
    },
    applyPlugins: function ($content) {
        let ctrl = this;
        app.fireEngine();
        $content.find("select.select2").select2();
        ctrl.bindDateTime();
        ctrl.handleMenuSelection();
    },
    date2str: function (x, y) {
        let z = {
            M: x.getMonth() + 1,
            d: x.getDate(),
            h: x.getHours(),
            m: x.getMinutes(),
            s: x.getSeconds()
        };
        y = y.replace(/(M+|d+|h+|m+|s+)/g, function (v) {
            return ((v.length > 1 ? "0" : "") + z[v.slice(-1)]).slice(-2)
        });

        return y.replace(/(y+)/g, function (v) {
            return x.getFullYear().toString().slice(-v.length)
        });
    },
    bindDateTime: function () {
        let ctrl = this;
        $('input[data-type="date"],input[data-type="datehijri"]').each(function () {
            let endDate = null;
            if ($(this).data('olddate') == true)
                endDate = ctrl.date2str(new Date(), 'yyyy-MM-dd');

            if (endDate == null) {
                $(this).hijriDatePicker({
                    format: 'YYYY-MM-DD',
                    hijri: $(this).data('hijri'),
                    locale: $('body').hasClass('rtl') ? 'ar-SA' : 'en',
                    isRTL: $('body').hasClass('rtl'),
                    widgetPositioning: {
                        horizontal: $('body').hasClass('rtl') ? 'right' : 'left',
                    },
                    showSwitcher: false,
                    ignoreReadonly: true,
                    icons: {
                        previous: $('body').hasClass('rtl') ? '<i class="far fa-chevron-right"></i>' : '<i class="far fa-chevron-left"></i>',
                        next: $('body').hasClass('rtl') ? '<i class="far fa-chevron-left"></i>' : '<i class="far fa-chevron-right"></i>',
                    },
                }).on('dp.change', function (e) { console.log(e); });
            }
            else {
                $(this).hijriDatePicker({
                    hijri: $(this).data('hijri'),
                    maxDate: endDate,
                    locale: $('body').hasClass('rtl') ? 'ar-SA' : 'en',
                    isRTL: $('body').hasClass('rtl'),
                    widgetPositioning: {
                        horizontal: $('body').hasClass('rtl') ? 'right' : 'left',
                    },
                    showSwitcher: false,
                    ignoreReadonly: true,
                    icons: {
                        previous: $('body').hasClass('rtl') ? '<i class="far fa-chevron-right"></i>' : '<i class="far fa-chevron-left"></i>',
                        next: $('body').hasClass('rtl') ? '<i class="far fa-chevron-left"></i>' : '<i class="far fa-chevron-right"></i>',
                    },
                }).on('dp.change', function (e) { console.log(e); });
            }
        });
    },
    handleMenuSelection: function() {
        $('.mm-show').removeClass('mm-show');
        $('.mm-active').removeClass('mm-active');
        for (var nk = window.location,
            o = $("ul#menu a").filter(function () {
                return this.href == nk;
            })
                .addClass("mm-active")
                .parent()
                .addClass("mm-active"); ;) {
            if (!o.is("li")) break;
            o = o.parent()
                .addClass("mm-show")
                .parent()
                .addClass("mm-active");
        };
    },
    hidePreloder: function (callBack) {
        if (callBack == null) {
            callBack = function () { };
        }
        $("#preloader").hide(callBack);
    },
    showPreloader: function () {
            $("#preloader").show();
    }
}










