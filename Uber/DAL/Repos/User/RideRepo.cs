using DAL.EF;
using DAL.EF.Entites.User;
using DAL.Interfaces;
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DAL.Repos.User
{
    internal class RideRepo : IRepo<Ride_u, int>
    {
        private readonly UberContext _context;

        public RideRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(Ride_u obj)
        {
            _context.Ride_us.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ride = _context.Ride_us.Find(id);
            if (ride != null)
            {
                _context.Ride_us.Remove(ride);
                _context.SaveChanges();
            }
        }

        public List<Ride_u> Get()
        {
            return _context.Ride_us.ToList();
        }

        public Ride_u Get(int id)
        {
            return _context.Ride_us.Find(id);
        }

        public void Update(Ride_u obj)
        {
            var existingRide = _context.Ride_us.Find(obj.RideID);
            if (existingRide != null)
            {
                existingRide.UserID = obj.UserID;
                existingRide.DriverID = obj.DriverID;
                existingRide.PickupLocation = obj.PickupLocation;
                existingRide.Destination = obj.Destination;
                existingRide.Fare = obj.Fare;
                existingRide.Status = obj.Status;
                // Update other properties as needed
                _context.SaveChanges();
            }
        }
    }
}