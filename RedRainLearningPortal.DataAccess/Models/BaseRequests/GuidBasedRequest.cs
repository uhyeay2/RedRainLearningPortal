using RedRainLearningPortal.DataAccess.Interfaces;

namespace RedRainLearningPortal.DataAccess.Models.BaseRequests
{
    public abstract class GuidBasedRequest : IRequestObject
    {
        public virtual Guid Guid { get; set; }

        public GuidBasedRequest(Guid guid) => Guid = guid;

        public GuidBasedRequest() { }

        public virtual object? GenerateParameters() => new { Guid };

        public abstract string GenerateSql();
    }
}
