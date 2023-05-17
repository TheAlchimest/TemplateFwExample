var app = {
    cVal: cascadeValuesHelper,
    cVisibl: cascadeVisibilityHelper,
    lookup: lookupHelper,
    inputs: inputsHelper,
    template: templateHelper,
    form: formHelper,
    navigation: navigationController,
    ui: uiController,
    lookupApiUrl: "",

    run: function () {
        app.lookupApiUrl = $("#WebLookupApiUrl").val();
        app.navigation.run();
        app.ui.run();
    },
    fireEngine: function () {
        app.cVal.run();
        app.cVisibl.run();
        app.lookup.run();
        app.inputs.handleMaxLength();
    }
    
}










