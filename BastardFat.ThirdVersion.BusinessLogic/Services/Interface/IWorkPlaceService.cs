using System.Collections.Generic;
using System.Threading.Tasks;
using BastardFat.ThirdVersion.Models.Records;

namespace BastardFat.ThirdVersion.BusinessLogic.Services.Interface
{
    public interface IWorkPlaceService
    {
        Task<IEnumerable<WorkPlaceModel>> GetAllWorkPlaces();

        Task<WorkPlaceModel> AddWorkPlace(WorkPlaceModel people);
        Task<WorkPlaceModel> UpdateWorkPlace(WorkPlaceModel people);
        Task<WorkPlaceModel> DeleteWorkPlace(int id);
    }
}