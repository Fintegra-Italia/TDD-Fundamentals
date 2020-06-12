using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyFiles.Interfaces;
using TidyFiles.Models;

namespace TidyFiles
{
    public class Engine : IEngine
    {
        IRuleManager RuleManager;
        IJsonReader<Filter> FilterReader;
        IFileListReader FileListReader;
        public Engine(IRuleManager ruleManager, IJsonReader<Filter> filterReader,
                        IFileListReader fileListReader)
        {
            RuleManager = ruleManager ?? throw new ArgumentNullException(nameof(ruleManager));
            FilterReader = filterReader ?? throw new ArgumentNullException(nameof(filterReader));
            FileListReader = fileListReader ?? throw new ArgumentNullException(nameof(fileListReader));
        }

        public IList<string> Apply(IList<string> Files, IList<Filter> Filters)
        {
            var res = RuleManager.GetRules("HasExtension"); 
            return new List<string>();
        }

        public IList<string> GetFiles(string FolderPath)
        {
            throw new NotImplementedException();
        }

        public IList<Filter> GetFilters(string FilePath)
        {
            //var res = FileListReader.GetFileList(FilePath);
            var res = Directory.GetFiles(FilePath).ToList().Where(e => e.Split('.').Last() == "json").ToList();
            var filtri = FilterReader.Read(res[0]);
            return new List<Filter>();
        }
    }
}
