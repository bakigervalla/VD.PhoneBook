using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.PhoneBook.Model;

namespace VD.PhoneBook.Store
{
    public interface IRepository
    {

        /// <summary>
        /// Store Contacts
        /// Return true if saved successfully otherwise false
        /// </summary>
        /// <param name="contact"></param>
        bool Save(IList<Contact> contacts);

        /// <summary>
        /// Read all contatcs from the store
        /// </summary>
        IEnumerable<Contact> GetContacts();

    }
}
