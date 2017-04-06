using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
    public class PeopleServiceImpl : IPeopleService
    {
        private readonly IPeoplesRepository _peoplesRepository;
        private readonly IMainUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PeopleServiceImpl(IPeoplesRepository peoplesRepository, IMainUnitOfWork unitOfWork)
        {
            _peoplesRepository = peoplesRepository;
            _unitOfWork = unitOfWork;

            _mapper = new MapperConfiguration(x =>
            {
                x.CreateMap<People, PeopleModel>()
                    .ReverseMap();

            }).CreateMapper();

        }


        public async Task<IEnumerable<PeopleModel>> GetAllPeoples()
        {
            return await _peoplesRepository
                .Query()
                .ProjectTo<PeopleModel>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<PeopleModel>> GetPeoplesByStudyPlace(int placeid)
        {
            return await _peoplesRepository
                .Query()
                .Where(x => x.StudyPlaceId == placeid)
                .ProjectTo<PeopleModel>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<PeopleModel>> GetPeoplesByWorkPlace(int placeid)
        {
            return await _peoplesRepository
                .Query()
                .Where(x => x.WorkPlaceId == placeid)
                .ProjectTo<PeopleModel>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task<PeopleModel> AddPeople(PeopleModel people)
        {
            var result =  _mapper.Map<PeopleModel>(
                _peoplesRepository.Add(
                    _mapper.Map<People>(people)
                    )
                );
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<PeopleModel> UpdatePeople(PeopleModel people)
        {
            var result = _mapper.Map<PeopleModel>(
                _peoplesRepository.Update(
                    _mapper.Map<People>(people)
                )
            );
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<PeopleModel> DeletePeople(int id)
        {
            var result =  _mapper.Map<PeopleModel>(
                await _peoplesRepository.DeleteAsync(id)
            );
            await _unitOfWork.CommitAsync();
            return result;
        }
    }
}