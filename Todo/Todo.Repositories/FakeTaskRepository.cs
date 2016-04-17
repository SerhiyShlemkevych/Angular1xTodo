using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace Todo.Repositories
{
    public class FakeTaskRepository : ITaskRepository
    {
        #region Data

        private static readonly List<TaskEntity> tasks;
        private static int lastGeneratedId;

        static FakeTaskRepository() 
        {
            tasks = new List<TaskEntity>()
            {
                new TaskEntity { Id = 1, Title = "Task #1", Done = false },
                new TaskEntity { Id = 2, Title = "Task #2", Done = false },
                new TaskEntity { Id = 3, Title = "Task #3", Done = false },
                new TaskEntity { Id = 4, Title = "Task #4", Done = false },
            };
            lastGeneratedId = 4;
        }

        private int GenerateNextId()
        {
            lastGeneratedId += 1;
            return lastGeneratedId;
        }

        #endregion

        #region ITaskRepository

        public IEnumerable<TaskEntity> GetAll()
        {
            return tasks;
        }

        public TaskEntity Add(TaskEntity task)
        {
            task.Id = GenerateNextId();
            tasks.Add(task);
            return task;
        }

        public void Delete(int taskId)
        {
            throw new NotImplementedException();
        }

        public TaskEntity Update(TaskEntity task)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}