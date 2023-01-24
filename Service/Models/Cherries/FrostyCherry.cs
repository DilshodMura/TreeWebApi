using Domain.Enums;
using Domain.ModelInterfaces.BaseTree;

namespace Database.Entities.Cherries
{
    public sealed class FrostyCherry : IBaseTree
    {
        public int Id { get; internal set; }
        /// <summary>
        /// The max height of the tree
        /// </summary>
        public double MaxHeight => 7;

        /// <summary>
        /// The Max Square of the tree
        /// </summary>
        public double MaxSquare => 3.4;

        /// <summary>
        /// In how many years the tree will give fruits
        /// </summary>
        public double MaxFruitliness => 8;

        /// <summary>
        /// Added default sort for particular tree
        /// </summary>
        public TreeSorts SortName => TreeSorts.Frosty;

        /// <summary>
        /// Adding default type for particalar tree
        /// </summary>
        public TreeTypes TreeTypes => TreeTypes.Cherry;
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
