using Domain.Enums;
using Domain.ModelInterfaces.BaseTree;

namespace Repository.BusinessModels
{
    public sealed class TreeModel:IBaseTree
    {
        public int Id { get; set; }
        /// <summary>
        /// The max height of the tree
        /// </summary>
        public double MaxHeight { get; set; }

        /// <summary>
        /// The Max Square of the tree
        /// </summary>
        public double MaxSquare { get; set; }

        /// <summary>
        /// In how many years the tree will give fruits
        /// </summary>
        public double MaxFruitliness { get; set; }

        /// <summary>
        /// Adding default sort for particalar tree
        /// </summary>
        public TreeSorts SortName { get; set; }

        /// <summary>
        /// Adding default type for particalar tree
        /// </summary>
        public TreeTypes TreeTypes { get; set; }

        public int AreaId { get; set; }
        public int Amount { get; set; }
    }
}
