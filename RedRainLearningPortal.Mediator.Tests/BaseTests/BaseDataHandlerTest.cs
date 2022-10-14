using AutoMapper;
using RedRainLearningPortal.DataAccess.Interfaces;
using RedRainLearningPortal.Mediator.Mappings;

namespace RedRainLearningPortal.Mediator.Tests.BaseTests
{
    public abstract class BaseDataHandlerTest
    {
        protected Mock<IDataHandler> _mockDataHandler = new();

        protected IMapper _mapper = MappingConfiguration.GetMappings();
    }
}
