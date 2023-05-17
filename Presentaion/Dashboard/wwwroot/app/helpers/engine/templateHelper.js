var templateHelper = {
    returnRadio: function (name, id, val, text, checked) {
        return `<div class="col-auto">
                    <div class="custom-control custom-radio mx-sm-2 my-2">
                        <input type="radio" class="custom-control-input"
                            value="${val}"
                            name="${name}"
                            id="${id}"
                            ${checked}>
                    <label class="custom-control-label font-weight-bold" for="${id}">${text}</label>
                    </div>
                </div>`;

    },
returnCheckbox: function (name, id, val, text, checked) {
        return `<div class="col-auto">
                    <div class="custom-control custom-checkbox mx-sm-2 my-2">
                        <input type="checkbox" class="custom-control-input"
                            value="${val}"
                            name="${name}"
                            id="${id}"
                            ${checked}>
                    <label class="custom-control-label font-weight-bold" for="${id}">${text}</label>
                    </div>
                </div>`;
    }

};
