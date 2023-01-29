using Domain.ModelInterfaces.TreeType;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TreeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeTypeController : ControllerBase
    {
        private readonly ITreeTypeService _treeService;

        public TreeTypeController(ITreeTypeService treeService)
        {
            _treeService = treeService;
        }

        /// <summary>
        /// Add tree type
        /// </summary>
        [HttpPost("AddTreeType")]
        public Task AddTreeType(string name)
        {
            return _treeService.AddTreeType(name);
        }

        /// <summary>
        /// Get all tree types
        /// </summary>
        [HttpGet("GettAllTypes")]
        public Task<ITreeType[]> GetAllTypes()
        {
            return _treeService.GetAllTreeTypes();
        }
    }
}
