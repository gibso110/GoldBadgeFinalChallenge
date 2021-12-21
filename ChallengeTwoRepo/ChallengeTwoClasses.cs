using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepo
{
    public class Claims
    {
        public Claims()
        {
        }

        public Claims(int claimID, string claimType, string description, double claimAmount, DateTime dateOfAccident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
            this.isValid = isValid;
        }

        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool isValid { get; set; }
    }

    public class RepoForClaims
    {
        private readonly Queue<Claims> _ClaimsQueue = new Queue<Claims>();

        //claimNumber

        public int _ClaimID = 0;


        //C
        public bool AddNewClaim(Claims newClaim)
        {
            if (newClaim != null)
            {
                _ClaimID++;
                newClaim.ClaimID = _ClaimID;
                _ClaimsQueue.Enqueue(newClaim);
                return true;
            };
            return false;

        }


            //R
            //read all items in queue
             public Queue<Claims> _showClaims()
            {
                return _ClaimsQueue;
            }

            //Claims by Claim ID

             Claims ClaimByIDNumber(int id)
            {
                foreach (Claims oldClaim in _ClaimsQueue)
                {
                    if (oldClaim.ClaimID == id)
                    {
                        return oldClaim;

                    }



                }
                _showClaims();
                Console.WriteLine("Please enter a valid claim ID Number");
                return null;

            }
        }

}
