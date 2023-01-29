using Domain.ModelInterfaces.FarmArea;

namespace Service.Models.FarmArea
{
    public class FarmArea : IFarmArea
    {
        /// <summary>
        /// Gets or internal sets id of farm area
        /// </summary>
        public int Id { get;  set; }

        /// <summary>
        /// Gets or internal sets the capacity of area 
        /// </summary>
        public double Capacity { get ; internal set; }
    }
}
