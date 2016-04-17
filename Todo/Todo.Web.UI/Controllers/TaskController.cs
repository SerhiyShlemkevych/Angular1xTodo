using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Entities;
using Todo.Repositories;
using Todo.Web.UI.Models;

namespace Todo.Web.UI.Controllers
{
    public class TaskController : Controller
    {
        #region Fields

        private readonly ITaskRepository _taskRepository;

        #endregion

        #region Constructors

        public TaskController()
        {
            _taskRepository = new FakeTaskRepository();
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTasks()
        {
            var tasks = _taskRepository.GetAll();
            return Json(tasks, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddTask(TaskModel task)
        {
            TaskEntity taskEntity = (TaskEntity)task; // explicit type conversion operator defined within the TaskModel class
            TaskEntity addedTaskEntity = _taskRepository.Add(taskEntity);            
            return Json(addedTaskEntity);
        }

        [HttpPost]
        public ActionResult UpdateTask(TaskModel task)
        {
            TaskEntity taskEntity = (TaskEntity)task; // explicit type conversion operator defined within the TaskModel class
            TaskEntity updatedTaskEntity = _taskRepository.Update(taskEntity);
            return Json(updatedTaskEntity);
        }

        #endregion

        #region Helpers

        #endregion

    }
}