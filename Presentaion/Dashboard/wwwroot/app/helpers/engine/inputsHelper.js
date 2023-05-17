var inputsHelper = {
    /*********
     * handle Onchange Api Action
     * the action that call api 
     * ******* */
    handleOnchangeApiAction: function (event, element) {
        let val = $(element).val();
        let url = $(element).attr("data-onchange-api-url");
        let get = $.ajax({
            url: url,
            type: 'GET',
            cache: false,
            contentType: false,
            processData: false
        });

        get.done(function (data, status, xhr) {
            if (xhr.responseJSON != null) {
                var genericResult = xhr.responseJSON;
                if (genericResult.Status == true) {
                    alert(genericResult.Message);
                    $(element).removeClass('is-invalid');
                }
                else {
                    alert(genericResult.Message);
                    $(element).addClass('is-invalid');

                }
            }
            else {
            }
        });
        get.fail(function (xhr, status, error) {
            alert(xhr.responseText);
        })
        get.always(function () {
            // vm.hideSmallLoading($targetModels);
        });
    },
    /*********
     * handle max length 
     * ******* */
    handleMaxLength: function () {

        $('input[type=number][max]:not([max=""])').on('input', function (ev) {
            var $this = $(this);
            var maxlength = $this.attr('max').length;
            var value = $this.val();
            if (value && value.length >= maxlength) {
                $this.val(value.substr(0, maxlength));
            }
        });
    }


};










