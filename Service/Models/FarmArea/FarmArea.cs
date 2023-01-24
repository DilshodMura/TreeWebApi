using Domain.ModelInterfaces.FarmArea;

namespace Database.Entities.FarmArea
{
    public class FarmArea : IFarmArea
    {
        /// <summary>
        /// Gets or internal sets id of farm area
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or internal sets the capacity of area 
        /// </summary>
        public double Capacity { get ; internal set; }
    }
}
