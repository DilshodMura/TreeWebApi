using Domain.Enums;
using Domain.ModelInterfaces.BaseTree;

namespace Domain.RepositoryInterfaces
{
    public interface ITreeRepository
    {
        /// <summary>
        /// Add new tree
        /// </summary>
        public Task AddTreesAsync(IBaseTree trees);

        /// <summary>
        /// Get all trees
        /// </summary>
        public Task<IBaseTree[]> GetAllAsync();

        /// <summary>
        /// Delete particular tree
        /// </summary>
        public Task Delete(int id);

        /// <summary>
        /// Gets particular tree by id
        /// </summary>
        public Task<IBaseTree> GetById(int id);

        /// <summary>
        /// Gets particular tree by sort
        /// </summary>
        public Task<IBaseTree> GetBySort(TreeSorts sort);

        /// <summary>
        /// Update particular tree by id
        /// </summary>
        public Task UpdateAsync(int id, IBaseTree tree);

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
