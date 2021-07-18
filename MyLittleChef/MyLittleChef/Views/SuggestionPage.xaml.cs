using MyLittleChef.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyLittleChef.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuggestionPage : ContentPage
    {
        public ObservableCollection<RecipeApi> observeRecipeList = new ObservableCollection<RecipeApi>();
        public SuggestionPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void SearchNewRecipe(string ingredients)
        {
            Regex.Replace(ingredients, @"\s+", "");
            var queryParamIngredients = ingredients.Replace(",", "%2C%20");
            var uri = "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/findByIngredients?number=5&ranking=2&ignorePantry=true";
            if (!queryParamIngredients.Equals(""))
            {
                uri = String.Concat(uri, $"&ingredients={ queryParamIngredients }");
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
                var recipesId = JsonConvert.DeserializeObject<List<RecipeId>>(content);
                if (recipesId.Count > 0)
                {
                    this.GetRecipeById(recipesId);
                }
            }
        }

        private async void GetRecipeById(List<RecipeId> recipesIdList)
        {
            List<string> recipesId = new List<string>();
            recipesIdList.ForEach(recipe => {
                recipesId.Add(recipe.Id.ToString());
                });
            var recipesIdString = String.Join(",", recipesId);
            var queryParamRecipesId = recipesIdString.Replace(",", "%2C");
            var uri = "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/informationBulk";
            if (!queryParamRecipesId.Equals(""))
            {
                uri = String.Concat(uri, $"?ids={ queryParamRecipesId }");
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
                var recipes = JsonConvert.DeserializeObject<List<RecipeApi>>(content);

                observeRecipeList = new ObservableCollection<RecipeApi>(recipes);
                recipeListView.ItemsSource = observeRecipeList;
                recipeListView.Position = 0;
            }
        }

        private void searchButton_Clicked(object sender, EventArgs e)
        {
            var ingredientsText = IngredientSearch.Text;
            if (String.IsNullOrEmpty(ingredientsText))
            {
                observeRecipeList = new ObservableCollection<RecipeApi>();
                recipeListView.ItemsSource = observeRecipeList;
            } else
            {
                this.SearchNewRecipe(ingredientsText);
            }
        }

        private void ViewRecipeButton_Clicked(object sender, EventArgs e)
        {
            var recipePosition = recipeListView.Position;
            var recipe = observeRecipeList[recipePosition];
            Launcher.OpenAsync(new Uri(recipe.SourceUrl));
        }
    }
}