using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_UnitTest
{
    [CollectionDefinition("Context collection")]
    public class InMemoryDbContextFixtureCollection : ICollectionFixture<InMemoryDbContextFixture>
    {       
    }
}
