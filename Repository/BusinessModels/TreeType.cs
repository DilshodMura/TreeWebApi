using Domain.ModelInterfaces.TreeType;

namespace Repository.BusinessModels
{
    public class TreeType : ITreeType
    {
        /// <summary>
        /// Gets or sets id of type 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name of type
        /// </summary>
        public string Name { get; set; }
    }
}
