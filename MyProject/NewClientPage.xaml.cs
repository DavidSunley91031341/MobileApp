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
	public partial class NewClientPage : ContentPage
	{
		public NewClientPage ()
		{
			InitializeComponent ();
		}

        private void AddClient_Clicked(object sender, EventArgs e)
        {
            Client client = new Client()
            {
                Name = nameEntry.Text,
                Description = descriptionEntry.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Client>();
                var numberOfRows = conn.Insert(client);

                if (numberOfRows > 0)
                    DisplayAlert("Success!", "New Client Added", "Ok");
                else
                    DisplayAlert("Failure", "Client Not Added", "Ok");
            }
        }
    }
}