using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BastardFat.AgileBoard.YetAnother.Database.Tables
{
    public class People : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int StudyPlaceId { get; set; }
        public virtual StudyPlace StudyPlace { get; set; }

        public int WorkPlaceId { get; set; }
        public virtual WorkPlace WorkPlace { get; set; }

    }
}