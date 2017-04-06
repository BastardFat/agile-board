using System.Collections.Generic;

namespace BastardFat.ThirdVersion.Models.Database
{
    public class WorkPlace : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<People> Peoples { get; set; }
    }
}