export default ngModule => {
    ngModule.config(function ($stateProvider, $urlRouterProvider, routes) {

        $urlRouterProvider.otherwise("/");

        routes.forEach(function (route) {
            $stateProvider.state(route.name, route.config);
        });
    });
};