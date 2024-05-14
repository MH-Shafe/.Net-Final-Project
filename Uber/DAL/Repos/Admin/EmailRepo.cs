using DAL.EF;
using DAL.EF.Entites.Admin;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    internal class EmailRepo : IRepo<Email, int>
    {
        private readonly UberContext _context;

        public EmailRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(Email obj)
        {
            _context.Emails.Add(obj);
            _context.SaveChanges();
        }

        public List<Email> Get()
        {
            return _context.Emails.ToList();
        }

        public Email Get(int id)
        {
            return _context.Emails.Find(id);
        }

        public void Update(Email obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var email = _context.Emails.Find(id);
            if (email != null)
            {
                _context.Emails.Remove(email);
                _context.SaveChanges();
            }
        }
    }
}
