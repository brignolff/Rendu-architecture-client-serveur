using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model;

namespace ORM
{
    public partial class ArchiNTiersContext : DbContext
    {
        public ArchiNTiersContext()
        {
        }

        public ArchiNTiersContext(DbContextOptions<ArchiNTiersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auteur> Auteurs { get; set; } = null!;
        public virtual DbSet<Livre> Livres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSqlLocalDB;Database=ArchiNTiers;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auteur>(entity =>
            {
                entity.HasKey(e => e.IdAuteur);

                entity.ToTable("Auteur");

                entity.Property(e => e.DateNaissance).HasColumnType("datetime");

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Prenom).HasMaxLength(50);
            });

            modelBuilder.Entity<Livre>(entity =>
            {
                entity.HasKey(e => e.IdLivre)
                    .HasName("PK__Livre__3B69D8A0B4961680");

                entity.ToTable("Livre");

                entity.Property(e => e.Genre).HasMaxLength(50);

                entity.Property(e => e.Titre).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
