using DTOs.GooglePlacesAPI;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace WebAPI.PlacesAPI
{
    public class GooglePlacesAPIClient
    {
        private string APIKey;
        private readonly HttpClient httpClient;
        public GooglePlacesAPIClient(IConfiguration configuration, HttpClient httpClient)
        {
            this.APIKey = configuration["GooglePlacesAPI"];
            this.httpClient = httpClient;
        }

        public async Task<GooglePlacesAPIResponseDTO> FindPlace(string keywords)
        {
            var url = $@"https://maps.googleapis.com/maps/api/place/findplacefromtext/json?fields=formatted_address%2Cname%2Crating%2Copening_hours%2Cgeometry"
                + $"&input={UrlEncoder.Default.Encode($"{keywords} Basel")}"
                + "&inputtype=textquery"
                + $"&key={APIKey}";
       

            var strinsg = await httpClient.GetStringAsync(url);
            var placesResponse = await httpClient.GetFromJsonAsync<GooglePlacesAPIResponseDTO>(url);


            //var t = await FindPlaceDetails(placesResponse.candidates.First().name);

            return placesResponse;
        }

        public async Task<PlaceDetailsResponseDTO> FindPlaceDetails(string placeId)
        {
            var url = $@"https://maps.googleapis.com/maps/api/place/details/json?place_id={placeId}&key={APIKey}";

            var placesResponse = await httpClient.GetFromJsonAsync<PlaceDetailsResponseDTO>(url);
            return placesResponse;
        }
    }
}
