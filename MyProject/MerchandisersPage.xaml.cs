using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MerchandisersPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public MerchandisersPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Ticket 1",
                "Ticket 2",
                "Ticket 3",
                "Ticket 4",
                "Ticket 5"
            };
			
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Lorem", "Ipsum", "Ok");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

    }
}
