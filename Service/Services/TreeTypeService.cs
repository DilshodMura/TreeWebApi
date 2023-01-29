using Domain.ModelInterfaces.TreeType;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using Service.Models.TreeType;

namespace Service.Services
{
    public sealed class TreeTypeService : ITreeTypeService
    {
        private readonly ITreeTypeRepository _treeTypeRepository;
        public TreeTypeService(ITreeTypeRepository treeTypeRepository)
        {
            _treeTypeRepository= treeTypeRepository;
        }

        /// <summary>
        /// Add tree type
        /// </summary>
        public Task AddTreeType(string name)
        {
            ITreeType treeType = new TreeType() { Name = name };  
            return _treeTypeRepository.AddTreeType(treeType);
        }

        /// <summary>
        /// Get all tree types
        /// </summary>
        public Task<ITreeType[]> GetAllTreeTypes()
        {
            return _treeTypeRepository.GetAllTreeTypes();
        }

        /// <summary>
        /// Delete tree type
        /// </summary>
        public Task RemoveTreeType(int treeTypeId)
        {
            var isExists = _treeTypeRepository.GetById(treeTypeId);
            if(isExists.Id!= treeTypeId)
                return _treeTypeRepository.DeleteTreeType(treeTypeId);
            throw new ArgumentException("No tree type has been found!");
        }
    }
}
