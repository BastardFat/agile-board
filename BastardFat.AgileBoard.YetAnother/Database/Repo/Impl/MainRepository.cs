using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BastardFat.AgileBoard.YetAnother.Database.Tables;
using BastardFat.AgileBoard.YetAnother.Database;

namespace BastardFat.AgileBoard.YetAnother.Database.Repo.Impl
{
    public class MainRepository : IRepository, IDisposable
    {
        private readonly MainDBContext _db;

        public MainRepository(MainDBContext db)
        {
            _db = db;

        }

        public People AddPeople(string firstname, string lastname, int studyPlaceId, int workPlaceId) =>
            _db.Transaction(() =>
                _db.Peoples.Add(new People()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    StudyPlaceId = studyPlaceId,
                    WorkPlaceId = workPlaceId
                })
            );

        public StudyPlace AddStudyPlace(string title, string description) =>
            _db.Transaction(() =>
                _db.StudyPlaces.Add(new StudyPlace()
                {
                    Title = title,
                    Description = description
                })
            );

        public WorkPlace AddWorkPlace(string title, string description) =>
            _db.Transaction(() =>
                _db.WorkPlaces.Add(new WorkPlace()
                {
                    Title = title,
                    Description = description
                })
            );

        public bool DeletePeople(int id) =>
            _db.TryTransaction(() =>
                _db.Peoples.Remove(_db.Peoples.Find(id))
            );

        public bool DeleteStudyPlace(int id) =>
            _db.TryTransaction(() =>
                _db.StudyPlaces.Remove(_db.StudyPlaces.Find(id))
            );

        public bool DeleteWorkPlace(int id) =>
            _db.TryTransaction(() =>
                _db.WorkPlaces.Remove(_db.WorkPlaces.Find(id))
            );


        public IQueryable<People> GetPeoples() => _db.Peoples;
        public IQueryable<StudyPlace> GetStudyPlaces() => _db.StudyPlaces;
        public IQueryable<WorkPlace> GetWorkPlaces() => _db.WorkPlaces;


        public People UpdatePeople(People entity) =>
            _db.Transaction(() =>
            {
                var found = _db.Peoples.SingleOrDefault(x => x.Id == entity.Id);
                if (found == null) return null;
                found.FirstName = entity.FirstName;
                found.LastName = entity.LastName;
                found.StudyPlaceId = entity.StudyPlaceId;
                found.WorkPlaceId = entity.WorkPlaceId;
                return found;
            });



        public StudyPlace UpdateStudyPlace(StudyPlace entity) =>
            _db.Transaction(() =>
            {
                var found = _db.StudyPlaces.SingleOrDefault(x => x.Id == entity.Id);
                if (found == null) return null;
                found.Title = entity.Title;
                found.Description = entity.Description;
                return found;
            });



        public WorkPlace UpdateWorkPlace(WorkPlace entity) =>
            _db.Transaction(() =>
            {
                var found = _db.WorkPlaces.SingleOrDefault(x => x.Id == entity.Id);
                if (found == null) return null;
                found.Title = entity.Title;
                found.Description = entity.Description;
                return found;
            });



        #region IDisposable Support
        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                _db.Dispose();
            }

            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}