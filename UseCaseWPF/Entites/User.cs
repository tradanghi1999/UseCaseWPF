using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Entites
{
    public class User
    {
        public Option<string> Email { get; }
        public Option<string> Password { get; }
        public Option<string> PhoneNumber { get; }
        public Option<int> PIN { get;}

        public User(
                    Option<string> email,
                    Option<string> password,
                    Option<string> phoneNumber,
                    Option<int> pin)
        {
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            PIN = pin;
        }


    }
}
