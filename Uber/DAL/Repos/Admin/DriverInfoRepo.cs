using DAL.EF.Entities.Admin;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Admin
{
   
        internal class DriverInfoRepo : Repo, IRepo<DriverInfo, int>
        {
            public void Create(DriverInfo obj)
            {
                db.DriverInfos.Add(obj);
                db.SaveChanges();
            }

            public void Delete(int id)
            {
                var exobj = Get(id);
                db.DriverInfos.Remove(exobj);
                db.SaveChanges();
            }

            public List<DriverInfo> Get()
            {
                return db.DriverInfos.ToList();
            }

            public DriverInfo Get(int id)
            {
                return db.DriverInfos.Find(id);
            }

        public List<DriverInfo> GetAll()
        {
            return db.DriverInfos.ToList();
        }
        public void Update(DriverInfo obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }


    }
    }
