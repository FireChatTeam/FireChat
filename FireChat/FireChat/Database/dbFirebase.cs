using Firebase.Database;
using Firebase.Database.Query;
using FireChat.Models;
using FireChat.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireChat.Database
{
    class dbFirebase
    {
        public static readonly String URL = "https://chat-xamarin.firebaseio.com/";
        public static readonly String CHATS = "ChatApp";
         FirebaseClient fbClient;

        public dbFirebase()
        {
            fbClient = new FirebaseClient(URL);
        }

        public async Task<List<Room>> getRoomList()
        {

            var list = await fbClient.Child(CHATS).OnceAsync<Room>();
            List<Room> listRooms = new List<Room>();
            List<FirebaseObject< Room>> li= list.ToList();
            foreach(var i in li)
            {
                Room r = i.Object;
                r.Key = i.Key;
                listRooms.Add(i.Object);
            }
            return listRooms;
        }

        public async Task<Room> saveRoom(Room rm)
        {
            await fbClient.Child(CHATS)
                    .PostAsync(rm);
            List<Room> lista = getRoomList().Result;
            foreach(Room room in lista)
            {
                if (room.Name.Equals(rm.Name))
                {
                    return room;
                }
            }
            return null;
        }

    }
}
