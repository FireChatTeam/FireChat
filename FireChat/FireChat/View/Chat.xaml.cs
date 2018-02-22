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
        ObservableCollection<Mensaje> mensajeList = new ObservableCollection<Mensaje>();
        public Chat ()
		{
			InitializeComponent ();

            _lstChat.ItemsSource = mensajeList;

            Mensaje m1 = new Mensaje();
            Mensaje m2 = new Mensaje();

            m1.UserName = "Miguel Puertas";
            m1.UserMessage = "No me gusta Xamarin gente :(";

            m2.UserName = "Miguel Paramos";
            m2.UserMessage = "Poooos te aguantas!";

            mensajeList.Add(m1);
            mensajeList.Add(m2);
        }
	}
}