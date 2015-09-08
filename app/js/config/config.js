export default ngModule => {
    ngModule.config(function(cfpLoadingBarProvider) {
        cfpLoadingBarProvider.includeSpinner = false;
    });
};