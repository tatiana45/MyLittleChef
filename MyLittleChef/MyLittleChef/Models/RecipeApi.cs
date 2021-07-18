using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyLittleChef.Models
{
    public class RecipeApiList
    {
        public List<RecipeApi> Recipes { get; set; }
    }
    public class RecipeApi
    {
        public string Title { get; set; }
        public string SourceUrl { get; set; }
        public string Image { get; set; }
        public string Instructions { get; set; }
    }

    public class RecipeId
    {
        public int Id { get; set; }
    }
}
