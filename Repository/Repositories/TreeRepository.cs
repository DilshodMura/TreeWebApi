using AutoMapper;
using Database.AppDbContexts;
using Database.Entities.Tree;
using Domain.Enums;
using Domain.ModelInterfaces.BaseTree;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Repository.BusinessModels;

namespace Repository.Repositories
{
    public class TreeRepository : ITreeRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public TreeRepository(AppDbContext appDbContext,IMapper mapper)
        {   
            _appDbContext= appDbContext;
            _mapper= mapper;
        }

        /// <summary>
        /// Add new tree
        /// </summary>
        public async Task AddTreesAsync(IBaseTree trees)
        {
            await _appDbContext.AddAsync(_mapper.Map<TreeDb>(trees));
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete tree
        /// </summary>
        public async Task Delete(int id)
        {
            var tree = await _appDbContext.TreeDbs.FirstOrDefaultAsync(c => c.Id == id);
            if(tree != null)
            {
                _appDbContext.TreeDbs.Remove(tree);
                await _appDbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all trees
        /// </summary>
        public async Task<IBaseTree[]> GetAllAsync()
        {
           return await _appDbContext.TreeDbs.Select(trees => _mapper.Map<TreeModel>(trees)).ToArrayAsync();
        }

        /// <summary>
        /// Get tree by id
        /// </summary>
        public async Task<IBaseTree> GetById(int id)
        {
            var result = await _appDbContext.TreeDbs.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<TreeModel>(result);
        }

        /// <summary>
        /// Get tree by sort
        /// </summary>
        public async Task<IBaseTree> GetBySort(TreeSorts sort)
        {
            var result = await _appDbContext.TreeDbs.FirstOrDefaultAsync(c => c.SortName == sort);
            return _mapper.Map<TreeModel>(result);
        }

        /// <summary>
        /// Update tree by id
        /// </summary>
        public async Task UpdateAsync(int id, IBaseTree tree)
        {
            var treeDb = await _appDbContext.TreeDbs.FirstOrDefaultAsync(c => c.Id == id);
            if(treeDb == null)
            {
                throw new Exception();
            }
             _appDbContext.Update(_mapper.Map(tree, treeDb));
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Calculate average height for trees in area
        /// </summary>
        public async Task<double> AverageMaxHeight(int areaId)
        {
            return await _appDbContext.TreeDbs.Where(c => c.AreaId == areaId).AverageAsync(c => c.MaxHeight);
        }

        /// <summary>
        /// Gets max fruitelness of trees
        /// </summary>
        public async Task<double> MaxFruitelness(int areaId)
        {
            return await _appDbContext.TreeDbs.Where(c => c.AreaId == areaId).MaxAsync(c => c.MaxFruitliness);
        }

        /// <summary>
        /// Gets area capacity of trees
        /// </summary>
        public async Task<double> AreaCapacity(int areaId)
        {
            var trees = _appDbContext.TreeDbs.Where(c => c.AreaId == areaId);
            if(trees == null)
            {
                return 0;
            }
            return await trees.SumAsync(t => t.MaxSquare);
        }
    }
}
