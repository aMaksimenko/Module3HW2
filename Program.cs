using HomeWork.Collections;
using HomeWork.Collections.Abstractions;
using HomeWork.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork
{
    internal class Program
    {
        private static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICultureResolver, CultureResolver>()
                .AddTransient<IPhoneBook<Contact>, PhoneBook<Contact>>()
                .AddTransient<Starter>()
                .BuildServiceProvider();
            var starter = serviceProvider.GetService<Starter>();

            starter?.Run();
        }
    }
}