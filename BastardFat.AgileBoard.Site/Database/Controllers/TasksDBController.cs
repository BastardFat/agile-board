using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BastardFat.AgileBoard.Site.Database.Tables;

namespace BastardFat.AgileBoard.Site.Database.Controllers
{
    public class TasksDBController : AgileBoardDBController
    {
        public TasksDBController(AgileBoardDBContext database) : base(database) { }

        public IQueryable<Task> GetAll() => Database.Tasks;

        public bool Add(Task task)
        {
            task.AddingDate = DateTime.Now;
            task.LastModified = DateTime.Now;
            try
            {
                return Database.TryTransaction(() =>
                    Database.Tasks.Add(task)
                );
            }
            catch
            {
                return false;
            }
        }

        public bool IncrementStage(int TaskId)
        {
            try
            {
                if (Database.Tasks.FirstOrDefault(t => t.Id == TaskId).Stage > 2) return false;
                return Database.TryTransaction(() =>
                {
                    Database.Tasks.FirstOrDefault(t => t.Id == TaskId).Stage++;
                    Database.Tasks.FirstOrDefault(t => t.Id == TaskId).LastModified = DateTime.Now;
                });
            }
            catch
            {
                return false;
            }
        }
        public bool DecrementStage(int TaskId)
        {
            try
            {
                if (Database.Tasks.FirstOrDefault(t => t.Id == TaskId).Stage < 1) return false;
                return Database.TryTransaction(() =>
                {
                    Database.Tasks.FirstOrDefault(t => t.Id == TaskId).Stage--;
                    Database.Tasks.FirstOrDefault(t => t.Id == TaskId).LastModified = DateTime.Now;
                });
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(int TaskId)
        {
            try
            {
                return Database.TryTransaction(() =>
                    Database.Tasks.Remove(Database.Tasks.FirstOrDefault(t => t.Id == TaskId))
                );
            }
            catch
            {
                return false;
            }
        }


    }
}