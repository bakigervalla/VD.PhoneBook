using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.PhoneBook.Model;
using VD.PhoneBook.Store;

namespace VD.PhoneBook.Services
{
    public class PhoneBookService : IPhoneBook, IFilter
    {

        /// <summary>
        /// Contacts repository
        /// </summary>
        public Repository repository;

        /// <summary>
        /// List of contacts 
        /// </summary>
        public List<Contact> Contacts { get; set; }

        /// <summary>
        /// Initialize Repository and Contacts list in the constructor
        /// </summary>
        public PhoneBookService()
        {
            repository = new Repository(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "phone_book.txt"));
            Contacts = new List<Contact>();
        }

        /// <summary>
        /// Store contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>return Reference to self object</returns>
        [STAThread]
        public PhoneBookService Add(Contact contact)
        {
            if (GetContact(contact.Name, contact.LastName))
                throw new Exception("Contact already exists");

            Contacts.Add(contact);

            return this;
        }

        /// <summary>
        /// Store multiple Contact
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns>return Reference to self object</returns>
        [STAThread]
        public PhoneBookService Add(IList<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                if (GetContact(contact.Name, contact.LastName))
                    throw new Exception("Contact already exists");

                Contacts.Add(contact);
            }

            return this;
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>reference to self</returns>
        [STAThread]
        public PhoneBookService Delete(Contact contact)
        {
            if (!GetContact(contact.Name, contact.LastName))
                throw new Exception("Contact does not exist");

            Contacts.Remove(contact);

            return this;
        }

        /// <summary>
        /// Modify contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>reference to self</returns>
        [STAThread]
        public PhoneBookService Edit(Contact contact)
        {
            if (!GetContact(contact.Name, contact.LastName))
                throw new Exception("Contact does not exist");

            Contacts.Remove(contact);
            Contacts.Add(contact);

            return this;
        }

        /// <summary>
        /// Persist data to db file
        /// </summary>
        /// <returns>returns true if sucess</returns>
        public bool Save()
        {
            return repository.Save(Contacts);
        }

        /// <summary>
        /// Save Contacts to store
        /// </summary>
        /// <returns>return Reference to self object</returns>
        [STAThread]
        public PhoneBookService GetContacts()
        {
            Contacts = repository.GetContacts().ToList();
            return this;
        }

        /// <summary>
        /// Sort contacts by FirstName
        /// </summary>
        /// <returns>return contacts list</returns>
        public IList<Contact> OrderByFirstName()
        {
            return Contacts.OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// Sort contacts by LastName
        /// </summary>
        /// <returns>return contacts list</returns>
        public IList<Contact> OrderByLastName()
        {
            return Contacts.OrderBy(x => x.LastName).ToList();
        }

        /// <summary>
        /// Check if contact exist
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>true if contact exist</returns>
        private bool GetContact(string firstName, string lastName)
        {
            return Contacts.Count(x => x.Name == firstName && x.LastName == lastName) > 0;
        }
    }
}
