﻿using FireChat.Database;
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
        private dbFirebase db = dbFirebase.getInstance();
        private string currentRoomKey;
        private User actualUser;

        public Chat (string roomkey, User actualUser)
		{
			InitializeComponent ();
            this.actualUser = actualUser;
            currentRoomKey = roomkey;

            _lstChat.ItemsSource = db.subChat(roomkey);
        }

        public void OnTap(Object sender, EventArgs args)
        {
            Message m = new Message();
            m.UserName = actualUser.Name;
            m.UserMessage = _etMessage.Text;
            _etMessage.Text = "";
            Task.Run(async () =>
            {
                await db.saveMessage(m, currentRoomKey);
            });

        }

        private void DesactivarIndicadorCarga()
        {
            activityIndicatorChat.IsVisible = false;
        }
    }
}