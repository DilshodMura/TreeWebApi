using Domain.ModelInterfaces.TreeSort;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;

namespace Service.Services
{
    public sealed class TreeSortService : ITreeSortService
    {
        private readonly ITreeSortRepository _treeSortRepository;
        private readonly ITreeTypeRepository _treeTypeRepository;

        public TreeSortService(ITreeSortRepository treeSortRepository, ITreeTypeRepository treeTypeRepository)
        {
            _treeSortRepository = treeSortRepository;
            _treeTypeRepository = treeTypeRepository;
        }

        /// <summary>
        /// Add tree sort
        /// </summary>
        public async Task AddTreeSort(ITreeSort treeSort)
        {
            var tree = await _treeTypeRepository.GetById(treeSort.TreeTypeId);
            if (tree == null)
                throw new ArgumentException("Tree sort not found");

            await _treeSortRepository.AddSort(treeSort);
        }

        /// <summary>
        /// Get all tree sorts
        /// </summary>
        public async Task<ITreeSort[]> GetAllTreeSorts()
        {
            return await _treeSortRepository.GetAllTreeSorts();
        }

        /// <summary>
        /// Delete tree sort
        /// </summary>
        public Task RemoveTreeSort(int treeSortId)
        {
            return _treeSortRepository.DeleteSort(treeSortId);
        }
    }
}
