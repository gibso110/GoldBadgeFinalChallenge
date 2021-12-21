using System;
using System.Collections.Generic;

namespace ChallengeOneRepo
{
    public class KomodoMenu
    {
        public KomodoMenu()
        {
        }

        public KomodoMenu(int mealNumber, string mealName, string ingredients, string mealDescription, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Ingredients = ingredients;
            Price = price;
            MealDescription = MealDescription;
        }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Ingredients { get; set; }
        public string MealDescription { get; set; }
        public double Price { get; set; }
    }

    public class MenuRepo
    {
        private readonly List<KomodoMenu> _menuItems = new List<KomodoMenu>();

        //Meal Number

        public int _MealNumberID = 0;



        //create
        public bool AddItemToMenu(KomodoMenu meal)
        {
            if (meal != null)
            {
                _MealNumberID++;
                meal.MealNumber = _MealNumberID;
                _menuItems.Add(meal);
                return true;
            };
            return false;

        }
        //read

        //read all items
        public List<KomodoMenu> _showMenu()
        {
            return _menuItems;
        }

        //Menu items by Meal ID Number

        public KomodoMenu MealByIDNumber(int id)
        {
            foreach (KomodoMenu menuItem in _menuItems)
            {
                if (menuItem.MealNumber == id)
                {
                    return menuItem;

                }



            }
            _showMenu();
            Console.WriteLine("Please enter a valid meal ID Number");
            return null;

        }


        //delete
        public bool DeleteMenuItem(int id)
        {

            KomodoMenu menuItemToDelete = MealByIDNumber(id);

            if (menuItemToDelete == null)
            {
                return false;
            }
            else
            {
                _menuItems.Remove(menuItemToDelete);
                return true;
            }
        }
    }

}
