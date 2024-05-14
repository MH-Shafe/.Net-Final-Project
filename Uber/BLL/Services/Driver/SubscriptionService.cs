using BLL.DTOs.Driver;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Driver
{
    public class SubscriptionService : IRepo<Subscription, int>
    {
        private readonly IRepo<Subscription, int> _subscriptionRepo;

        public SubscriptionService(IRepo<Subscription, int> subscriptionRepo)
        {
            _subscriptionRepo = subscriptionRepo;
        }

        public void Create(Subscription obj)
        {
            _subscriptionRepo.Create(obj);
        }

        public List<Subscription> Get()
        {
            return _subscriptionRepo.Get();
        }

        public Subscription Get(int id)
        {
            return _subscriptionRepo.Get(id);
        }

        public void Update(Subscription obj)
        {
            _subscriptionRepo.Update(obj);
        }

        public void Delete(int id)
        {
            _subscriptionRepo.Delete(id);
        }
    }
}

