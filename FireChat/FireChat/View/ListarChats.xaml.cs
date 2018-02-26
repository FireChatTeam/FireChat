using FireChat.Models;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListarChats : ContentPage
	{
        public ObservableCollection<Room> chats { get; set; }
        public ListarChats ()
		{
            chats = new ObservableCollection<Room>();
            for(int i = 0; i < 5; i++)
            {
                chats.Add(new Room("Chat " + (i + 1)));
            }
			InitializeComponent ();
            lstView.ItemsSource = chats;
		}
	}
    
}
