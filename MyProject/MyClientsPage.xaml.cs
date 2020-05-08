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
	public partial class MyClientsPage : ContentPage
	{
		public MyClientsPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Client>();

                var clients = conn.Table<Client>().ToList();
                clientListView.ItemsSource = clients;
            }
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewClientPage());
        }
    }
}