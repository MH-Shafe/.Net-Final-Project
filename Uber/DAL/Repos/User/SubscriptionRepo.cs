using DAL.EF;
using DAL.EF.Entites.User;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.User
{
    internal class SubscriptionRepo : IRepo<Subscription_u, int>
    {
        private readonly UberContext _context;

        public SubscriptionRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(Subscription_u obj)
        {
            _context.Subscription_us.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var subscription = _context.Subscription_us.Find(id);
            if (subscription != null)
            {
                _context.Subscription_us.Remove(subscription);
                _context.SaveChanges();
            }
        }

        public List<Subscription_u> Get()
        {
            return _context.Subscription_us.ToList();
        }

        public Subscription_u Get(int id)
        {
            return _context.Subscription_us.Find(id);
        }

        public void Update(Subscription_u obj)
        {
            var existingSubscription = _context.Subscription_us.Find(obj.SubscriptionID);
            if (existingSubscription != null)
            {
                existingSubscription.UserID = obj.UserID;
                existingSubscription.Type = obj.Type;
                existingSubscription.Duration = obj.Duration;
                existingSubscription.Price = obj.Price;
                existingSubscription.ExpiryDate = obj.ExpiryDate;
                // Update other properties as needed
                _context.SaveChanges();
            }
        }
    }
}