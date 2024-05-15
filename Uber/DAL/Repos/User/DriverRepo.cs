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
    internal class DriverRepo : IRepo<Driver_u, int>
    {
        private readonly UberContext _context;

        public DriverRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(Driver_u obj)
        {
            _context.Driver_us.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var driver = _context.Driver_us.Find(id);
            if (driver != null)
            {
                _context.Driver_us.Remove(driver);
                _context.SaveChanges();
            }
        }

        public List<Driver_u> Get()
        {
            return _context.Driver_us.ToList();
        }

        public Driver_u Get(int id)
        {
            return _context.Driver_us.Find(id);
        }

        public void Update(Driver_u obj)
        {
            var existingDriver = _context.Driver_us.Find(obj.DriverID);
            if (existingDriver != null)
            {
                existingDriver.FirstName = obj.FirstName;
                existingDriver.LastName = obj.LastName;
                existingDriver.Email = obj.Email;
                existingDriver.Phone = obj.Phone;
                // Update other properties as needed
                _context.SaveChanges();
            }
        }
    }
}