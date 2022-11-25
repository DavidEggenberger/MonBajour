using DTOs.GooglePlacesAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.PlacesAPI;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesSearchController : ControllerBase
    {
        private readonly GooglePlacesAPIClient googlePlacesAPIClient;
        public PlacesSearchController(GooglePlacesAPIClient googlePlacesAPIClient)
        {
            this.googlePlacesAPIClient = googlePlacesAPIClient;
        }

        [HttpGet("{location}")]
        public async Task<ActionResult<GooglePlacesAPIResponseDTO>> GetPlacesAPIResponse([FromRoute] string location)
        {
            return Ok(await googlePlacesAPIClient.FindPlace(location));
        }
    }
}
