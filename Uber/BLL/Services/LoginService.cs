using BLL.DTOs;
using BLL.Services.Admin;
using DAL;
using DAL.EF.Entites;

using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class LoginService
    {
        public static LoginDTO Get(int id)
        {
            var data = DataFactory.LoginData().Get(id);
            return MapToDTO(data);
        }

        public static void Create(LoginDTO dto)
        {
            var login = MapToEntity(dto);
            DataFactory.LoginData().Create(login);
        }

        public static List<LoginDTO> Get()
        {
            var data = DataFactory.LoginData().Get();
            return data.Select(MapToDTO).ToList();
        }

        public static List<LoginDTO> GetByRole(string roll)
        {
            var data = DataFactory.LoginData().Get().Where(l => l.roll == roll).ToList();
            return data.Select(MapToDTO).ToList();
        }
        public static LoginDTO GetByUsernameAndPassword(string username, string password)
        {
            var data = DataFactory.LoginData().Get().FirstOrDefault(u => u.username == username && u.password == password);

            // Check if data is null, meaning no user found with the provided username and password
            if (data == null)
                return null;

            return MapToDTO(data);
        }

        private static LoginDTO MapToDTO(Login entity)
        {
            return new LoginDTO
            {
                Id = entity.Id,
                username = entity.username,
                password = entity.password,
                roll = entity.roll,
                SignUpId = entity.SignUpId,
                // Assuming SignUp is already mapped
                SignUp = SignUpService.Get(entity.SignUpId)
            };
        }

        private static Login MapToEntity(LoginDTO dto)
        {
            return new Login
            {
                Id = dto.Id,
                username = dto.username,
                password = dto.password,
                roll = dto.roll,
                SignUpId = dto.SignUpId
            };
        }
    }
}