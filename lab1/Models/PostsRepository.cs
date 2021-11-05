using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class PostsRepository : IPostRepository
    {
        private readonly AppDbContext _appDbContext;
        public PostsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext; 
        }
        public IEnumerable<Post> GetAll => _appDbContext.Posts;

        public IEnumerable<Post> HighlightedPosts => _appDbContext.Posts.Where(p => p.IsHighlighted);

        public void AddPost(Post post)
        {
            _appDbContext.Add(post);
            _appDbContext.SaveChanges();
        }

        public Post GetPostById(int id)
        {
            return _appDbContext.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            throw new NotImplementedException();
        }

        public void EditPost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
