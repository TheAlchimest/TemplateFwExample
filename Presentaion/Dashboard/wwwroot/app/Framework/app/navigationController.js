var navigationController = {
    baseUrl: null,
    isDefaultAsRestricedMode: true,
    run: function () {
        $(window).on('hashchange', function () {
            navigationController.refreshContent()
        });
        navigationController.refreshContent();
    },
    refreshContent: function () {
        let ctrl = this;
        let targetPage = 'home';
        let hashMatch = /^#!\/(.+)/.exec(location.hash);
        // if a target page is provided in the location hash
        if (hashMatch) {
            targetPage = hashMatch[1];
        }
        else if (window.location.pathname == "/" || window.location.pathname.toLowerCase() == "/home/") {
            targetPage = 'dashboard';
            window.location.hash = "#!dashboard";
        }
        else {
            return;
        }
        //window.document.title = $activeLink.length ? $activeLink.text() + ' | Celebrate You' : 'Celebrate You';
        app.ui.showPreloader();
        let url = '/' + targetPage;
        let jqxhr = $.get(url)
            .done(function (html, status, xhr) {
                if (jqxhr.Target == null || jqxhr.Target == location.hash) {
                    app.ui.refresh(html);
                }
                else {
                    app.ui.hidePreloder();
                }
            })
            .fail(function () {
                if (jqXHR.status == 403) {
                    location.href = '/Home/UnauthorizedAction';
                } else if (jqXHR.status == 404) {
                    location.href = '/Home/PageNotFound';
                } else {
                    //location.href = '/Home/Error';
                }
                app.ui.hidePreloder();
            })
            .always(function () {
            });

        if (ctrl.isDefaultAsRestricedMode) {
            jqxhr.Target = location.hash;

        }
    }
}










