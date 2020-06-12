using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyFiles.Models;

namespace TestProject.Builders
{
    public class EngineInputBuilder
    {
        private Filter FiltroCasuale;
        private IList<string> ListaFile = null;
        private IList<Filter> ListaFiltri = null;
        public EngineInputBuilder()
        {
            FiltroCasuale = new Filter() { Id = 1, RuleName = "regolaACaso", Destination = "finalDestination2", Value = "valoreAcaso" };

            ListaFile = new List<string>() { "fileuno.jpeg", "file2.json", "file4.xlsx" };
            ListaFiltri = new List<Filter>() {
                new Filter() { Id = 1, RuleName = "regolaACaso", Destination = "finalDestination2", Value = "valoreAcaso" },
                new Filter() { Id = 2, RuleName = "regolaACaso2", Destination = "finalDestination3", Value = "valoreAcaso" },
                new Filter() { Id = 3, RuleName = "regolaACaso3", Destination = "finalDestination4", Value = "valoreAcaso" }
            };
        }
        public IList<Filter> FilterListWithRandomValue()
        {
            return ListaFiltri;
        }
        public IList<string> FileListWithAJsonFile()
        {
            return ListaFile;
        }
        public Filter RandomFilter()
        {
            return FiltroCasuale;
        }
        public IList<Filter> SingleElementFilterList()
        {
            return new List<Filter>() { FiltroCasuale };
        }
    }
}
