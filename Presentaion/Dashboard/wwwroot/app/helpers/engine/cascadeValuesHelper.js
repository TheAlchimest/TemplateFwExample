String.prototype.format = function (o) {
    return this.replace(/{([^{}]*)}/g,
        function (a, b) {
            var r = o[b];
            return typeof r === 'string' ? r : a;
        }
    );
};

/******************************
 * handle cascade values
 ******************************/
var cascadeValuesHelper = {
    //
    run: function () {
        let helper = cascadeValuesHelper;
        //first collect cascade values parents 
        let cascadeParents = helper.collectCascadeParents();
        //second  bind onParentValueChange on parents
        helper.bindOnParentChangeEvent(cascadeParents);
        //fire onParentValueChange for all parents except any one will get data from api
        helper.fireOnChangeForParents(cascadeParents);
    },
    //
    collectCascadeParents: function () {
        let cascadeParents = [];
        $("[data-cascade-with]").each(function () {
            let $parentElementId = $(this).attr('data-cascade-with');
            let $parentElement = $('#' + $parentElementId);
            $parentElement.attr('data-parent-cascade', 'true');
            //add to cascade values parents
            cascadeParents.push($parentElement);
        });
        return cascadeParents;
    },
    //
    bindOnParentChangeEvent: function (parents) {
        let helper = cascadeValuesHelper;
        parents.forEach(function ($parent) {
            $parent.change(function () {
                helper.onParentValueChange($parent);
            });
        });
    },
    //
    onParentValueChange: function ($parentElement) {
        let helper = cascadeValuesHelper;

        let parentVal = $parentElement.val();
        let parentId = $parentElement.attr('id');
        $("[data-cascade-with='" + parentId + "']").each(function () {
            helper.loadCascadeChildrenDataFromApi($(this), $parentElement, parentId, parentVal);
        });
    },
    //

    fireOnChangeForParents: function (parents) {
        let helper = cascadeValuesHelper;

        parents.forEach(function ($parent) {
            let apiUrl = $parent.attr("data-api-url");
            if (typeof apiUrl === 'undefined') {
                helper.onParentValueChange($parent);

            }
        });
    },



    fireOnParentCascadeChange: function ($element) {
        
        let helper = cascadeValuesHelper;
        if ($element.attr('data-parent-cascade') == 'true') {
            helper.onParentValueChange($element);
        }
    },
    // load cascade child data from api 
    loadCascadeChildrenDataFromApi: function($element, $parentCascadeElement, parentId, parentVal) {
        apiUrl = $($element).attr('data-cascade-api-url');
        if (typeof parentVal !== 'undefined' && parentVal!=null) {
            apiUrl = apiUrl+parentVal ;
        }
        app.lookup.loadSelectDataFromApi($element, apiUrl, $parentCascadeElement)
    }
};
