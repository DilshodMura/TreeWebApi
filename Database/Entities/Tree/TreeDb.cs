using Database.Entities.FarmArea;
using Database.Entities.Sort;

namespace Database.Entities.Tree
{
    public class TreeDb 
    {
        /// <summary>
        /// Gets or sets tree id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets sort of tree.
        /// </summary>
        public int TreeSortId { get; set; }

        public TreeSortDb TreeSort { get; set; }
        /// <summary>
        /// Gets or sets foreign key for area
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets foreing key for area in tree table.
        /// </summary>
        public FarmAreaDb Area { get; set; }
    }
}
