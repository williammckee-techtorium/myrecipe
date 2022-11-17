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
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void registerBtn_Clicked(object sender, EventArgs e)
        {
            if (Password.Text != VerifiedPassword.Text)
            {
                await DisplayAlert("Failed", "Passwords are not matched", "OK");
                return;
            }
            var user = new User
            {
                Username =Username.Text,
                Password =Password.Text
            };
            int result = await SqliteDatabase.SaveUserAsync(user);
            if (result == 1)
            {
                await DisplayAlert("Success","User has been saved","OK");
                await Navigation.PopAsync();
            }
            else if(result == -1)
            {
                await DisplayAlert("Failed", "User is already exist!", "OK");
            }
            
        }
    }
}