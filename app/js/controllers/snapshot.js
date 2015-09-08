export default ngModule => {

    ngModule.controller("snapshot", function (smartflowService) {
        const vm = this;
        vm.data = {};

        activate();

        function activate(ignoreLoadingBar) {
            return smartflowService.snapshotData(ignoreLoadingBar).then(function (data) {
                vm.data = data;
                return data;
            });
        }
    });
};