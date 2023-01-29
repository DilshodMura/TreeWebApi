using AutoMapper;
using Database.AppDbContexts;
using Database.Entities.Sort;
using Domain.ModelInterfaces.TreeSort;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Repository.BusinessModels;

namespace Repository.Repositories
{
    public class TreeSortRepository : ITreeSortRepository
    {
        private readonly IMapper _mapper;

        public TreeSortRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Add new tree sort
        /// </summary>
        public async Task AddSort(ITreeSort treeSort)
        {
            using var dbContext = new AppDbContext();
            var mappeer = _mapper.Map<TreeSortDb>(treeSort);
            var a = await dbContext.TreeSortDbs.AddAsync(mappeer);
            var b = await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete tree sort
        /// </summary>
        public async Task DeleteSort(int treeSortId)
        {
            await using var dbContext = new AppDbContext();
            var tree = await dbContext.TreeSortDbs.FirstAsync(c => c.Id == treeSortId);
            dbContext.TreeSortDbs.Remove(tree);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all tree sorts
        /// </summary>
        public async Task<ITreeSort[]> GetAllTreeSorts()
        {
            await using var dbContext = new AppDbContext();
            return await _mapper.ProjectTo<TreeSort>(dbContext.TreeSortDbs).ToArrayAsync();
        }

        /// <summary>
        /// Get the tree sort by id
        /// </summary>
        public async Task<ITreeSort> GetById(int sortId)
        {
            await using var dbContext = new AppDbContext();
            var result = await dbContext.TreeSortDbs.FirstOrDefaultAsync(c => c.Id == sortId);
            return _mapper.Map<TreeSort>(result);
        }
    }
}
