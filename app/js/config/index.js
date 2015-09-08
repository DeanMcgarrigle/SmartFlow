export default ngModule => {
    require("./config")(ngModule);
    require("./routes")(ngModule);
    require("./constants")(ngModule);
};