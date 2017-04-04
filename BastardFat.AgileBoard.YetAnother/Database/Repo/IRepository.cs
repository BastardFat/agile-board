using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BastardFat.AgileBoard.YetAnother.Database.Tables;

namespace BastardFat.AgileBoard.YetAnother.Database.Repo
{
    public interface IRepository
    {
        IQueryable<StudyPlace> GetStudyPlaces();

        IQueryable<WorkPlace> GetWorkPlaces();

        IQueryable<People> GetPeoples();


        StudyPlace AddStudyPlace(string title, string description);

        WorkPlace AddWorkPlace(string title, string description);

        People AddPeople(string firstname, string lastname, int studyPlaceId, int workPlaceId);



        bool DeleteStudyPlace(int id);

        bool DeleteWorkPlace(int id);

        bool DeletePeople(int id);


        StudyPlace UpdateStudyPlace(StudyPlace entity);

        WorkPlace UpdateWorkPlace(WorkPlace entity);

        People UpdatePeople(People entity);

    }
}
