using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.Admin;
using DAL;
using DAL.EF.Entites;
using DAL.EF.Entites.Admin;
using System.Collections.Generic;

namespace BLL.Services
{
    public class SignUpService
    {
        private static IMapper mapper;

        static SignUpService() // Add a static constructor to initialize mapper
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
        public static SignUpDTO Get(int id)
        {
            var data = DataFactory.SignUpData().Get(id);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SignUp, SignUpDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<SignUpDTO>(data);
            return ret;
        }

        public static void CreateSignUp(SignUpDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SignUpDTO, SignUp>();
            });
            var mapper = new Mapper(config);
            var signUp = mapper.Map<SignUp>(dto);
            DataFactory.SignUpData().Create(signUp);
        }

        public static List<SignUpDTO> GetSignUps()
        {
            var data = DataFactory.SignUpData().Get();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SignUp, SignUpDTO>();
            });
            var mapper = new Mapper(config);
            var retData = mapper.Map<List<SignUpDTO>>(data);

            return retData;
        }

        public static void CreateSignUpAndLogin(SignUpLoginDTO dto) // Changed method name
        {
           // var mapper = new Mapper(config);
            var signUp = mapper.Map<SignUp>(dto.SignUp);
            DataFactory.SignUpData().Create(signUp);

            dto.Login.SignUpId = signUp.Id;

            var login = mapper.Map<Login>(dto.Login);
            DataFactory.LoginData().Create(login);
        }


    }
}
