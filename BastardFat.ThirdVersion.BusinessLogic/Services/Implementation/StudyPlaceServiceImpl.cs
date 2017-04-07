using System.Collections.Generic;
using System.Data.Entity;
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
        private readonly IMainUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudyPlaceServiceImpl(IStudyPlacesRepository studyPlacesRepository, IMainUnitOfWork unitOfWork)
        {
            _studyPlacesRepository = studyPlacesRepository;
            _unitOfWork = unitOfWork;

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
            var result = _mapper.Map<StudyPlaceModel>(
                _studyPlacesRepository.Add(
                    _mapper.Map<StudyPlace>(people)
                )
            );
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<StudyPlaceModel> UpdateStudyPlace(StudyPlaceModel people)
        {
            if(people.Id == 1) throw new HttpException(406, "Not Acceptable");
            var result = _mapper.Map<StudyPlaceModel>(
                _studyPlacesRepository.Update(
                    _mapper.Map<StudyPlace>(people)
                )
            );
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<StudyPlaceModel> DeleteStudyPlace(int id)
        {
            if (id == 1) throw new HttpException(406, "Not Acceptable");
            var result = _mapper.Map<StudyPlaceModel>(
                await _studyPlacesRepository.DeleteAsync(id)
            );
            await _unitOfWork.CommitAsync();
            return result;
        }
    }
}