using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyFiles.Models;

namespace TidyFiles.Interfaces
{
    public interface IEngine
    {
        IList<string> GetFiles(string FolderPath);
        IList<Filter> GetFilters(string FilePath);
        IList<string> Apply(IList<string> Files, IList<Filter> Filters);
    }
}
