using DAL.EF;
using DAL.Interfaces;
using DAL.EF.Entities.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DAL.Repos.User
{
    internal class UserRepo : Repo, IRepo<UserEF, int> // Update type to UserEF
    {
        private readonly UberContext _context;

        public UserRepo(UberContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(UserEF obj) // Update parameter type to UserEF
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            _context.UserEF.Add(obj); // Update DbSet reference
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.UserEF.Find(id); // Update DbSet reference
            if (user != null)
            {
                _context.UserEF.Remove(user); // Update DbSet reference
                _context.SaveChanges();
            }
        }

        public List<UserEF> Get() // Update return type to List<UserEF>
        {
            return _context.UserEF.ToList(); // Update DbSet reference
        }

        public UserEF Get(int id) // Update return type to UserEF
        {
            return _context.UserEF.Find(id); // Update DbSet reference
        }

        public void Update(UserEF obj) // Update parameter type to UserEF
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var existingUser = _context.UserEF.Find(obj.UserID); // Update DbSet reference
            if (existingUser != null)
            {
                existingUser.Username = obj.Username;
                existingUser.Email = obj.Email;
                existingUser.Password = obj.Password;
                existingUser.PhoneNumber = obj.PhoneNumber;
                // Update other properties as needed
                _context.SaveChanges();
            }
        }
    }
}
