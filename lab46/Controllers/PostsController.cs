using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApiAppv2.Models;

namespace RestApiAppv2.Controllers
{   
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostsController(IPostRepository postRepository, IMapper mappper)
        {
            _postRepository = postRepository; 
            _mapper = mappper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PostDto>> GetPostAllWithQuery(string? keyWord)

        {
            var postListFromRepo = _postRepository.GetSearch(keyWord);
            return Ok(_mapper.Map<IEnumerable<PostDto>>(postListFromRepo));
        }

        [HttpGet("{id}", Name = "GetPost")]
        public ActionResult<PostDto> GetPost(int id)
        {
            var post = _postRepository.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PostDto>(post));

        }


        [HttpPost]
        public ActionResult<PostDto> CreatePost(PostForCreationDto post)
        {

            var postEntity = _mapper.Map<Entities.Post>(post);

            var pathBase = HttpContext.User.Claims.ToList();
            var userId = pathBase[10].Value;

            postEntity.PublishDate = DateTime.Now;
            postEntity.AuthorId = userId;
            _postRepository.AddPost(postEntity);
            _postRepository.Save();

            var postToReturn = _mapper.Map<PostDto>(postEntity);
            return CreatedAtRoute("GetPost", new { Id = postToReturn.Id }, postToReturn);

        }

        [HttpPut("{id}")]
        public ActionResult EditPost(int id, PostForUpdateDto post)
        {
            if (!_postRepository.PostExist(id))
            {
                return NotFound();
            }

            var postFromRepo = _postRepository.GetPostById(id);
            var pathBase = HttpContext.User.Claims.ToList();
             var userId = pathBase[10].Value;
            var adminClaim = pathBase[11].Value;

            if (!postFromRepo.AuthorId.Equals(userId) || adminClaim == "Administrator")
            {
                return Unauthorized();
            }

            _mapper.Map(post, postFromRepo);
            _postRepository.EditPost(postFromRepo);
            _postRepository.Save();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_postRepository.PostExist(id))
            {
                return NotFound();
            }

            var postFromRepo = _postRepository.GetPostById(id);
            var pathBase = HttpContext.User.Claims.ToList();
            var userId = pathBase[10].Value;
            var adminClaim = pathBase[11].Value;

            if (!postFromRepo.AuthorId.Equals(userId) || adminClaim == "Administrator")
            {
                return Unauthorized();
            }

            _postRepository.DeletePost(postFromRepo);
            _postRepository.Save();
            return NoContent();
        }
    }
    
}
