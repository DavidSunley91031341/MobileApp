using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyMerchandisersPage : ContentPage
	{
		public MyMerchandisersPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Merchandiser>();

                var merchandisers = conn.Table<Merchandiser>().ToList();
                merchandiserListView.ItemsSource = merchandisers;
            }
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewMerchandiserPage());
        }
    }
}