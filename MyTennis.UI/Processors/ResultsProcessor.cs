using MyTennis.Core.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyTennis.UI.Processors
{
    class ResultsProcessor : IProcessor<ResultDTO>
    {
        private readonly string url = "https://localhost:44368/api/result";

        public async Task<bool> Add(ResultDTO t)
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

        public async Task<ResultDTO> FindById(int id)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"{url}/{id}");
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResultDTO>(content);
        }

        public async Task<List<ResultDTO>> GetAll()
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ResultDTO>>(content);
        }

        public async Task<bool> Update(ResultDTO t)
        {
            string obj = JsonConvert.SerializeObject(t);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }
    }
}