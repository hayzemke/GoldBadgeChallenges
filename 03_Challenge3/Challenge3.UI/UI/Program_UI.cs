using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge3.Data;

public class Program_UI
{
    private readonly Challenge3_Repo _badgeRepo = new Challenge3_Repo();
    public void Run()
    {
        SeedData();

        RunApplication();
    }
    public void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome To Komodo Insurance Badging System!");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("Please Select An Action:\n" +
            "1. Create New Badge \n" +
            "2. Get Badge By ID \n" +
            "3. Update Existing Badge \n" +
            "4. See All Badges\n" +
            "10. Close Application.\n");

            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CreateNewBadge();
                    break;

                case "2":
                    GetBadgeByID();
                    break;

                case "3":
                    UpdateExistingBadge();
                    break;

                case "4":
                    SeeAllBadges();
                    break;

                case "10":
                    isRunning = CloseApplication();
                    break;

                default:
                    System.Console.WriteLine("Sorry, Invalid Selection.");
                    PressAnyKeyToContinue();
                    break;
            }
            PressAnyKeyToContinue();
        }
    }
    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Have A Great Day!");
        PressAnyKeyToContinue();
        return false;
    }
    private void SeeAllBadges()
    {
        Console.Clear();
        Dictionary<int, Badge> ListOfBadges = _badgeRepo.SeeAllBadges();
        foreach (KeyValuePair<int, Badge> badge in ListOfBadges) //!
        {
            DisplayAllBadges(badge.Value);
        }
        PressAnyKeyToContinue();
    }
    private void DisplayAllBadges(Badge badge)
    {
        System.Console.WriteLine($"Badge ID:{badge.ID}\nDoorNumber:{string.Join(",", badge.Doors)}");
    }
    private void GetBadgeByID()
    {
        Console.Clear();
        try
        {
            System.Console.WriteLine("Please Input An Existing Badge ID:");
            int ID = int.Parse(Console.ReadLine());
            var selectedBadge = _badgeRepo.GetBadgeByID(ID);
            if (selectedBadge != null)
            {
                DisplayAllBadges(selectedBadge);
            }
            else
            {
                System.Console.WriteLine("Badge Does Not Exist!");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry Invalid Selection!");
        }
        PressAnyKeyToContinue();
    }
    private void UpdateExistingBadge()
    {
        Console.Clear();
        var badge = _badgeRepo.SeeAllBadges();
        System.Console.WriteLine("Please Enter Badge Number:");
        var ID = int.Parse(Console.ReadLine());
        var selectedBadge = _badgeRepo.GetBadgeByID(ID);
        if (selectedBadge != null)
        {
            var newBadge = new Badge();
            System.Console.WriteLine("====== Badge Information Form =======");
            // System.Console.WriteLine("Enter Badge Number:");
            // newBadge.ID = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Please make a selection:");
            System.Console.WriteLine("1. Add Door\n2. Remove Door\n");
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddDoor();
                    break;

                case "2":
                    RemoveDoor();
                    break;

                default:
                    break;
            }
        }
        PressAnyKeyToContinue();
    }

    private void RemoveDoor()
    {
        Console.Clear();
        System.Console.WriteLine("Please Enter Badge ID");
        var userInput = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Please Enter Door Number:");
        var userInputDoorNumber = Console.ReadLine();

        var Success = _badgeRepo.RemoveDoor(userInput, userInputDoorNumber);
        if (Success)
        {
            System.Console.WriteLine("Successful!");
        }
        else
        {
            System.Console.WriteLine("Unsuccessful!");
        }
        PressAnyKeyToContinue();
    }

    private void AddDoor()
    {
        Console.Clear();
        System.Console.WriteLine("Please Enter Badge ID");
        var userInput = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Please Enter Door Number:");
        var userInputDoorNumber = Console.ReadLine();

        var Success = _badgeRepo.AddDoor(userInput, userInputDoorNumber);
        if (Success)
        {
            System.Console.WriteLine("Successful!");
        }
        else
        {
            System.Console.WriteLine("Unsuccessful!");
        }
        PressAnyKeyToContinue();
    }

    private void CreateNewBadge()
    {
        Console.Clear();
        var newBadge = new Badge();
        System.Console.WriteLine("New Badge Information Sheet:");

        // System.Console.WriteLine("Enter Badge Number:");
        // newBadge.ID = int.Parse(Console.ReadLine());

        bool hasAddedAllDoors = false;
        while (!hasAddedAllDoors)
        {
            System.Console.WriteLine("Enter Door Access:");
            var userInputDoor = Console.ReadLine();
            newBadge.Doors.Add(userInputDoor);


            System.Console.WriteLine("Any Other Doors? Y/N");
            string userInput = Console.ReadLine();
            if (userInput == "Y" || userInput == "y")
            {
                continue;
            }
            else
            {
                hasAddedAllDoors = true;
            }
        }

        bool isSuccessful = _badgeRepo.CreateNewBadge(newBadge);
        if (isSuccessful)
        {
            System.Console.WriteLine($"{newBadge.ID} was added to database!");
        }
        else
        {
            System.Console.WriteLine("Badge was NOT added to database.");
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
        Badge badge1 = new Badge(new List<string> { "A1", "A3", "B2" });
        Badge badge2 = new Badge(new List<string> { "A2", "B3", "C2" });
        Badge badge3 = new Badge(new List<string> { "A6", "A9", "C2" });
        Badge badge4 = new Badge(new List<string> { "A1", "A3" });
        Badge badge5 = new Badge(new List<string> { "C2", "B2", "B4" });

        _badgeRepo.CreateNewBadge(badge1);
        _badgeRepo.CreateNewBadge(badge2);
        _badgeRepo.CreateNewBadge(badge3);
        _badgeRepo.CreateNewBadge(badge4);
        _badgeRepo.CreateNewBadge(badge5);
    }
}