using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using VolcanoFinder.Models;

namespace VolcanoFinder.Services
{
    public class CloudDataStore : IDataStore<Volcano>
    {

        private List<Volcano> volcanoes;

        public CloudDataStore()
        {

        }

        public async Task<bool> AddItemAsync(Volcano item)
        {
            volcanoes.Add(item);

            ///TODO : Send the new Volcano to the Cloud store as well...

            return await Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Volcano> GetItemAsync(string id)
        {
            return await Task.FromResult(volcanoes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Volcano>> GetItemsAsync(bool forceRefresh = false)
        {
            var baseAddr = new Uri(Constants.APIURL);
            var client = new HttpClient { BaseAddress = baseAddr };

            var request = new HttpRequestMessage(HttpMethod.Get, "");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", App.AuthResult.AccessToken);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var reviewJson = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            volcanoes = JsonSerializer.Deserialize<List<Volcano>>(reviewJson, options);

            return volcanoes;
        }

        public Task<bool> UpdateItemAsync(Volcano item)
        {
            throw new NotImplementedException();
        }
    }
}
