using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA20241219
{
    internal class Authors
    {
        private string firstname;
        private string lastname;

        public string Firstname
        {
            get => firstname;
            set
            {
                if (value.Length < 3 || value.Length > 32)
                    throw new Exception("Invalid firstname");
                firstname = value;
            }
        }

        public string Lastname
        {
            get => lastname;
            set
            {
                if (value.Length < 3 || value.Length > 32)
                    throw new Exception("Invalid lastname");
                lastname = value;
            }
        }

        public Guid Guid { get; set; }

        public Authors(string fullName)
        {
            string[] nameParts = fullName.Split(' ');
            if (nameParts.Length != 2)
                throw new ArgumentException("Invalid full name format");

            Firstname = nameParts[0];
            Lastname = nameParts[1];
            Guid = Guid.NewGuid();
        }
    }
}
