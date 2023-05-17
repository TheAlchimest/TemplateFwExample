var voteListController = {
    emptyAction: '<span class="btn btn-light text-white btn-md py-1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>',
    activateAction: '<button onclick="voteListController.activate(this);" class="btn btn-outline-success btn-md py-1"> تفعيل </button>',
    deactivateAction: '<button onclick="voteListController.deactivate(this);"  class="btn btn-outline-danger btn-md py-1"> إيقاف </button>',
    editAction: '<a href="#!/vote/edit/{id}" class="btn btn-outline-primary btn-md py-1">تعديل</a>',
    deleteAction: '<button onclick="voteListController.delete(this);" class="btn btn-outline-danger btn-md py-1">حذف</button>',
    resultsAction: '<a href="#!/vote/results/{id}" class="btn btn-outline-primary btn-md py-1">النتائج</a>',
    //resultsAction:'<span class="btn btn-outline-primary btn-md py-1">النتائج</span>',
    titleTd: '<span class="text-primary"><b>{title}</b></span>',
    activStatus: '<span  class="btn btn-success text-white btn-md py-1 btn-block"> مفعل </span>',
    inActivStatus: '<span  class="btn btn-danger btn-md py-1 btn-block"> غير مفعل </span>',
    drawAllRowsActions: function () {
        let ctrl = this;
        $(".table-responsive-md").find("tbody>tr").each(function (index) {
            let actions = ctrl.drawRowActions($(this));
        });

    },
    drawRowActions: function ($tr) {

        let ctrl = this;
        let activationCount = parseInt($tr.attr("data-activation-count"));
        let isDefault = ($tr.attr("data-is-default") === 'true');
        ctrl.drawActivationAction($tr, isDefault, activationCount);
        ctrl.drawEditAction($tr, activationCount);
        ctrl.drawDeleteAction($tr, activationCount);
        ctrl.drawResultsAction($tr, activationCount);
        ctrl.drawTitle($tr);
        ctrl.drawStatus($tr, isDefault);

    },
    drawTitle: function ($tr) {

        let ctrl = this;
        let title = ctrl.titleTd.replace("{title}", $tr.attr("data-name"));
        $tr.find(".td-title").html(title);
    },
    drawStatus: function ($tr, isDefault) {

        let ctrl = this;
        let action = (isDefault) ? ctrl.activStatus : ctrl.inActivStatus;
        $tr.find(".td-status").html(action);
    },
    drawActivationAction: function ($tr, isDefault, activationCount) {
        let ctrl = this;
        let action = (isDefault) ? ctrl.deactivateAction : ctrl.activateAction;
        if (!isDefault && activationCount > 0) action = ctrl.emptyAction;
        $tr.find(".td-actions").html(action);
    },
    drawEditAction: function ($tr, activationCount) {
        let ctrl = this;
        let action = (activationCount == 0) ? ctrl.editAction.replace("{id}", $tr.attr("data-id-encode")) : ctrl.emptyAction;
        $tr.find(".td-edit").html(action);
    },
    drawDeleteAction: function ($tr, activationCount) {

        let ctrl = this;
        let action = (activationCount == 0) ? ctrl.deleteAction : ctrl.emptyAction;
        $tr.find(".td-delete").html(action);
    },
    drawResultsAction: function ($tr, activationCount) {

        let ctrl = this;
        //  let action = (activationCount > 0) ? ctrl.resultsAction : ctrl.emptyAction;
        let action = (activationCount > 0) ? ctrl.resultsAction.replace("{id}", $tr.attr("data-id-encode")) : ctrl.emptyAction;
        //let action = ctrl.resultsAction.replace("{id}", $tr.attr("data-id-encode"));
        $tr.find(".td-results").html(action);
    },
    getActionTr: function (element) {
        let $element = $(element);
        return $element.closest('tr');
    },
    activate: function (element) {

        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.activate, '/vote/activate');
    },
    deactivate: function (element) {

        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.deactivate, '/vote/deactivate');

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