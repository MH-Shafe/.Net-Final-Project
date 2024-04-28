using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoginService
    {
        public static LoginDTO Get(int id)
        {
            var data = DataFactory.LoginData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Login, LoginDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<LoginDTO>(data);
            return ret;
        }
        public static void Create(LoginDTO c)
        {
            //convert courseDTO to Login
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LoginDTO, Login>();
            });
            var mapper = new Mapper(config);
            var crs = mapper.Map<Login>(c);
            DataFactory.LoginData().Create(crs);
        }
        public static List<LoginDTO> Get()
        {
            var data = DataFactory.LoginData().Get(); //List<Login> ef model

            //mapper
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Login, LoginDTO>();
            });
            var mapper = new Mapper(config);
            var retdata = mapper.Map<List<LoginDTO>>(data);


            return retdata;
        }
    }
}
