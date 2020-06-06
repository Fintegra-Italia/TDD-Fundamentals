using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TidyFiles;
using TidyFiles.Models;

namespace TestProject
{
    [TestClass]
    public class FileReader_TEST
    {
        [TestMethod]
        public void FilterReader_inNotNull_ShouldPass()
        {
            var filterReader = new FilterReader<Filter>();
            var currentFolder = AppDomain.CurrentDomain.BaseDirectory;
            IList<Filter> Filters = filterReader.Read($"{currentFolder}\\Filters.json");
            Assert.IsNotNull(Filters);
        }
    }
}
