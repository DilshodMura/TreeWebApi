using Domain.ModelInterfaces.FarmArea;

namespace Domain.RepositoryInterfaces
{
    public interface IFarmRepository
    {
        /// <summary>
        /// Adds new area
        /// </summary>
        public Task AddFarmArea(IFarmArea farm);

        /// <summary>
        /// Delete particular area by id
        /// </summary>
        public Task DeleteFarmArea(int id);

        /// <summary>
        /// Gets area by id.
        /// </summary>
        public Task<IFarmArea> GetFarmAreaById(int id);

        /// <summary>
        /// Update the particular area
        /// </summary>
        public Task UpdateFarmArea(int areaId,IFarmArea area);

        /// <summary>
        /// Gets all areas
        /// </summary>
        public Task<IFarmArea[]> GetAllAreasAsync();
    }
}
