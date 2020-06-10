using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Builders;
using MSTest.Utils;
using Newtonsoft.Json;
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
            FilterFilePath = $@"{baseFolder}FileForIntegrationTest/Filters.json";
            FilterEmpty = $@"{baseFolder}FileForIntegrationTest/FiltersEmpty.json";
            FilterNoData = $@"{baseFolder}FileForIntegrationTest/FiltersNoData.json";
            FilterIncorrectFormat = $@"{baseFolder}FileForIntegrationTest/FiltersIncorrectFormat.json";
        }

        [TestMethod]
        public void Read_ReadingValidJsonWithoutItems_RetriveEmptyList()
        {
            //Act
            IList<Filter> filterList = FileReader.Read(FilterNoData);
            //Assert
            Assert.AreEqual(0, filterList.Count);
        }

        [TestMethod]
        public void Read_ReadingValidJson_RetriveFilterList()
        {
            //Arrange
            var builder = new FilterBuilder();
            List<Filter> expectedList = new List<Filter>();
            expectedList.Add(builder.WithId(1).WithDestination("Pdf_Files").WithRuleName("HasExtension").WithValue("pdf").Build());
            expectedList.Add(builder.WithId(2).WithDestination("Images_Files").WithRuleName("HasExtension").WithValue("jpg").Build());
            expectedList.Add(builder.WithId(3).WithDestination("Images_Files").WithRuleName("HasExtension").WithValue("png").Build());
            //Act
            IList<Filter> filterList = FileReader.Read(FilterFilePath);
            //Assert
            AssertHelper.AreEqual(expectedList, filterList);
        }

        [TestMethod]
        public void Read_ReadingValidJson_RetriveListNull()
        {
            //Act
            IList<Filter> filterList = FileReader.Read(FilterEmpty);
            //Assert
            Assert.IsNull(filterList);
        }

     /*

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

    */

    }
}
