using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class Program_UI
{
    private readonly Challenge1_Repo _menuRepo = new Challenge1_Repo();
    public void Run()
    {
        SeedData();
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("~~~~~~ Welcome to Komodo Cafe! ~~~~~~");
            System.Console.WriteLine("Please Make A Selection:\n" +
            "1. Create A Menu Item\n" +
            "2. See All Menu Items\n" +
            "3. Find Menu Item By ID\n" +
            "4. Delete A Menu Item\n" +
            "10. Close Application\n");
            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    CreateMenuItem();
                    break;

                case "2":
                    SeeAllMenuItems();
                    break;

                case "3":
                    FindMenuItemByID();
                    break;

                case "4":
                    DeleteMenuItem();
                    break;

                case "10":
                    isRunning = CloseApplication();
                    break;

                default:
                    System.Console.WriteLine("Invalid Selection!");
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }

    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thanks For Using Our Application! \n" +
        "Have a Great Day!");
        PressAnyKeyToContinue();
        return false;
    }

    private void DeleteMenuItem()
    {
        Console.Clear();

        PressAnyKeyToContinue();
    }

    private void FindMenuItemByID()
    {
        Console.Clear();

        PressAnyKeyToContinue();
    }

    private void SeeAllMenuItems()
    {
        Console.Clear();

        PressAnyKeyToContinue();
    }

    private void CreateMenuItem()
    {
        Console.Clear();


        PressAnyKeyToContinue();
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press Any Key To Continue!");
        Console.ReadKey();
    }

    private void SeedData()
    {
        MenuItems menuItem1 = new MenuItems("Americano","Espresso with Water (Basically A Plain Black Coffee.","Espresso, Water", 2.00);
        MenuItems menuItem2 = new MenuItems("Latte","Espresso with Steamed Milk. Can Be Served Hot or Iced.","Espresso, Milk of Choice", 3.50);
        MenuItems menuItem3 = new MenuItems("Cappuccino","Espresso Topped with Frothed Steamed Milk.","Espresso, Milk of Choice", 3.50);
        MenuItems menuItem4 = new MenuItems("Cold Brew","Espresso Grounds That Have Been Steeped in Water for Several Hours","Espresso, Water", 2.50);
        MenuItems menuItem5 = new MenuItems("Bagel w/ Cream Cheese","Everything Bagel with Cream Cheese. Can Substitute with Vegan Cream Cheese","Bagel, cream cheese", 4.50);
        MenuItems menuItem6 = new MenuItems("Scone","Choose From: Chocolate, Vanilla, Sausage/Egg/Cheese, Spinach/Egg/Cheese.","Flour, Butter, Cream, Egg, Baking Powder, Salt, Sugar. Please Ask Barista For Complete List Depending On What You Get.", 2.00);
        MenuItems menuItem7 = new MenuItems("Muffin","Choose From: Oatmeal Raisin, Chocolate, Blueberry.","Flour, Egg, Butter, Sugar, Salt. Please Ask Barista For Complete List Depending On Which One You Get.", 2.00);
        MenuItems menuItem8 = new MenuItems("Breakfast Sandwich","Choose From: Sausage/Egg/Cheese, Bacon/Egg/Cheese, Spinach/Egg/Cheese","English Muffin, Choice of Cheese, Choice of Meat", 2.00);
        
        _menuRepo.AddMenuItem(menuItem1);
        _menuRepo.AddMenuItem(menuItem2);
        _menuRepo.AddMenuItem(menuItem3);
        _menuRepo.AddMenuItem(menuItem4);
        _menuRepo.AddMenuItem(menuItem5);
        _menuRepo.AddMenuItem(menuItem6);
        _menuRepo.AddMenuItem(menuItem7);
        _menuRepo.AddMenuItem(menuItem8);
    }
}
