using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BombRepo : Repo, IRepo<bombdisposal, int, bool>
    {
        public bool Add(bombdisposal obj)
        {
            db.bombdisposals.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.bombdisposals.Find(id);
            db.bombdisposals.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<bombdisposal> Get()
        {
            return db.bombdisposals.ToList();
        }

        public bombdisposal Get(int id)
        {
            return db.bombdisposals.Find(id);
        }

        public bool Update(bombdisposal obj)
        {
            var ext = Get(obj.id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
