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
    internal class SingRepo_u : IRepo<SingUp_u, int>
    {
        private readonly UberContext context;

        public SingRepo_u(UberContext context)
        {
            this.context = context;
        }

        public void Create(SingUp_u obj)
        {
            context.SignUp_us.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var exobj = Get(id);
            if (exobj != null)
            {
                context.SignUp_us.Remove(exobj);
                context.SaveChanges();
            }
        }

        public List<SingUp_u> Get()
        {
            return context.SignUp_us.ToList();
        }

        public SingUp_u Get(int id)
        {
            return context.SignUp_us.Find(id);
        }

        public void Update(SingUp_u obj)
        {
            var exobj = Get(obj.Id);
            if (exobj != null)
            {
                context.Entry(exobj).CurrentValues.SetValues(obj);
                context.SaveChanges();
            }
        }
    }
}
