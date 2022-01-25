using RestApiAppv2.Entities;

namespace RestApiAppv2.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetSearch(string keyWord);
        Post GetPostById(int id);
        void AddPost(Post post);
        void EditPost(Post post);
        void DeletePost(Post post);
        void DeleteAllPosts(IEnumerable<Post> posts);
        bool PostExist(int id);
        bool Save();
    }
}
