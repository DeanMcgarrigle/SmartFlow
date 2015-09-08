export default ngModule => {

    var routes = [];

    routes.push({
        name: "dashboard",
        config: {url: "/", template: require("../templates/dashboard.html"), icon: "th-large"}
    });
    routes.push({
        name: "config",
        config: {url: "/config", template: require("../templates/config.html"), icon: "cog"}
    });
    routes.push({
        name: "snapshot",
        config: {url: "/snapshot", template: require("../templates/snapshot.html"), icon: "facetime-video"}
    });

    ngModule.constant("routes", routes);
};