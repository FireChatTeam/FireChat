using FireChat.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FireChat
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
           InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e) { 
        
            Navigation.PushModalAsync(new Chat());
        }
    }
}
