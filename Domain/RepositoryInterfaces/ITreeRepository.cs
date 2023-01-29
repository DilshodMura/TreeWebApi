using Domain.ModelInterfaces.BaseTree;

namespace Domain.RepositoryInterfaces
{
    public interface ITreeRepository
    {
        /// <summary>
        /// Add new tree
        /// </summary>
        public Task AddTreesAsync(IEnumerable<IBaseTree> trees);

        /// <summary>
        /// Get all trees
        /// </summary>
        public Task<IBaseTree[]> GetAllTreesAsync();

        /// <summary>
        /// Delete particular tree
        /// </summary>
        public Task DeleteTree(int id);

        /// <summary>
        /// Gets particular tree by id
        /// </summary>
        public Task<IBaseTree> GetTreeById(int id);

        /// <summary>
        /// Update particular tree by id
        /// </summary>
        public Task UpdateTreeAsync(IBaseTree tree);

        /// <summary>
        /// Calculates average height in particular area
        /// </summary>
        public Task<double> AverageMaxHeight(int areaId);

        /// <summary>
        /// Calculates max fruitless in particular area
        /// </summary>
        public Task<double> MaxFruitelness(int areaId);

        /// <summary>
        /// Calculates capacity of area
        /// </summary>
        public Task<double> AreaCapacity(int areaId);
    }
}
