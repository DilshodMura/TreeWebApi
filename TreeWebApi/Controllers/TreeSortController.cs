using Domain.ModelInterfaces.TreeSort;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Models.TreeSort;

namespace TreeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeSortController : ControllerBase
    {
        private readonly ITreeSortService _treeService;

        public TreeSortController(ITreeSortService treeService)
        {
            _treeService = treeService;
        }

        /// <summary>
        /// Add new tree sort
        /// </summary>
        [HttpPost("AddNewSort")]
        public async Task AddSort([FromQuery] TreeSort treeSort)
        {
            await _treeService.AddTreeSort(treeSort);
        }

        /// <summary>
        /// Get all tree sorts
        /// </summary>
        [HttpGet("GetAllSorts")]
        public async Task<ITreeSort[]> GetAllTrees()
        {
           return await _treeService.GetAllTreeSorts();
        }

        /// <summary>
        /// Delete tree sort 
        /// </summary>
        [HttpDelete]
        public async Task Delete(int sortId)
        {
            _treeService.RemoveTreeSort(sortId);
        }
    }
}
