using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrganizerApp.Data
{
    public class ExternalDataService
    {
        public static dynamic getDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(queryString);

            dynamic data = null;
            if (response != null)
            {
                var r = response.Result;
                string json = r.Content.ReadAsStringAsync().Result.ToString();
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }
        public static async Task<dynamic> getDataFromService1(string queryString)
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
