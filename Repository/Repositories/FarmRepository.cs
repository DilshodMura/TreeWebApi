using AutoMapper;
using Database.AppDbContexts;
using Database.Entities.FarmArea;
using Domain.ModelInterfaces.FarmArea;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Repository.BusinessModels;

namespace Repository.Repositories
{
    public sealed class FarmRepository : IFarmRepository
    {
        private readonly IMapper _mapper;

        public FarmRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Add new farm area
        /// </summary>
        public async Task AddFarmArea(IFarmArea farm)
        {
            await using var dbContext = new AppDbContext();
            await dbContext.AddAsync(_mapper.Map<FarmAreaDb>(farm));
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete farm area
        /// </summary>
        public async Task DeleteFarmArea(int id)
        {
            await using var dbContext = new AppDbContext();
            var farmArea = await dbContext.FarmAreaDbs.FirstOrDefaultAsync(c => c.Id == id);
            if (farmArea != null)
            {
                dbContext.FarmAreaDbs.Remove(farmArea);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets farm area by Id
        /// </summary>
        public async Task<IFarmArea> GetFarmAreaById(int id)
        {
            await using var dbContext = new AppDbContext();
            var result = await dbContext.FarmAreaDbs.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<FarmModel>(result); 
        }

        /// <summary>
        /// Updates the farm area by id
        /// </summary>
        public async Task UpdateFarmArea(int areaId,IFarmArea area)
        {
            await using var dbContext = new AppDbContext();
            var farmDb = await dbContext.FarmAreaDbs.FirstOrDefaultAsync(x => x.Id == areaId);
            if (farmDb is null)
                throw new Exception("Tree can not be found");

            dbContext.FarmAreaDbs.Update(_mapper.Map(area, farmDb));

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all areas
        /// </summary>
        public async Task<IFarmArea[]> GetAllAreasAsync()
        {
            await using var dbContext = new AppDbContext();
            return await dbContext.FarmAreaDbs.Select(farmarea => _mapper.Map<FarmModel>(farmarea)).ToArrayAsync();
        }
    }
}
