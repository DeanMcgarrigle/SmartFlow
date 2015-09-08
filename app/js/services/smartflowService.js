export default ngModule => {

    ngModule.factory("smartflowService", function ($http) {
        return {
            snapshotData: snapshotData
        };

        function snapshotData(ignoreLoadingBar) {
            return $http.get("/smartflow/snapshot", {ignoreLoadingBar: ignoreLoadingBar}).then(function (data) {
                return data.data;
            });
        }
    });
};