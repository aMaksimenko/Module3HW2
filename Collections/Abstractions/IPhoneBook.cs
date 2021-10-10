using System.Collections.Generic;

namespace HomeWork.Collections.Abstractions
{
    public interface IPhoneBook<T>
    {
        public IReadOnlyCollection<T> this[string key] { get; }

        public void Add(T item);
    }
}