using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Models;

public partial class TreeDbFirstContext : DbContext
{
    public TreeDbFirstContext()
    {
    }

    public TreeDbFirstContext(DbContextOptions<TreeDbFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FarmArea> FarmAreas { get; set; }

    public virtual DbSet<Tree> Trees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=nba-091-01-UZ\\SQLEXPRESS;Database=TreeDbFirst; Integrated Security=SSPI;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FarmArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FarmArea__3214EC07935FCD6C");

            entity.ToTable("FarmArea");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tree>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trees__3214EC07239C488D");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Area).WithMany(p => p.Trees)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Trees__AreaId__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
