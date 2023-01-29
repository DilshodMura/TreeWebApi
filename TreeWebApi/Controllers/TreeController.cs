using Domain.ModelInterfaces.TreeSort;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;


namespace TreeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService _treeService;

        public TreeController(ITreeService treeService)
        {
            _treeService = treeService;
        }
        
        /// <summary>
        /// Get all trees
        /// </summary>
        [HttpGet("GetAllTrees")]
        public async Task<IActionResult> GetAllTrees()
        {
            return Ok(await _treeService.GetAllTrees());
        }

        /// <summary>
        /// Add tree
        /// </summary>
        [HttpPost("AddTrees")]
        public async Task AddTrees(int sortId, int count, int areaId)
        {
            await _treeService.AddTree(count, sortId, areaId);
        }

        /// <summary>
        /// Delete tree
        /// </summary>
        [HttpDelete("DeleteTrees")]
        public async Task DeleteTree(int treeId)
        {
            await _treeService.DeleteAsync(treeId);
        }

        /// <summary>
        /// Calculate average height of trees in particular area
        /// </summary>
        [HttpGet("Average-Height")]
        public async Task<double> CalculateverageHeight(int areaID)
        {
            return await _treeService.AverageMaxHeight(areaID);
        }

        /// <summary>
        /// Calculates max height of trees in particular area
        /// </summary>
        [HttpGet("Max-Fruitelness")]
        public async Task<double> MaxFruitelness(int areaId)
        {
            return await _treeService.GetMaxFruitelness(areaId);
        }

        /// <summary>
        /// Area capacity of trees in particular area
        /// </summary>
        [HttpGet("TreeCapacity")]
        public async Task<double> AreaCapacity(int areaId)
        {
            return await _treeService.AreaCapacity(areaId);
        }
    }
}
