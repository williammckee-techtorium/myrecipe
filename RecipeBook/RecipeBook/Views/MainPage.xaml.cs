using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RecipeBook.Model;
using RecipeBook.Database;
using RecipeBook.Views;

namespace RecipeBook
{
    public partial class MainPage : ContentPage
    {
        string _username;
        public MainPage(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void RecipeBookBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RecipeList());
        }

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            if (Title.Text != null && Description.Text != null && Ingredients.Text != null && Image.Text != null &&
                Title.Text != "" && Description.Text != "" && Ingredients.Text != "" && Image.Text != "") {

                var recipe = new Recipe
                {
                    Username = _username,
                    Title = Title.Text,
                    Description = Description.Text,
                    Ingredients = Ingredients.Text,
                    Image = Image.Text
                };

                int result = await SqliteDatabase.SaveRecipeAsync(recipe);
                if (result == 1)
                {
                    await DisplayAlert("Success", "Your recipe has been saved","OK");
                    Title.Text = "";
                    Description.Text = "";
                    Ingredients.Text = "";
                    Image.Text = "";
                }
        }

        }
    }
}
