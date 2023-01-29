using Domain.ModelInterfaces.TreeType;

namespace Service.Models.TreeType
{
    public class TreeType : ITreeType
    {
        /// <summary>
        /// Gets or sets id of type 
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or sets name of type
        /// </summary>
        public string Name { get; set; }
    }
}
