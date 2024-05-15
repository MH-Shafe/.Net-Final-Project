﻿using DAL.EF.Entities.Driver;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Driver
{
    internal class DriverRepo : IRepo<DriverEF, int>
    {
        private readonly UberContext _context;

        public DriverRepo(UberContext context)
        {
            _context = context;
        }

        public void Create(DriverEF obj)
        {
            _context.DriverEFs.Add(obj);
            _context.SaveChanges();
        }

        public List<DriverEF> Get()
        {
            return _context.DriverEFs.ToList();
        }

        public DriverEF Get(int id)
        {
            return _context.DriverEFs.Find(id);
        }

        public void Update(DriverEF obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var driver = _context.DriverEFs.Find(id);
            if (driver != null)
            {
                _context.DriverEFs.Remove(driver);
                _context.SaveChanges();
            }
        }
    }
}