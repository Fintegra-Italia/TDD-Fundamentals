using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TidyFilesConsole;
using TidyFilesConsole.Models;

namespace MSTest
{
    [TestClass]
    public class FileReader_TEST
    {
        FilterReader<Filter> FileReader;
        string FilterFilePath;
        string FilterEmpty;
        string FilterNoData;
        string FilterIncorrectFormat;

        [TestInitialize]
        public void Setup()
        {
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            FileReader = new FilterReader<Filter>();
            FilterFilePath = $@"{baseFolder}\FileForIntegrationTest\Filters.json";
            FilterEmpty = $@"{baseFolder}\FileForIntegrationTest\FiltersEmpty.json";
            FilterNoData = $@"{baseFolder}\FileForIntegrationTest\FiltersNoData.json";
            FilterIncorrectFormat = $@"{baseFolder}\FileForIntegrationTest\FiltersIncorrectFormat.json";
        }

        [TestMethod]
        public void FilterReader_CorrectFilePath_ShoudReturn_NotNull()
        {
            IList<Filter> Actual = FileReader.Read(FilterFilePath);
            Assert.IsNotNull(Actual);
        }
        [TestMethod]
        public void FilterReader_CorrectFilePath_ShoudReturn_CorrectLentgth()
        {
            IList<Filter> Actual = FileReader.Read(FilterFilePath);
            Assert.IsTrue(Actual.Count == 3);
        }
        [TestMethod]
        public void FilterReader_CorrectFilePath_ShoudReturn_CorrectCollection()
        {
            IList<Filter> Expected = new List<Filter>()
            {
                new Filter(){Id = 1, RuleName = "HasExtension", Value = "pdf", Destination = "Pdf_Files"},
                new Filter(){Id = 2, RuleName = "HasExtension", Value = "jpg", Destination = "Images_Files"},
                new Filter(){Id = 3, RuleName = "HasExtension", Value = "png", Destination = "Images_Files"}
            };

            IList<Filter> Actual = FileReader.Read(FilterFilePath);
            ICollection exp = Expected.OrderBy(e => e.Id).ToList() as ICollection;
            ICollection act = Actual.OrderBy(e => e.Id).ToList() as ICollection;
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("  ")]
        [DataRow("  123abc  ")]
        [DataRow("\\")]
        [DataRow("Filter.txt")]
        [DataRow("Filter.docx")]
        [DataRow("Filter.png")]
        [DataRow("Filter.jpeg")]
        [DataRow("Filter.sln")]
        public void FilterReader_InvalidFilePath_ShoudThrow_ArgumentException(string invalidFilePath)
        {
            Assert.ThrowsException<ArgumentException>(() => FileReader.Read(invalidFilePath));
        }

        [TestMethod]
        public void FilterReader_EmptyFile_ShouldReturn_EmptyCollection()
        {
            IList<Filter> Actual = FileReader.Read(FilterEmpty);
            Assert.IsNotNull(Actual, "Actual non Dovrebbe essere null");
            Assert.AreEqual(Actual.Count, 0, "Numero di Elementi non corretto");
        }
        [TestMethod]
        public void FilterReader_NoDataFile_ShouldReturn_EmptyCollection()
        {
            IList<Filter> Actual = FileReader.Read(FilterNoData);
            Assert.IsNotNull(Actual, "Actual non Dovrebbe essere null");
            Assert.AreEqual(Actual.Count, 0, "Numero di Elementi non corretto");
        }
        [TestMethod]
        public void FilterReader_IncorrectJsonFormat_ShoudThrow_Exception()
        {
            Assert.ThrowsException<FormatException>(() => FileReader.Read(FilterIncorrectFormat));
        }
    }
}
