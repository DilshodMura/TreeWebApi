using Database.Entities.Type;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities.Sort
{
    public class TreeSortDb
    {
        /// <summary>
        /// Gets or sets id of sort
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name of sort
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Max Height of the tree
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
        /// Gets or sets the type id for sort
        /// </summary>
        [ForeignKey("TreeTypeId")]
        public int TreeTypeId { get; set; }
        public TreeTypeDb TreeType { get; set; }
    }
}
