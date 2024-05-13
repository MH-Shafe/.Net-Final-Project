using AutoMapper;
using BLL.DTOs.Admin;
using BLL.DTOs;
using DAL.EF.Entites;
using DAL.EF.Entites.Admin;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services.Admin
{
    public class ManageUsersService
    {
        private static IMapper mapper;

        static ManageUsersService() // Add a static constructor to initialize mapper
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SignUp, SignUpDTO>();
                cfg.CreateMap<SignUpDTO, SignUp>();
                cfg.CreateMap<Login, LoginDTO>();
                cfg.CreateMap<LoginDTO, Login>();
            });
            mapper = config.CreateMapper();
        }

        private readonly IRepo<SignUp, int> signUpRepo;
        private readonly IRepo<Login, int> loginRepo;

        public ManageUsersService(IRepo<SignUp, int> signUpRepo, IRepo<Login, int> loginRepo)
        {
            this.signUpRepo = signUpRepo;
            this.loginRepo = loginRepo;
        }

        public SignUpDTO GetUser(int userId)
        {
            var user = signUpRepo.Get(userId);
            return mapper.Map<SignUpDTO>(user);
        }

        public List<SignUpDTO> GetAllUsers()
        {
            var users = signUpRepo.Get();
            return mapper.Map<List<SignUpDTO>>(users);
        }

        public void CreateUser(SignUpDTO userDTO)
        {
            var user = mapper.Map<SignUp>(userDTO);
            signUpRepo.Create(user);
        }

        public void UpdateUser(int userId, SignUpDTO updatedUserDTO)
        {
            var existingUser = signUpRepo.Get(userId);
            if (existingUser == null)
            {
                throw new ArgumentException("User not found.");
            }

            var updatedUser = mapper.Map<SignUp>(updatedUserDTO);
            updatedUser.Id = userId;
            signUpRepo.Update(updatedUser);
        }

        public void DeleteUser(int userId)
        {
            var existingUser = signUpRepo.Get(userId);
            if (existingUser == null)
            {
                throw new ArgumentException("User not found.");
            }

            signUpRepo.Delete(userId);
        }

        // Methods for managing login details

        public LoginDTO GetLogin(int userId)
        {
            var login = loginRepo.Get(userId);
            return mapper.Map<LoginDTO>(login);
        }

        public void CreateLogin(LoginDTO loginDTO)
        {
            var login = mapper.Map<Login>(loginDTO);
            loginRepo.Create(login);
        }

        public void UpdateLogin(int userId, LoginDTO updatedLoginDTO)
        {
            var existingLogin = loginRepo.Get(userId);
            if (existingLogin == null)
            {
                throw new ArgumentException("Login details not found.");
            }

            var updatedLogin = mapper.Map<Login>(updatedLoginDTO);
            updatedLogin.Id = userId;
            loginRepo.Update(updatedLogin);
        }

        public void DeleteLogin(int userId)
        {
            var existingLogin = loginRepo.Get(userId);
            if (existingLogin == null)
            {
                throw new ArgumentException("Login details not found.");
            }

            loginRepo.Delete(userId);
        }
    }
}
