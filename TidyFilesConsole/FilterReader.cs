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
            if (path is null) throw new ArgumentNullException("Argument null exception ", nameof(path));

            FileInfo fileInfo = new FileInfo(path);
            string extensionToCheck = fileInfo.Extension;

            if(!ExtensionIsAllowed(extensionToCheck)) throw new ArgumentNullException("Extension not allowed", nameof(extensionToCheck));

            List<Filter> list;
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Filter>>(content);
            }

            return list;
        }

        private bool ExtensionIsAllowed(string extensionToCheck)
        {
            List<string> extensionAllowed = new List<string>() { ".pdf", ".jpg", ".png" };
            return extensionAllowed.Contains(extensionToCheck);
        }
    }
}