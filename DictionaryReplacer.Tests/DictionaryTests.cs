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

        [Test]
        public void WhenReplacingWithCaseSensitiveKey_Then_UseExactMatch()
        {
            var replacements = new Dictionary<string, string>
                {
                    { "TEMP", "temporary" },
                    { "temp", "Temporary" },
                    { "Temp", "tempoRary" }
                };

            var result = Dictionary.ReplaceString("$temp$", replacements);

            Assert.That(result, Is.EqualTo("Temporary"));
        }

        [Test]
        public void WhenMultipleOccurrencesOfSamePlaceholder_Then_ReplaceAll()
        {
            var replacements = new Dictionary<string, string> { { "word", "replaced" } };
            var result = Dictionary.ReplaceString("This $word$ and that $word$.", replacements);
            Assert.That(result, Is.EqualTo("This replaced and that replaced."));
        }

        [Test]
        public void WhenPlaceholdersWithSpecialCharacters_Then_ReplaceCorrectly()
        {
            var replacements = new Dictionary<string, string> { { "special char", "handled" } };
            var result = Dictionary.ReplaceString("This has a $special char$.", replacements);
            Assert.That(result, Is.EqualTo("This has a handled."));
        }

        [Test]
        public void WhenPlaceholdersAtStartAndEnd_Then_ReplaceCorrectly()
        {
            var replacements = new Dictionary<string, string> { { "start", "beginning" }, { "end", "finish" } };
            var result = Dictionary.ReplaceString("$start$ in the middle $end$", replacements);
            Assert.That(result, Is.EqualTo("beginning in the middle finish"));
        }

        [Test]
        public void WhenNoMatchingKeyword_Then_LeaveAsIs()
        {
            var replacements = new Dictionary<string, string> { { "start", "beginning" } };
            var result = Dictionary.ReplaceString("$start$ in the middle $end$", replacements);
            Assert.That(result, Is.EqualTo("beginning in the middle $end$"));
        }

        [Test]
        public void WhenNoCaseInsensitiveReplacement_Then_ReplaceCorrectly()
        {
            var remplacements = new Dictionary<string, string> { { "VILLE", "Paris" } };
            var resultat = Dictionary.ReplaceString("Bienvenue à $ville$.", remplacements);
            Assert.That(resultat, Is.EqualTo("Bienvenue à Paris."));
        }
    }
}
