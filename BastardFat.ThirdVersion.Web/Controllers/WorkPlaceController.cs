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
    public class WorkPlaceController : ApiController
    {

        private readonly IWorkPlaceService _service;

        public WorkPlaceController(IWorkPlaceService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<WorkPlaceModel>> Get()
        {
            return await _service.GetAllWorkPlaces();
        }

        [HttpPost]
        public async Task<WorkPlaceModel> Post([FromBody] WorkPlaceModel model)
        {
            return await _service.AddWorkPlace(model);
        }

        [HttpPut]
        public async Task<WorkPlaceModel> Put([FromBody] WorkPlaceModel model)
        {
            return await _service.UpdateWorkPlace(model);
        }

        [HttpDelete]
        public async Task<WorkPlaceModel> Delete(int id)
        {
            return await _service.DeleteWorkPlace(id);
        }
    }
}
