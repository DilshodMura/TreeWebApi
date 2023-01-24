using Domain.Enums;

namespace Domain.ModelInterfaces.BaseTree
{
    public interface IBaseTree
    {

        public int Id { get; }
        /// <summary>
		/// Gets the max height of the tree
		/// </summary>
		public double MaxHeight { get; }

        /// <summary>
        /// Gets tax Square of the tree
        /// </summary>
        public double MaxSquare { get; }

        /// <summary>
        /// Gets in how many years the tree will give fruits
        /// </summary>
        public double MaxFruitliness { get; }

        /// <summary>
        /// Gets the tree sort type
        /// </summary>
        public TreeSorts SortName { get; }

        /// <summary>
        /// Gets default type for particalar tree
        /// </summary>
        public TreeTypes TreeTypes { get; }

        /// <summary>
        /// Gets areaId of tree in was planted
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Gets the count of particular tree
        /// </summary>
        public int Amount { get; set; }
    }
}
