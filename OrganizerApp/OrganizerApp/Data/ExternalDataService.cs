using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrganizerApp.Data
{
    public class ExternalDataService
    {
        public static async Task<dynamic> getDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString).ConfigureAwait(false);

            dynamic data = null;
            if (response != null)
            {
                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }
    }
}
