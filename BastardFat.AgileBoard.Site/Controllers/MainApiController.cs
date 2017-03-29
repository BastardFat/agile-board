using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BastardFat.AgileBoard.Site.Controllers
{
    public class MainApiController : ApiController
    {
        [HttpGet]
        public bool MoveRight(int taskid)
        {
            Thread.Sleep(1000);
            using (var db = new Database.AgileBoardDBManager())
            {
                return db.TaskDBController.IncrementStage(taskid);
            }
        }

        [HttpGet]
        public bool MoveLeft(int taskid)
        {
            Thread.Sleep(1000);
            using (var db = new Database.AgileBoardDBManager())
            {
                return db.TaskDBController.DecrementStage(taskid);
            }
        }
    }
}
