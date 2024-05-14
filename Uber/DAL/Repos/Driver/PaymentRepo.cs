using DAL.EF;
using DAL.EF.Entities.Driver;

using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.User
{
    internal class PaymentRepo : IRepo<Payment, int>
    {
        private readonly UberContext _context;

        public PaymentRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(Payment obj)
        {
            _context.Payments.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
            }
        }

        public List<Payment> Get()
        {
            return _context.Payments.ToList();
        }

        public Payment Get(int id)
        {
            return _context.Payments.Find(id);
        }

        public void Update(Payment obj)
        {
            var payment = _context.Payments.Find(obj.PaymentID);
            if (payment != null)
            {
                // Assuming you want to update all properties
                payment.PaymentMethod = obj.PaymentMethod;
                payment.TransactionAmount = obj.TransactionAmount;
                payment.Timestamp = obj.Timestamp;

                _context.SaveChanges();
            }
        }
    }
}