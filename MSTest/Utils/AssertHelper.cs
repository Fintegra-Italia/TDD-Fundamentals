using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Comparer;
using TidyFilesConsole.Models;

namespace MSTest.Utils
{
    public static class AssertHelper
    {
        public static void AreEqual(IList<Filter> expected, IList<Filter> actual)
        {
            if (!expected.SequenceEqual(actual, new FilterComparer()))
            {
                throw new AssertFailedException("Objects aren't equal");
            }
        }
    }
}
