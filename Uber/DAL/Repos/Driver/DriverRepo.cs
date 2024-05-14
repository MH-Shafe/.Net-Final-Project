using DAL.EF;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos.Driver
{/*
    internal class DriverRepo : IRepo<DriverRepo, int>
    {
        private readonly UberContext _context;

        public DriverRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(DriverRepo obj)
        {
            _context.Drivers.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var driver = _context.Drivers.Find(id);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
            }
        }

        public List<DriverRepo> Get()
        {
            return _context.Drivers.ToList();
        }

        public DriverRepo Get(int id)
        {
            return _context.Drivers.Find(id);
        }

        public void Update(DriverRepo obj)
        {
            var driver = _context.Drivers.Find(obj.UserID);
            if (driver != null)
            {
                // Assuming you want to update all properties
                driver.Username = obj.Username;
                driver.Email = obj.Email;
                driver.Password = obj.Password;
                driver.PhoneNumber = obj.PhoneNumber;

                _context.SaveChanges();
            }
        }
    }*/
}
