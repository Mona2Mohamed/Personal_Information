using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project5.Models
{
    public partial class Project5Model1 : DbContext
    {
        public Project5Model1()
            : base("name=Project5Model1")
        {
        }

        public virtual DbSet<Personal_Information> Personal_Information { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personal_Information>()
                .Property(e => e.Phone_Number_)
                .IsUnicode(false);
        }
    }
}
