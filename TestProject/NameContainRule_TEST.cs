using System;
using TidyFiles;
using Xunit;

namespace TestProject
{
    
    public class NameContainRule_TEST
    {
        [Fact]
        public void PassingCorrectData_ShouldReturnTrue()
        {
            string filePath = "immagine_sfondo.jpg";
            string value = "sfondo";
            var rule = new NameContain().GetRule();

            bool actual = rule.Invoke(filePath, value);

            Assert.True(actual);
        }
        [Fact]
        public void PassingIncorrectData_ShouldReturnFalse()
        {
            string filePath = "immagine_sfondo.jpg";
            string value = "rendiconto";
            var rule = new NameContain().GetRule();

            bool actual = rule.Invoke(filePath, value);

            Assert.False(actual);
        }
    }
}
