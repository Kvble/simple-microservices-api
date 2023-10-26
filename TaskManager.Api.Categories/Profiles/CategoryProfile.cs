using AutoMapper;

namespace TaskManager.Api.Categories.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Database.Entities.Category, Models.Category>();
        }

    }
}
