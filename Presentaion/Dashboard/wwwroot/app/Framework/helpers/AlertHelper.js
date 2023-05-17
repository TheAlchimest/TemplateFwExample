var alertHelper = {


    success: function (title, msg) {
        alertHelper.runWithMessageFixing(title, msg, "success");
    },
    warning: function (title, msg) {
        ;
        alertHelper.runWithMessageFixing(title, msg, "warning");
    },
    error: function (title, msg) {
        alertHelper.runWithMessageFixing(title, msg, "error");
    },
    runWithMessageFixing: function (title, msg, icon) {
        if (!title && msg) { title = msg; msg = ""; }
        if (!title) { title = ""; }
        if (!msg) { msg = ""; }
        swal.fire(title, msg, icon);
    },
    multiLine: function (title, msgArr, type) {
        let msg = ''
        msgArr.forEach(function (element, index) {
            msg += `<li>${element}</li>`;
        });
        msg = `<ul>${msg}</ul>`;
        swal.fire(title, msg, type)
    },
    showResponse: function (webResponse, status, xhr, onsuccess) {
        console.log("webResponse", webResponse);
        console.log("status", status);
        console.log("xhr", xhr);
        console.log(webResponse);
        if (webResponse) {
            if (webResponse.Status) {
                if (webResponse.Title || webResponse.Message) {
                    alertHelper.success(webResponse.Title, webResponse.Message);
                }
                // additions 
                if (typeof onsuccess !== "undefined" && onsuccess != null) {
                    onsuccess();
                }
            }
            else {
                let errorMessages = [];

                if (webResponse.Message) {
                    errorMessages.push(webResponse.Message);
                }
                if (webResponse.Errors != null && webResponse.Errors.length > 0) {
                    for (var i = 0; i < webResponse.Errors.length; i++) {
                        var error = webResponse.Errors[i];
                        if (error.PropertyName) {
                            $.smkAddError($("#" + error.PropertyName), error.ErrorMessage);
                        }
                        errorMessages.push(error.ErrorMessage);
                    }
                }
                if (errorMessages.length > 1) {
                    alertHelper.multiLine(webResponse.Title, errorMessages, "error");
                }
                else if (errorMessages.length == 1) {
                    alertHelper.error(webResponse.Title, errorMessages[0]);
                }
            }
        }
        else {
            alertHelper.error(status, "");

        }
    }
    ,
    showResponse2: function (webResponse, status, xhr, redirecturl) {
        console.log("webResponse", webResponse);
        console.log("status", status);
        console.log("xhr", xhr);
        console.log(webResponse);
        if (webResponse.Status) {
            if (webResponse.Message != null && webResponse.Message.length > 0) {
                swal.fire(webResponse.Message, "", "success").then((result) => {
                    /* Read more about isConfirmed, isDenied below */
                    if (result.isConfirmed) {
                        window.location = redirecturl;
                    }
                });
            }
            // additions 
            if (typeof onsuccess !== "undefined" && onsuccess != null) {
                onsuccess();
            }

        } else {
            if (webResponse.Messages != null && webResponse.Messages.length > 1) {
                alertHelper.multiLine("خطأ", webResponse.Messages, "error");
            }
            if (webResponse.Messages != null && webResponse.Messages.length > 0) {
                alertHelper.error(webResponse.Messages.join(), "");
            }
        }
    }
};

