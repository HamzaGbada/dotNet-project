using Microsoft.EntityFrameworkCore;
using RestoManager_HamzaGbada.Models.RestosModel;

namespace RestoManager_HamzaGbada.Models.RestosModel
{
    public class RestosDbContext : DbContext

    {
        public RestosDbContext(DbContextOptions<RestosDbContext> options)
            : base(options)
        { }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Proprietaire> Proprietaires { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Proprietaire>().ToTable("TProprietaire", "resto");
            modelBuilder.Entity<Proprietaire>().HasKey(p => p.Numero);

            modelBuilder.Entity<Proprietaire>().Property(p => p.Nom).HasColumnName("NomProp")
                .HasMaxLength(20).IsRequired();

            modelBuilder.Entity<Proprietaire>().Property(p => p.Email).HasColumnName("EmailProp")
    .HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Proprietaire>().Property(p => p.Gsm).HasColumnName("GsmProp")
    .HasMaxLength(8).IsRequired();



            modelBuilder.Entity<Restaurant>().ToTable("TRestaurant", "resto");
            modelBuilder.Entity<Restaurant>().HasKey(p =>p.CodeResto);

            modelBuilder.Entity<Restaurant>().Property(p => p.NomResto)
                .HasMaxLength(20).IsRequired();

            modelBuilder.Entity<Restaurant>().Property(p => p.Specialite).HasColumnName("SpecResto")
    .HasMaxLength(50).IsRequired().HasDefaultValue("Tunisienne");

            modelBuilder.Entity<Restaurant>().Property(p => p.Ville).HasColumnName("VilleResto")
    .HasMaxLength(8).IsRequired();
            modelBuilder.Entity<Restaurant>().Property(p => p.Tel).HasColumnName("TelResto")
    .HasMaxLength(8).IsRequired();

            modelBuilder.Entity<Proprietaire>().HasMany(r => r.Restaurants).WithOne(
                p => p.Proprietaire).HasForeignKey(r => r.NumProp)
                .HasConstraintName("Relation_Proprio_Restos");


            modelBuilder.Entity<Avis>(entity =>
            {
                entity.ToTable("TAvis", "admin");
                entity.HasKey(e => e.CodeAvis);
                entity.Property(e => e.NomPersonne).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Note).IsRequired();
                entity.Property(e => e.Commentaire)
                    .HasMaxLength(256);
                entity.HasOne(a => a.Restaurant).WithMany(r => r.Avis)
                    .HasForeignKey(a => a.NumResto)
                    .HasConstraintName("Relation_Resto_Avis");
            });



        }
        public DbSet<RestoManager_HamzaGbada.Models.RestosModel.Avis> Avis { get; set; } = default!;
    }
}
