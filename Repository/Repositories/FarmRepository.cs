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

        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public FarmRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Add new farm area
        /// </summary>
        public async Task AddFarmArea(IFarmArea farm)
        {
            await _appDbContext.AddAsync(_mapper.Map<FarmAreaDb>(farm));
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete farm area
        /// </summary>
        public async Task DeleteFarmArea(int id)
        {
            var farmArea = await _appDbContext.FarmAreaDbs.FirstOrDefaultAsync(c => c.Id == id);
            if (farmArea != null)
            {
                _appDbContext.FarmAreaDbs.Remove(farmArea);
                await _appDbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets farm area by Id
        /// </summary>
        public async Task<IFarmArea> GetFarmAreaById(int id)
        {
            var result = await _appDbContext.FarmAreaDbs.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<FarmModel>(result); 
        }

        /// <summary>
        /// Updates the farm area by id
        /// </summary>
        public async Task UpdateFarmArea(int areaId,IFarmArea area)
        {
            var farmDb = await _appDbContext.FarmAreaDbs.FirstOrDefaultAsync(x => x.Id == areaId);
            if (farmDb is null)
                throw new Exception("Tree can not be found");

            _appDbContext.FarmAreaDbs.Update(_mapper.Map(area, farmDb));

            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all areas
        /// </summary>
        public async Task<IFarmArea[]> GetAllAreasAsync()
        {
            return await _appDbContext.FarmAreaDbs.Select(farmarea => _mapper.Map<FarmModel>(farmarea)).ToArrayAsync();
        }
    }
}
