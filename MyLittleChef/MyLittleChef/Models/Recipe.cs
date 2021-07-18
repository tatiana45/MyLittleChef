using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLittleChef.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public int Rating { get; set; }
        public int CookTime { get; set; }
        public string Type { get; set; }

        public Recipe() { }

        public Recipe(string title, string ingredients, string instructions, string type, int cookTime, int rating)
        {
            Title = title;
            Ingredients = ingredients;
            Instructions = instructions;
            Type = type;
            CookTime = cookTime;
            Rating = rating;
        }

        public bool IsValidNumber(string number)
        {
            int value;
            if (Int32.TryParse(number, out value))
            {
                return true;
            }
            return false;
        }

        public bool IsValidRating(string rating)
        {
            double value;
            if (double.TryParse(rating, out value))
            {
                if (value >= 0 && value <= 5)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
