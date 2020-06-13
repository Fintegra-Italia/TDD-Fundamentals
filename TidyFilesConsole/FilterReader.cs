using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TidyFilesCore.Interfaces;

namespace TidyFilesConsole
{
    public class FilterReader<Filter> : IJsonReader<Filter>
    {
        public IList<Filter> Read(string path)
        {
            if (String.IsNullOrEmpty(path)) throw new ArgumentNullException("Argument null exception ", nameof(path));

            FileInfo fileInfo = new FileInfo(path);
            string extensionToCheck = fileInfo.Extension;

            if(! extensionToCheck.Equals(".json")) throw new ArgumentNullException("Extension not allowed", nameof(extensionToCheck));

            List<Filter> list = new List<Filter>();

            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Filter>>(content);
            }

            return list;
        }
    }
}