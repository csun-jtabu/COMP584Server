using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldModel;

namespace COMP584Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController(Comp584Context context) : ControllerBase
    {
        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost ("CountriesController")]
        public async Task<ActionResult> PostCountries()
        {
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost ("Cities")]
        public async Task<ActionResult> PostCities()
        {
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
