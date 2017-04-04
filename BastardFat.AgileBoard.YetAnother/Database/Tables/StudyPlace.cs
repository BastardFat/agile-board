using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BastardFat.AgileBoard.YetAnother.Database.Tables
{
    public class StudyPlace : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<People> Peoples { get; set; }

    }
}