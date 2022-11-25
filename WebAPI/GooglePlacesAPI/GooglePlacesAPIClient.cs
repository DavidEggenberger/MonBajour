using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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

        public async Task<PlacesAPIResponseDTO> FindPlace(string keywords)
        {
            var url = $@"https://maps.googleapis.com/maps/api/place/findplacefromtext/json?fields=formatted_address%2Cname%2Crating%2Copening_hours%2Cgeometry"
                + $"&input={UrlEncoder.Default.Encode(keywords)}"
                + "&inputtype=textquery"
                + $"&key={APIKey}";
       
            return await httpClient.GetFromJsonAsync<PlacesAPIResponseDTO>(url);
        }
    }
    public class Candidate
    {
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string name { get; set; }
        public OpeningHours opening_hours { get; set; }
        public double rating { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
        public Viewport viewport { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class OpeningHours
    {
        public bool open_now { get; set; }
    }

    public class PlacesAPIResponseDTO
    {
        public List<Candidate> candidates { get; set; }
        public string status { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

}
