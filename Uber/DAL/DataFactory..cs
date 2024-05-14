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

        public static IRepo<DriverInfo, int> DriverInfoData() // Corrected method name
        {
            return new DriverInfoRepo(); // Make sure you have a DriverInfoRepo class
        }
        public static IRepo<Email, int> EmailData() // Corrected method name
        {
            return new EmailRepo(context); // Make sure you have a DriverInfoRepo class
        }
    }
}
