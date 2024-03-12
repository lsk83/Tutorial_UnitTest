using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_UnitTest.Model
{
    public interface IPropertyManager
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        void MutateFirstName(string name);
    }

    public class PropertyManager : IPropertyManager
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public void MutateFirstName(string name)
        {
            this.FirstName = name;
        }
    }

    public class PropertyManagerConsumer
    {
        private readonly IPropertyManager _propertyManager;

        public PropertyManagerConsumer(IPropertyManager propertyManager)
        {
            _propertyManager = propertyManager;
        }

        public void ChangeName(string name)
        {
            _propertyManager.FirstName = name;
        }

        public string GetFirstName()
        {
            return _propertyManager.FirstName;
        }
    
        public string GetLastName()
        {
            return _propertyManager.LastName;
        }

        public void ChangeRemoteName(string name)
        {
            _propertyManager.MutateFirstName(name);
        }
    }
}
