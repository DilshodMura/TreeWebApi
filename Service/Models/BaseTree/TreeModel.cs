using Domain.ModelInterfaces.BaseTree;
using Domain.ModelInterfaces.FarmArea;
using Domain.ModelInterfaces.TreeSort;

namespace Service.Models.BaseTree
{
    public sealed class TreeModel : IBaseTree
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the tree sort id
        /// </summary>
        public int TreeSortId { get; set; }
        public ITreeSort TreeSort { get; }

        /// <summary>
        /// Gets or sets the area id
        /// </summary>
        public int AreaId { get; set; }
        public IFarmArea Area { get; set; }

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
