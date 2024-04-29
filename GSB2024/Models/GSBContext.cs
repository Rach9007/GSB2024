using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GSB2024.Models
{
    public partial class GSBContext : DbContext
    {
        public GSBContext()
        {
        }

        public GSBContext(DbContextOptions<GSBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departement> Departements { get; set; } = null!;
        public virtual DbSet<Medecin> Medecins { get; set; } = null!;
        public virtual DbSet<Specialite> Specialites { get; set; } = null!;
        public virtual DbSet<Utilsateur> Utilsateurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GSP_API;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasKey(e => e.IdDepartement)
                    .HasName("PK__Departem__1013779AB11DB979");

                entity.ToTable("Departement");

                entity.Property(e => e.IdDepartement)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CodeRegion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomDepartement)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomRegion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medecin>(entity =>
            {
                entity.HasKey(e => e.IdMedecin)
                    .HasName("PK__Medecin__8371CA43A8A712FB");

                entity.ToTable("Medecin");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdDepartement)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartementNavigation)
                    .WithMany(p => p.Medecins)
                    .HasForeignKey(d => d.IdDepartement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medecin__IdDepar__3E52440B");

                entity.HasOne(d => d.IdSpecialiteNavigation)
                    .WithMany(p => p.Medecins)
                    .HasForeignKey(d => d.IdSpecialite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medecin__IdSpeci__3D5E1FD2");
            });

            modelBuilder.Entity<Specialite>(entity =>
            {
                entity.HasKey(e => e.IdSpecialite)
                    .HasName("PK__Speciali__5C8D4E7C6E64572A");

                entity.ToTable("Specialite");

                entity.Property(e => e.LibelleSpecialite)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Utilsateur>(entity =>
            {
                entity.HasKey(e => e.IdUtilisateur)
                    .HasName("PK__Utilsate__45A4C157F9777A3B");

                entity.ToTable("Utilsateur");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MotDePasse)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
