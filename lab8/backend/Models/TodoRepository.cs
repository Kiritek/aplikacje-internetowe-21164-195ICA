using System.Collections.Generic;
using System.Linq;

namespace ToDoApi.Models
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;
        public TodoRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void AddTodo(Todo todo) => _context.Todos.Add(todo);
        public void DeleteTodo(Todo todo) => _context.Todos.Remove(todo);

        public void EditTodo(Todo todo)
        {

        }

        public IEnumerable<Todo> GetAll() => _context.Todos.ToList();

        public Todo GetTodoById(int id) => _context.Todos.FirstOrDefault(t => t.Id == id);

        public bool Save() => (_context.SaveChanges() >= 0);
   

        public bool TodoExist(int id) =>_context.Todos.Any(t => t.Id == id);

    }
}
