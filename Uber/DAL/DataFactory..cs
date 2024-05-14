using DAL.EF;
using DAL.EF.Entites;
using DAL.EF.Entites.Admin;
using DAL.EF.Entites;
using DAL.Interfaces;
using DAL.Repos;
using DAL.Repos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Entities.User;
using DAL.EF.Entites.User;

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
        public static IRepo<Payment_u, int> Payment_uData()
        {
            return new PaymentRepo(context);
        }
        public static IRepo<UserEF, int> UserEFData()
        {
            return new UserRepo(context);
        }
        public static IRepo<Subscription_u, int> Subscription_uData()
        {
            return new SubscriptionRepo(context);
        }

    }
}
