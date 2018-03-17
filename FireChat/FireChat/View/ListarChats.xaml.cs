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
        private static readonly string CREAR_CHAT = "CREAR NUEVA SALA", GUARDAR = "GUARDAR O CERRAR";
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

        private void modificado()
        {
            cargando(false);
        }

        private void cargando(bool isLoad)
        {
            activityIndicator.IsVisible = isLoad;
            lstView.IsVisible = !isLoad;
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
                list = db.getRoomList().Result;
                chats.Clear();
                foreach (Room r in list)
                {
                    chats.Add(r);
                }
            });
        }

        private void nuevoChat()
        {

            if (!string.IsNullOrWhiteSpace(entryNombre.Text))
            {
                bool continene = false;
                foreach (var ro in chats)
                {
                    continene = continene || ro.Name.Equals(entryNombre.Text);
                }
                if (!continene)
                {
                    activityIndicator.IsVisible = true;
                    lstView.IsVisible = false;
                    Task.Run(() =>
                    {
                        Room r = new Room { Name = entryNombre.Text };
                     
                        chats.Add(db.saveRoom(r).Result);
                    });
                }
                else
                {
                    DisplayAlert("ERROR","Ya existe una sala con un nombre igual", "Ok");
                }
                entryNombre.Text = "";
            }

            entryNombre.IsVisible = !entryNombre.IsVisible;
            labelNombre.IsVisible = entryNombre.IsVisible;
            buttonCrearChat.Text = (entryNombre.IsVisible) ? GUARDAR : CREAR_CHAT;
        }
    }
}
