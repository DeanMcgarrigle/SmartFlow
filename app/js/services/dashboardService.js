export default ngModule => {

    ngModule.factory("dashboardService", function ($http) {
        return {
            getData: getData
        };

        function getData(ignoreLoadingBar) {
            return $http.get("/smartflow/dashboard", {ignoreLoadingBar: ignoreLoadingBar}).then(function (data) {
                return data.data;
            });
        }
    });
};