using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _postsRepository;
        public PostsController(IPostRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }
        public ViewResult AllPosts()
        {
            IEnumerable<Post> posts;
            posts = _postsRepository.GetAll.Where(p=>p.PostPublishDate<DateTime.Now).OrderByDescending(p=>p.PostPublishDate);

            return View(posts);
        }
        public IActionResult Details(int id)
        {
            var post = _postsRepository.GetPostById(id);
            if (post == null)
                return NotFound();

            return View(post);
        }
    }
}
