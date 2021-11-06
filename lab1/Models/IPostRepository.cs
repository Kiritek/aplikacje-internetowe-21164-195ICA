using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll { get; }
        IEnumerable<Post> HighlightedPosts { get; }
        Post GetPostById(int? id);
        void AddPost(Post post);
        void RemovePost(int id);
        void EditPost(Post post);
    }
}
