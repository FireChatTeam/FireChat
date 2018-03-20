using System;
using System.Collections.Generic;
using System.Text;

namespace FireChat.Models
{
    public class User
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public User(string name, string password, string email)
        {
            this.Name = name;
            this.Password = password;
            this.Email = email;
        }


        public static User getDefaultUser()
        {
            return new User("cenec", "admincenec", "cenec@mail.es");
        }
    }
}
