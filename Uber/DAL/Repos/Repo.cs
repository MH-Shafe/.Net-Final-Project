using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.Repos
{
    internal class Repo
    {
        protected UberContext db;
        internal Repo()
        {
            db = new UberContext();
        }
    }
}
