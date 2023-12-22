using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.XUnitTest.TestModel
{
    public class PassDataByMemberData : IEnumerable<object[]>
    {
        public static IEnumerable<object[]> GetDataParam() 
        {
            return new List<object[]>()
            {
                new object[] {1},
                new object[] {2}
            };
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return (IEnumerator<object[]>)GetDataParam();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
