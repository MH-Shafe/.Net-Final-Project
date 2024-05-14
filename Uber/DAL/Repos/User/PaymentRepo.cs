using DAL.EF;
using DAL.EF.Entities.User;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.User
{
    internal class PaymentRepo : IRepo<Payment_u, int>
    {
        private readonly UberContext _context;

        public PaymentRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(Payment_u obj)
        {
            _context.Payment_us.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var payment = _context.Payment_us.Find(id);
            if (payment != null)
            {
                _context.Payment_us.Remove(payment);
                _context.SaveChanges();
            }
        }

        public List<Payment_u> Get()
        {
            return _context.Payment_us.ToList();
        }

        public Payment_u Get(int id)
        {
            return _context.Payment_us.Find(id);
        }

        public void Update(Payment_u obj)
        {
            var payment = _context.Payment_us.Find(obj.PaymentID);
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