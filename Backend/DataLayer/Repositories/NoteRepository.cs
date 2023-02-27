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
    public class NoteRepository : IRepository<Note>
    {
        AppDbContext db;
        public NoteRepository(AppDbContext context)
        {
            this.db = context;
        }
        public void Create(Note item)
        {
            db.Notes.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
            db.SaveChanges();
        }

        public Note Get(int id)
        {
            Note note = db.Notes.Find(id);
            return note;

        }

        public IEnumerable<Note> GetAll()
        {
            return db.Notes;
        }

        public Note Update(Note item)
        {
            db.Notes.Update(item);
            db.SaveChanges();
            return item;
        }
    }
}
