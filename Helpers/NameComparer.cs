using System.Collections.Generic;
using HomeWork.Models;

namespace HomeWork.Helpers
{
    public class NameComparer<T> : IComparer<T>
        where T : Contact
    {
        public int Compare(T x, T y)
        {
            return string.CompareOrdinal(x?.Name, y?.Name);
        }
    }
}