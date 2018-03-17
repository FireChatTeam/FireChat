using FireChat.Database;
using FireChat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireChat.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Chat : ContentPage
	{
        private ObservableCollection<Message> mensajeList;
        private dbFirebase db = new dbFirebase();
        private List<Message> list = new List<Message>();
        private string currentRoomKey;


        public Chat (string roomkey)
		{
			InitializeComponent ();

            currentRoomKey = roomkey;

            mensajeList = new ObservableCollection<Message>();
            _lstChat.ItemsSource = mensajeList;

            actualizarMensajes();
        }

        private void actualizarMensajes()
        {
            Task.Run(() =>
            {
                list = db.getMessageList(currentRoomKey).Result;
                mensajeList.Clear();
                foreach (Message m in list)
                {
                    mensajeList.Add(m);
                }
            });
        }

        public void OnTap(Object sender, EventArgs args)
        {
            Message m = new Message();
            m.UserName = "CENEC";
            m.UserMessage = _etMessage.Text;
            _etMessage.Text = "";
            Task.Run(async () =>
            {
                await db.saveMessage(m, currentRoomKey);
                actualizarMensajes();
            });

        }
    }
}