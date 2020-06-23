using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.PhoneBook.Model;

namespace VD.PhoneBook.Store
{
    public class Repository : IRepository
    {

        private string Path { get; set; } = string.Empty;

        public Repository(string filePath)
        {
            this.Path = filePath;

            // Clear db file if exist
            if (File.Exists(filePath))
                File.WriteAllText(filePath, string.Empty);
            else
                File.Create(filePath);
        }

        /// <summary>
        /// Store Contacts
        /// Return true if saved successfully otherwise false
        /// </summary>
        /// <param name="contact"></param>
        public bool Save(IList<Contact> contacts)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(Path, FileMode.Open)))
                {
                    foreach (var contact in contacts)
                        writer.Write(contact.ToString());
                }

                return true;
            }
            catch (IOException ioe)
            {
                throw;
            }
        }

        /// <summary>
        /// Read all contatcs from the store
        /// </summary>
        public IEnumerable<Contact> GetContacts()
        {
            string line;
            Contact c = null;

            using (var file = new StreamReader(Path))
            {
                var list = new List<Contact>();

                while ((line = file.ReadLine()) != null)
                {
                    var record = line.Split(' ');

                    if (!record[0].Equals("*"))
                    {
                        if (c != null)
                            list.Add(c);

                        c = new Contact
                        {
                            Id = record[0],
                            Name = record[1],
                            LastName = record[2],
                            Phones = new List<Phone>()
                        };
                    }
                    else
                    {
                        // read phone list
                        c.Phones = new List<Phone>
                        {
                            new Phone { Type = record[1], Number = record[2] }
                        };
                    }
                }

                list.Add(c);

                return list;
            }
        }

    }

}
