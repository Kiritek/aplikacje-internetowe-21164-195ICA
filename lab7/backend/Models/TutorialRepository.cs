using System.Collections.Generic;
using System.Linq;

namespace CRUD_API2.Models
{
    public class TutorialRepository : ITutorialRepository
    {
        private readonly AppDbContext _context;
        public TutorialRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IEnumerable<Tutorial> GetAll() => _context.Tutorials.ToList();

        public IEnumerable<Tutorial> GetSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return _context.Tutorials.ToList<Tutorial>();
            }
            var collection = _context.Tutorials as IQueryable<Tutorial>;
            keyword = keyword.Trim();
            collection = collection.Where(t=> t.Title.Contains(keyword));
            return collection.ToList();
        }

        public void AddTutorial(Tutorial tutorial)
        {
            _context.Tutorials.Add(tutorial);
        }

        public void DeleteAllTutorials(IEnumerable<Tutorial> tutorials)
        {
            foreach (var tutorial in tutorials)
            {
                _context.Tutorials.Remove(tutorial);
                _context.SaveChanges();
            }
   
        }

        public void DeleteTutorial(Tutorial tutorial)
        {
            _context.Tutorials.Remove(tutorial);
        }

        public void EditTutorial(Tutorial tutorial)
        {

        }

        public Tutorial GetTutorialById(int id) => _context.Tutorials.FirstOrDefault(t => t.Id == id);

        public void RemoveTutorial(int id)
        {
            var tutorial = _context.Tutorials.Find(id);
            _context.Tutorials.Remove(tutorial);
            _context.SaveChanges();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool TutorialExist(int id)
        {
            return _context.Tutorials.Any(t => t.Id == id);

        }
    }
}
