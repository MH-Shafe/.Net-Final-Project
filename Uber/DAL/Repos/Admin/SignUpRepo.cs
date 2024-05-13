using DAL.EF;
using DAL.EF.Entites.Admin;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class SignUpRepo : IRepo<SignUp, int>
    {
        private readonly UberContext context;

        public SignUpRepo(UberContext context)
        {
            this.context = context;
        }

        public void Create(SignUp obj)
        {
            context.SignUps.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var exobj = Get(id);
            if (exobj != null)
            {
                context.SignUps.Remove(exobj);
                context.SaveChanges();
            }
        }

        public List<SignUp> Get()
        {
            return context.SignUps.ToList();
        }

        public SignUp Get(int id)
        {
            return context.SignUps.Find(id);
        }

        public object GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(SignUp obj)
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
