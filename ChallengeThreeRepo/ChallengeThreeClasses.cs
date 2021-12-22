using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class Outings
    {
        public Outings()
        {
        }

        public Outings(string eventType, int numberInAttendance, DateTime dateOfEvent, double costPerPerson, double costForEvent)
        {
            EventType = eventType;
            NumberInAttendance = numberInAttendance;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
            CostForEvent = costForEvent;
        }

        public string EventType { get; set; }
        public int NumberInAttendance { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double CostPerPerson { get; set; }
        public double CostForEvent { get; set; }
    }
   

    public class KomodoOutingsMethods
    {
        private readonly List<Outings> _komodoOutingsList = new List<Outings>();

        //C

        public void CreateNewOuting(Outings newOuting)
        {
            if(newOuting != null)
            {
                _komodoOutingsList.Add(newOuting);
            }
            else
            {
                Console.WriteLine("This is not a valid outing");
            }
        }


        //R

        //Display all outings
        public List<Outings> _ShowAllOutings()
        {
            return _komodoOutingsList;
        }

        //Display Combined costs for all outings


        public void CominedCostOfOutings()
        {
            double total = _komodoOutingsList.Sum(Outings => Outings.CostForEvent);
            Console.WriteLine($"The total cost of all of the events is ${total}.");
        }

        //Display event costs by type
        public void OutingCostByEventType(string eventType)
        {
            foreach(Outings outing in _komodoOutingsList)
            {
                if(outing.EventType == eventType)
                {
                    double total = _komodoOutingsList.Sum(Outings => Outings.CostForEvent);
                    Console.WriteLine($"The total cost for all {eventType} type outings is ${total}");
                }
            }
        }



    }
}


