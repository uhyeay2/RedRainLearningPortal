using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;
using RedRainLearningPortal.Mediator.Handlers.UserHandlers;

namespace RedRainLearningPortal.Mediator.Mappings.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();

            CreateMap<GetUserByEmailOrAccountName, GetUserByEmailRequest>().ReverseMap();
            CreateMap<InsertUser, InsertUserRequest>().ReverseMap();
            CreateMap<IsEmailRegistered, IsEmailRegisteredRequest>().ReverseMap();
        }
    }
}
