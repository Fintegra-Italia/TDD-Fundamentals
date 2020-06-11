using System;
using TidyFiles;
using Xunit;

namespace TestProject
{
    
    public class NameContainRule_TEST
    {
        [Theory]
        [InlineData("immagine_sfondo.jpg", "sfondo")]
        [InlineData("rendiconto_mensile.pdf", "rendiconto")]
        [InlineData("lista_spesa.xls", "spesa")]
        [InlineData("rendiconto_mensile.xls", "rendiconto")]
        public void PassingCorrectData_ShouldReturnTrue(string filePath, string value)
        {
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
