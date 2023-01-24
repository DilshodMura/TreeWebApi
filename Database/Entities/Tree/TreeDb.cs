using Database.Entities.FarmArea;
using Domain.Enums;

namespace Database.Entities.Tree
{
    public class TreeDb
    {
        /// <summary>
        /// Gets or sets tree id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the max height of the tree
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
        /// Gets or sets default sort for particalar tree
        /// </summary>
        public TreeSorts SortName { get; set; }

        /// <summary>
        /// Gets or sets default type for particalar tree
        /// </summary>
        public TreeTypes TreeTypes { get; set; }

        /// <summary>
        /// Gets or sets foreign key for area
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets foreing key for area in tree table.
        /// </summary>
        public FarmAreaDb Area { get; set; }

        /// <summary>
        /// Gets or sets amount of particular tree.
        /// </summary>
        public int Amount { get; set; }
    }
}
