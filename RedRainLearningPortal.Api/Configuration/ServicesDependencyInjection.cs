namespace RedRainLearningPortal.Api.Configuration
{
    public static class ServicesDependencyInjection
    {
        public static IServiceCollection Inject(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSingleton<Domain.Interfaces.IConfig, ApiConfig>();

            services.AddTransient<DataAccess.Interfaces.IDataHandler, DataAccess.DataHandler>(); // DataAccess DataHandler

            services.AddSingleton(Mediator.Mappings.MappingConfiguration.GetMappings()); // Auto Mapper
            
            services.AddMediatR(typeof(Mediator.MediatorEntryPoint).Assembly); // MediatR Entry Point

            services.AddTransient<Middleware.ExceptionHandlingMiddleware>(); // Exception Middleware

            return services;
        }
    }
}
