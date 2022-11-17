using RecipeBook.Database;
using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void registerBtn_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Register());
        }

        private async void loginBtn_Clicked(object sender, EventArgs e)
        {
        
            var result = await SqliteDatabase.LoginAsync(Username.Text, Password.Text);
            if (result != null)
            {
                await Navigation.PushAsync(new MainPage(result.Username));
            }
            else
            {
                await DisplayAlert("Failed", "User name or password is wrong!", "OK");
            }
            
        }
    }
}