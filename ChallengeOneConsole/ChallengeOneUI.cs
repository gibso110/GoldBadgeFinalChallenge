using ChallengeOneRepo;
using System;
using System.Collections.Generic;

namespace ChallengeOneConsole
{
    class ChallengeOneUI
    {
        //New Instance of KomodoMenu
        private KomodoMenu _KomodoMenu = new KomodoMenu();

        //New instance of MenuRepo

        private MenuRepo _MenuRepo = new MenuRepo();

        //Run program function
        public void Run()
        {
            menu();
        }

        //program Menu

        public void menu()
        {
            bool keepRunning = true;
            while (keepRunning == true)
            {
                //display all options

                Console.WriteLine("What Would you like to do?\n" +
                   "1. Create a new menu item.\n" +
                   "2. View current menu items.\n" +
                   "3. View menu items by menu order number.\n" +
                   "4. Delete a menu item\n" +
                   "5. Exit the program.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        ViewAllMenuItems();
                        break;
                    case "3":
                        ViewMenuItemByNumber();
                        break;
                    case "4":
                        DeleteMenuItem();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid Number");
                        menu();
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();


            }

        }

        private void CreateNewMenuItem()
        {
            KomodoMenu newItem = new KomodoMenu();
            Console.WriteLine("Enter Items Name:");
            newItem.MealName = Console.ReadLine();
            Console.WriteLine("Enter a description for your new meal:");
            newItem.MealDescription = Console.ReadLine();
            Console.WriteLine("Enter the ingredients of the meal separated by commas:");
            newItem.Ingredients = Console.ReadLine();
            Console.WriteLine("Enter a price for the new item:");
            newItem.Price = double.Parse(Console.ReadLine());
            _MenuRepo.AddItemToMenu(newItem);
        }

        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<KomodoMenu> menuItems = _MenuRepo._showMenu();
            foreach (KomodoMenu menu in menuItems)
            {
                Console.WriteLine($"Item Name: {menu.MealName}\n" +
                    $"Meal Number: {menu.MealNumber}\n" +
                    $"Meal Description: {menu.MealDescription}\n" +
                    $"Meal Ingredients: {menu.Ingredients}\n" +
                    $"Meal Price: ${menu.Price}\n");
            }
        }

        private void ViewMenuItemByNumber()
        {
            Console.Clear();
            Console.WriteLine("What is the items' menu number:");
            int menuNum = int.Parse(Console.ReadLine());
            KomodoMenu menuItem = _MenuRepo.MealByIDNumber(menuNum);
            if (menuItem != null)
            {
                Console.WriteLine($"Item Name: {menuItem.MealName}\n" +
                    $"Meal Number: {menuItem.MealNumber}\n" +
                    $"Meal Description: {menuItem.MealDescription}\n" +
                    $"Meal Ingredients: {menuItem.Ingredients}\n" +
                    $"Meal Price: ${menuItem.Price}\n");
            }
            else
            {
                Console.WriteLine("There is no meal with that menu number.");
            }
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            ViewAllMenuItems();
            Console.WriteLine("Enter the menu number of the item that you would like to delete:");
            int menuNum = int.Parse(Console.ReadLine());
            bool wasDeleted = _MenuRepo.DeleteMenuItem(menuNum);

            if (wasDeleted == true)
            {
                Console.WriteLine("The item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The item could not be deleted.");
            }

        }
    }
}

