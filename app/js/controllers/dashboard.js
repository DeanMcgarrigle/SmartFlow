export default ngModule => {

    ngModule.controller("dashboard", function ($interval, dashboardService) {
        const vm = this;
        vm.data = {
            totalClients: 0,
            dwellTime: "00:00:00",
            activeFloors: 0,
            floors: []
        };

        activate();

        $interval(function() {
            activate(true);
        }, 60000);

        function activate(ignoreLoadingBar) {
            return dashboardService.getData(ignoreLoadingBar).then(function (data) {
                vm.data = data;
                return data;
            });
        }
    });
};