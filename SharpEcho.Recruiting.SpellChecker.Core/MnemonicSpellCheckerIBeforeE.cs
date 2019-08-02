using SharpEcho.Recruiting.SpellChecker.Contracts;
using System;

namespace SharpEcho.Recruiting.SpellChecker.Core
{
    /// <summary>
    /// This spell checker implements the following rule:
    /// "I before E, except after C" is a mnemonic rule of thumb for English spelling.
    /// If one is unsure whether a word is spelled with the sequence ei or ie, the rhyme
    /// suggests that the correct order is ie unless the preceding letter is c, in which case it is ei. 
    /// 
    /// Examples: believe, fierce, collie, die, friend, deceive, ceiling, receipt would be evaulated as spelled correctly
    /// heir, protein, science, seeing, their, and veil would be evaluated as spelled incorrectly.
    /// </summary>
    public class MnemonicSpellCheckerIBeforeE : ISpellChecker
    {
        /// <summary>
        /// Returns false if the word contains a letter sequence of "ie" when it is immediately preceded by c
        /// </summary>
        /// <param name="word">The word to be checked</param>
        /// <returns>true when the word is spelled correctly, false otherwise</returns>
        public bool Check(string word)
        {
            int ieIndex = word.IndexOf("ie", System.StringComparison.CurrentCultureIgnoreCase);
            if (ieIndex != 0 && ieIndex != -1) {
                if (word[(ieIndex - 1)] == ('c' | 'C')) { return false; }   //Returns false if the word contains a letter sequence of "ie" when it is immediately preceded by c
                else { return true; }
            }
            else { return true; }

            throw new System.NotImplementedException();
        
        }
    }
}