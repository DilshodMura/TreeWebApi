using AutoMapper;
using AutoMapper.QueryableExtensions;
using Database.AppDbContexts;
using Database.Entities.Tree;
using Domain.ModelInterfaces.BaseTree;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Repository.BusinessModels;

namespace Repository.Repositories
{
    public class TreeRepository : ITreeRepository
    {

        private readonly IMapper _mapper;

        public TreeRepository(IMapper mapper)
        {   
            _mapper= mapper;
        }

        /// <summary>
        /// Add new tree
        /// </summary>
        public async Task AddTreesAsync(IEnumerable<IBaseTree> trees)
        {
            await using var dbContext = new AppDbContext();
            var a = dbContext.TreeDbs.AddRangeAsync(trees.Select(_mapper.Map<TreeDb>));
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete tree
        /// </summary>
        public async Task DeleteTree(int id)
        {
            await using var dbContext = new AppDbContext();
            var tree = await dbContext.TreeDbs.FirstAsync(c => c.Id == id);
            dbContext.TreeDbs.Remove(tree);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all trees
        /// </summary>
        public async Task<IBaseTree[]> GetAllTreesAsync()
        {
            await using var dbContext = new AppDbContext();
            var configuration = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<IBaseTree, TreeDb>()
                                                 .ForPath(t => t.Area.Id, opt => opt.MapFrom(t => t.AreaId))
                                                 .ForPath(c => c.TreeSort.Name, opt => opt.MapFrom(t => t.Name))
                                                 .ForPath(c => c.TreeSort.MaxSquare, opt => opt.MapFrom(t => t.MaxSquare))
                                                 .ForPath(c => c.TreeSort.MaxFruitliness, opt => opt.MapFrom(t => t.MaxFruitliness))
                                                 .ForPath(c => c.TreeSort.MaxHeight, opt => opt.MapFrom(t => t.MaxHeight));

                cfg.CreateProjection<TreeDb, TreeBusinessModel>()
                                                 .ForMember(c => c.AreaId, opt => opt.MapFrom(t => t.Area.Id))
                                                 .ForMember(c => c.Name, opt => opt.MapFrom(t => t.TreeSort.Name))
                                                 .ForMember(c => c.MaxSquare, opt => opt.MapFrom(t => t.TreeSort.MaxSquare))
                                                 .ForMember(c => c.MaxFruitliness, opt => opt.MapFrom(t => t.TreeSort.MaxFruitliness))
                                                 .ForMember(c => c.MaxHeight, opt => opt.MapFrom(t => t.TreeSort.MaxHeight))
                                                 .ForMember(c => c.TreeSort, opt => opt.Ignore());
            });

            return await dbContext.TreeDbs.Include(t => t.TreeSort).ProjectTo<TreeBusinessModel>(configuration).AsNoTracking().ToArrayAsync();
            
        }

        /// <summary>
        /// Get tree by id
        /// </summary>
        public async Task<IBaseTree> GetTreeById(int id)
        {
            await using var dbContext = new AppDbContext();
            var result = await dbContext.TreeDbs.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<TreeBusinessModel>(result);
        }

        /// <summary>
        /// Update tree by id
        /// </summary>
        public async Task UpdateTreeAsync(IBaseTree tree)
        {
            await using var dbContext = new AppDbContext();
            var treeDb = await dbContext.TreeDbs.FirstAsync(c => c.Id == tree.Id);
            dbContext.Update(_mapper.Map(tree, treeDb));
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Calculate average height for trees in area
        /// </summary>
        public async Task<double> AverageMaxHeight(int areaId)
        {
            await using var dbContext = new AppDbContext();
            return await dbContext.TreeDbs.Where(c => c.AreaId == areaId).AverageAsync(c => c.TreeSort.MaxHeight);
        }

        /// <summary>
        /// Gets max fruitelness of trees
        /// </summary>
        public async Task<double> MaxFruitelness(int areaId)
        {
            await using var dbContext = new AppDbContext();
            return await dbContext.TreeDbs.Where(c => c.AreaId == areaId).MaxAsync(c => c.TreeSort.MaxFruitliness);
        }

        /// <summary>
        /// Gets area capacity of trees
        /// </summary>
        public async Task<double> AreaCapacity(int areaId)
        {
            await using var dbContext = new AppDbContext();
            var trees = dbContext.TreeDbs.Where(c => c.AreaId == areaId);
            if(trees == null)
            {
                return 0;
            }
            return await trees.SumAsync(t => t.TreeSort.MaxSquare);
        }
    }
}
