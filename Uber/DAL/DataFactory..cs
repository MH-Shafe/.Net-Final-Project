using DAL.EF;
using DAL.EF.Entites;
using DAL.EF.Entites.Admin;
using DAL.EF.Entites.Driver;
using DAL.EF.Entites.User;
using DAL.EF.Entities.Driver;
using DAL.EF.Entities.User;
using DAL.Interfaces;
using DAL.Repos;
using DAL.Repos.Driver;
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

        public static IRepo<SignUp_D, int> SignUpData_D()
        {
            return new SignUpRepo_D(context);
        }

        public static IRepo<DriverEF, int> DriverData_D()
        {
            return new DriverRepo(context);
        }


        public static IRepo<Payment, int> PaymentData()
        { 
             return new PaymentRepo(context); 
        }

        public static IRepo<Subscription, int> SubscriptionData()
        {
            return new SubscriptionRepo(context);
        }

        public static IRepo<Ride, int> RideData()
        {
            return new RideRepo(context);
        }

        public static IRepo<UserEF, int> UserData()
        {
            return new UserRepo(context);
        }

    }
}
