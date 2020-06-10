using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MSTest.Comparer;
using TidyFilesConsole.Models;

namespace MSTest.Utils
{
    public static class AssertHelper
    {

        public static void AreEqual(IList<Filter> expected, IList<Filter> actual)
        {
            if(!expected.SequenceEqual(actual,new FilterComparer()))
            {
                throw new ArgumentNullException("Object aren't equal", nameof(expected));
            }
        }
    }
}
