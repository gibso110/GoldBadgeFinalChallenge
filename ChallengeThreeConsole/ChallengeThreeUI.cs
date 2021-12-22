using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeThreeRepo;

namespace ChallengeThreeConsole
{
    class ChallengeThreeUI
    {
        //new instance of Outings
        Outings _outings = new Outings();

        //new instance of OutingsMethods

        KomodoOutingsMethods _komodoOutingsMethods = new KomodoOutingsMethods();

        public void run()
        {
            menu();
        }

        public bool isRunning = true;

        public void menu()
        {
            seedEvents();

            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("1. Display a list of all outings\n\n" +
                    "2. Add a new outing\n\n" +
                    "3. View combined cost for all outings\n\n" +
                    "4. View combined cost for all outings of the same event type\n\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllEvents();
                        break;
                    case "2":
                        AddNewEvent();
                        break;
                    case "3":
                        CombindedOutingsCost();
                        break;
                    case "4":
                        OutingCostByEventType();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye. Press any key to continue...");
                        Console.ReadKey();
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a valid number. Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;


                }

            }
        }


        public void ViewAllEvents()
        {
            Console.Clear();
            Console.WriteLine("Event Type\t # of People\t Date\t\t Cost Per Person\t Event Total Cost\n\n");
            List<Outings> allOutings = _komodoOutingsMethods._ShowAllOutings();
            foreach (Outings outing in allOutings)
            {
                string outingDate = outing.DateOfEvent.ToString("M/d/yyyy");

                Console.WriteLine($"{outing.EventType}\t\t {outing.NumberInAttendance}\t\t {outingDate}\t ${outing.CostPerPerson}\t\t\t ${outing.CostForEvent}\n");
                
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }


        public void AddNewEvent()
        {
            Outings newOuting = new Outings();

            Console.WriteLine("What type of event is this? 1.Golf\t 2.Bowling\t 3.Amusement Park\t 4.Concert:");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    newOuting.EventType = "Golf";
                    break;
                case "2":
                    newOuting.EventType = "Bowling";
                    break;
                case "3":
                    newOuting.EventType = "Amusement Park";
                    break;
                case "4":
                    newOuting.EventType = "Concert";
                    break;
                default:
                    Console.Write("Please enter a valid input: ");
                    input = Console.ReadLine();
                    break;
            }

            Console.WriteLine("How many people attended the event?");
            newOuting.NumberInAttendance = int.Parse(Console.ReadLine());

            Console.WriteLine("What was the date of the event (MM/DD/YYYY)?");
            newOuting.DateOfEvent = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("What was the total cost for the event?");
            newOuting.CostForEvent = double.Parse(Console.ReadLine());
            double costPerPerson = newOuting.CostForEvent / newOuting.NumberInAttendance;
            newOuting.CostPerPerson = costPerPerson;
            _komodoOutingsMethods.CreateNewOuting(newOuting);

            Console.WriteLine("The Outing has been successfully added. Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }
        public void CombindedOutingsCost()
        {
            _komodoOutingsMethods.CominedCostOfOutings();
        }


        public void OutingCostByEventType()
        {
            string eventType = "";

            Console.WriteLine("What type of event would you like to see the total costs for?\n" +
                "1.Golf\t 2.Bowling\t 3.Amusement Park\t 4.Concert");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    eventType = "Golf";
                    break;
                case "2":
                    eventType = "Bowling";
                    break;
                case "3":
                    eventType = "Amusement Park";
                    break;
                case "4":
                    eventType = "Concert";
                    break;
                default:
                    Console.Write("Please enter a valid input: ");
                    input = Console.ReadLine();
                    break;
            }


            _komodoOutingsMethods.OutingCostByEventType(eventType);
        }

        public void seedEvents()
        {
            

            Outings golfOuting = new Outings("Golf", 100, DateTime.Now, 5, 500);

            Outings bowlingOuting = new Outings("Bowling", 100, DateTime.Now, 5, 500);

            Outings concertOuting = new Outings("Concert", 100, DateTime.Now, 5, 500);

            _komodoOutingsMethods.CreateNewOuting(golfOuting);

            _komodoOutingsMethods.CreateNewOuting(bowlingOuting);

            _komodoOutingsMethods.CreateNewOuting(concertOuting);


        }
    }
}
