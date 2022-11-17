using RecipeBook.Database;
using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeList : ContentPage
    {
        public RecipeList()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var recipes = await SqliteDatabase.GetRecipesAsync();
            listView.ItemsSource = recipes;
        }
        
        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var button = ((ImageButton)sender);
            var recipe = button.CommandParameter as Recipe;
            var result = await SqliteDatabase.DeleteRecipeAsync(recipe);
            
            if (result == 1)
            {
                await DisplayAlert("Success", "Recipe has been deleted", "OK");
                OnAppearing();
            }
           
        }

        private async Task OpenAnimation(View view, uint length = 250)
        {
            view.RotationX = -90;
            view.IsVisible = true;
            view.Opacity = 0;
            _ = view.FadeTo(1, length);
            await view.RotateXTo(0, length);
        }

        private async Task CloseAnimation(View view, uint length = 250)
        {
            _ = view.FadeTo(0, length);
            await view.RotateXTo(-90, length);
            view.IsVisible = false;
        }

        private async void MainExpander_Tapped(object sender, EventArgs e)
        {
            var expander = sender as Expander;
            var detailsView = expander.FindByName<Grid>("DetailsView");

            if (expander.IsExpanded)
            {
                
                await OpenAnimation(detailsView);
            }
            else
            {
                await CloseAnimation(detailsView);
     
            }
        }
    }
}