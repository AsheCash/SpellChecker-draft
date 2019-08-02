using System;
using System.Linq;
using SharpEcho.Recruiting.SpellChecker.Contracts;
using SharpEcho.Recruiting.SpellChecker.Core;

namespace SharpEcho.Recruiting.SpellCheckerConsole
{
    /// <summary>
    /// Thank you for your interest in a position at SharpEcho.  The following are the "requirements" for this project:
    /// 
    /// 1. Implent Main() below so that a user can input a sentance.  Each word in that
    ///    sentance will be evaluated with the SpellChecker, which returns true for a word
    ///    that is spelled correctly and false for a word that is spelled incorrectly.  Display
    ///    out each *distnict* word that is misspelled.  That is, if a user uses the same misspelled
    ///    word more than once, simply output that word one time.
    ///    
    ///    Example:
    ///    Please enter a sentance: Salley sells seashellss by the seashore.  The shells Salley sells are surely by the sea.
    ///    Misspelled words: Salley seashellss
    ///    
    /// 2. The concrete implementation of SpellChecker depends on two other implementations of ISpellChecker, DictionaryDotComSpellChecker
    ///    and MnemonicSpellCheckerIBeforeE.  You will need to implement those classes.  See those classes for details.
    ///    
    /// 3. There are covering unit tests in the SharpEcho.Recruiting.SpellChecker.Tests library that should be implemented as well.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This application is intended to allow a user enter some text (a sentence)
        /// and it will display a distinct list of incorrectly spelled words
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("SPELLCHECKER.\n" +
    "Reference sentence to copy: Salley sells seashellss by the seashore.  The shells Salley sells are surely by the sea.\n" +
    "Misspelled words expected: \n" +
    "Salley\n" +
    "seashells\n\n");
            bool flag = true;
            while (flag == true)
            {
                Console.Write("Please enter a sentence: ");
                var sentence = Console.ReadLine();

                // first break the sentance up into words,
                string[] tempParsed;
                char[] seperators = new char[] { ' ', '.', ',', '!', '?', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=', '/', '\\' };
                tempParsed = sentence.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                // then iterate through the list of words using the spell checker
                // capturing distinct words that are misspelled
                // use this spellChecker to evaluate the words
                var spellChecker = new SpellChecker.Core.SpellChecker

                    (
                        new ISpellChecker[]
                        {
                        new MnemonicSpellCheckerIBeforeE(),
                        new DictionaryDotComSpellChecker(),
                        }
                    );

                //display a distinct list of incorrectly spelled words
                string[] finalParsed = tempParsed.Distinct(StringComparer.CurrentCultureIgnoreCase).ToArray();
                int parsedLength = finalParsed.Length;
                for (int i = 0; i != parsedLength; i++) { 
                    if (!spellChecker.Check(finalParsed[i])) { Console.WriteLine(finalParsed[i]); }
                }

                //Re-test
                Console.Write("\nPress ENTER to test more sentences. Hit any character to EXIT: ");
                if (Console.ReadKey(true).Key == ConsoleKey.Enter) { 
                    Console.WriteLine("\n");    //2 lines are entered instead of just the 1.
                }
                else { flag = false; }
                
            }
        }

    }
}
