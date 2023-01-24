using Database.Entities.FarmArea;
using Database.Entities.Tree;
using Microsoft.EntityFrameworkCore;

namespace Database.AppDbContexts
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TreeDb> TreeDbs { get; set; }
        public virtual DbSet<FarmAreaDb> FarmAreaDbs{ get; set; }



    }
}
