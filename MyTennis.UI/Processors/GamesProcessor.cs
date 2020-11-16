using MyTennis.Core.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyTennis.UI.Processors
{
    class GamesProcessor : IProcessor<GameDTO>
    {
        private readonly string url = "https://localhost:44368/api/game";

        public async Task<bool> Add(GameDTO t)
        {
            string obj = JsonConvert.SerializeObject(t);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync($"{url}/{id}");
            await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode;
        }

        public async Task<GameDTO> FindById(int id)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"{url}/{id}");
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GameDTO>(content);
        }

        public async Task<List<GameDTO>> GetAll()
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<GameDTO>>(content);
        }

        public async Task<bool> Update(GameDTO t)
        {
            string obj = JsonConvert.SerializeObject(t);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }
    }
}