using RedRainLearningPortal.Mediator.Mappings.MappingProfiles;

namespace RedRainLearningPortal.Mediator.Mappings
{
    public static class MappingConfiguration
    {
        public static IMapper GetMappings() => new MapperConfiguration(config =>
        {
            config.AllowNullDestinationValues = true;

            config.AddProfiles(new List<Profile>()
            {
                new UserMappingProfile()
            });

        }).CreateMapper();
    }
}
