using FireChat.Database;
using FireChat.Models;
using Plugin.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireChat
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
        private dbFirebase db = dbFirebase.getInstance();

        public RegistrationPage ()
		{
			InitializeComponent ();
        }

        void OnRegisterTouched(object sender, EventArgs e)
        {
            User userToRegist = new User(txtName.Text, txtPassword1.Text, txtMail.Text);

            Task.Run(() =>
            {
                db.saveUser(userToRegist);
                Notification notification = new Notification
                    {
                        Title = "Registro correcto",
                        Message = "Registrado como: " + userToRegist.Name + 
                        " con password: " + userToRegist.Password + 
                        " y email: " + userToRegist.Email, 
                        Vibrate = Preferencias.getVibracion()
                    };
                CrossNotifications.Current.Send(notification);
            });
        }

        void OnNameTouched(object sender, EventArgs e)
        {
            txtName.Text = "";
        }

        void OnMailTouched(object sender, EventArgs e)
        {
            txtMail.Text = "";
        }


        void OnPasswordTouched1(object sender, EventArgs e)
        {
            txtPassword1.Text = "";
        }


        void OnPasswordTouched2(object sender, EventArgs e)
        {
            txtPassword2.Text = "";
        }

    }
}