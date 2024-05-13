using DAL.EF;
using DAL.EF.Entites;
using DAL.EF.Entites.Admin;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class ManageUsersRepo : IRepo<User, int>
    {
        private readonly UberContext context;

        public ManageUsersRepo(UberContext context)
        {
            this.context = context;
        }

        public void Create(User obj)
        {
            if (obj is SignUp)
            {
                context.SignUps.Add((SignUp)obj);
            }
            else if (obj is Login)
            {
                context.Logins.Add((Login)obj);
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = Get(id);
            if (user != null)
            {
                if (user is SignUp)
                {
                    context.SignUps.Remove((SignUp)user);
                }
                else if (user is Login)
                {
                    context.Logins.Remove((Login)user);
                }

                context.SaveChanges();
            }
        }

        public List<User> Get()
        {
            var users = new List<User>();
            users.AddRange(context.SignUps);
            users.AddRange(context.Logins);
            return users;
        }

        public User Get(int id)
        {
            var signUp = context.SignUps.FirstOrDefault(s => s.Id == id);
            if (signUp != null)
                return signUp;

            var login = context.Logins.FirstOrDefault(l => l.Id == id);
            return login;
        }

        public void Update(User obj)
        {
            if (obj is SignUp)
            {
                var signUp = obj as SignUp;
                var existingSignUp = context.SignUps.FirstOrDefault(s => s.Id == signUp.Id);
                if (existingSignUp != null)
                {
                    existingSignUp.username = signUp.username;
                    existingSignUp.Name = signUp.Name;
                    existingSignUp.Email = signUp.Email;
                    existingSignUp.Country = signUp.Country;
                    context.SaveChanges();
                }
            }
            else if (obj is Login)
            {
                var login = obj as Login;
                var existingLogin = context.Logins.FirstOrDefault(l => l.Id == login.Id);
                if (existingLogin != null)
                {
                    existingLogin.username = login.username;
                    existingLogin.password = login.password;
                    existingLogin.roll = login.roll;
                    existingLogin.SignUpId = login.SignUpId;
                    context.SaveChanges();
                }
            }
        }
    }
}
