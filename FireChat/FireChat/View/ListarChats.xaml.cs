using FireChat.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FireChat.Database;
using System.Threading.Tasks;

namespace FireChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarChats : ContentPage
    {
        private ObservableCollection<Room> chats { get; set; }
        private dbFirebase db = new dbFirebase();
        private Room rm = new Room();
        private List<Room> list = new List<Room>();

        public ListarChats()
        {
            InitializeComponent();
            chats = new ObservableCollection<Room>();
            lstView.ItemsSource = chats;

            actualizarChats();

        }


        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            DisplayAlert("Item Selected", ((Room)e.SelectedItem).Name, "Ok");
        }

        private void actualizarChats()
        {
            Task.Run(() =>
            {
                //activityIndicator.IsVisible = true;
               /// lstView.IsVisible = false;
               
                list = db.getRoomList().Result;
                chats.Clear();
                foreach (Room r in list)
                {
                    chats.Add(r);
                }
                //activityIndicator.IsVisible = false;
                //lstView.IsVisible = true;
            });
        }

        private void nuevoChat()
        {
            Task.Run(async () =>
            {
                Room r = new Room { Name = "Chat prueba en FB" };
                await db.saveRoom(r);
                actualizarChats();
            });
        }
    }
}
