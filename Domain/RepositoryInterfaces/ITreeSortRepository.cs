using Domain.ModelInterfaces.TreeSort;

namespace Domain.RepositoryInterfaces
{
    public interface ITreeSortRepository
    {
        /// <summary>
        /// Add new tree sort
        /// </summary>
        public Task AddSort(ITreeSort treeSort);

        /// <summary>
        /// Delete existing tree sort
        /// </summary>
        public Task DeleteSort(int treeSortId);

        /// <summary>
        /// Get all tree sorts
        /// </summary>
        public Task<ITreeSort[]> GetAllTreeSorts();

        /// <summary>
        /// Gets the tree sort by id 
        /// </summary>
        public Task<ITreeSort> GetById(int id);
    }
}
