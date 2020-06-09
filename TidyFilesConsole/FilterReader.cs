using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyFilesCore.Interfaces;

namespace TidyFilesConsole
{
    public class FilterReader<Filter> : IJsonReader<Filter>
    {
        public IList<Filter> Read(string FilePath)
        {
            return new List<Filter>();
        }
    }
}
