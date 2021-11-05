using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _postsRepository;
        public HomeController(IPostRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }
        public ViewResult AllPosts()
        {
            IEnumerable<Post> posts;
            posts = _postsRepository.GetAll.Where(p => p.PostPublishDate < DateTime.Now).OrderByDescending(p => p.PostPublishDate);

            return View(posts);
        }
        [HttpGet]
        public ViewResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Delete(int id)
        {
            _postsRepository.RemovePost(id);
            RedirectToAction("AllPosts");
            return View();
        }
        public IActionResult PostDetails(int id)
        {
            var post = _postsRepository.GetPostById(id);
            if (post == null)
                return NotFound();

            return View(post);
        }
        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.PostDate = DateTime.Now;
                _postsRepository.AddPost(post);
                return RedirectToAction("AllPosts");
            }
            else
            {
                return View(post);
            }
        }

    }
}
