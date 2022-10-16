global using RedRainLearningPortal.Mediator.Abstractions.Responses;
global using Microsoft.AspNetCore.Mvc;
global using MediatR;


using RedRainLearningPortal.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

ServicesDependencyInjection.Inject(builder.Services);

var app = builder.BuildApp();

app.Run();
