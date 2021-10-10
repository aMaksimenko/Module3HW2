using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using HomeWork.Collections.Abstractions;
using HomeWork.Helpers;
using HomeWork.Models;
using HomeWork.Models.Enums;

namespace HomeWork.Collections
{
    public class PhoneBook<T> : IPhoneBook<T>
        where T : Contact
    {
        private IDictionary<CultureInfo, List<T>> _cultureCollection;
        private IDictionary<AdditionalKeys, List<T>> _additionalCollection;
        private ICultureResolver _cultureResolver;

        public PhoneBook(ICultureResolver cultureResolver)
        {
            _cultureResolver = cultureResolver;
            _cultureResolver.Add("en-GB");
            _cultureResolver.Add("ru-RU");

            _cultureCollection = new Dictionary<CultureInfo, List<T>>();
            _additionalCollection = new Dictionary<AdditionalKeys, List<T>>();

            foreach (var culture in _cultureResolver.GetCultures())
            {
                _cultureCollection.Add(culture, new List<T>());
            }

            _additionalCollection.Add(AdditionalKeys.Number, new List<T>());
            _additionalCollection.Add(AdditionalKeys.Special, new List<T>());
        }

        public IReadOnlyCollection<T> this[string key]
        {
            get
            {
                var collection = DetermineCollection(key);
                var result = new List<T>();

                foreach (var contact in collection)
                {
                    if (contact.Name.StartsWith(key, StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Add(contact);
                    }
                }

                return result;
            }
        }

        public void Add(T item)
        {
            var collection = DetermineCollection(item.Name);

            collection.Add(item);
            collection.Sort(new NameComparer<T>());
        }

        private List<T> DetermineCollection(string name)
        {
            try
            {
                var cultureInfo = _cultureResolver.GetCultureInfo(name);

                return _cultureCollection[cultureInfo];
            }
            catch
            {
                if (Regex.IsMatch(name[0].ToString(), "[0-9]"))
                {
                    return _additionalCollection[AdditionalKeys.Number];
                }

                return _additionalCollection[AdditionalKeys.Special];
            }
        }
    }
}