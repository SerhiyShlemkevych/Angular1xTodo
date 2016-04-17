using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace Todo.Web.UI.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }

        public static explicit operator TaskEntity (TaskModel taskModel)
        {
            TaskEntity taskEntity = new TaskEntity()
            {
                Id = taskModel.Id,
                Title = taskModel.Title,
                Done = taskModel.Done
            };
            return taskEntity;
        }

        public static explicit operator TaskModel(TaskEntity taskEntity)
        {
            TaskModel taskModel = new TaskModel()
            {
                Id = taskEntity.Id,
                Title = taskEntity.Title,
                Done = taskEntity.Done
            };
            return taskModel;
        }
    }
}
