using DapperApp.Library1.Models;
using DapperApp.Library1.Queries;
using System;

namespace DapperApp.ConsoleUI
{
    internal class Program
    {
        static PersonQueries personQueries = new PersonQueries();

        static void Main(string[] args)
        {
            //https://github.com/btkacademy/csharp-basic
            //https://github.com/btkacademy/design-patterns
            //https://www.learndapper.com
            CreatePerson();
            WritePersonList();
            UpdatePersom();
            WritePersonList();
            DeletePerson();
            WritePersonList();
            Filter();
        }
        private static void Filter()
        {
            Console.Write("Aramak İstediğiniz İsmi Giriniz:");
            string filter = Console.ReadLine();
            var persons = personQueries.Filter(filter);
            foreach (var person in persons)
            {
                Console.WriteLine("Id = {0}, Adı = {1}, Soyad = {2}",
                    person.Id,
                    person.Name,
                    person.Surname);
            }
        }

        private static void DeletePerson()
        {
            Console.Write("Lütfen  Silmek İstediğiniz İd Giriniz=");
            int Id = Convert.ToInt32(Console.ReadLine());
            personQueries.Delete(Id);
            Console.WriteLine($"Id={Id} olan  Kayıt Silinmiştir");
        }

        private static void UpdatePersom()
        {
            Console.WriteLine("Lütfen İd Giriniz");
            int Id = Convert.ToInt32(Console.ReadLine());
            var persons = personQueries.Get(Id);
            Console.WriteLine($"Name={persons.Name}");
            Console.WriteLine("Yeni İsim Giriniz");
            persons.Name = Console.ReadLine();
            Console.WriteLine($"Surname={persons.Surname}");
            Console.WriteLine("Yeni Soyisim Giriniz");
            persons.Surname = Console.ReadLine();
            personQueries.UpdatePerson(persons);
        }

        static void CreatePerson()
        {
            Person person = new Person();

            Console.Write("Adı = ");
            person.Name = Console.ReadLine();
            Console.Write("Soyadı = ");
            person.Surname = Console.ReadLine();

            personQueries.CreatePerson(person);
            Console.WriteLine("Kayıt eklendi id = {0}", person.Id);
        }
        static void WritePersonList()
        {
            var persons = personQueries.GetPersons();

            foreach (var person in persons)
            {
                Console.WriteLine("Id = {0}, Adı = {1}, Soyad = {2}",
                    person.Id,
                    person.Name,
                    person.Surname);
            }
        }

        //Update, Delete methodları yazılacak
        //Filtreli listeleme yapılabilir (Adı x ile başlayanları listelesin gibi ...)
    }
}
