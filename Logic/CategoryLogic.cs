using MultiTenantDotNet9.Infrastructure;
using MultiTenantDotNet9.Models;
using Microsoft.EntityFrameworkCore;

namespace MultiTenantDotNet9.Logic
{
    public class CategoryLogic(SystemContext systemContext)
    {
        private readonly SystemContext _systemContext = systemContext;

        public async Task<List<Category>> List()
        {
            return await _systemContext.Category.ToListAsync();
        }
    }
}
