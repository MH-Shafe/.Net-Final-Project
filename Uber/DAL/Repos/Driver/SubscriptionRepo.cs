using DAL.EF.Entites.Driver;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Driver
{
    internal class SubscriptionRepo : IRepo<Subscription, int>
    {
        private readonly UberContext _context;

        public SubscriptionRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(Subscription obj)
        {
            _context.Subscriptions.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var subscription = _context.Subscriptions.Find(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                _context.SaveChanges();
            }
        }

        public List<Subscription> Get()
        {
            return _context.Subscriptions.ToList();
        }

        public Subscription Get(int id)
        {
            return _context.Subscriptions.Find(id);
        }

        public void Update(Subscription obj)
        {
            var subscription = _context.Subscriptions.Find(obj.SubscriptionID);
            if (subscription != null)
            {
                
                subscription.Type = obj.Type;
                subscription.Duration = obj.Duration;
                subscription.Price = obj.Price;
                subscription.ExpiryDate = obj.ExpiryDate;

                _context.SaveChanges();
            }
        }
    }
}