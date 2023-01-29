using Database.Entities.Sort;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities.Type
{
    public class TreeTypeDb
    {
        /// <summary>
        /// Gets or sets id of type 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name of type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sorts collection for type.
        /// </summary>
        public virtual ICollection<TreeSortDb> TreeSorts { get; set; }
    }
}
