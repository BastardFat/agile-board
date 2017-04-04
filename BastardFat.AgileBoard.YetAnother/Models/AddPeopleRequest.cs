using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BastardFat.AgileBoard.YetAnother.Models
{
    public class AddPeopleRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int studyPlaceId { get; set; }
        public int workPlaceId { get; set; }
    }
}