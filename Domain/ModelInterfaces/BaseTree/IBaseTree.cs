using Domain.ModelInterfaces.FarmArea;
using Domain.ModelInterfaces.TreeSort;

namespace Domain.ModelInterfaces.BaseTree
{
    public interface IBaseTree
    {
        /// <summary>
        /// Gets or sets tree id.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or sets sort of tree.
        /// </summary>
        public int TreeSortId { get; }

        public ITreeSort TreeSort { get; }

        /// <summary>
        /// Gets or sets foreign key for area
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets name of sort
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the max height of tree
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
    }
}
