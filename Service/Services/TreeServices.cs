using Domain.ModelInterfaces.BaseTree;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using Service.Models.BaseTree;

namespace Service.Services
{
    public sealed class TreeServices : ITreeService
    {
        private readonly ITreeRepository _treeRepository;
        private readonly IFarmRepository _fararmRepository;
        private readonly ITreeSortRepository _treeSortRepository;
        public TreeServices(ITreeRepository treeRepository, IFarmRepository fararmRepository, ITreeSortRepository treeSortRepository)
        {
            _treeRepository = treeRepository;
            _fararmRepository = fararmRepository;
            _treeSortRepository = treeSortRepository;
        }

        /// <summary>
        /// Add tree
        /// </summary>
        public async Task AddTree(int count, int sortId, int areaId)
        {
            var farmID = await _fararmRepository.GetFarmAreaById(areaId);
            if(farmID == null)
            {
                throw new Exception("Farm ID has not been found!");
            }
            var treeSort = await _treeSortRepository.GetById(sortId);
            IList<IBaseTree> trees = new List<IBaseTree>();
            for(int index = 0; index < count; index++)
            {
                var treeObj = new TreeModel()
                {
                    TreeSortId = sortId,
                    AreaId = areaId
                };
                trees.Add(treeObj);
            }
            await _treeRepository.AddTreesAsync(trees);
        }

        /// <summary>
        /// Get all trees
        /// </summary>
        public async Task<IBaseTree[]> GetAllTrees()
        {
           return await _treeRepository.GetAllTreesAsync();
        }

        /// <summary>
        /// Delete tree
        /// </summary>
        public async Task DeleteAsync(int treeId)
        {
            await _treeRepository.DeleteTree(treeId);
        }

        /// <summary>
        /// Calculate average height of trees
        /// </summary>
        public async Task<double> AverageMaxHeight (int areaId)
        {
            return await _treeRepository.AverageMaxHeight(areaId);
        }

        /// <summary>
        /// Get max fruitelness of trees in area
        /// </summary>
        public async Task<double> GetMaxFruitelness(int areaId)
        {
            return await _treeRepository.MaxFruitelness(areaId);
        }

        /// <summary>
        /// Gets area capacity of trees
        /// </summary>
        public async Task<double> AreaCapacity(int areaId)
        {
            var areaCap = _fararmRepository.GetFarmAreaById(areaId).Result;
            if((await _treeRepository.AreaCapacity(areaId))> areaCap.Capacity)
            {
                throw new Exception("Trees area is more than farm area!");
            }
            return await _treeRepository.AreaCapacity(areaId);
        }
    }
}
