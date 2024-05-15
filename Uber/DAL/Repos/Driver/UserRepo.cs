using DAL.EF.Entities.User;
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
    internal class UserRepo : IRepo<UserEF, int>
    {
        private readonly UberContext _context;

        public UserRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(UserEF obj)
        {
            _context.UserEFs.Add(obj);
            _context.SaveChanges();
        }

        public List<UserEF> Get()
        {
            return _context.UserEFs.ToList();
        }

        public UserEF Get(int id)
        {
            return _context.UserEFs.Find(id);
        }

        public void Update(UserEF obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.UserEFs.Find(id);
            if (user != null)
            {
                _context.UserEFs.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
