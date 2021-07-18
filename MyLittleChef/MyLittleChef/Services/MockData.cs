using MyLittleChef.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLittleChef.Services
{
    public class MockData
    {
        public static List<Recipe> GetRecipes()
        {
            var recipesList = new List<Recipe>();

            var pulledPorkRecipe = new Recipe
            {
                Title = "Pulled Pork Roast",
                CookTime = 180,
                Type = "American",
                Rating = 4,
                Ingredients = "1 pork shoulder, 2 colves garlic, 1 onion, chicken stock, apple cider vinegar, barbeque sauce",
                Instructions = "1. Place pork shoulder into the slow cooker and pout in barbecue sauce, apple cide vinergar and chicken stock.\n" +
                "2. Mince garlic and onion and stir it in.\n" +
                "3. Cover and cook on High until the pork shreds easily with a fork."
            };
            recipesList.Add(pulledPorkRecipe);

            var bakedWholeChicken = new Recipe
            {
                Title = "Slow Cooking Whole Chicken",
                CookTime = 500,
                Type = "American",
                Rating = 5,
                Ingredients = "Whole chicken, salt, pepper, paprika",
                Instructions = "1. Season chicken with salt, pepper and paprika.\n" +
               "2. Place chicken inside the slow cooker and set slow cooker to high for an hour.\n" +
               "3. Turn it down to low and cook for another 8 hours or until chicken is cooked."
            };
            recipesList.Add(bakedWholeChicken);

            var fiveSpiceChickenWing = new Recipe
            {
                Title = "Chinese Five Spice Chicken Wing",
                CookTime = 45,
                Type = "Chinese",
                Rating = 5,
                Ingredients = "chicken wing, 4 colves garlic, 3 spring onions, 1tbs five spice powder, 2tbs soy sauce, 2tbs sweet chilli sauce",
                Instructions = "1. Whisk together garlic, spring onions, five spice, soy scause, chill sauce in a bowl.\n" +
                "2. Coat the chicken evenly with the sauce mixture and marrinate it for at least 8 hours.\n" +
                "3. Bake in the oven on 320F for 45 minutes."
            };
            recipesList.Add(fiveSpiceChickenWing);

            var pastaBolognese = new Recipe
            {
                Title = "Chunky Pasta Bolognese",
                CookTime = 40,
                Type = "Italian",
                Rating = 5,
                Ingredients = "1 onion, ground beef, mushrooms, peppers, garlic, tomato sauce",
                Instructions = "1. Cook onion until softend. Add groud beef and cook until it browned.\n" +
               "2. Add remaining vegetables and garlic and cook for 10 minutes.\n" +
               "3. Lastly add tomato sauce and simmer it for 20minutes."
            };
            recipesList.Add(pastaBolognese);

            var bakedSamosas = new Recipe
            {
                Title = "Golden Baked Samosas",
                CookTime = 30,
                Type = "Indian",
                Rating = 3,
                Ingredients = "150g plain flour, 1/4 teaspoon salt, nigella seeds, potato, egg white",
                Instructions = "1. Preheat oven to 400F.\n" +
              "2. Mix oil into flour and mix it well. Then add salt and nigella seeds, then knead into firm dough adding water as needed.\n" +
              "3. Divide and roll out discs size of dough. Fill it with potato mixture and seal the edge using water.\n" +
              "4. Bake for 25 minutes or until the samosas turn golden brown."
            };
            recipesList.Add(bakedSamosas);

            var berryCumble = new Recipe
            {
                Title = "Berry Crumble",
                CookTime = 40,
                Type = "American",
                Rating = 4,
                Ingredients = "Blackberries, raspberries, blueberries, sugar, flour, oats, cinnamon, butter",
                Instructions = "1. Preheat oven to 380F.\n" +
              "2. Gentaly mix blackberries, raspberries, blueberries and sugar together.\n" +
              "3. Combine flour, oats, brown sugar, cinnamon together. Rub in butter until it evenly mixed.\n" +
              "4. Lay it out in a baking dish and cover it with berries. Bake it for 30 minutes or until topping is golden brown."
            };
            recipesList.Add(berryCumble);

            return recipesList;
        }
    }
}
