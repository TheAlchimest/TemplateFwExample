var businessToSpController = {
    emptyAction: '<span class="btn btn-light text-white btn-md py-1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>',
    titleTd: '<span class="text-primary"><b>{title}</b></span>',
    drawAllRowsActions: function () {
        let ctrl = this;
        $(".table-responsive-md").find("tbody>tr").each(function (index) {
            let actions = ctrl.drawRowActions($(this));
        });

    },
    drawRowActions: function ($tr) {

        let ctrl = this;
        let status = parseInt($tr.attr("data-status"));
        ctrl.drawAddSpAccountAction($tr, status);
        ctrl.drawTitle($tr);
        foundationAcountsListController.drawStatus($tr, status);

    },
    drawTitle: function ($tr) {

        let ctrl = this;
        let title = ctrl.titleTd.replace("{title}", $tr.attr("data-name"));
        $tr.find(".td-title").html(title);
    },
    drawAddSpAccountAction: function ($tr, status) {
        
        let ctrl = this;
        let action = '<button onclick="businessToSpController.AddSpAccount(this);" class="btn btn-outline-success btn-md py-1"> انشاء حساب </button>';

        $tr.find(".td-actions").html(action);
    },
    getActionTr: function (element) {
        let $element = $(element);
        return $element.closest('tr');
    },
    AddSpAccount: function (element) {
        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.businessToSp, '/FoundationAccountsBusinessToSp/AddSpAccountForBusiness');
    },
    updateStatus: function () {
        $('#grid-filter').trigger('submit');
    },
    confirm: function ($tr, operation, actionUrl, calback) {
        
        let title = "";
        let baseMsg = "";
        switch (operation) {
            case operationTypes.businessToSp:
                title = messages.makeSpAccountConfirmation;
                baseMsg = messages.makeSpAccountItemText;
                break;
            default:
                break;
        }

        let ctrl = this;
        let name = $tr.attr('data-name');
        let data = JSON.parse($tr.attr('data-to-post'));
        let text = baseMsg.replace("##", name);

        let options = {
            icon: 'question',
            title: title,
            text: text,
            actionUrl: actionUrl,
            data: data,
            onsuccess: function () {
                if (calback) {
                    calback();
                }
                else {
                    ctrl.updateStatus();
                }
            }
        };
        confirmationHelper.confimWithAjaxCall(options);
    }

}

