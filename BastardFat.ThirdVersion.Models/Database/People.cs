namespace BastardFat.ThirdVersion.Models.Database
{
    public class People : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Description { get; set; }

        public int StudyPlaceId { get; set; }
        public virtual StudyPlace StudyPlace { get; set; }

        public int WorkPlaceId { get; set; }
        public virtual WorkPlace WorkPlace { get; set; }
    }
}