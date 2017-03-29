using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BastardFat.AgileBoard.Site.Database
{
    public class AgileBoardDBController
    {
        public AgileBoardDBController(AgileBoardDBContext database)
        {
            Database = database;
        }
        public AgileBoardDBContext Database { get; }
    }
}
