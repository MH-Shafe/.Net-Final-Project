using DAL.EF;
using DAL.EF.Entites.Admin;
using DAL.EF.Entites;
using DAL.EF.Entities;
using DAL.EF.Entities.Admin;
using DAL.Interfaces;
using DAL.Repos;
using DAL.Repos.Admin;
using System;
using DAL.Repositories;

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

        public static IRepo<DriverInfo, int> DriverInfoData() 
        {
            return new DriverInfoRepo(); 
        }
        public static IRepo<Email, int> EmailData() 
        {
            return new EmailRepo(context); 
        }
        public static IRepo<PasswordChange, int> PasswordChangeData() 
        {
            return new PasswordChangeRepo(); 
        }
    }
}
