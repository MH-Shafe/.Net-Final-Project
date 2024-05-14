using AutoMapper;
using BLL.DTOs.User;
using DAL.EF.Entities.Driver;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services.User
{
    public class PaymentService
    {
        private readonly IRepo<Payment, int> _paymentRepo;
        private readonly IMapper _mapper;

        public PaymentService(IRepo<Payment, int> paymentRepo, IMapper mapper)
        {
            _paymentRepo = paymentRepo;
            _mapper = mapper;
        }

        public void CreatePayment(PaymentDTO paymentDTO)
        {
            var paymentEntity = _mapper.Map<Payment>(paymentDTO);
            _paymentRepo.Create(paymentEntity);
        }

        public void UpdatePayment(PaymentDTO paymentDTO)
        {
            var paymentEntity = _mapper.Map<Payment>(paymentDTO);
            _paymentRepo.Update(paymentEntity);
        }

        public void DeletePayment(int id)
        {
            _paymentRepo.Delete(id);
        }

        public PaymentDTO GetPayment(int id)
        {
            var paymentEntity = _paymentRepo.Get(id);
            return _mapper.Map<PaymentDTO>(paymentEntity);
        }

        public List<PaymentDTO> GetAllPayments()
        {
            var paymentEntities = _paymentRepo.Get();
            return _mapper.Map<List<PaymentDTO>>(paymentEntities);
        }
    }
}
