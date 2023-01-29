
namespace Domain.ModelInterfaces.FarmArea
{
    public interface IFarmArea
    {
        /// <summary>
        /// Gets the id of particular area
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets the capacity of farm area
        /// </summary>
        public double Capacity { get; }
    }
}
