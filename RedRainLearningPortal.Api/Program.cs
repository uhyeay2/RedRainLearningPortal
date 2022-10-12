using RedRainLearningPortal.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

ServicesDependencyInjection.Inject(builder.Services);

var app = builder.BuildApp();

app.Run();
