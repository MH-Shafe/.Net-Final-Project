using DAL.EF;
using DAL.EF.Entites.Driver;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos.Driver
{
    internal class SignUpRepo_D : IRepo<SignUp_D, int>
    {
        private readonly UberContext context;

        public SignUpRepo_D(UberContext context)
        {
            this.context = context;
        }

        public void Create(SignUp_D obj)
        {
            context.SignUp_Ds.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var exobj = Get(id);
            if (exobj != null)
            {
                context.SignUp_Ds.Remove(exobj);
                context.SaveChanges();
            }
        }

        public List<SignUp_D> Get()
        {
            return context.SignUp_Ds.ToList();
        }

        public SignUp_D Get(int id)
        {
            return context.SignUp_Ds.Find(id);
        }

        public void Update(SignUp_D obj)
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
