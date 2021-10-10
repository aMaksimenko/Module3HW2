using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using HomeWork.Collections.Abstractions;

namespace HomeWork.Collections
{
    public class CultureResolver : ICultureResolver
    {
        private IDictionary<string, CultureInfo> _dictionary;

        public CultureResolver()
        {
            _dictionary = new Dictionary<string, CultureInfo>();
        }

        public void Add(string cultureString)
        {
            var cultureInfo = new CultureInfo(cultureString);

            _dictionary.Add(cultureString, cultureInfo);
        }

        public CultureInfo GetCultureInfo(string stringToTest)
        {
            var charToText = stringToTest[0];

            if (Regex.IsMatch(charToText.ToString(), "[a-z]", RegexOptions.IgnoreCase))
            {
                return _dictionary["en-GB"];
            }

            if (Regex.IsMatch(charToText.ToString(), "[а-я]", RegexOptions.IgnoreCase))
            {
                return _dictionary["ru-RU"];
            }

            throw new ArgumentException("No such CultureInfo stored");
        }

        public CultureInfo[] GetCultures()
        {
            return _dictionary.Values.ToArray();
        }
    }
}