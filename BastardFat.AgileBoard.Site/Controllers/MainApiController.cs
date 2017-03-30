using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using BastardFat.AgileBoard.Site.Models;

namespace BastardFat.AgileBoard.Site.Controllers
{
    public class MainApiController : ApiController
    {
        [HttpGet]
        public bool MoveRight(int taskid)
        {
            using (var db = new Database.AgileBoardDBManager())
            {
                return db.TaskDBController.IncrementStage(taskid);
            }
        }

        [HttpGet]
        public bool MoveLeft(int taskid)
        {
            using (var db = new Database.AgileBoardDBManager())
            {
                return db.TaskDBController.DecrementStage(taskid);
            }
        }

        [HttpGet]
        public bool RemoveTask(int taskid)
        {
            using (var db = new Database.AgileBoardDBManager())
            {
                return db.TaskDBController.Remove(taskid);
            }
        }

        
        [HttpGet]
        public bool RemoveUser(int id)
        {
            using (var db = new Database.AgileBoardDBManager())
            {
                var usr = db.UserDBController.GetById(id);
                if (usr == null) return false;
                return db.UserDBController.Delete(usr.Name);
            }
        }

        [HttpPost]
        public bool AddTask([FromBody] AddTaskRequest task)
        {
            
            using (var db = new Database.AgileBoardDBManager())
            {
                return db.TaskDBController.Add(new Database.Tables.Task()
                {
                    Title = task.Title,
                    Markdown = System.Web.HttpUtility.HtmlEncode(task.Body),
                    HasImage = false,
                    Stage = 0,
                    UserId = Accounts.AccountManager.CurrentUser.Id,
                    ImageUrl = null
                });
            }
        }
    }
}
