using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge2.Data;

public class Program_UI
{
    private readonly Challenge2_Repo _Repo = new Challenge2_Repo();
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
            System.Console.WriteLine("Welcome To Komodo's Insurance Claim Department!");
            System.Console.WriteLine("------------------------------------------------------------\n");
            System.Console.WriteLine("Please Make A Selection:\n" +
            "1. Enter A New Claim\n" +
            "2. See All Claims\n" +
            "3. Take Care Of Next Claim\n" +
            "10. Close Application\n");

            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    EnterNewClaim();
                    break;

                case "2":
                    SeeAllClaims();
                    break;

                case "3":
                    NextClaim();
                    break;

                case "10":
                    isRunning = CloseApplication();
                    break;

                default:
                    System.Console.WriteLine("Invalid Selection.");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        PressAnyKeyToContinue();
    }
    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Have A Great Day!");
        PressAnyKeyToContinue();
        return false;
    }
    private void NextClaim()
    {
        Console.Clear();
        var claimItem = _Repo.NextClaim();
        if (claimItem == null)
        {
            System.Console.WriteLine("Sorry, All Claims are Handled!");
        }
        else
        {
            DisplayClaim(claimItem);

            System.Console.WriteLine("Do You Want To Handle This Claim Right Now? Y/N");
            var userInput = Console.ReadLine();
            if (userInput == "Y" || userInput == "y")
            {
                if (_Repo.HandleClaim())
                {
                    System.Console.WriteLine("Claim was Handled!");
                }
                else
                {
                    System.Console.WriteLine("Claim was not handled.");
                }
            }
        }
        PressAnyKeyToContinue();
    }
    private void SeeAllClaims()
    {
        Console.Clear();
        Queue<ClaimItem> ListOfClaims = _Repo.SeeAllClaims();
        foreach (ClaimItem claimItem in ListOfClaims)
        {
            DisplayClaim(claimItem);
        }
        PressAnyKeyToContinue();
    }
    private void DisplayClaim(ClaimItem claimItem)
    {
        System.Console.WriteLine($"Claim ID: {claimItem.ClaimID}\n" +
        $"Claim Type: {claimItem.ClaimType}\n" +
        $"Claim Description: {claimItem.Description}\n" +
        $"Claim Amount: {claimItem.ClaimAmount}\n" +
        $"Date Of Accident: {claimItem.DateOfIncident}\n" +
        $"Date Of Claim: {claimItem.DateOfClaim}\n" +
        $"Is The Claim Valid? {claimItem.IsValid}\n");
    }
    private void EnterNewClaim()
    {
        Console.Clear();
        var newClaim = new ClaimItem();
        System.Console.WriteLine("Claim Information Form:\n");
        System.Console.WriteLine("Please Enter Type Of Claim:");
        newClaim.ClaimType = GiveMeClaimType(newClaim);

        System.Console.WriteLine("Please Enter A Description:");
        newClaim.Description = Console.ReadLine();

        System.Console.WriteLine("Please Enter Amount Of Claim:");
        newClaim.ClaimAmount = Double.Parse(Console.ReadLine());

        System.Console.WriteLine("Please Enter Date Of Accident:");
        newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

        System.Console.WriteLine("Please Enter Date Of Claim:");
        newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

        System.Console.WriteLine("Is The Claim Valid?");
        string userInput = Console.ReadLine();
        if (userInput == "Y" || userInput == "y")
        {
            newClaim.IsValid = true;
        }
        else
        {
            newClaim.IsValid = false;
        }
        bool isSuccessful = _Repo.EnterNewClaim(newClaim);
        if (isSuccessful)
        {
            System.Console.WriteLine($"{newClaim.ClaimID} Was Added To Database!");
        }
        else
        {
            System.Console.WriteLine("Claim was NOT added to database.");
        }
        PressAnyKeyToContinue();
    }
    private ClaimType GiveMeClaimType(ClaimItem newClaim)
    {
        System.Console.WriteLine("Select A Claim Type:\n" +
        "1. Car\n" +
        "2. House\n" +
        "3. Theft\n");

        string claimType = Console.ReadLine();

        switch (claimType)
        {
            case "1":
                return ClaimType.Car;

            case "2":
                return ClaimType.Home;

            case "3":
                return ClaimType.Theft;

            default:
                System.Console.WriteLine("Invalid Answer.");
                return ClaimType.Car;
        }
    }
    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press Any Key To Continue!");
        Console.ReadKey();
    }
    private void SeedData()
    {
        ClaimItem Car = new ClaimItem(ClaimType.Car, "Hit and Run Accident", 1500d, new DateTime(2022, 01, 12), new DateTime(2022, 01, 25), true);
        ClaimItem Home = new ClaimItem(ClaimType.Home, "Tree Fell Into My House", 5000d, new DateTime(2022, 02, 17), new DateTime(2022, 03, 02), true);
        ClaimItem Theft = new ClaimItem(ClaimType.Theft, "Jewelry Stolen", 500d, new DateTime(2022, 03, 25), new DateTime(2022, 04, 12), true);
        ClaimItem Car1 = new ClaimItem(ClaimType.Car, "Got Backed Into In A Parking Lot", 1000d, new DateTime(2022, 02, 28), new DateTime(2022, 04, 07), false);

        _Repo.EnterNewClaim(Car);
        _Repo.EnterNewClaim(Home);
        _Repo.EnterNewClaim(Theft);
        _Repo.EnterNewClaim(Car1);
    }
}