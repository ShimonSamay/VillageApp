using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VillageAPP.Models
{
    public partial class VillageDB : DbContext
    {
        public VillageDB()
            : base("name=VillageDB")
        {
        }
        public virtual DbSet<Resident> Residents { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
