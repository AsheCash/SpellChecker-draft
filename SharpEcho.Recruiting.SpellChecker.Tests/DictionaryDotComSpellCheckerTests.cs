using NUnit.Framework;

using SharpEcho.Recruiting.SpellChecker.Contracts;
using SharpEcho.Recruiting.SpellChecker.Core;

namespace SharpEcho.Recruiting.SpellChecker.Tests
{
    [TestFixture]
    class DictionaryDotComSpellCheckerTests
    {
        private ISpellChecker SpellChecker;

        [SetUp] //Changed from TestFixtureSetUp
        public void TestFixureSetUp()
        {
            SpellChecker = new DictionaryDotComSpellChecker();
        }

        [Test]
        public void Check_That_SharpEcho_Is_Misspelled()
        {
            string sharpEchoMisspelled = "SharpEcho";
            Assert.AreEqual(false, SpellChecker.Check(sharpEchoMisspelled));

        }

        [Test]
        public void Check_That_South_Is_Not_Misspelled()
        {
            string southCorrect = "South";
            Assert.AreEqual(true, SpellChecker.Check(southCorrect));
        }
    }
}
