using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IDP_RPWebAPI;

public partial class AspnetwebapidbContext : DbContext
{
    public AspnetwebapidbContext()
    {
    }

    public AspnetwebapidbContext(DbContextOptions<AspnetwebapidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=CTAADPG038Q88\\SQLEXPRESS;database=aspnetwebapidb;integrated security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Custid).HasName("pk_custid");

            entity.ToTable("customers");

            entity.Property(e => e.Custid)
                .ValueGeneratedNever()
                .HasColumnName("custid");
            entity.Property(e => e.Custname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("custname");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("location");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("pk_orderid");

            entity.ToTable("orders");

            entity.Property(e => e.Orderid)
                .ValueGeneratedNever()
                .HasColumnName("orderid");
            entity.Property(e => e.Custid).HasColumnName("custid");
            entity.Property(e => e.Ordername)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ordername");

            entity.HasOne(d => d.Cust).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Custid)
                .HasConstraintName("fk_custid");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("pk_username");

            entity.ToTable("users");

            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Pwd)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pwd");
            entity.Property(e => e.Userrole)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userrole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
