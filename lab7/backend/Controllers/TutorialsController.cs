using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CRUD_API2.Models;
using AutoMapper;

namespace CRUD_API2.Controllers
{
    [Route("api/TutorialsController")]
    [ApiController]
    
    public class TutorialsController : ControllerBase
    {
        private readonly ITutorialRepository _tutorialRepository;
        private readonly IMapper _mapper;

        public TutorialsController(ITutorialRepository tutorialRepository, IMapper mapper)
        {
            _tutorialRepository= tutorialRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TutorialDto>> GetAllWithQuery(
            [FromQuery] string name,string category)
        {
            var tutorialListFromRepo = _tutorialRepository.GetSearch(name,category);

            return Ok(_mapper.Map<IEnumerable<TutorialDto>>(tutorialListFromRepo));
        }
        [HttpGet("{id}", Name="GetTutorial")]
        public ActionResult<TutorialDto> Get(int id)
        {
            var tutorial = _tutorialRepository.GetTutorialById(id);
            if(tutorial == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TutorialDto>(tutorial));

        }

        [HttpPost]
        public ActionResult<TutorialDto> CreateTutorial(TutorialForCreationDto tutorial) { 
        
            var tutorailEntity = _mapper.Map<Models.Tutorial>(tutorial);
            _tutorialRepository.AddTutorial(tutorailEntity);
            _tutorialRepository.Save();
            var tutorialToReturn = _mapper.Map<TutorialDto>(tutorailEntity);
            return CreatedAtRoute("GetTutorial", new { Id= tutorialToReturn.Id},tutorialToReturn);

        }
        [HttpOptions]
        public IActionResult GetTutorialsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult EditTutorial(int id, TutorialForUpdateDto tutorial)
        {
            if (!_tutorialRepository.TutorialExist(id))
            {
                return NotFound();
            }
            var tutorialFromRepo = _tutorialRepository.GetTutorialById(id);
            _mapper.Map(tutorial, tutorialFromRepo);
            _tutorialRepository.EditTutorial(tutorialFromRepo);
            _tutorialRepository.Save();
            return NoContent();
        }


        [HttpDelete]
        public ActionResult DeleteAllTutorials()
        {
            var tutorials = _tutorialRepository.GetAll();
            _tutorialRepository.DeleteAllTutorials(tutorials);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTutorial(int id)
        {
            if (!_tutorialRepository.TutorialExist(id)){
                return NotFound();
            }
            var tutorial = _tutorialRepository.GetTutorialById(id);
            _tutorialRepository.DeleteTutorial(tutorial);
            _tutorialRepository.Save();
            return NoContent();
        }
    }
}
