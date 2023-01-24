using Database.Entities.Apples;
using Database.Entities.Cherries;
using Domain.Enums;
using Domain.ModelInterfaces.BaseTree;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using System.Formats.Asn1;

namespace Service.Services
{
    public sealed class TreeServices : ITreeService
    {
        private readonly ITreeRepository _treeRepository;
        private readonly IFarmRepository _fararmRepository;
        public TreeServices(ITreeRepository treeRepository, IFarmRepository fararmRepository)
        {
            _treeRepository = treeRepository;
            _fararmRepository = fararmRepository;
        }

        /// <summary>
        /// Add tree
        /// </summary>
        public async Task AddTree(int count, TreeSorts sorts, int areaId)
        {
            var farmID = await _fararmRepository.GetFarmAreaById(areaId);
            if(farmID == null)
            {
                throw new Exception("Farm ID has not been found!");
            }
            var sort = await _treeRepository.GetBySort(sorts);

            if(sort == null)
            {
                switch (sorts)
                {
                    case TreeSorts.Golden:
                        var treeGolden = new AppleGolden()
                        {
                            Amount = count,
                            AreaId = areaId
                        };
                        await _treeRepository.AddTreesAsync(treeGolden);
                        break;
                    case TreeSorts.Semerenko:
                        var treeSemerenko = new AppleSemerenko()
                        {
                            Amount = count,
                            AreaId = areaId
                        };
                        await _treeRepository.AddTreesAsync(treeSemerenko);
                        break;
                    case TreeSorts.Oakland:
                        var treeOkland = new OklandCherry()
                        {
                            Amount = count,
                            AreaId = areaId
                        };
                        await _treeRepository.AddTreesAsync(treeOkland);
                        break;
                    case TreeSorts.Frosty:
                        var treeFrosty = new FrostyCherry()
                        {
                            Amount = count,
                            AreaId = areaId
                        };
                        await _treeRepository.AddTreesAsync(treeFrosty);
                        break;
                }
            }
            else
            {
                sort.Amount += count;
                await _treeRepository.UpdateAsync(sort.Id, sort);
            }
        }

        /// <summary>
        /// Get all trees
        /// </summary>
        public async Task<IBaseTree[]> GetAllTrees()
        {
           return await _treeRepository.GetAllAsync();
        }

        public async Task DeleteAsync(int count, int areaId, TreeSorts sort)
        {
            var area = await _fararmRepository.GetFarmAreaById(areaId);
            if(area== null)
            {
                throw new Exception("Area not found");
            }
            var treeSort = await _treeRepository.GetBySort(sort);
            if (sort == null)
                throw new Exception("Tree sort has not been found");
            if ((treeSort.Amount -= count) < 0)
                throw new Exception("Not enough trees to remove");
            treeSort.Amount -= count;
            await _treeRepository.UpdateAsync(treeSort.Id, treeSort);
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
