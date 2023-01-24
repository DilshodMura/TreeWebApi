using Domain.ModelInterfaces.FarmArea;

namespace Repository.BusinessModels
{
    public sealed class FarmModel:IFarmArea
    {
        /// <summary>
        /// Gets or internal sets id of area.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or internal sets the capacity of area
        /// </summary>
        public double Capacity { get; internal set; }
    }
}
