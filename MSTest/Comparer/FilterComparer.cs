using System;
using System.Collections.Generic;
using TidyFilesConsole.Models;

namespace MSTest.Comparer
{
    public class FilterComparer : IEqualityComparer<Filter>
    {
        public bool Equals(Filter expected, Filter actual)
        {
            if (expected is null || actual is null)
            return false;

            return expected.Id == actual.Id &&
                    expected.RuleName.Equals(actual.RuleName) &&
                    expected.Value.Equals(actual.Value) &&
                    expected.Destination.Equals(actual.Destination);
        }

        public int GetHashCode(Filter filter)
        {
            if (filter is null) return 0;
            int hashId = filter.Id.GetHashCode();
            return hashId;
        }
    }
}
