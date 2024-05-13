using DAL.EF;
using DAL.EF.Entites.Admin;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class SignUpRepo : IRepo<SignUp, int>
    {
        private readonly UberContext _context;

        public SignUpRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(SignUp obj)
        {
            _context.SignUps.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var exobj = Get(id);
            if (exobj != null)
            {
                _context.SignUps.Remove(exobj);
                _context.SaveChanges();
            }
        }

        public List<SignUp> Get()
        {
            return _context.SignUps.ToList();
        }

        public SignUp Get(int id)
        {
            return _context.SignUps.Find(id);
        }

        public void Update(SignUp obj)
        {
            var exobj = Get(obj.Id);
            if (exobj != null)
            {
                _context.Entry(exobj).CurrentValues.SetValues(obj);
                _context.SaveChanges();
            }
        }
    }
}
