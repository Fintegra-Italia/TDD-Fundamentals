using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Builders
{
    public class FileListBuilder
    {
        private IList<string> ListaFile;
        public FileListBuilder()
        {
            ListaFile = new List<string>();
        }
        public FileListBuilder WithCorrectFileName()
        {
            ListaFile = new List<string>() { "fileuno.jpeg", "file2.json", "file4.xlsx" };
            return this;
        }
        public IList<string> Build()
        {
            return ListaFile;
        }
    }
}
