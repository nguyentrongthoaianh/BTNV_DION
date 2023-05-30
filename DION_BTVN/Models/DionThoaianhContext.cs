using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DION_BTVN.Models;

public partial class DionThoaianhContext : DbContext
{
    public DionThoaianhContext()
    {
    }

    public DionThoaianhContext(DbContextOptions<DionThoaianhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=103.157.218.110;Initial Catalog=DION.THOAIANH;User ID=sa;Password=beK%gwmh4S4n!e43;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            //entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F590E76C6");

            entity.ToTable("Account");

            //entity.Property(e => e.Id)
            //    .ValueGeneratedNever()
            //    .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
