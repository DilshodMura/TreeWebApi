using Domain.Enums;
using Domain.ModelInterfaces.BaseTree;

namespace Database.Entities.Apples
{
    public sealed class AppleGolden : IBaseTree
    {
        public int Id { get; internal set; }
        /// <summary>
        /// The Max Square of the tree
        /// </summary>
        public double MaxSquare => 14;

        /// <summary>
        /// The max height of the tree
        /// </summary>
        public double MaxHeight => 1.4;

        /// <summary>
        /// In how many years the tree will give fruits
        /// </summary>
        public double MaxFruitliness => 7;

        /// <summary>
        /// Adding default sort for particalar tree
        /// </summary>
        public TreeSorts SortName => TreeSorts.Golden;

        /// <summary>
        /// Adding default type for particalar tree
        /// </summary>
        public TreeTypes TreeTypes => TreeTypes.Apple;

        /// <summary>
        /// Gets or sets farm area
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// gets or sets amount of tree
        /// </summary>
        public int Amount { get; set; }
    }
}
