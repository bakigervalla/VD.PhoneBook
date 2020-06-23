using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.PhoneBook.Model;

namespace VD.PhoneBook.Services
{
    public interface IFilter
    {
        /// <summary>
        /// Enumerate Contacts by First Name
        /// </summary>
        /// <returns>return contacts list</returns>
        IList<Contact> OrderByFirstName();

        /// <summary>
        /// Enumerate Contacts by Last Name
        /// </summary>
        /// <returns>return contacts list</returns>
        IList<Contact> OrderByLastName();

    }
}
