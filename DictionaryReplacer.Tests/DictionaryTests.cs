using DictionaryReplacer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryReplacer.Tests
{
    [TestFixture]
    public class DictionaryTests
    {
        [Test]
        public void WhenDictionary_IsEmpty_Then_CountIsZero()
        {
            //Arrange
            var dictionary = new Dictionary<string, string>();

            //Act
            var result = dictionary.Count;

            //Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void WhenDictionary_IsNotEmpty_Then_CountIsNotZero()
        {
            //Arrange
            var dictionary = new Dictionary<string, string>() { { "temp", "temporary" } }; ;

            //Act
            var result = dictionary.Count;

            //Assert
            Assert.That(result, Is.Not.EqualTo(0));
        }

        [Test]
        public void WhenSingleReplacementInString_Then_ReplaceCorrectly()
        {
            var replacements = new Dictionary<string, string> { { "temp", "temporary" } };
            var result = Dictionary.ReplaceString("$temp$", replacements);

            Assert.That(result, Is.EqualTo("temporary"));
        }

        [Test]
        public void WhenMultipleReplacementsInString_Then_ReplaceCorrectly()
        {
            var replacements = new Dictionary<string, string>
                {
                    { "temp", "temporary" },
                    { "name", "John Doe" }
                };

            var result = Dictionary.ReplaceString("$temp$ here comes the name $name$", replacements);

            Assert.That(result, Is.EqualTo("temporary here comes the name John Doe"));
        }

    }
}
