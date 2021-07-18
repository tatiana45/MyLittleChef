using MyLittleChef.Models;
using MyLittleChef.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyLittleChef.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyRecipePage : ContentPage
    {
        public ObservableCollection<Recipe> observeRecipeListView;

        public MyRecipePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            var myRecipes = await App.Database.GetRecipesAsync();

            if (myRecipes.Count == 0)
            {
                var mockRecipes = generateMockData();
                mockRecipes.ForEach(recipe =>
                {
                    myRecipes.Add(recipe);
                });
            }

            observeRecipeListView = new ObservableCollection<Recipe>(myRecipes);
            recipeListView.ItemsSource = observeRecipeListView;
            base.OnAppearing();
        }

        private List<Recipe> generateMockData()
        {
            var recipeList = MockData.GetRecipes();
            recipeList.ForEach(async recipe =>
            {
                await App.Database.SaveRecipeAsync(recipe);
            });
            return recipeList; 
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRecipePage());
        }

        private async void recipeListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedRecipe = (Recipe)e.SelectedItem;
            await Navigation.PushAsync(new RecipeDisplayPage(selectedRecipe));
        }
    }
}