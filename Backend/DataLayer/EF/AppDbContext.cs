using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; } = null!;
        public DbSet<Reference> Refs { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reference>().HasKey(x => new { x.FromId, x.ToId });
            modelBuilder.Entity<Reference>().HasOne(x=>x.NoteFrom).WithMany(x=>x.ReferenceTo).HasForeignKey(x=>x.FromId);
            modelBuilder.Entity<Reference>().HasOne(x=>x.NoteTo).WithMany(x=>x.ReferenceFrom).HasForeignKey(x=>x.ToId);
            /*modelBuilder.Entity<Reference>().HasOne(r => r.Note).WithMany(n => n.Refs).HasForeignKey(x => x.NoteId);
            modelBuilder.Entity<Reference>().HasOne(r => r.NoteLink).WithMany(n => n.Referring).HasForeignKey(x => x.LinkId);*/
            modelBuilder.Entity<Note>().HasData(
                new Note() { Id = 1, Title = "Моя первая заметка", Content = "Какой-то текст" },
                new Note() { Id = 2, Title = "Моя вторая заметка", Content = "Ещё какой-то текст" }
            );
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
