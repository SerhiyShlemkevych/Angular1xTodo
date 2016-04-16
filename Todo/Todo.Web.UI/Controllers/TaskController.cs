using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Web.UI.Models;

namespace Todo.Web.UI.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTasks()
        {
            TaskModel[] tasks = new TaskModel[]
            {
                new TaskModel { Id = 1, Title = "Task #1" },
                new TaskModel { Id = 2, Title = "Task #2" },
                new TaskModel { Id = 3, Title = "Task #3" },
                new TaskModel { Id = 4, Title = "Task #4" },
            };
            return Json(tasks, JsonRequestBehavior.AllowGet);
        }
    }
}