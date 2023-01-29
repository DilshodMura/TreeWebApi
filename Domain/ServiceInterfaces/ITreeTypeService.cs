using Domain.ModelInterfaces.TreeType;

namespace Domain.ServiceInterfaces
{
    public interface ITreeTypeService
    {
        /// <summary>
        /// Add new tree type
        /// </summary>
        public Task AddTreeType(string name);

        /// <summary>
        /// Remove existing tree type
        /// </summary>
        public Task RemoveTreeType(int treeTypeId);

        /// <summary>
        /// Get all tree types
        /// </summary>
        public Task<ITreeType[]> GetAllTreeTypes();
    }
}
