
/******************************
 * handle cascade values
 ******************************/
var jsonHelper = {

    objectifyFormArray: function (formArray) {
        
        //serialize data function
        var propertiesArray = {};
        var name = '';
        var indexOfArrFirst = -2;
        var indexOfArrLast = -2;
        var childIndex = -2;
        var childPropertyName = '';
        for (var i = 0; i < formArray.length; i++) {
            name = formArray[i]['name'];
            indexOfArrFirst = name.indexOf('[');
            if (indexOfArrFirst < 0) {
                if ((typeof propertiesArray[name] === "undefined")) {
                    propertiesArray[name] = formArray[i]['value'];
                }
                else {
                    //objectify master detail form data
                    if (!Array.isArray(propertiesArray[name])) {
                        let oldValue = propertiesArray[name];
                        propertiesArray[name] = [];
                        propertiesArray[name].push(oldValue);
                    }
                    propertiesArray[name].push(formArray[i]['value']);
                }
            }
            else {//array
                var childItemName = name.split("[")[0];
                indexOfArrLast = name.indexOf(']');
                childIndex = name.substr(indexOfArrFirst + 1, ((indexOfArrLast - 1) - indexOfArrFirst));
                childPropertyName = name.split(".")[1];
                if ((typeof propertiesArray[childItemName] === "undefined")) {
                    propertiesArray[childItemName] = [];
                }
                while (propertiesArray[childItemName].length <= childIndex) {
                    propertiesArray[childItemName].push({});
                }
                propertiesArray[childItemName][childIndex][childPropertyName] = formArray[i]['value'];
            }
        }
        //remove null values
        $.each(propertiesArray, function (key, value) {
            if (value === "" || value === null) {
                delete propertiesArray[key];
            }
        });
        return propertiesArray;
    }

    ,bindJsonToForm: function (json,$form) {
        $.each(json, function (key, value) {
            $form.find("input[name='" + key + "']").val(value);
            $form.find("textarea[name='" + key + "']").val(value);
            $form.find("select[name='" + key + "']").val(value).attr('data-value', value);
 
        });
    },
    bindTestDataToForm: function ($form) {
        $.each($form.find('input,textarea,select'), function (element) {
            console.log($(this).attr('id'));
        });
    }
};
