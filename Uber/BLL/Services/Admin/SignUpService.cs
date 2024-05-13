using AutoMapper;
using BLL.DTOs.Admin;
using DAL;
using DAL.EF.Entites.Admin;
using DAL.EF.Entities.Admin;
using DAL.Repos.Admin;
using System.Collections.Generic;

namespace BLL.Services.Admin
{
    public class SignUpService
    {
        public static SignUpDTO Get(int id)
        {
            var data = DataFactory.SignUpData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SignUp, SignUpDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<SignUpDTO>(data);
            return ret;
        }

        public static void Create(SignUpDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SignUpDTO, SignUp>();
            });
            var mapper = new Mapper(config);
            var entity = mapper.Map<SignUp>(dto);
            DataFactory.SignUpData().Create(entity);
        }

        public static List<SignUpDTO> GetAll()
        {
            var data = DataFactory.SignUpData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SignUp, SignUpDTO>();
            });
            var mapper = new Mapper(config);
            var dtos = mapper.Map<List<SignUpDTO>>(data);

            return dtos;
        }
    }
}
