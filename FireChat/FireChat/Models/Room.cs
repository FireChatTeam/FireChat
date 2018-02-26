using System;
using System.Collections.Generic;
using System.Text;

namespace FireChat.Models
{
    public class Room
    {
        public Room(String name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }
    }
}
