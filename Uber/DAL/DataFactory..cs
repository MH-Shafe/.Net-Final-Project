using DAL.EF;
using DAL.EF.Entites;
using DAL.EF.Entites.Admin;
using DAL.EF.Entites.User;
using DAL.Interfaces;
using DAL.Repos;
using DAL.Repos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataFactory
    {
        private static UberContext context = new UberContext();
        public static IRepo<Login, int> LoginData()
        {
            return new LoginRepo();
        }
        
        public static IRepo<SignUp, int> SignUpData()
        {
            return new SignUpRepo(context);
        }
        public static IRepo<SingUp_u, int> SignUpData_u()
        {
            return new SingRepo_u(context);
        }
    }
}
