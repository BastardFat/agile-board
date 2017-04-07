using System.Collections.Generic;
using System.Threading.Tasks;
using BastardFat.ThirdVersion.Models.Records;

namespace BastardFat.ThirdVersion.BusinessLogic.Services.Interface
{
    public interface IStudyPlaceService
    {
        Task<IEnumerable<StudyPlaceModel>> GetAllStudyPlaces();

        Task<StudyPlaceModel> AddStudyPlace(StudyPlaceModel people);
        Task<StudyPlaceModel> UpdateStudyPlace(StudyPlaceModel people);
        Task<StudyPlaceModel> DeleteStudyPlace(int id);
    }
}