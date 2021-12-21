using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeTwoRepo;

namespace ChallengeTwoConsole
{
    class ChallengeTwoUI
    {

        //New Instance of Claims
        private Claims _Claims = new Claims();

        //New instance of Repo for claims

        private RepoForClaims _RepoForClaims = new RepoForClaims();

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
                   "1. See all claims.\n" +
                   "2. Take Care of next claim\n" +
                   "3. Enter new claim.\n" +
                   "4. Exit the program\n" );

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        DequeueNextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
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


        //View All Claims Method

        private void ViewAllClaims()
        {
            Console.Clear();
            Queue<Claims> currentClaims = _RepoForClaims._showClaims();

            

            foreach (Claims claim in currentClaims)
            {
               var DateOfAccidentNoTime = claim.DateOfAccident.ToString("M/d/yyyy");
               var DateOfClaimNoTime = claim.DateOfClaim.ToString("M/d/yyyy");

                Console.WriteLine($"ClaimID\t Type\t Description\t\t Amount\t DateOfAccident\t DateOfClaim\t IsValid\n" +
                    $"{claim.ClaimID}\t {claim.ClaimType}\t {claim.Description}\t ${claim.ClaimAmount}\t {DateOfAccidentNoTime}\t {DateOfClaimNoTime}\t {claim.isValid}\n");
                

            }
        }

        //Create a new claim
        private void CreateNewClaim() 
        {
            Claims newClaim = new Claims();

            Console.WriteLine("What type of claim is this: car, home, or theft?");
            string typeOfClaim = Console.ReadLine().ToLower();
            

            if (typeOfClaim == "car")
            {
                newClaim.ClaimType = typeOfClaim;
            }
            else if(typeOfClaim == "home") 
            {
                newClaim.ClaimType = typeOfClaim;
            }
            else if (typeOfClaim == "theft")
            {
                newClaim.ClaimType = typeOfClaim;
            }
            else
            {
                Console.WriteLine("Please enter a valid claim type.");
                newClaim.ClaimType = Console.ReadLine().ToLower();

            }
            Console.WriteLine("Write a brief Description of the claim:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("What is the claim amount?");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("When did the accident happen? Enter date in the format MM/DD/YY:");
            newClaim.DateOfAccident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("What is the date the claim was made? Enter date in the format MM/DD/YY:");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            int days = (newClaim.DateOfClaim - newClaim.DateOfAccident).Days;

            if (days <= 30)
            {
                newClaim.isValid = true;
            }
            else
            {
                newClaim.isValid = false;
            }

            _RepoForClaims.AddNewClaim(newClaim);
        }

        //Take Care of claim
       private void DequeueNextClaim()
        {
            Console.Clear();
            Queue<Claims> currentClaims = _RepoForClaims._showClaims();
            var DateOfAccidentNoTime = currentClaims.Peek().DateOfAccident.ToString("M/d/yyyy");
            var DateOfClaimNoTime = currentClaims.Peek().DateOfClaim.ToString("M/d/yyyy");

            Console.WriteLine($"ClaimID\t Type\t Description\t\t Amount\t DateOfAccident\t DateOfClaim\t IsValid\n" +
                    $"{currentClaims.Peek().ClaimID}\t {currentClaims.Peek().ClaimType}\t {currentClaims.Peek().Description}\t ${currentClaims.Peek().ClaimAmount}\t {DateOfAccidentNoTime}\t {DateOfClaimNoTime}\t {currentClaims.Peek().isValid}\n" +
                    $"Do you want to deal with this claim now? Y/N");
            
            string dealWithClaim = Console.ReadLine().ToLower();

            if (dealWithClaim == "y")
            {
                currentClaims.Dequeue();
                Console.WriteLine("The claim has been removed from the queue.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                DequeueNextClaim();
            }
            else
            {
                Console.WriteLine("Did not deal with claim. Returning to main menu.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                menu();
            }



           

        }




    }
}
