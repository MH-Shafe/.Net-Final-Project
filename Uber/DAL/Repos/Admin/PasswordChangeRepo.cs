using DAL.EF;
using DAL.EF.Entities.Admin;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repos.Admin
{
    internal class PasswordChangeRepo : Repo, IRepo<PasswordChange, int>
    {
        public void Create(PasswordChange obj)
        {
            using (var context = new UberContext())
            {
                context.PasswordChanges.Add(obj);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new UberContext())
            {
                var passwordChange = context.PasswordChanges.Find(id);
                if (passwordChange != null)
                {
                    context.PasswordChanges.Remove(passwordChange);
                    context.SaveChanges();
                }
            }
        }

        public List<PasswordChange> Get()
        {
            using (var context = new UberContext())
            {
                return context.PasswordChanges.ToList();
            }
        }

        public PasswordChange Get(int id)
        {
            using (var context = new UberContext())
            {
                return context.PasswordChanges.Find(id);
            }
        }

        public void Update(PasswordChange obj)
        {
            using (var context = new UberContext())
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
