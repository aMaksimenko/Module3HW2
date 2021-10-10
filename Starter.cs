using System;
using HomeWork.Collections.Abstractions;
using HomeWork.Models;

namespace HomeWork
{
    public class Starter
    {
        private readonly IPhoneBook<Contact> _phoneBook;

        public Starter(IPhoneBook<Contact> phoneBook)
        {
            _phoneBook = phoneBook;
        }

        public void Run()
        {
            FillWithContacts();

            var x = _phoneBook["Ан"];

            foreach (var i in x)
            {
                Console.WriteLine(i.Name);
            }
        }

        public void FillWithContacts()
        {
            _phoneBook.Add(new Contact()
            {
                Name = "Bob", LastName = "Smith"
            });
            _phoneBook.Add(new Contact()
            {
                Name = "Антон", LastName = "Жевский"
            });
            _phoneBook.Add(new Contact()
            {
                Name = "Анна", LastName = "Филипова"
            });
            _phoneBook.Add(new Contact()
            {
                Name = "0382718", LastName = "321321"
            });
            _phoneBook.Add(new Contact()
            {
                Name = "||||||", LastName = "321321"
            });
            _phoneBook.Add(new Contact()
            {
                Name = "Гриша", LastName = "Чешский"
            });
            _phoneBook.Add(new Contact()
            {
                Name = "Богдан", LastName = "Бабичев"
            });
            _phoneBook.Add(new Contact()
            {
                Name = "Андрей", LastName = "Бобский"
            });
            _phoneBook.Add(new Contact()
            {
                Name = "John", LastName = "Gordon"
            });
        }
    }
}