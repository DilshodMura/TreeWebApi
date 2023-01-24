using Domain.Enums;
using Domain.ModelInterfaces.BaseTree;

namespace Domain.ServiceInterfaces
{
    public interface ITreeService
    {
        /// <summary>
        /// Add new tree
        /// </summary>
        public Task AddTree(int count, TreeSorts sorts, int areaId);

        /// <summary>
        /// Get all trees
        /// </summary>
        public Task<IBaseTree[]> GetAllTrees();

        /// <summary>
        /// Calculates average height in particular area
        /// </summary>
        public Task<double> AverageMaxHeight(int areaId);

        /// <summary>
        /// Calculates max fruitless in particular area
        /// </summary>
        public Task<double> GetMaxFruitelness(int areaId);

        /// <summary>
        /// Delete tree
        /// </summary>
        public Task DeleteAsync(int count, int areaId, TreeSorts sort);

        /// <summary>
        /// Calculates capacity of trees
        /// </summary>
        public Task<double> AreaCapacity(int areaId);

    }
}
