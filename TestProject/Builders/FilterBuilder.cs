using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyFiles.Models;

namespace TestProject.Builders
{
    public class FilterBuilder
    {
        private IList<Filter> listaFiltri;
        private Filter filtro;
        public FilterBuilder()
        {
            listaFiltri = new List<Filter>();

        }
        public FilterBuilder WithNoDataList()
        {
            listaFiltri = new List<Filter>();
            return this;
        }
        public FilterBuilder WithOneRandomFilterList()
        {
            listaFiltri.Add(new Filter() { Id = 1, RuleName = "regolaACaso", Destination = "finalDestination2", Value = "valoreAcaso" });
            return this;
        }
        public FilterBuilder WithOneValidFilterList()
        {
            listaFiltri.Add(new Filter() { Id = 1, RuleName = "HasExtension", Destination = "filesPDF", Value = "pdf" });
            return this;
        }
        public FilterBuilder WithValidFilter()
        {
            filtro = new Filter() { Id = 1, RuleName = "HasExtension", Destination = "filesPDF", Value = "pdf" };
            return this;
        }
        public IList<Filter> BuildList()
        {
            return listaFiltri;
        }
        public Filter Build()
        {
            return filtro;
        }

    }
}
