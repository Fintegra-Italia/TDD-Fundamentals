using Newtonsoft.Json;
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

        public void ApplyAction(string FileName, string Destination)
        {
        }

        public IList<string> ApplyFilter(IList<string> Files, Filter Filter)
        {
            RuleManager.GetRules("nomeregola");
            return new List<string>();
        }

        public void Execute()
        {
            IList<string> files = GetFiles("filepath");
            IList<Filter> filtri = GetFilters("filepath2");
            foreach(var filtro in filtri)
            {
                IList<string> Selezioniati = ApplyFilter(files, filtro);
                foreach(string file in Selezioniati)
                {
                    string destinazione = filtro.Destination;
                    ApplyAction(file, destinazione);
                }
            }
        }

        public IList<string> GetFiles(string FolderPath)
        {
            IList<string> fileList = FileListReader.GetFileList("filejson.json");
            return fileList;
        }

        public IList<Filter> GetFilters(string FilePath)
        {
            IList<string> fileList = FileListReader.GetFileList("filejson.json");
            IList<Filter> filters = FilterReader.Read("filepath.json");
            return filters;
        }
    }
}
