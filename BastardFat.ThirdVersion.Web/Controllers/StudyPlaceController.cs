using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BastardFat.ThirdVersion.BusinessLogic.Services.Interface;
using BastardFat.ThirdVersion.Models.Records;

namespace BastardFat.ThirdVersion.Web.Controllers
{
    public class StudyPlaceController : ApiController
    {

        private readonly IStudyPlaceService _service;

        public StudyPlaceController(IStudyPlaceService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<StudyPlaceModel>> Get()
        {
            return await _service.GetAllStudyPlaces();
        }

        [HttpPost]
        public async Task<StudyPlaceModel> Post([FromBody] StudyPlaceModel model)
        {
            return await _service.AddStudyPlace(model);
        }

        [HttpPut]
        public async Task<StudyPlaceModel> Put([FromBody] StudyPlaceModel model)
        {
            return await _service.UpdateStudyPlace(model);
        }

        [HttpDelete]
        public async Task<StudyPlaceModel> Delete([FromBody] int id)
        {
            return await _service.DeleteStudyPlace(id);
        }
    }
}
