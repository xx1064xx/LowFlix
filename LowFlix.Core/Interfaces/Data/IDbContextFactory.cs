using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowFlix.Core.Interfaces.Data
{
    using LowFlix.Core.Domain;
    public interface IDbContextFactory
    {

        LowFlixContext CreateContext();
        LowFlixContext CreateReadOnlyContext();

    }
}
