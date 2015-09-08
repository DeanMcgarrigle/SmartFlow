export default ngModule => {
    require("./dashboardService")(ngModule);
    require("./smartflowService")(ngModule);
};