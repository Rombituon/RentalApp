using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalApp.Data;
using RentalApp.Models;

namespace RentalApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnotherRenterController : ControllerBase
    {
        private readonly RentalDataContext _context;

        public AnotherRenterController(RentalDataContext context)
        {
            _context = context;
        }

        // GET: api/AnotherRenter/GetAll


        [HttpGet()]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Renter>>> GetRenters()
        {
            return await _context.Renters.ToListAsync();
        }
    }
}
