using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Builders;
using MSTest.Utils;
using TidyFilesConsole;
using TidyFilesConsole.Models;

namespace MSTest
{

    [TestClass]
    public class FileReaderTest
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
            IList<Filter> expectedList = new List<Filter>();
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

        [TestMethod]
        public void Read_ReadingJsonWithUnexpectedFormat_RetriveException()
        {
            //Act and Assert
            Assert.ThrowsException<Exception>(() => FileReader.Read(FilterIncorrectFormat));
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
        public void Read_ReadingInvalidFile_RetriveException(string invalidFilePath)
        {
            //Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => FileReader.Read(invalidFilePath));
        }
        

    }
}
