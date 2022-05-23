using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApi2.Models
{
    public partial class versenyzesContext : DbContext
    {
        public versenyzesContext()
        {
        }

        public versenyzesContext(DbContextOptions<versenyzesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Versenyszamok> Versenyszamoks { get; set; }
        public virtual DbSet<Versenyzo> Versenyzos { get; set; }
        public virtual DbSet<Versenyzoorszag> Versenyzoorszags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=versenyzes;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Versenyszamok>(entity =>
            {
                entity.HasKey(e => e.VersenyszamId)
                    .HasName("PRIMARY");

                entity.ToTable("versenyszamok");

                entity.HasIndex(e => e.VersenyzoId, "versenyzo_id");

                entity.Property(e => e.VersenyszamId)
                    .HasColumnType("int(11)")
                    .HasColumnName("versenyszam_id");

                entity.Property(e => e.VersenyszamFajta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("versenyszam_fajta");

                entity.Property(e => e.VersenyzoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("versenyzo_id");

                entity.HasOne(d => d.Versenyzo)
                    .WithMany(p => p.Versenyszamoks)
                    .HasForeignKey(d => d.VersenyzoId)
                    .HasConstraintName("versenyszamok_ibfk_1");
            });

            modelBuilder.Entity<Versenyzo>(entity =>
            {
                entity.ToTable("versenyzo");

                entity.Property(e => e.VersenyzoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("versenyzo_id");

                entity.Property(e => e.Eletkor)
                    .HasColumnType("int(2)")
                    .HasColumnName("eletkor");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nev");
            });

            modelBuilder.Entity<Versenyzoorszag>(entity =>
            {
                entity.HasKey(e => e.OrszagId)
                    .HasName("PRIMARY");

                entity.ToTable("versenyzoorszag");

                entity.HasIndex(e => e.VersenyzoId, "versenyzo_id");

                entity.Property(e => e.OrszagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("orszag_id");

                entity.Property(e => e.Orszaghelye)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("orszaghelye");

                entity.Property(e => e.Orszagneve)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("orszagneve");

                entity.Property(e => e.VersenyzoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("versenyzo_id");

                entity.HasOne(d => d.Versenyzo)
                    .WithMany(p => p.Versenyzoorszags)
                    .HasForeignKey(d => d.VersenyzoId)
                    .HasConstraintName("versenyzoorszag_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
