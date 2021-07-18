using MyLittleChef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyLittleChef.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRecipePage : ContentPage
    {
        public Recipe recipe;
        public bool isEdit;

        public AddRecipePage()
        {
            InitializeComponent();
            Title = "Add New Recipe";
            DeleteButton.Text = "Cancel";
            this.recipe = new Recipe();
        }

        public AddRecipePage(Recipe _recipe)
        {
            this.isEdit = true;
            InitializeComponent();
            Title = "Edit Recipe";
            this.recipe = _recipe;

            Name.Text = this.recipe.Title;
            CookTime.Text = this.recipe.CookTime.ToString();
            Rating.Text = this.recipe.Rating.ToString();
            Type.Text = this.recipe.Type;
            Ingredients.Text = this.recipe.Ingredients;
            Instructions.Text = this.recipe.Instructions;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            var recipeName = Name.Text;
            var cookTime = CookTime.Text;
            var rating = Rating.Text;
            var type = Type.Text;
            var ingredients = Ingredients.Text;
            var instructions = Instructions.Text;
            if (string.IsNullOrEmpty(recipeName) || string.IsNullOrEmpty(cookTime) || string.IsNullOrEmpty(rating) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(ingredients) || string.IsNullOrEmpty(instructions))
            {
                await DisplayAlert("Action Required", "Please fill in all the fields", "Ok");
            }
            else if (!this.recipe.IsValidNumber(cookTime))
            {
                await DisplayAlert("Action Required", "Cook time can only accept numbers", "Ok");
            }
            else if (!this.recipe.IsValidRating(rating)) {
                await DisplayAlert("Action Required", "Please provide a rating between 0-5", "Ok");
            }
            else
            {
                var cookTimeNum = Int32.Parse(cookTime);
                var ratingNum = Int32.Parse(rating);
                if (isEdit)
                {
                    this.recipe.Title = recipeName;
                    this.recipe.CookTime = cookTimeNum;
                    this.recipe.Rating = ratingNum;
                    this.recipe.Type = type;
                    this.recipe.Ingredients = ingredients;
                    this.recipe.Instructions = instructions;
                    await App.Database.SaveRecipeAsync(this.recipe);
                    await Navigation.PopAsync();
                } else
                {
                    var tempRecipe = new Recipe(recipeName, ingredients, instructions, type, cookTimeNum, ratingNum);
                    await App.Database.SaveRecipeAsync(tempRecipe);
                    await Navigation.PopAsync();
                }
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (isEdit)
            {
                var prompt = await DisplayAlert("Warning", "Are you sure you want to delete this recipe?", "Delete", "Cancel");
                if (prompt)
                {
                    await App.Database.DeleteRecipeAsync(this.recipe);
                    await Navigation.PopAsync();
                }
            } else
            {
                await Navigation.PopAsync();
            }
        }
    }
}