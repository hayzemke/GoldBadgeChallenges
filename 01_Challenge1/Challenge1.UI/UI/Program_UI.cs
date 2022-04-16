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
        try
        {
            System.Console.WriteLine("Please Enter Item ID:");
            int itemID = int.Parse(Console.ReadLine());
            var selectedItem = _menuRepo.GetMenuItemByID(itemID);
            if (selectedItem != null)
            {
                bool isSuccessful = _menuRepo.RemoveMenuItem(selectedItem.ItemID);
                if (isSuccessful)
                {
                    System.Console.WriteLine("Item Successfully Removed!");
                }
                else
                {
                    System.Console.WriteLine("Item Was Not Removed!");
                }
            }
            else
            {
                System.Console.WriteLine("Item does not exist.");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry Invalid Selection.");
        }
        PressAnyKeyToContinue();
    }
    private void FindMenuItemByID()
    {
        Console.Clear();
        try
        {
            System.Console.WriteLine("Please Enter Item ID:");
            int itemID = int.Parse(Console.ReadLine());
            var selectedItem = _menuRepo.GetMenuItemByID(itemID);
            if (selectedItem != null)
            {
                DisplayMenuItems(selectedItem);
            }
            else
            {
                System.Console.WriteLine("Item does not exist.");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry Invalid Selection.");
        }
        PressAnyKeyToContinue();
    }
    private void SeeAllMenuItems()
    {
        Console.Clear();
        List<MenuItem> menuItems = _menuRepo.SeeAllMenuItems();
        foreach (MenuItem menuItem in menuItems)
        {
            DisplayMenuItems(menuItem);
        }
        PressAnyKeyToContinue();
    }
    private void DisplayMenuItems(MenuItem menuItems)
    {
        System.Console.WriteLine($"Item Id:{menuItems.ItemID}\nName:{menuItems.Name}\nDescription:{menuItems.Description}\nIngredients:{menuItems.Ingredients}\nPrice:{menuItems.Price}\n" +
        "---------------------------------");
    }
    private void CreateMenuItem()
    {
        Console.Clear();
        var newMenuItem = new MenuItem();
        System.Console.WriteLine("~~~ Create A New Menu Item ~~~~\n");
        System.Console.WriteLine("Name of Item:\n");
        newMenuItem.Name = Console.ReadLine();
        System.Console.WriteLine("Item Description:\n");
        newMenuItem.Description = Console.ReadLine();
        System.Console.WriteLine("Item Ingredients:\n");
        newMenuItem.Ingredients = Console.ReadLine();
        System.Console.WriteLine("Item Price:");
        newMenuItem.Price = Double.Parse(Console.ReadLine());  //!
        bool isSuccessful = _menuRepo.AddMenuItem(newMenuItem);
        if (isSuccessful)
        {
            System.Console.WriteLine($"{newMenuItem.Name} Was Added To The Menu!");
        }
        else
        {
            System.Console.WriteLine("Item Was Not Added To Database.");
        }
        PressAnyKeyToContinue();
    }
    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press Any Key To Continue!");
        Console.ReadKey();
    }
    private void SeedData()
    {
        MenuItem menuItem1 = new MenuItem("Americano", "Espresso with Water (Basically A Plain Black Coffee.", "Espresso, Water", 2.00);
        MenuItem menuItem2 = new MenuItem("Latte", "Espresso with Steamed Milk. Can Be Served Hot or Iced.", "Espresso, Milk of Choice", 3.50);
        MenuItem menuItem3 = new MenuItem("Cappuccino", "Espresso Topped with Frothed Steamed Milk.", "Espresso, Milk of Choice", 3.50);
        MenuItem menuItem4 = new MenuItem("Cold Brew", "Espresso Grounds That Have Been Steeped in Water for Several Hours", "Espresso, Water", 2.50);
        MenuItem menuItem5 = new MenuItem("Bagel w/ Cream Cheese", "Everything Bagel with Cream Cheese. Can Substitute with Vegan Cream Cheese", "Bagel, cream cheese", 4.50);
        MenuItem menuItem6 = new MenuItem("Scone", "Choose From: Chocolate, Vanilla, Sausage/Egg/Cheese, Spinach/Egg/Cheese.", "Flour, Butter, Cream, Egg, Baking Powder, Salt, Sugar. Please Ask Barista For Complete List Depending On What You Get.", 2.00);
        MenuItem menuItem7 = new MenuItem("Muffin", "Choose From: Oatmeal Raisin, Chocolate, Blueberry.", "Flour, Egg, Butter, Sugar, Salt. Please Ask Barista For Complete List Depending On Which One You Get.", 2.00);
        MenuItem menuItem8 = new MenuItem("Breakfast Sandwich", "Choose From: Sausage/Egg/Cheese, Bacon/Egg/Cheese, Spinach/Egg/Cheese", "English Muffin, Choice of Cheese, Choice of Meat", 2.00);

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
