using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRainLearningPortal.Domain.Interfaces
{
    public interface IConfig
    {
        string GetConnectionString(string connectionStringName);
    }
}
