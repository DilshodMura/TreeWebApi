using Database.Entities.FarmArea;
using Domain.ModelInterfaces.FarmArea;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;

namespace Service.Services
{
    public sealed class FarmService : IFarmService 
    {
        private readonly IFarmRepository _farmRepository;
        public FarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        /// <summary>
        /// Add farm area
        /// </summary>
        public async Task AddFarmArea(int area)
        {
            var farmArea = new FarmArea()
            {
                Capacity = area
            };
            await _farmRepository.AddFarmArea(farmArea);
        }

        /// <summary>
        /// Delete farm area
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var farmArea = await _farmRepository.GetFarmAreaById(id);
            if(farmArea != null)
            {
                await _farmRepository.DeleteFarmArea(id);
            }
            throw new Exception("Farm area has not been found");
        }

        /// <summary>
        /// Get all areas
        /// </summary>
        public async Task<IFarmArea[]> GetAllAsync()
        {
            return await _farmRepository.GetAllAreasAsync();
        }

        /// <summary>
        /// Update area
        /// </summary>
        public async Task UpdateAsync(IFarmArea farmArea)
        {
            var farm = await _farmRepository.GetFarmAreaById(farmArea.Id);
            if (farm == null)
                throw new Exception("Farm Area has not been found");

            await _farmRepository.UpdateFarmArea(farmArea.Id, farmArea);
        }
    }
}
