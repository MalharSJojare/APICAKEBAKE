using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CakeBake.CakeBakeDir
{
    public partial class CakeBakeContext : DbContext
    {
        public CakeBakeContext()
        {
        }

        public CakeBakeContext(DbContextOptions<CakeBakeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminTable> AdminTables { get; set; }
        public virtual DbSet<CakeTable> CakeTables { get; set; }
        public virtual DbSet<CustomerTable> CustomerTables { get; set; }
        public virtual DbSet<OrderTable> OrderTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLSERVER2019G3;Database=CakeBake;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminTable>(entity =>
            {
                entity.HasKey(e => e.Asername)
                    .HasName("PK__AdminTab__47A0239EDCB2B653");

                entity.ToTable("AdminTable");

                entity.Property(e => e.Asername)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Aemail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AEmail");

                entity.Property(e => e.AmobNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AMobNo");

                entity.Property(e => e.Apassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APassword");
            });

            modelBuilder.Entity<CakeTable>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__CakeTabl__B40CC6CDC7879D5B");

                entity.ToTable("CakeTable");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.ProDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProImage)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ProName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerTable>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Customer__536C85E56B694752");

                entity.ToTable("CustomerTable");

                entity.HasIndex(e => e.UmobNo, "UQ__Customer__BC718A690B4365C3")
                    .IsUnique();

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uaddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UAddress");

                entity.Property(e => e.Uemail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UEmail");

                entity.Property(e => e.UmobNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UMobNo");

                entity.Property(e => e.Upassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPassword");
            });

            modelBuilder.Entity<OrderTable>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderTab__C3905BCFBCEF8B69");

                entity.ToTable("OrderTable");

                entity.HasIndex(e => e.Username, "UQ__OrderTab__536C85E471C246F9")
                    .IsUnique();

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Uaddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UAddress");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
