using MultiTenantDotNet9.Logic;
using MultiTenantDotNet9.Models;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenantDotNet9.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController(ILogger<CategoryController> logger, CategoryLogic categoryLogic) : ControllerBase
    {        
        private readonly ILogger<CategoryController> _logger = logger;
        private readonly CategoryLogic _categoryLogic = categoryLogic;

        [HttpGet]
        public async Task<List<Category>> List()
        {
            return await  _categoryLogic.List();
        }
    }
}
