var userAccountsController = {
    controllerRoute: '',
    emptyAction: '',
    detailsAction: '',
    titleTd: '',
    initializeActions: function (controller) {
        let ctrl = this;
        ctrl.controllerRoute = controller;
        ctrl.emptyAction = `<span class="btn btn-light text-white btn-md py-1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>`;
        ctrl.detailsAction = `<a href="#!/${controller}/GetBlockReasonNotes/{id}" class="btn btn-outline-primary btn-md py-1">تفاصيل</a>`;
        ctrl.titleTd = `<span class="text-primary"><b>{title}</b></span>`;
    },
    drawAllRowsActions: function (controller) {
        let ctrl = this;
        this.initializeActions(controller);
        $(".table-responsive-md").find("tbody>tr").each(function (index) {
            let actions = ctrl.drawRowActions($(this));
        });

    },
    drawRowActions: function ($tr) {

        let ctrl = this;
        let status = parseInt($tr.attr("data-status"));

        ctrl.drawActivationAction($tr, status);
        //ctrl.drawEditAction($tr);
        ctrl.drawDetailsAction($tr);
        ctrl.drawTitle($tr);
        ctrl.drawStatus($tr, status);

    },
    drawDetailsAction: function ($tr) {

        let ctrl = this;
        let action = ctrl.detailsAction.replace("{id}", $tr.attr("data-id"));
        $tr.find(".td-detailes").html(action);
    },
    drawTitle: function ($tr) {

        let ctrl = this;
        let title = ctrl.titleTd.replace("{title}", $tr.attr("data-name"));
        $tr.find(".td-title").html(title);
    },
    drawStatus: function ($tr, status) {

        let ctrl = this;
        
        let action = "";
        switch (status) {
            case UserAccountStatusEnum.Blocked:
                action = '<span class="btn btn-danger text-white btn-md py-1">محظور</span>';
                break;
            case UserAccountStatusEnum.Rejected:
                action = '<span class="btn btn-danger text-white btn-md py-1">مرفوض</span>';
                break;
            case UserAccountStatusEnum.PendingReview:
                action = '<span class="btn btn-primary text-white btn-md py-1">في انتظار المراجعة</span>';
                break;
            case UserAccountStatusEnum.UnderRevision:
                action = '<span class="btn btn-warning text-white btn-md py-1">تحت المراجعة</span>';
                break;
            case UserAccountStatusEnum.Active:
                action = '<span class="btn btn-success text-white btn-md py-1">فعال</span>';
                break;
            default:
                action = '<span class="btn btn-info text-white btn-md py-1"></span>';
                break;
        }
        $tr.find(".td-status").html(action);
    },
    drawActivationAction: function ($tr, status) {
        
        let ctrl = this;
        let activate = '<button onclick="userAccountsController.activate(this);" class="btn btn-outline-success btn-md py-1"> تفعيل </button>';
        let deactivate = '<button onclick="userAccountsController.deactivate(this);"  class="btn btn-outline-danger btn-md py-1"> إيقاف </button>';
        let reject = '<button onclick="userAccountsController.reject(this);"   class="btn btn-outline-danger btn-md py-1"> رفض </button>';
        
        let action = "";
        switch (status) {
            case UserAccountStatusEnum.Blocked:
            case UserAccountStatusEnum.Rejected:
                action = activate;
                break;
            case UserAccountStatusEnum.PendingReview:
            case UserAccountStatusEnum.UnderRevision:
                action = activate + "" + reject;
                break;
            case UserAccountStatusEnum.Active:
                action = deactivate;
                break;
            default:
                action = activate + "" + deactivate;
                break;
        }

        $tr.find(".td-actions").html(action);
    },
    drawUsersAction: function ($tr, status) {

        let ctrl = this;
        let action = (status == UserAccountStatusEnum.Active) ? ctrl.usersAction.replace("{id}", $tr.attr("data-id")) : ctrl.emptyAction;
        $tr.find(".td-users").html(action);
    },
    getActionTr: function (element) {
        let $element = $(element);
        return $element.closest('tr');
    },
    activate: function (element) {
        
        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.activate, `/${ctrl.controllerRoute}/activate`);
    },
    deactivate: function (element) {
        
        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        let $deactivateAccountModal = $("#deactivateAccountModal");
        let id = $tr.attr('data-id');
        let name = $tr.attr('data-name');
        $deactivateAccountModal.find("#DeactivatedAccountId").val(id);
        $deactivateAccountModal.find("#lblName").text(name);
        deactivationModalController.showDeactivationModal(`/${ctrl.controllerRoute}/Deactivate`,  deactivationType.User);

    },
    reject: function (element) {
        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.reject, `/${ctrl.controllerRoute}/reject`);
    },
    updateStatus: function () {
        $('#grid-filter').trigger('submit');
    },
    viewDetails: function (element) {
        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        let id = $tr.attr('data-id-encode');
        document.location = `/${ctrl.controllerRoute}/BlockReasonNotes/` + id;
    },
    confirm: function ($tr, operation, actionUrl, calback) {
        
        let title = "";
        let baseMsg = "";
        switch (operation) {
            case operationTypes.activate:
                title = messages.activationConfirmation;
                baseMsg = messages.activationItemText;
                break;
            case operationTypes.deactivate:
                title = messages.deactivationConfirmation;
                baseMsg = messages.deactivationItemText;
                break;
            case operationTypes.reject:
                title = messages.rejectConfirmation;
                baseMsg = messages.rejectItemText;
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
