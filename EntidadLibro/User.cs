using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesApi
{
    public class User
    {
        //Atributos del Usuario
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public long UserId { get; set; }
        public string Address { get; set; }
        public int MobilePhoneNumber { get; set; }
        public string Email { get; set; }

        //Constructor vacio
        public User()
        {
        }

        //Constructor con argumentos
        public User(string name, DateTime birthDate, long userId, string address, int mobilePhoneNumber, string email)
        {
            Name = name;
            birthDate = BirthDate;
            UserId = userId;
            Address = address;
            MobilePhoneNumber = mobilePhoneNumber;
            Email = email;
        }

        public string ShowTabulatedInfo()
        {
            StringBuilder message = new StringBuilder();
            message.Append(UserId);
            message.Append("\t\t");
            message.Append(Name);
            message.Append("\t\t");
            message.Append(BirthDate);
            message.Append("\t\t");
            message.Append(Address);
            message.Append("\t\t");
            message.Append(MobilePhoneNumber);

            return message.ToString();
        }
    }
}
