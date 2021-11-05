using System;
using System.Collections.Generic;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// RideRepository class for Rides List
    /// </summary>
    class RideRepository
    {
        //Dictionary to Store rides UserID and Store int List
        Dictionary<string, List<Ride>> userRides = null;

        /// <summary>
        /// Constructor to create dictionary
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Function to Add Ride List to Specified UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CabInvoiceCustomException)
            {
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }

        /// <summary>
        /// Function to Get Rides List as an Array for Specified UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Ride[] GetRides(string userId)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (Exception)
            {
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_USER_ID, "Invalid user ID");
            }
        }
    }
}