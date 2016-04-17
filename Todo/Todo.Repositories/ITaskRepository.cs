using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace Todo.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskEntity> GetAll();
        TaskEntity Add(TaskEntity task);
        TaskEntity Update(TaskEntity task);
        void Delete(int taskId);
    }
}
