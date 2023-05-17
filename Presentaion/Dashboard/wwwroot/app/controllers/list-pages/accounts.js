var foundationAcountsListController = {
    controllerRoute: '',
    delegationControllerRoute: '',
    emptyAction: '',

    editAction: '',
    detailsAction: '',
    usersAction: '',
    titleTd: '',
    initializeActions: function (controller, delegationController) {
        let ctrl = this;
        ctrl.controllerRoute = controller;
        ctrl.delegationControllerRoute = delegationController;
        ctrl.emptyAction = `<span class="btn btn-light text-white btn-md py-1 d-none">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>`;
        ctrl.editAction = `<a href="#!/${controller}/Edit/{id}" class="btn btn-outline-primary btn-md py-1">تعديل</a>`;
        ctrl.detailsAction = `<a href="#!/${controller}/GetBlockReasonNotes/{id}/{type}" class="btn btn-outline-primary btn-md py-1">تفاصيل</a>`;

        ctrl.usersAction = `<a href="/#!/${delegationController}/index/{id}"><span class="btn btn-primary text-white btn-md py-1">المفوضين</span></a>`;
        ctrl.titleTd = `<span class="text-primary"><b>{title}</b></span>`;

    },
    drawAllRowsActions: function (controller, delegationController) {
        
        let ctrl = this;
        this.initializeActions(controller, delegationController);
        $(".table-responsive-md").find("tbody>tr").each(function (index) {
            let actions = ctrl.drawRowActions($(this));
        });

    },
    drawRowActions: function ($tr) {

        let ctrl = this;
        let status = parseInt($tr.attr("data-status"));

        ctrl.drawActivationAction($tr, status);
        ctrl.drawEditAction($tr);
        ctrl.drawDetailsAction($tr);
        //ctrl.drawDeleteAction($tr);
        ctrl.drawUsersAction($tr, status);
        ctrl.drawTitle($tr);
        ctrl.drawStatus($tr, status);

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
        let activate = '<button onclick="foundationAcountsListController.activate(this);" class="btn btn-outline-success btn-md py-1"> تفعيل </button>';
        let deactivate = '<button onclick="foundationAcountsListController.deactivate(this);"  class="btn btn-outline-danger btn-md py-1"> إيقاف </button>';
        let reject = '<button onclick="foundationAcountsListController.reject(this);"   class="btn btn-outline-danger btn-md py-1"> رفض </button>';
      
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
    drawEditAction: function ($tr) {

        let ctrl = this;
        let action = ctrl.editAction.replace("{id}", $tr.attr("data-id"));
        $tr.find(".td-edit").html(action);
    },
    drawDetailsAction: function ($tr) {

        let ctrl = this;
        let action = ctrl.detailsAction.replace("{id}", $tr.attr("data-id"))
            .replace("{type}", $tr.attr("data-foundation-type"));
        $tr.find(".td-detailes").html(action);
    },
    drawDeleteAction: function ($tr) {
        let ctrl = this;
        $tr.find(".td-delete").html(ctrl.deleteAction);
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
        deactivationModalController.showDeactivationModal(`/${ctrl.controllerRoute}/deactivate`, deactivationType.Foundation);
    },
    reject: function (element) {

        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.deactivate, `/${ctrl.controllerRoute}/reject`);

    },
    delete: function (element) {

        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.delete, '/vote/delete', function () {
            actionsController.removePaginatedTr($tr);
        });

    },
    updateStatus: function () {
        $('#grid-filter').trigger('submit');
    },
    viewDetails: function (element) {
        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        let id = $tr.attr('data-id-encode');
        let foundationType = $tr.attr('data-foundation-type');
        document.location = `/${ctrl.controllerRoute}/BlockReasonNotes/` + id + "/" + foundationType;
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
            case operationTypes.delete:
                title = messages.deleteConfirmation;
                baseMsg = messages.deleteItemText;
                break;
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
var deactivationModalController = {

    deactivationConfirmed: function (url, deactivateType) {
        let ctrl = this;
        let $deactivateAccountModal = $("#deactivateAccountModal");

        var data = {
            "Id": $deactivateAccountModal.find("#DeactivatedAccountId").val(),
            "BlockReasonID": $deactivateAccountModal.find("#BlockReasonID").val(),
            "BlockReasonNote": $deactivateAccountModal.find("#BlockReasonNote").val()
        }
        if (!(data.BlockReasonID && data.BlockReasonID > 0)) {
            $.smkRemoveError($deactivateAccountModal.find("#BlockReasonID"));
            $.smkAddError($deactivateAccountModal.find("#BlockReasonID"), "اختر سبب الايقاف");
            return;
        }
        $.ajax({
            url: url,
            method: "POST",
            data: data,
            success: function (result, status, xhr) {
                if (deactivateType == deactivationType.Foundation) {

                    foundationAcountsListController.updateStatus();
                }
                else {
                    userAccountsController.updateStatus();
                }
                ctrl.hideDeactivationModal();
                alertHelper.showResponse(result, status, xhr, options.onsuccess);
            },
            error: function (xhr, status, errorThrown) {
                alertHelper.error(messages.errorActivation, status, xhr);
            }
        });
    },
    showDeactivationModal: function (url, dactiveType) {
        let ctrl = this;
        //ctrl.clearDeactivationModel();
        let $deactivateAccountModal = $("#deactivateAccountModal");
        $deactivateAccountModal.find("#btnConfirmDeactivation").attr("onclick", "deactivationModalController.deactivationConfirmed('" + url + "'," + dactiveType + ");");
        $deactivateAccountModal.find("#btnCancelDeactivation").attr("onclick", "deactivationModalController.deactivationCanceled('" + url + "');");
        $deactivateAccountModal.modal('show');
    },
    hideDeactivationModal: function () {
        let ctrl = this;
        ctrl.clearDeactivationModel();
        $("#deactivateAccountModal").modal('hide');
        // $('.modal-backdrop').remove();
    },
    deactivationCanceled: function (element) {
        let ctrl = this;
        ctrl.hideDeactivationModal();
    },
    clearDeactivationModel: function () {
        let ctrl = this;
        let $deactivateAccountModal = $("#deactivateAccountModal");
        $deactivateAccountModal.find("#DeactivatedAccountId").val("");
        //$deactivateAccountModal.find("#BlockReasonID").val("");
        $("#BlockReasonID").val($("#BlockReasonID option:first").val());
        $deactivateAccountModal.find("#BlockReasonNote").val("");
        $deactivateAccountModal.find("#lblName").text("");
        $.smkRemoveError($deactivateAccountModal.find("#BlockReasonID"));
    }
}