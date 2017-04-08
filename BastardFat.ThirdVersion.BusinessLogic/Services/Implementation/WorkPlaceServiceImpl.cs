using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BastardFat.ThirdVersion.BusinessLogic.Services.Interface;
using BastardFat.ThirdVersion.DatabaseInteraction.Repository.Interface;
using BastardFat.ThirdVersion.DatabaseInteraction.UnitOfWork.Interface;
using BastardFat.ThirdVersion.Models.Database;
using BastardFat.ThirdVersion.Models.Records;

namespace BastardFat.ThirdVersion.BusinessLogic.Services.Implementation
{
    public class WorkPlaceServiceImpl : IWorkPlaceService
    {
        private readonly IWorkPlacesRepository _workPlacesRepository;
        private readonly IPeoplesRepository _peoplesRepository;
        private readonly IMainUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkPlaceServiceImpl(IWorkPlacesRepository workPlacesRepository, IMainUnitOfWork unitOfWork, IPeoplesRepository peoplesRepository)
        {
            _workPlacesRepository = workPlacesRepository;
            _unitOfWork = unitOfWork;
            _peoplesRepository = peoplesRepository;

            _mapper = new MapperConfiguration(x =>
            {
                x.CreateMap<WorkPlace, WorkPlaceModel>()
                    .ReverseMap();
                x.CreateMap<People, PeopleModel>()
                    .ReverseMap();
            }).CreateMapper();
        }

        public async Task<IEnumerable<WorkPlaceModel>> GetAllWorkPlaces()
        {
            return await _workPlacesRepository
                .Query()
                .ProjectTo<WorkPlaceModel>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task<WorkPlaceModel> AddWorkPlace(WorkPlaceModel people)
        {
            var result = _workPlacesRepository.Add(
                _mapper.Map<WorkPlace>(people)
            );
            await _unitOfWork.CommitAsync();
            return _mapper.Map<WorkPlaceModel>(result);
        }

        public async Task<WorkPlaceModel> UpdateWorkPlace(WorkPlaceModel people)
        {
            if (people.Id == 1) throw new HttpException(406, "Not Acceptable");
            var result = _workPlacesRepository.Update(
                _mapper.Map<WorkPlace>(people)
            );
            await _unitOfWork.CommitAsync();
            return _mapper.Map<WorkPlaceModel>(result);
        }

        public async Task<WorkPlaceModel> DeleteWorkPlace(int id)
        {
            if (id == 1) throw new HttpException(406, "Not Acceptable");

            await _peoplesRepository
                .Query()
                .Where(p => p.WorkPlaceId == id)
                .ForEachAsync(p => p.WorkPlaceId = 1);

            var result = await _workPlacesRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<WorkPlaceModel>(result);
        }
    }
}