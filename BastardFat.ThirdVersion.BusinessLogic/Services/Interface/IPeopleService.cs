using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BastardFat.ThirdVersion.Models.Database;
using BastardFat.ThirdVersion.Models.Records;

namespace BastardFat.ThirdVersion.BusinessLogic.Services.Interface
{
    public interface IPeopleService
    {
        Task<IEnumerable<PeopleModel>> GetAllPeoples();
        Task<IEnumerable<PeopleModel>> GetPeoplesByStudyPlace(int placeid);
        Task<IEnumerable<PeopleModel>> GetPeoplesByWorkPlace(int placeid);

        Task<PeopleModel> AddPeople(PeopleModel people);
        Task<PeopleModel> UpdatePeople(PeopleModel people);
        Task<PeopleModel> DeletePeople(int id);
    }
}
