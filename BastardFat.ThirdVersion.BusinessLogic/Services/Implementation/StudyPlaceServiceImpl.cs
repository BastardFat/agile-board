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
    public class StudyPlaceServiceImpl : IStudyPlaceService
    {
        private readonly IStudyPlacesRepository _studyPlacesRepository;
        private readonly IPeoplesRepository _peoplesRepository;
        private readonly IMainUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudyPlaceServiceImpl(IStudyPlacesRepository studyPlacesRepository, IMainUnitOfWork unitOfWork, IPeoplesRepository peoplesRepository)
        {
            _studyPlacesRepository = studyPlacesRepository;
            _unitOfWork = unitOfWork;
            _peoplesRepository = peoplesRepository;

            _mapper = new MapperConfiguration(x =>
            {
                x.CreateMap<StudyPlace, StudyPlaceModel>()
                    .ReverseMap();
                x.CreateMap<People, PeopleModel>()
                    .ReverseMap();
            }).CreateMapper();
        }

        public async Task<IEnumerable<StudyPlaceModel>> GetAllStudyPlaces()
        {
            return await _studyPlacesRepository
                .Query()
                .ProjectTo<StudyPlaceModel>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task<StudyPlaceModel> AddStudyPlace(StudyPlaceModel people)
        {
            var result = _studyPlacesRepository.Add(
                _mapper.Map<StudyPlace>(people)
            );
            await _unitOfWork.CommitAsync();
            return _mapper.Map<StudyPlaceModel>(result);
        }

        public async Task<StudyPlaceModel> UpdateStudyPlace(StudyPlaceModel people)
        {
            if (people.Id == 1) throw new HttpException(406, "Not Acceptable");
            var result = _studyPlacesRepository.Update(
                _mapper.Map<StudyPlace>(people)
            );
            await _unitOfWork.CommitAsync();
            return _mapper.Map<StudyPlaceModel>(result);
        }

        public async Task<StudyPlaceModel> DeleteStudyPlace(int id)
        {
            if (id == 1) throw new HttpException(406, "Not Acceptable");
            await _peoplesRepository
                .Query()
                .Where(p => p.StudyPlaceId == id)
                .ForEachAsync(p => p.StudyPlaceId = 1);

            var result = _studyPlacesRepository.Delete(id);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<StudyPlaceModel>(result);
        }
    }
}