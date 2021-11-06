using Microsoft.EntityFrameworkCore;
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
            _appDbContext.Posts.Add(post);
            _appDbContext.SaveChanges();
        }

        public Post GetPostById(int? id)
        {
            return _appDbContext.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            var post = _appDbContext.Posts.Find(id);
            _appDbContext.Posts.Remove(post);
            _appDbContext.SaveChanges();
        }

        public void EditPost(Post post)
        {
            var entry = _appDbContext.Posts.Find(2);
            entry.Author = post.Author;
            entry.Category = post.Category;
            entry.IsHighlighted = post.IsHighlighted;
            entry.PostDate = post.PostDate;
            entry.PostPublishDate = post.PostDate;
            entry.PostShortDescritpion = post.PostShortDescritpion;
            entry.PostLongDescription = post.PostLongDescription;
            entry.Score = post.Score;
         
            _appDbContext.SaveChanges();
        }
    }
}
