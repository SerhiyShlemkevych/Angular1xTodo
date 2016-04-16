(function (angular) {

    angular
        .module("tasksModule")
        .factory("tasksService", tasksService);

    tasksService.$inject = [ "$http" ];

    function tasksService($http) {

        var service = {
            getTasks: getTasksAjax
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

    }

})(angular);