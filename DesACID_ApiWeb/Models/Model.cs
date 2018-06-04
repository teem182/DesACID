namespace DesACID_ApiWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model2")
        {
        }

        public virtual DbSet<Datos> Datos { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Datos>()
                .Property(e => e.country_code)
                .IsUnicode(false);

            modelBuilder.Entity<Datos>()
                .Property(e => e.Indicador)
                .IsUnicode(false);

            modelBuilder.Entity<Datos>()
                .Property(e => e.Tasa)
                .IsUnicode(false);

            modelBuilder.Entity<Datos>()
                .Property(e => e.Country_Name)
                .IsUnicode(false);
        }
    }
}
