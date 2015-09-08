const _ = require("lodash");

window._ = _;

require("angular");
require("angular-ui-router");
require("angular-loading-bar");

const ngModule = angular.module("app", ["angular-loading-bar", "ui.router"]);

require("./config")(ngModule);
require("./directives")(ngModule);
require("./controllers")(ngModule);
require("./services")(ngModule);
require("./common")(ngModule);