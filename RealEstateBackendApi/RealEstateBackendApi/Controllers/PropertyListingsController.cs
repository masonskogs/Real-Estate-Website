using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateBackendApi.Models;

namespace RealEstateBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyListingsController : ControllerBase
    {
        private readonly RealEstateDbContext _dbContext;

        public PropertyListingsController(RealEstateDbContext realEstateDbContext)
        {
            _dbContext = realEstateDbContext;     
                }

        [HttpGet]
        public async Task<IEnumerable<PropertyListing>> Get()
        {
            var result = await _dbContext.PropertyListings.ToListAsync();

            return result;
        }
    }
}
