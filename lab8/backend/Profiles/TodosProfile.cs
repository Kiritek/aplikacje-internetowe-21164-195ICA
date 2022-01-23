using AutoMapper;

namespace ToDoApi.Profiles
{
    public class TodosProfile :Profile
    {
        public TodosProfile()
        {
            CreateMap<Models.Todo, Models.TodoDto>();
            CreateMap<Models.TodoForCreationDto, Models.Todo>();
            CreateMap<Models.TodoForUpdateDto, Models.Todo>();
        }
    }
}
