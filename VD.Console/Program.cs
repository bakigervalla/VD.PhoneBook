using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.PhoneBook.Model;
using VD.PhoneBook.Services;

namespace VD.ContactConsole
{
    class Program
    {

        static void Main(string[] args)
        {

            IPhoneBook service = new PhoneBookService();

            var contacsList = new List<Contact> {
                new Contact
                {
                    Name = "Baki",
                    LastName = "Gervalla",
                    Phones = new List<Phone> {
                        new Phone { Type = "Work", Number = "044287715" },
                        new Phone { Type = "Home", Number = "049494949" }
                    }
                },
                new Contact
                {
                    Name = "Denart",
                    LastName = "Prishtina",
                    Phones = new List<Phone> { new Phone { Type = "Home", Number = "044123123" } }
                },
                new Contact
                {
                    Name = "Urani",
                    LastName = "England",
                    Phones = new List<Phone> { new Phone { Type = "Cellphone", Number = "044287715" } }
                }
            };

            service.Add(contacsList)
                .Save();

            ShowContacts(
                service.GetContacts().OrderByFirstName()
                );


            Console.WriteLine("Type F or L to order the list. Type D to delete a contact.");
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.F:
                    Console.Clear();
                    ShowContacts(service.GetContacts().OrderByFirstName());
                    break;
                case ConsoleKey.L:
                    Console.Clear();
                    ShowContacts(service.GetContacts().OrderByLastName());
                    break;
                case ConsoleKey.D:
                    Console.WriteLine("Type contact name you want to delete");
                    var name = Console.ReadLine();

                    var contact = contacsList.FirstOrDefault(x => x.Name.Equals(name));

                    if (contact == null)
                        return;

                    service.Delete(contact);

                    Console.Clear();

                    ShowContacts(service.GetContacts().OrderByFirstName());

                    break;
            }

            Console.ReadLine();

        }

        static void ShowContacts(IEnumerable<Contact> list)
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Contacts");
            Console.WriteLine("=============================");

            foreach (var contact in list)
            {
                Console.WriteLine(contact.ToString());
            }
        }

    }
}
