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
	public partial class NewMerchandiserPage : ContentPage
	{
		public NewMerchandiserPage ()
		{
			InitializeComponent ();
		}

        private void AddMerchandiser_Clicked(object sender, EventArgs e)
        {
            Merchandiser merchandiser = new Merchandiser()
            {
                Name = nameEntry.Text,
                Contact = contactEntry.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Merchandiser>();
                var numberOfRows = conn.Insert(merchandiser);

                if (numberOfRows > 0)
                    DisplayAlert("Success!", "New Merchandiser Added", "Ok");
                else
                    DisplayAlert("Failure", "Merchandiser Not Added", "Ok");
            }
        }
    }
}