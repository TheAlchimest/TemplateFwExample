var serviceListController = {
    emptyAction: '<span class="btn btn-light text-white btn-md py-1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>',
    activateAction: '<button onclick="serviceListController.publish(this);" class="btn btn-outline-success btn-md py-1"> نشر </button>',
    deactivateAction: '<button onclick="serviceListController.unpublish(this);"  class="btn btn-outline-danger btn-md py-1"> إيقاف النشر</button>',
    drawAllRowsActions: function () {
        let ctrl = this;
        $(".table-responsive-md").find("tbody>tr").each(function (index) {
            let actions = ctrl.drawRowActions($(this));
        });

    },
    drawRowActions: function ($tr) {

        let ctrl = this;
        let isPublished = ($tr.attr("data-is-published") === 'true');
        ctrl.drawActivationAction($tr, isPublished);

    },
    drawActivationAction: function ($tr, isPublished) {
        let ctrl = this;
        let action = (isPublished) ? ctrl.deactivateAction : ctrl.activateAction;
        $tr.find(".td-actions").html(action);
    },
    getActionTr: function (element) {
        let $element = $(element);
        return $element.closest('tr');
    },
    publish: function (element) {

        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.publish, '/Service/Publish');
    },
    unpublish: function (element) {

        let ctrl = this;
        let $tr = ctrl.getActionTr(element);
        ctrl.confirm($tr, operationTypes.unpublish, '/Service/UnPublish');

    },
    updateStatus: function () {
        $('#grid-filter').trigger('submit');
    },
    confirm: function ($tr, operation, actionUrl, calback) {
        
        let title = "";
        let baseMsg = "";
        switch (operation) {
            case operationTypes.publish:
                title = messages.publishConfirmation;
                baseMsg = messages.publishItemText;
                break;
            case operationTypes.unpublish:
                title = messages.unpublishConfirmation;
                baseMsg = messages.unpublishItemText;
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