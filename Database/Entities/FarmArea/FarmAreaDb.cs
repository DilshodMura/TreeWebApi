using Database.Entities.Tree;

namespace Database.Entities.FarmArea
{
    public class FarmAreaDb 
    {
        /// <summary>
        /// Gets or sets id for farm area
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets area capacity
        /// </summary>
        public double Capacity { get ; set; }

        /// <summary>
        /// foreign key for trees that area contains
        /// </summary>
        public virtual ICollection<TreeDb> trees { get; set; }
    }
}
