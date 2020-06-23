using NUnit.Framework;
using System.Collections.Generic;
using VD.PhoneBook.Model;
using VD.PhoneBook.Services;

namespace NUnitTest
{

    [TestFixture]
    public class PhoneBookTest
    {
        IPhoneBook service;

        [SetUp]
        public void Init()
        {
            service = new PhoneBookService();
        }

        [Test]
        public void AddContact()
        {
            Contact c = new Contact
            {
                Name = "Baki",
                LastName = "Gervalla",
                Phones = new List<Phone> {
                        new Phone { Type = "Work", Number = "044287715" },
                        new Phone { Type = "Home", Number = "049494949" }
                    }
            };

            Assert.DoesNotThrow(() => service.Add(c).Save());
        }

        [Test]
        public void GetContacts()
        {
            Assert.DoesNotThrow(() => service.GetContacts());
        }

        [Test]
        public void EditContact()
        {

            // Add a contact to be edited
            Contact newContact = new Contact
            {
                Name = "Baki",
                LastName = "Gervalla",
                Phones = new List<Phone> {
                        new Phone { Type = "Work", Number = "044287715" },
                        new Phone { Type = "Home", Number = "049494949" }
                    }
            };

            Assert.DoesNotThrow(() => service.Add(newContact));

            Contact c = new Contact
            {
                Id = "632928C2-648B-4C0F-87C9-2BC0AAE3B0B1",
                Name = "Baki",
                LastName = "Gervalla",
                Phones = new List<Phone> {
                         new Phone { Type = "Work", Number = "044400500" },
                         new Phone { Type = "Home", Number = "049100200" }
                    }
            };
            Assert.DoesNotThrow(() => service.Edit(c));
        }

        [Test]
        public void DeleteContact()
        {

            // Add a contact to be edited
            Contact newContact = new Contact
            {
                Name = "Baki",
                LastName = "Gervalla",
                Phones = new List<Phone> {
                        new Phone { Type = "Work", Number = "044287715" },
                        new Phone { Type = "Home", Number = "049494949" }
                    }
            };

            Assert.DoesNotThrow(() => service.Add(newContact));

            Contact c = new Contact
            {
                Id = "3632928C2-648B-4C0F-87C9-2BC0AAE3B0B1",
                Name = "Baki",
                LastName = "Gervalla",
                Phones = new List<Phone> {
                         new Phone { Type = "Work", Number = "044400500" },
                         new Phone { Type = "Home", Number = "049100200" }
                    }

            };

            Assert.DoesNotThrow(() => service.Delete(c));

        }

    }
}