
var pollListController = {
    emptyAction: '<span class="btn btn-light text-white btn-md py-1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>',
    activateAction: '<button onclick="pollListController.activate(this,{count});" class="btn btn-outline-success btn-md py-1"> تفعيل </button>',
    deactivateAction: '<button onclick="pollListController.deactivate(this,{count});"  class="btn btn-outline-danger btn-md py-1"> إيقاف </button>',
    editAction: '<a href="#!/poll/edit/{id}" class="btn btn-outline-primary btn-md py-1">تعديل</a>',
    deleteAction: '<button onclick="pollListController.delete(this);" class="btn btn-outline-danger btn-md py-1">حذف</button>',
    resultsAction: '<a href="#!/Poll/Results/{id}" class="btn btn-outline-primary btn-md py-1">النتائج</a>',
    questionsAction: '<a href="#!/PollQuestion/Index/{id}" class="btn btn-outline-primary btn-md py-1">الاسئلة</a>',
    questionsActionWithTitle: '<a href="#!/PollQuestion/Index/{id}" class="py-1"><span class="text-primary"><b>{title}</b></span></a>',
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
        //data-id="@item.PollId" data-activation-count="@item.ActivationCount" data-is-default="@item.IsDefault" data-name="@item.Title" data-to-post='{"id":"@item.PollId"}'
        let activationCount = parseInt($tr.attr("data-activation-count"));
        let questionCount = parseInt($tr.attr("data-question-count"));
        let isDefault = ($tr.attr("data-is-default") === 'true');
        ctrl.drawActivationAction($tr, isDefault, activationCount, questionCount);
        ctrl.drawEditAction($tr, activationCount);
        ctrl.drawDeleteAction($tr, activationCount);
        ctrl.drawResultsAction($tr, activationCount);
        ctrl.drawQuestionsAction($tr, activationCount);
        ctrl.drawTitle($tr);
        ctrl.drawStatus($tr, isDefault);

    },
    drawTitle: function ($tr) {

        let ctrl = this;
        let title = ctrl.questionsActionWithTitle.replace("{title}", $tr.attr("data-name")).replace("{id}", $tr.attr("data-id-encode"));
        $tr.find(".td-title").html(title);
    },
    drawStatus: function ($tr, isDefault) {

        let ctrl = this;
        let action = (isDefault) ? ctrl.activStatus : ctrl.inActivStatus;
        $tr.find(".td-status").html(action);
    },
    drawActivationAction: function ($tr, isDefault, activationCount, questionCount) {

        let ctrl = this;
        let action = (isDefault) ? ctrl.deactivateAction : ctrl.activateAction;
        if (!isDefault && activationCount > 0) action = ctrl.emptyAction;

        action = action.replace("{count}", questionCount);

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
        let action = (activationCount > 0) ? ctrl.resultsAction.replace("{id}", $tr.attr("data-id-encode")) : ctrl.emptyAction;
        $tr.find(".td-results").html(action);
    },
    drawQuestionsAction: function ($tr) {

        let ctrl = this;
        let action = ctrl.questionsAction.replace("{id}", $tr.attr("data-id-encode"));
        $tr.find(".td-questions").html(action);
    },
    getActionTr: function (element) {
        let $element = $(element);
        return $element.closest('tr');
    },
    activate: function (element, count) {
        if (count == 0) {
            alertHelper.error("لابد من ادخال اسئلة قبل تفعيل الاستطلاع", "");
            return;
        }

        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.activate, '/poll/activate');
    },
    deactivate: function (element, count) {

        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.deactivate, '/poll/deactivate');

    },
    delete: function (element) {

        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.delete, '/poll/delete', function () {
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