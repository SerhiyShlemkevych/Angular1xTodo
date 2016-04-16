(function (angular) {

    angular
        .module("tasksModule")
        .controller("TasksController", TasksController);

    TasksController.$inject = ['$scope', "tasksService" ];

    function TasksController($scope, tasksService) {
        var vm = this;
        vm.tasks = [];

        activate();

        function activate() {
            var tasksPromise = tasksService.getTasks();
            tasksPromise.then(function (response) {
                console.log("[TasksController] tasksPromise - ", response);
                $scope.$applyAsync(function () {
                    vm.tasks.push.apply(vm.tasks, response.data);
                });
            });
        }        

    }

})(angular);