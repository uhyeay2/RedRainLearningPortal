global using MediatR;
global using AutoMapper;
global using RedRainLearningPortal.DataAccess.Interfaces;
global using RedRainLearningPortal.DataAccess.Models.DataTransferObjects;
global using RedRainLearningPortal.Domain.Models;
global using RedRainLearningPortal.Mediator.Abstractions.Handlers;
global using RedRainLearningPortal.Mediator.Abstractions.Requests;
global using RedRainLearningPortal.Mediator.Abstractions.Responses;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RedRainLearningPortal.Mediator.Tests")]
namespace RedRainLearningPortal.Mediator
{
    public class MediatorEntryPoint { }
}
