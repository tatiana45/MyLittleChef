using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLittleChef.Models;

namespace UnitTestsMyLittleChef
{
    [TestClass]
    public class RecipeTest
    {
        [TestMethod]
        //Should return false when validate against a non numeric string
        public void isValidNumber_On_Non_Numeric ()
        {
            Recipe recipe = new Recipe();
            var expectedResult = false;

            var actualResult = recipe.IsValidNumber("abc");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        //Should return true when validate against a numeric string
        public void isValidNumber_On_Numeric()
        {
            Recipe recipe = new Recipe();
            var expectedResult = true;

            var actualResult = recipe.IsValidNumber("123");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        //Should return false when validate against a empty string
        public void isValidNumber_On_EmptyOrNull()
        {
            Recipe recipe = new Recipe();
            var expectedResult = false;

            var actualResult = recipe.IsValidNumber("");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        //Should return false when validate against string greater than 5
        public void IsValidRating_On_GreaterThan_5()
        {
            Recipe recipe = new Recipe();
            var expectedResult = false;

            var actualResult = recipe.IsValidRating("6");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        //Should return false when validate against string less than 0
        public void IsValidRating_On_LessThan_0()
        {
            Recipe recipe = new Recipe();
            var expectedResult = false;

            var actualResult = recipe.IsValidRating("-1");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        //Should return true when validate against string between 0 and 5
        public void IsValidRating_On_Between_0_And_5()
        {
            Recipe recipe = new Recipe();
            var expectedResult = true;

            var actualResult = recipe.IsValidRating("3");

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
