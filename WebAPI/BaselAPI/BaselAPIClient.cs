using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebAPI.BaselAPI
{
    public class BaselAPIClient
    {
        private readonly HttpClient httpClient;
        public BaselAPIClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<EntsorgungsstelleDTO>> LoadEntsorgungsstellen()
        {
            var respnse = await httpClient.GetFromJsonAsync<APIResponseRootDTO<APIResponseRecordDTO<EntsorgungsstelleDTO>>>("https://data.bs.ch/api/records/1.0/search/?dataset=100021&q=&rows=310&facet=kategorie&facet=plz&facet=ortschaft&facet=zustaendig");

            return respnse.records.Select(r => r.fields);
        }
    }
}
