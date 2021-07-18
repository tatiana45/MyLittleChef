using MyLittleChef.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyLittleChef.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopularRecipe : ContentPage
    {
        public ObservableCollection<RecipeApi> observeRecipeList = new ObservableCollection<RecipeApi>();
        public Dictionary<string, string> mealTypeDic = new Dictionary<string, string>
        {
            { "All", "all" },
            { "Appetizer", "appetizer" },
            { "Breakfast", "breakfast" },
            { "Dessert", "dessert" },
            { "Main Course", "mainCourse" },
            { "Salad", "salad" },
            { "Vegan", "vegan" },
            { "Soup", "soup" }
        };
        public PopularRecipe()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
           if (observeRecipeList.Count == 0)
            {
                CategoryPicker.SelectedIndex = 0;
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://rapidapi.p.rapidapi.com/recipes/random?number=5"),
                    Headers =
                {
                    { "x-rapidapi-key", "47b2907739msh814e7268b8effebp17c619jsn97e1cb8c488c" },
                    { "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" }
                }
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var recipes = JsonConvert.DeserializeObject<RecipeApiList>(content);
                    observeRecipeList = new ObservableCollection<RecipeApi>(recipes.Recipes);
                    recipeListView.ItemsSource = observeRecipeList;
                }
            }
            base.OnAppearing();
        }

        private void recipeListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var recipe = (RecipeApi)e.SelectedItem;
            Launcher.OpenAsync(new Uri(recipe.SourceUrl));
        }

        private void searchButton_Clicked(object sender, EventArgs e)
        {
            var tag = (string)CategoryPicker.SelectedItem;
            this.SearchNewRecipe(tag);
        }

        private async void SearchNewRecipe(string tag)
        {
            var queryParamTag = mealTypeDic[tag];
            var uri = "https://rapidapi.p.rapidapi.com/recipes/random?number=5";
            if (!queryParamTag.Equals("all"))
            {
                uri = String.Concat(uri, $"&tags={ queryParamTag }");
            }
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),
                Headers =
                {
                    { "x-rapidapi-key", "47b2907739msh814e7268b8effebp17c619jsn97e1cb8c488c" },
                    { "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var recipes = JsonConvert.DeserializeObject<RecipeApiList>(content);
                observeRecipeList = new ObservableCollection<RecipeApi>(recipes.Recipes);
                recipeListView.ItemsSource = observeRecipeList;
                recipeListView.Position = 0;
            }
        }

        private void ButtonRecipe_Clicked(object sender, EventArgs e)
        {
            var recipePosition = recipeListView.Position;
            var recipe = observeRecipeList[recipePosition];
            Launcher.OpenAsync(new Uri(recipe.SourceUrl));
        }
    }
}