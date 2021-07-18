using MyLittleChef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyLittleChef.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDisplayPage : ContentPage
    {
        public Recipe recipe;
        public RecipeDisplayPage(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
        }

        protected override void OnAppearing()
        {
            Title = this.recipe.Title;
            CookTime.Text = $"{ this.recipe.CookTime }min";
            Rating.Text = $"{this.recipe.Rating}/5";
            Type.Text = this.recipe.Type;
            Ingredients.Text = this.recipe.Ingredients;
            Instructions.Text = this.recipe.Instructions;
            base.OnAppearing();
        }

        private async void ButtonDeleteRecipe_Clicked(object sender, EventArgs e)
        {
            var prompt = await DisplayAlert("Warning", "Are you sure you want to delete this recipe?", "Delete", "Cancel");
            if (prompt)
            {
                await App.Database.DeleteRecipeAsync(this.recipe);
                await Navigation.PopToRootAsync();
            }
        }

        private async void ButtonEditRecipe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRecipePage(this.recipe));
        }

        private async void ShareButton_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = Instructions.Text,
                Title = "Recipe sharing"
            });
        }
    }
}