
using Domain.ModelInterfaces.FarmArea;

namespace Domain.ServiceInterfaces
{
    public interface IFarmService
    {
        /// <summary>
        /// Add new area
        /// </summary>
        public Task AddFarmArea(int area);

        /// <summary>
        /// Get all areas
        /// </summary>
        public Task<IFarmArea[]> GetAllAsync();

        /// <summary>
        /// Update area
        /// </summary>
        public Task UpdateAsync(IFarmArea farmArea);

        /// <summary>
        /// Delete area 
        /// </summary>
        public Task DeleteAsync(int id);

    }
}
