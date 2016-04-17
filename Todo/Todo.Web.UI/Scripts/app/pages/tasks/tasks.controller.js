(function (angular) {

    angular
        .module("tasksModule")
        .controller("TasksController", TasksController);

    TasksController.$inject = ['$scope', "tasksService" ];

    function TasksController($scope, tasksService) {
        var vm = this;
        vm.tasks = [];
        vm.newTaskTitle = "";
        vm.onAddNewTask = onAddNewTask;
        vm.onDoneChanged = onDoneChanged;
        vm.isNewTaskTitleValid = isNewTaskTitleValid;

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

        function onAddNewTask() {
            console.log("[TasksController] onAddNewTask - ", arguments);
            var newTask = { Id: 0, Title: vm.newTaskTitle, Done: false };
            tasksService
                .addTask(newTask)
                .then(function (response) {
                    console.log("[TasksController] onAddNewTask - success", arguments);
                    vm.tasks.push(response.data);
                    vm.newTaskTitle = "";
                }, function (response) {
                    console.log("[TasksController] onAddNewTask - fail", arguments);
                    alert("Adding a new task has failed.");
                });
        }

        function onDoneChanged(task) {
            console.log("[TasksController] onDoneChanged - ", arguments);
            tasksService
                .updateTask(task)
                .then(function (response) {
                    console.log("[TasksController] - success", arguments);
                }, function () {
                    console.log("[TasksController] - fail", arguments);
                });
        }

        function isNewTaskTitleValid() {
            return (angular.isString(vm.newTaskTitle) && vm.newTaskTitle.length >= 1 && vm.newTaskTitle.length <= 50);
        }

    }

})(angular);