using Domain.ModelInterfaces.TreeType;

namespace Domain.RepositoryInterfaces
{
    public interface ITreeTypeRepository
    {
        /// <summary>
        /// Add new tree type
        /// </summary>
        /// <returns></returns>
        public Task AddTreeType(ITreeType treeType);

        /// <summary>
        /// Delete tree type
        /// </summary>
        /// <returns></returns>
        public Task DeleteTreeType(int treeTypeId);

        /// <summary>
        /// Get all tree types
        /// </summary>
        /// <returns></returns>
        public Task<ITreeType[]> GetAllTreeTypes();

        /// <summary>
        /// Gets the tree type by id 
        /// </summary>
        public Task<ITreeType> GetById(int typeId);
    }
}
