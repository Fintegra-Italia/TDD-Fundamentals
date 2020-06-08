using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyFiles.Interfaces;

namespace TidyFiles
{
    public class FilterReader<Filter> : IJsonReader<Filter>
    {
        public IList<Filter> Read(string FilePath)
        {
            return new List<Filter>();
        }
    }
}
