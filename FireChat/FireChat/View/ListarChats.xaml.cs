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
	public partial class ListarChats : ContentPage
	{
        public ObservableCollection<String> chats { get; set; }
        public ListarChats ()
		{
            chats = new ObservableCollection<string>();
            for(int i = 0; i < 5; i++)
            {
                chats.Add("Chat " + (i + 1));
            }
			InitializeComponent ();
            lstView.ItemsSource = chats;
		}
	}
    
}
