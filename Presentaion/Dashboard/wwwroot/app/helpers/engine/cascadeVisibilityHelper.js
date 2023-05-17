

var cascadeVisibilityHelper = {
    run: function () {
        let helper = cascadeVisibilityHelper;
        //first collect cascade values parents 
        let cascadeParents = helper.collectCascadeParents();
        //second  bind onParentValueChange on parents
        helper.bindOnParentChangeEvent(cascadeParents);
        //fire onParentValueChange for all parents except any one will get data from api
        helper.fireOnChangeForParents(cascadeParents);
    },
    //
    collectCascadeParents: function () {
        let helper = cascadeVisibilityHelper;

        let cascadeParents = [];
        $("[data-visibility-depend-on-element]").each(function () {
            let $parentElementId = $(this).attr('data-visibility-depend-on-element');
            let $parentElement = $('[name="' + $parentElementId + '"]');
            $parentElement.attr('data-parent-cascade', 'true');
            cascadeParents.push($parentElement);
        });
        return cascadeParents;
    },
    //
    bindOnParentChangeEvent: function (parents) {
        let helper = cascadeVisibilityHelper;

        parents.forEach(function ($parent) {
            $parent.change(function () {
                helper.onParentValueChange($parent);
            });
        });
    },
    //
    onParentValueChange: function ($parentElement) {
        let parentVal = $parentElement.val();
        let parentName = $parentElement.attr('name');
        $("[data-visibility-depend-on-element='" + parentName + "']").each(function () {
            if ($(this).attr('data-visibility-depend-on-value') == parentVal) {
                $(this).parents('.form-group').show();
            }
            else {
                $(this).parents('.form-group').hide();
            }
        });
    },
    //
    /*ده عشان العناصر اللي هتقرا من عناصر تانية غير مرتبطة ب api */
    fireOnChangeForParents: function (parents) {
        let helper = cascadeVisibilityHelper;

        parents.forEach(function ($parent) {
            //trigger on change
            helper.onParentValueChange($parent);
        });
    },
};



