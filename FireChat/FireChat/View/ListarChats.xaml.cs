using FireChat.Models;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListarChats : ContentPage
	{
        public ObservableCollection<ChatModel> chats { get; set; }
        public ListarChats ()
		{
            chats = new ObservableCollection<ChatModel>();
            for(int i = 0; i < 5; i++)
            {
                chats.Add(new ChatModel("Chat " + (i + 1)));
            }
			InitializeComponent ();
            lstView.ItemsSource = chats;
		}
	}
    
}
