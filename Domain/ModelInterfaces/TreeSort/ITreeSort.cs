
namespace Domain.ModelInterfaces.TreeSort
{
    public interface ITreeSort
    {
        /// <summary>
        /// Gets or sets id of sort
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or sets name of sort
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the max height of tree sort 
        /// </summary>
        public double MaxHeight { get; set; }

        /// <summary>
        /// Gets or sets the Max Square of the tree
        /// </summary>
        public double MaxSquare { get; set; }

        /// <summary>
        /// Gets or sets in how many years the tree will give fruits
        /// </summary>
        public double MaxFruitliness { get; set; }

        /// <summary>
        /// Gets or sets the type id for sorts
        /// </summary>
        public int TreeTypeId { get; set; }
    }
}
