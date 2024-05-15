using BLL.DTOs.Driver;
using DAL.EF.Entites.User;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Driver
{
    public class RideService
    {
        private readonly IRepo<Ride, int> _rideRepo;

        public RideService(IRepo<Ride, int> rideRepo)
        {
            _rideRepo = rideRepo;
        }

        public void CreateRide(RideDTO rideDTO)
        {
            // Map DTO to entity
            var ride = new Ride
            {
                RideID = rideDTO.RideID,
                UserID = rideDTO.UserID,
                DriverID = rideDTO.DriverID,
                PickupLocation = rideDTO.PickupLocation,
                Destination = rideDTO.Destination,
                Fare = rideDTO.Fare,
                Status = rideDTO.Status
            };

            // Call repository to create ride
            _rideRepo.Create(ride);
        }

        public List<RideDTO> GetAllRides()
        {
            var rides = _rideRepo.Get();
            var rideDTOs = new List<RideDTO>();

            // Map entities to DTOs
            foreach (var ride in rides)
            {
                rideDTOs.Add(new RideDTO
                {
                    RideID = ride.RideID,
                    UserID = ride.UserID,
                    DriverID = ride.DriverID,
                    PickupLocation = ride.PickupLocation,
                    Destination = ride.Destination,
                    Fare = ride.Fare,
                    Status = ride.Status
                });
            }

            return rideDTOs;
        }

        public RideDTO GetRideById(int id)
        {
            var ride = _rideRepo.Get(id);

            if (ride == null)
                return null;

            // Map entity to DTO
            var rideDTO = new RideDTO
            {
                RideID = ride.RideID,
                UserID = ride.UserID,
                DriverID = ride.DriverID,
                PickupLocation = ride.PickupLocation,
                Destination = ride.Destination,
                Fare = ride.Fare,
                Status = ride.Status
            };

            return rideDTO;
        }

        public void UpdateRide(RideDTO rideDTO)
        {
            // Map DTO to entity
            var ride = new Ride
            {
                RideID = rideDTO.RideID,
                UserID = rideDTO.UserID,
                DriverID = rideDTO.DriverID,
                PickupLocation = rideDTO.PickupLocation,
                Destination = rideDTO.Destination,
                Fare = rideDTO.Fare,
                Status = rideDTO.Status
            };

            // Call repository to update ride
            _rideRepo.Update(ride);
        }

        public void DeleteRide(int id)
        {
            _rideRepo.Delete(id);
        }
    }
}