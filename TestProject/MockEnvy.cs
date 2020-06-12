using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidyFiles
{
    internal static class MockEnvy
    {
        internal static Mock<T> AsMock<T>(this T obj) where T : class
        {
            return Mock.Get(obj);
        }
    }
}
