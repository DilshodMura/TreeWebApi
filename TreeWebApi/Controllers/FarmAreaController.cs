using Domain.ModelInterfaces.FarmArea;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TreeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmAreaController : ControllerBase
    {
        private readonly IFarmService _farmService;

        public FarmAreaController(IFarmService farmService)
        {
            _farmService = farmService;
        }

        /// <summary>
        /// Add Area
        /// </summary>
        [HttpPost("AddArea")]
        public async Task AddArea(int area)
        {
            await _farmService.AddFarmArea(area);
        }

        /// <summary>
        /// Get all areas
        /// </summary>
        [HttpGet("GetAllAreas")]
        public async Task<IActionResult> GetAllAreas()
        {
            return Ok(await _farmService.GetAllAsync());
        }

        /// <summary>
        /// Delete area
        /// </summary>
        [HttpDelete("DeleteArea")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            await _farmService.DeleteAsync(id);
            return Ok();
        }

        /// <summary>
        /// Update area
        /// </summary>
        [HttpPost("UpdateArea")]
        public async Task<IActionResult> UpdateArea(IFarmArea farmArea)
        {
            await _farmService.UpdateAsync(farmArea);
            return Ok();
        }
    }
}
