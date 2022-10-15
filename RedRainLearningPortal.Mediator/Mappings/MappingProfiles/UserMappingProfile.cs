using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;
using RedRainLearningPortal.Domain.Models.Users;
using RedRainLearningPortal.Mediator.Handlers.UserHandlers;

namespace RedRainLearningPortal.Mediator.Mappings.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // DTO x Domain
            CreateMap<UserDTO, User>().ReverseMap();

            // Get Requests
            CreateMap<GetUserByEmailOrAccountName, GetUserByEmailRequest>().ReverseMap();
            CreateMap<GetUserByEmailOrAccountName, GetUserByAccountNameRequest>().ReverseMap();
            CreateMap<GetUserByGuid, GetUserByGuidRequest>().ReverseMap();
            CreateMap<InsertUserRequest, GetUserByEmailRequest>().ReverseMap();
            
            // IsExists Requests
            CreateMap<IsAccountNameTaken, IsAccountNameTakenRequest>().ReverseMap();
            CreateMap<IsEmailRegistered, IsEmailRegisteredRequest>().ReverseMap();
            
            // Insert Requests
            CreateMap<InsertUser, InsertUserRequest>().ReverseMap();

            // Delete Requests
            CreateMap<DeleteUser, DeleteUserRequest>().ReverseMap();
        }
    }
}
