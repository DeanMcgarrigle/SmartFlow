export default ngModule => {

    ngModule.directive('sidebar', function ($window, routes) {

        return {
            restrict: 'E',
            scope: true,
            template: require('./sidebar.html'),
            controller: function ($scope) {

                $scope.routes = routes;
                $scope.toggleSidebar = toggleSidebar;

                function toggleSidebar() {
                    $scope.isOpen = !$scope.isOpen;
                    $scope.$emit('is-open-toggled', $scope.isOpen);
                }
            },
            link: function ($scope, elem) {

                var mobileView = 992;

                angular.element($window).bind('resize', function() {
                    $scope.isOpen = $window.innerWidth >= mobileView;
                    $scope.$apply();
                    $scope.$emit('is-open-toggled', $scope.isOpen);
                });
            }
        };
    });
};
