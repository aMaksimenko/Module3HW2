using System.Globalization;

namespace HomeWork.Collections.Abstractions
{
    public interface ICultureResolver
    {
        public void Add(string cultureString);
        public CultureInfo GetCultureInfo(string stringToTest);
        public CultureInfo[] GetCultures();
    }
}