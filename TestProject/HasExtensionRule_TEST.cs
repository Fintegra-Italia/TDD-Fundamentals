using System;
using NUnit.Framework;
using FluentAssert;
using TidyFiles;
using System.Collections;
using TidyFiles.Interfaces;

namespace TestProject
{
    [TestFixture]
    public class HasExtensionRule_TEST
    {
        IRule Rule;
        [SetUp]
        public void Setup()
        {
            Rule = new HasExtension();
        }
        [Test]
        public void HasExtensionRule_GetRule_ShoulNotNull()
        {
            Func<string, string, bool> actual = Rule.GetRule();
            Assert.That(actual, Is.Not.Null);
        }

        [TestCaseSource(typeof(DataForRuleInvokingTest), "TestData")]
        public bool RuleInvoking_ShouldReturn_CorrectValue(string filePath, string value)
        {
            Func<string, string, bool> rule = Rule.GetRule();
            return rule.Invoke(filePath, value);
        }

        [Test]
        [TestCaseSource(typeof(DataForIncorrectFilePathTest), "TestData")]
        public object RuleInvoking_WithIncorrect_Parameter_ShouldThrow_ArgumentException(string filePath, string value)
        {
            Func<string, string, bool> rule = Rule.GetRule();
            return rule.Invoke(filePath, value);
        }

        public class DataForRuleInvokingTest
        {
            public static IEnumerable TestData
            {
                get
                {
                    yield return new TestCaseData("file.pdf", "pdf").Returns(true);
                    yield return new TestCaseData("file.txt", "txt").Returns(true);
                    yield return new TestCaseData("file.pdf", "txt").Returns(false);
                    yield return new TestCaseData("file.txt", "pdf").Returns(false);
                }
            }
        }
        public class DataForIncorrectFilePathTest
        {
            public static IEnumerable TestData
            {
                get
                {
                    yield return new TestCaseData("", "pdf").Returns(new ArgumentException());
                    yield return new TestCaseData(" ", "pdf").Returns(new ArgumentException());
                    yield return new TestCaseData("  ", "pdf").Returns(new ArgumentException());
                    yield return new TestCaseData("\\", "pdf").Returns(new ArgumentException());
                    yield return new TestCaseData(null, "pdf").Returns(new ArgumentException());
                    yield return new TestCaseData("filenoext", "pdf").Returns(new ArgumentException());
                    yield return new TestCaseData(" 12345wer ", "pdf").Returns(new ArgumentException());
                    yield return new TestCaseData("file.pdf", "").Returns(new ArgumentException());
                    yield return new TestCaseData("file.pdf", " ").Returns(new ArgumentException());
                    yield return new TestCaseData("file.pdf", null).Returns(new ArgumentException());
                    yield return new TestCaseData("file.pdf", "123456789").Returns(new ArgumentException());
                }
            }
        }
    }
}
