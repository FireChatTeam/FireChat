using FireChat.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FireChat.Models;
using FireChat.View;
using Plugin.Notifications;

namespace FireChat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private dbFirebase db = dbFirebase.getInstance();

        public LoginPage()
        {
            InitializeComponent();

        }

        void OnLoginTouched(object sender, EventArgs e)
        {
            User user = new User(txtName.Text, txtPassword.Text, "correo@correo.es");
            bool loginOK = false;

            Task t = Task.Run(() =>
            {
                loginOK = db.checkLogin(user).Result;
                Notification notification;
                if (loginOK)
                {
                    notification = new Notification
                    {
                        Title = "Login correcto",
                        Message = "Logeado como: " + user.Name,
                        Vibrate = Preferencias.getVibracion()
                    };

                }
                else
                {
                    notification = new Notification
                    {
                        Title = "Login incorrecto",
                        Message = "Nombre o contraseña erróneos",
                        Vibrate = Preferencias.getVibracion()
                    };
                }
                CrossNotifications.Current.Send(notification);
            });
            while (!t.IsCompleted)
            {
                if (loginOK)
                {
                    Navigation.PushModalAsync(new ListarChats(user));
                }
            }
        }

        void OnNameTouched(object sender, EventArgs e)
        {
            txtName.Text = "";
        }

        void OnPasswordTouched(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }
    }
}