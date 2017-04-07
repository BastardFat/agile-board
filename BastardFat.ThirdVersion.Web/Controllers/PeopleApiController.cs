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
    public class PeopleApiController : ApiController
    {
        private readonly IPeopleService _service;

        public PeopleApiController(IPeopleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<PeopleModel>> Get()
        {
            return await _service.GetAllPeoples();
        }

        [HttpPost]
        public async Task<PeopleModel> Post([FromBody] PeopleModel model)
        {
            return await _service.AddPeople(model);
        }

        [HttpPut]
        public async Task<PeopleModel> Put([FromBody] PeopleModel model)
        {
            return await _service.UpdatePeople(model);
        }

        [HttpDelete]
        public async Task<PeopleModel> Delete(int id)
        {
            return await _service.DeletePeople(id);
        }
    }
}