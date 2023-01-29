using AutoMapper;
using Database.AppDbContexts;
using Database.Entities.Type;
using Domain.ModelInterfaces.TreeType;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Repository.BusinessModels;

namespace Repository.Repositories
{
    public class TreeTypeRepository : ITreeTypeRepository
    {
        private readonly IMapper _mapper;

        public TreeTypeRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Add new tree type
        /// </summary>
        public async Task AddTreeType(ITreeType treeType )
        {
            await using var dbContext = new AppDbContext();
            await dbContext.TreeTypesDb.AddAsync(_mapper.Map<TreeTypeDb>(treeType));
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete tree type
        /// </summary>
        public async Task DeleteTreeType(int treeTypeId)
        {
            await using var dbContext = new AppDbContext();
            var tree = await dbContext.TreeTypesDb.FirstAsync(c => c.Id == treeTypeId);
            dbContext.TreeTypesDb.Remove(tree);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all tree type
        /// </summary>
        public async Task<ITreeType[]> GetAllTreeTypes()
        {
            await using var dbContext = new AppDbContext();
            return await _mapper.ProjectTo<TreeType>(dbContext.TreeTypesDb).ToArrayAsync();
        }

        /// <summary>
        /// Get the tree type by id
        /// </summary>
        public async Task<ITreeType> GetById(int typeId)
        {
            await using var dbContext = new AppDbContext();
            var result = await dbContext.TreeTypesDb.FirstOrDefaultAsync(c => c.Id == typeId);
            return _mapper.Map<TreeType>(result);
        }
    }
}
