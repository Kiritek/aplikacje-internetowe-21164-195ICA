using RestApiAppv2.Data;
using RestApiAppv2.Entities;
using System.Collections.Generic;

namespace RestApiAppv2.Models
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void AddPost(Post post)=> _context.Posts.Add(post);


        public void DeleteAllPosts(IEnumerable<Post> posts)
        {
            foreach (var post in posts)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }

        public void DeletePost(Post post) => _context.Posts.Remove(post);

        public void EditPost(Post post)
        {
        }

        public IEnumerable<Post> GetAll() => _context.Posts.ToList();

        public Post GetPostById(int id) => _context.Posts.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Post> GetSearch(string keyWord)
        {
            if (string.IsNullOrWhiteSpace(keyWord))
            {
                return _context.Posts.ToList<Post>();
            }
            var collection = _context.Posts as IQueryable<Post>;
            keyWord = keyWord.Trim();
            collection = collection.Where(t => t.Title.Contains(keyWord));
            return collection.ToList();
        }

        public bool PostExist(int id)=> _context.Posts.Any(p=>p.Id == id);

        public bool Save()=> (_context.SaveChanges() >= 0);
    }
}
