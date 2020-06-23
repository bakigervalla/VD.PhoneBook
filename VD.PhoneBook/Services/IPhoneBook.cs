using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.PhoneBook.Model;

namespace VD.PhoneBook.Services
{
    public interface IPhoneBook
    {
        /// <summary>
        /// Add Contact
        /// Contact should be unique based on Name + LastName
        /// </summary>
        /// <param name="contact"></param>
        PhoneBookService Add(Contact contact);

        /// <summary>
        /// Add multiple Contact
        /// Contact should be unique based on Name + LastName
        /// </summary>
        /// <param name="contact"></param>
        PhoneBookService Add(IList<Contact> contacts);

        /// <summary>
        /// Edit Contact info
        /// </summary>
        /// <param name="contact"></param>
        PhoneBookService Edit(Contact contact);

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="contact"></param>
        PhoneBookService Delete(Contact contact);

        /// <summary>
        /// Get Contacts from store
        /// </summary>
        /// <returns>FluentApi: return Reference to self object</returns>
        PhoneBookService GetContacts();

    }
}
