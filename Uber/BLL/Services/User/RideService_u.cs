using BLL.DTOs.User;
using DAL.EF.Entites.User;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.User
{
    public class RideService_u
    {
        private readonly IRepo<Ride_u, int> _rideRepo;

        public RideService_u(IRepo<Ride_u, int> rideRepo)
        {
            _rideRepo = rideRepo;
        }

        public void CreateRide(RideDTO rideDTO)
        {
            var rideEntity = MapToEntity(rideDTO);
            _rideRepo.Create(rideEntity);
        }

        public void UpdateRide(RideDTO rideDTO)
        {
            var rideEntity = MapToEntity(rideDTO);
            _rideRepo.Update(rideEntity);
        }

        public void DeleteRide(int id)
        {
            _rideRepo.Delete(id);
        }

        public List<RideDTO> GetAllRides()
        {
            var rideEntities = _rideRepo.Get();
            return rideEntities.Select(MapToDTO).ToList();
        }

        public RideDTO GetRideById(int id)
        {
            var rideEntity = _rideRepo.Get(id);
            return MapToDTO(rideEntity);
        }

        private Ride_u MapToEntity(RideDTO rideDTO)
        {
            return new Ride_u
            {
                RideID = rideDTO.RideID,
                UserID = rideDTO.UserID,
                DriverID = rideDTO.DriverID,
                PickupLocation = rideDTO.PickupLocation,
                Destination = rideDTO.Destination,
                Fare = rideDTO.Fare,
                Status = rideDTO.Status
            };
        }

        private RideDTO MapToDTO(Ride_u rideEntity)
        {
            return new RideDTO
            {
                RideID = rideEntity.RideID,
                UserID = rideEntity.UserID,
                DriverID = rideEntity.DriverID,
                PickupLocation = rideEntity.PickupLocation,
                Destination = rideEntity.Destination,
                Fare = rideEntity.Fare,
                Status = rideEntity.Status
            };
        }
    }
}
