using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidyFilesCore.Interfaces
{
    public interface IJsonReader<T>
    {
        IList<T> Read(string FilePath);
    }
}
