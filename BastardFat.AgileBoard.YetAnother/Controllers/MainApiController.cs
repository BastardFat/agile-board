using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BastardFat.AgileBoard.YetAnother.Database.Repo;
using BastardFat.AgileBoard.YetAnother.Database.Tables;
using BastardFat.AgileBoard.YetAnother.Models;

namespace BastardFat.AgileBoard.YetAnother.Controllers
{
    public class MainApiController : ApiController
    {
        public MainApiController(IRepository repo)
        {
            _repo = repo;
        }

        private IRepository _repo;

        [HttpGet]
        public string Test() => _repo.GetStudyPlaces().FirstOrDefault()?.Title;

        [HttpGet]
        public IEnumerable<StudyPlace> GetStudyPlaces() => _repo.GetStudyPlaces().ToArray();

        [HttpGet]
        public IEnumerable<WorkPlace> GetWorkPlaces() => _repo.GetWorkPlaces().ToArray();

        [HttpGet]
        public IEnumerable<People> GetPeoples() => _repo.GetPeoples().ToArray();

        [HttpPost]
        public StudyPlace AddStudyPlace([FromBody] AddPlaceRequest request) => _repo.AddStudyPlace(request.title, request.description);

        [HttpPost]
        public WorkPlace AddWorkPlace([FromBody] AddPlaceRequest request) => _repo.AddWorkPlace(request.title, request.description);

        [HttpPost]
        public People AddPeople(AddPeopleRequest request) => _repo.AddPeople(request.firstname, request.lastname, request.studyPlaceId, request.workPlaceId);

        [HttpPost]
        public bool DeleteStudyPlace([FromBody] int id) => _repo.DeleteStudyPlace(id);

        [HttpPost]
        public bool DeleteWorkPlace([FromBody] int id) => _repo.DeleteWorkPlace(id);

        [HttpPost]
        public bool DeletePeople([FromBody] int id) => _repo.DeletePeople(id);

        [HttpPost]
        public StudyPlace UpdateStudyPlace([FromBody] StudyPlace entity) => _repo.UpdateStudyPlace(entity);

        [HttpPost]
        public WorkPlace UpdateWorkPlace([FromBody] WorkPlace entity) => _repo.UpdateWorkPlace(entity);

        [HttpPost]
        public People UpdatePeople([FromBody] People entity) => _repo.UpdatePeople(entity);

    }
}
