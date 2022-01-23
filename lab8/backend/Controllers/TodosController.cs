using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;
        public TodosController(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;   
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetAll()
        {
            var todoListFromRepo = _todoRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<TodoDto>>(todoListFromRepo));
        }
        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoDto> Get(int id)
        {
            var Todo = _todoRepository.GetTodoById(id);
            if (Todo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TodoDto>(Todo));

        }

        [HttpPost]
        public ActionResult<TodoDto> CreateTodo(TodoForCreationDto Todo)
        {

            var tutorailEntity = _mapper.Map<Models.Todo>(Todo);
            _todoRepository.AddTodo(tutorailEntity);
            _todoRepository.Save();
            var TodoToReturn = _mapper.Map<TodoDto>(tutorailEntity);
            return CreatedAtRoute("GetTodo", new { Id = TodoToReturn.Id }, TodoToReturn);

        }
        [HttpOptions]
        public IActionResult GetTodosOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult EditTodo(int id, TodoForUpdateDto Todo)
        {
            if (!_todoRepository.TodoExist(id))
            {
                return NotFound();
            }
            var TodoFromRepo = _todoRepository.GetTodoById(id);
            _mapper.Map(Todo, TodoFromRepo);
            _todoRepository.EditTodo(TodoFromRepo);
            _todoRepository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            if (!_todoRepository.TodoExist(id))
            {
                return NotFound();
            }
            var Todo = _todoRepository.GetTodoById(id);
            _todoRepository.DeleteTodo(Todo);
            _todoRepository.Save();
            return NoContent();
        }
    }
}
