using System.Collections.Generic;

namespace ToDoApi.Models
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo GetTodoById(int id);
        void AddTodo(Todo todo);
        void EditTodo(Todo todo);
        void DeleteTodo(Todo todo);
        bool TodoExist(int id);
        bool Save();
    }
}
