using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.PhoneBook.Model
{
    public class Phone
    {
        /// <summary>
        /// Type of the PhoneNumer Work, Cellphone, Home
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Numer as string characters
        /// </summary>
        public string Number { get; set; }
    }
}
