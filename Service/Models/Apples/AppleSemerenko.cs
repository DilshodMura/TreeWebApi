using Domain.Enums;
using Domain.ModelInterfaces.BaseTree;

namespace Database.Entities.Apples
{
    public sealed class AppleSemerenko : IBaseTree
    {
        public int Id { get; internal set; }
        /// <summary>
        /// The max height of the tree
        /// </summary>
        public double MaxHeight => 2.4;

        /// <summary>
        /// The Max Square of the tree
        /// </summary>
        public double MaxSquare => 5;

        /// <summary>
        /// In how many years the tree will give fruits
        /// </summary>
        public double MaxFruitliness => 3;

        /// <summary>
        /// Added default sort for particular tree
        /// </summary>
        public TreeSorts SortName => TreeSorts.Semerenko;

        /// <summary>
        /// Adding default type for particalar tree
        /// </summary>
        public TreeTypes TreeTypes => TreeTypes.Apple;

        /// <summary>
        /// Gets or sets farm area
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets tree count
        /// </summary>
        public int Amount { get; set; }
    }
}
