using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BastardFat.AgileBoard.Site.Models
{
    public class AddTaskRequest
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }
}