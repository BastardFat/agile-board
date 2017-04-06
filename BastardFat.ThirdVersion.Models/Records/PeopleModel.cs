namespace BastardFat.ThirdVersion.Models.Records
{
    public class PeopleModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int StudyPlaceId { get; set; }
        public StudyPlaceModel StudyPlaceModel { get; set; }
        public int WorkPlaceId { get; set; }
        public WorkPlaceModel WorkPlaceModel { get; set; }
    }
}