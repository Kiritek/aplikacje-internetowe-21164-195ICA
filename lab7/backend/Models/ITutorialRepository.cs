using System.Collections.Generic;

namespace CRUD_API2.Models
{
    public interface ITutorialRepository
    {
        IEnumerable<Tutorial> GetAll();
        IEnumerable<Tutorial> GetSearch(string keyWord);
        Tutorial GetTutorialById(int id);
        void AddTutorial(Tutorial tutorial);
        void EditTutorial(Tutorial tutorial);
        void DeleteTutorial(Tutorial tutorial);
        void DeleteAllTutorials(IEnumerable<Tutorial> tutorials);
        bool TutorialExist(int id);
        bool Save();
    }
}
