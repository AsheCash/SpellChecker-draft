using SharpEcho.Recruiting.SpellChecker.Contracts;
using System;
using System.Net;

namespace SharpEcho.Recruiting.SpellChecker.Core
{
    /// <summary>
    /// This is a dictionary based spell checker that uses dictionary.com to determine if
    /// a word is spelled correctly
    /// 
    /// The URL to do this looks like this: http://dictionary.reference.com/browse/<word>
    /// where <word> is the word to be checked
    /// 
    /// Example: http://dictionary.reference.com/browse/SharpEcho would lookup the word SharpEcho
    /// 
    /// We look for something in the response that gives us a clear indication whether the
    /// word is spelled correctly or not
    /// </summary>
    public class DictionaryDotComSpellChecker : ISpellChecker
    {
        public bool Check(string word)
        {
            string url = ("https://www.dictionary.com/browse/" + word);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.AllowAutoRedirect = true;

            try
            {
                HttpWebResponse webResponse = null;
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                if (webResponse != null) {
                    webResponse.Close();
                    return true;
                } 
            }
            catch (WebException e) { return false;  }
            throw new System.NotImplementedException();
        }
    }
}
