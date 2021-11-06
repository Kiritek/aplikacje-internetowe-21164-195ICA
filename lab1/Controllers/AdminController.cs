using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{  [Authorize]
    public class AdminController : Controller
    {
        private readonly IPostRepository _postsRepository;
        public AdminController(IPostRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }
        public ViewResult AllPosts()
        {
            IEnumerable<Post> posts;
            posts = _postsRepository.GetAll.OrderByDescending(p => p.PostPublishDate);

            return View(posts);
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
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Author = User.Identity.Name;
                post.PostDate = DateTime.Now;
                _postsRepository.AddPost(post);
                return RedirectToAction("PostDetails", new { id = post.Id });
            }
            else
            {
                return View(post);
            }
        }
        [HttpGet]
        public IActionResult EditPost(int id)
        {
            var model = _postsRepository.GetPostById(id);
            if (model == null)
            {
                return RedirectToAction("PostDetails", new { id = model.Id });
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                _postsRepository.EditPost(post);
                return RedirectToAction("AllPosts");
            }
            return View(post);
        }

        [HttpGet]
        public IActionResult DeletePost(int? id)
        {
            var model = _postsRepository.GetPostById(id);
            if (model == null)
            {
                return RedirectToAction("AllPosts");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            _postsRepository.RemovePost(id);

            return RedirectToAction("AllPosts");
        }
    }
}
