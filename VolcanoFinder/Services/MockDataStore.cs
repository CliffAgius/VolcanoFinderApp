using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolcanoFinder.Models;

namespace VolcanoFinder.Services
{
    public class MockDataStore : IDataStore<Volcano>
    {
        readonly List<Volcano> volcanoes;

        public MockDataStore()
        {
            volcanoes = new List<Volcano>()
            {
                new Volcano { Id = "4cb67ab0-ba1a-0e8a-8dfc-d48472fd5766", VolcanoName = "Abu", Country = "Japan", Region = "Honshu-Japan", Location = new Location{ type = "Point", coordinates = new float[] {(float)131.6, (float)34.5 } }, Elevation = 571, Type="Shield volcano", Status="Holocene", LastKnownEruption = "Unknown" },
                new Volcano { Id = "246927ec-11c6-56da-b97c-00e5ed69fd3f", VolcanoName = "Acamarachi", Country = "Chile", Region = "Chile-N", Location = new Location{ type = "Point", coordinates = new float[] {(float)-67.62, (float)-23.3 } }, Elevation = 6046, Type="Stratovolcano", Status="Holocene", LastKnownEruption = "Unknown" }
            };
        }

        public async Task<bool> AddItemAsync(Volcano item)
        {
            volcanoes.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Volcano item)
        {
            var oldItem = volcanoes.Where((Volcano arg) => arg.Id == item.Id).FirstOrDefault();
            volcanoes.Remove(oldItem);
            volcanoes.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = volcanoes.Where((Volcano arg) => arg.Id == id).FirstOrDefault();
            volcanoes.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Volcano> GetItemAsync(string id)
        {
            return await Task.FromResult(volcanoes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Volcano>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(volcanoes);
        }
    }
}