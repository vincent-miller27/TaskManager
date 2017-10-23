(function () {
    "use strict";

    angular.module("app-tasks", ["ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                templateUrl: "/Scripts/views/tasksView.html",
                controller: "tasksController",
                controllerAs: "vm"
            });

            $routeProvider.otherwise({ redirectTo: "/" });

        });
})();