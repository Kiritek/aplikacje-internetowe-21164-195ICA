using AutoMapper;

namespace CRUD_API2.Profiles
{
    public class TutorialsProfile :Profile
    {
        public TutorialsProfile()
        {
            CreateMap<Models.Tutorial, Models.TutorialDto>();
            CreateMap<Models.TutorialForCreationDto, Models.Tutorial>();
            CreateMap<Models.TutorialForUpdateDto, Models.Tutorial>();
        }
    }
}
