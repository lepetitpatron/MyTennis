using MyTennis.Core.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyTennis.UI.Processors
{
    class FinesProcessor : IProcessor<FineDTO>
    {
        private readonly string url = "https://localhost:44368/api/fine";

        public async Task<bool> Add(FineDTO t)
        {
            string obj = JsonConvert.SerializeObject(t);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }

        public Task<bool> Delete(int id)
        {
            return null;
        }

        public async Task<FineDTO> FindById(int id)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"{url}/{id}");
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FineDTO>(content);
        }

        public async Task<List<FineDTO>> GetAll()
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<FineDTO>>(content);
        }

        public async Task<bool> Update(FineDTO t)
        {
            string obj = JsonConvert.SerializeObject(t);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }
    }
}
