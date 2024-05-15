using DAL.EF.Entites.User;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Driver
{
    internal class RideRepo : IRepo<Ride, int>
    {
        private readonly UberContext _context;

        public RideRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(Ride obj)
        {
            _context.Rides.Add(obj);
            _context.SaveChanges();
        }

        public List<Ride> Get()
        {
            return _context.Rides.ToList();
        }

        public Ride Get(int id)
        {
            return _context.Rides.Find(id);
        }

        public void Update(Ride obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ride = _context.Rides.Find(id);
            if (ride != null)
            {
                _context.Rides.Remove(ride);
                _context.SaveChanges();
            }
        }
    }
}