using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.PhoneBook.Model
{
    public class Contact
    {
        /// <summary>
        /// Contact Id
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Contact Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Contact LastName
        /// </summary>
        public string LastName { get; set; }
       
        public IEnumerable<Phone> Phones { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} {1} {2}", Id, Name, LastName).AppendLine();

            foreach (var phone in Phones)
                sb.AppendFormat("* {0} {1}", phone.Type, phone.Number).AppendLine();

            return sb.ToString();
        }
    }
}
