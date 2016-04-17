(function (angular) {

    angular
        .module("tasksModule")
        .factory("tasksService", tasksService);

    tasksService.$inject = [ "$http" ];

    function tasksService($http) {

        var service = {
            getTasks: getTasksAjax,
            addTask: addTask,
            updateTask: updateTask
        };

        return service;

        function getTasksAjax() {
            var promise = $http.get("/Task/GetTasks");
            return promise;
        }

        function getTasks() {
            if (localStorage.tasks) {
                return JSON.parse(localStorage.tasks);
            } else {
                return [];
            }
        }

        function addTask(task) {
            var promise = $http.post("/Task/AddTask", task);
            return promise;
        }

        function updateTask(task) {
            var promise = $http.post("/Task/UpdateTask", task);
            return promise;
        }

    }

})(angular);