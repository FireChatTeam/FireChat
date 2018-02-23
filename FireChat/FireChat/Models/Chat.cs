using System;
using System.Collections.Generic;
using System.Text;

namespace FireChat.Models
{
    public class ChatModel
    {
        public String Nombre { get; set; }
        public ChatModel(string Nombre)
        {
            this.Nombre = Nombre;
        }
    }
}
