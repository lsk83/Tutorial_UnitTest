using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_UnitTest
{
    public class InMemoryDbContextFixture : IDisposable
    {        
        public InMemoryDbContextFixture()
        {
            Debug.WriteLine("Inside Constructor");
        }

        public void Dispose()
        {
            Debug.WriteLine("Inside CleanUp or Dispose method");
        }
    }
}
