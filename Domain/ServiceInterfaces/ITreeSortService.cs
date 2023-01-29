using Domain.ModelInterfaces.TreeSort;

namespace Domain.ServiceInterfaces
{
    public interface ITreeSortService
    {
        /// <summary>
        /// Add new tree sort
        /// </summary>
        public Task AddTreeSort(ITreeSort treeSort);

        /// <summary>
        /// Delete tree sort
        /// </summary>
        public Task RemoveTreeSort(int treeSortId);

        /// <summary>
        /// Get all tree sorts
        /// </summary>
        public Task<ITreeSort[]> GetAllTreeSorts();
    }
}
