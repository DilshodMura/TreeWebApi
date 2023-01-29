using Database.Entities.FarmArea;
using Database.Entities.Sort;
using Database.Entities.Tree;
using Database.Entities.Type;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Database.AppDbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public AppDbContext()
        {

        }
        public virtual DbSet<TreeDb> TreeDbs { get; set; }
        public virtual DbSet<FarmAreaDb> FarmAreaDbs{ get; set; }

        public virtual DbSet<TreeSortDb> TreeSortDbs { get; set; }
        public virtual DbSet<TreeTypeDb> TreeTypesDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreeDb>()
                .HasOne(t => t.Area)
                .WithMany(p => p.trees)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TreeSortDb>()
                .HasOne(x => x.TreeType)
                .WithMany(z => z.TreeSorts)
                .OnDelete(DeleteBehavior.Cascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=nba-091-01-UZ\\SQLEXPRESS;Database=TreeDb;Trusted_Connection=True; TrustServerCertificate=True;",
                 builder => builder.EnableRetryOnFailure())
                 .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning));
            }
        }
    }
}
