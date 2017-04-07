using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
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
        private readonly IMainUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkPlaceServiceImpl(IWorkPlacesRepository workPlacesRepository, IMainUnitOfWork unitOfWork)
        {
            _workPlacesRepository = workPlacesRepository;
            _unitOfWork = unitOfWork;

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
            var result = _mapper.Map<WorkPlaceModel>(
                _workPlacesRepository.Add(
                    _mapper.Map<WorkPlace>(people)
                )
            );
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<WorkPlaceModel> UpdateWorkPlace(WorkPlaceModel people)
        {
            var result = _mapper.Map<WorkPlaceModel>(
                _workPlacesRepository.Update(
                    _mapper.Map<WorkPlace>(people)
                )
            );
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<WorkPlaceModel> DeleteWorkPlace(int id)
        {
            var result = _mapper.Map<WorkPlaceModel>(
                await _workPlacesRepository.DeleteAsync(id)
            );
            await _unitOfWork.CommitAsync();
            return result;
        }
    }

}