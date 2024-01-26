using DictionaryReplacer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryReplacer.Tests
{
    [TestFixture]
    public class StringReplacerTests
    {
        [Test]
        public void WhenDictionary_IsEmpty_Then_CountIsZero()
        {
            var dictionary = new Dictionary<string, string>();

            var result = dictionary.Count;

            Assert.AreEqual(0, result);
        }
    }
}
