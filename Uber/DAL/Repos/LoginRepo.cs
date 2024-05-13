using DAL.EF.Entites;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LoginRepo :Repo, IRepo<Login, int>
    {
        public void Create(Login obj)
        {
            db.Logins.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var exobj = Get(id);
            db.Logins.Remove(exobj);
            db.SaveChanges();
        }

        public List<Login> Get()
        {
            return db.Logins.ToList();
        }

        public Login Get(int id)
        {
            return db.Logins.Find(id);
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Login obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
