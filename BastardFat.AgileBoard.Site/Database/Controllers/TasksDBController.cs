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

        

    }
}