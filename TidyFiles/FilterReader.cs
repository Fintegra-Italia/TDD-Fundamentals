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
        IFileListReader FileListReader;
        public FilterReader(IFileListReader fileListReader)
        {
            FileListReader = FileListReader ?? throw new ArgumentNullException(nameof(FileListReader));
        }
        public IList<Filter> Read(string FilePath)
        {
            return new List<Filter>();
        }
    }
}
