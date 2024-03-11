using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Tutorial_UnitTest.Model
{
    public class UserDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new UserInfo() { UserID="user1", UserName="name1", Age=10 } };
            yield return new object[] { new UserInfo() { UserID="user2", UserName="name2", Age=20 } };
            yield return new object[] { new UserInfo() { UserID="user3", UserName="name3", Age=30 } };
            yield return new object[] { new UserInfo() { UserID="user4", UserName="name4", Age=40 } };
        }
    }
}
