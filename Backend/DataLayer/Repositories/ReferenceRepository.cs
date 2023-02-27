using DataLayer.EF;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ReferenceRepository : IRepository<Reference>
    {
        AppDbContext db;
        public ReferenceRepository(AppDbContext db)
        {
            this.db = db;
        }

        public void Create(Reference item)
        {
            db.Refs.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Reference reference = db.Refs.Find(id);
            db.Refs.Remove(reference);
            db.SaveChanges();
        }

        public Reference Get(int id)
        {
            Reference reference = db.Refs.Find(id);
            return reference;
        }

        public IEnumerable<Reference> GetAll()
        {
            return db.Refs;
        }

        public Reference Update(Reference item)
        {
            db.Refs.Update(item);
            db.SaveChanges();
            return item;
        }
    }
}
