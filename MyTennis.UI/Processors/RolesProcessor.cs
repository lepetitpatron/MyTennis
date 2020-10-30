using MyTennis.Core;
using MyTennis.UI.Processors;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyTennis.UI
{
    public class RolesProcessor : IProcessor<RoleDTO>
    {
        private readonly string url = "https://localhost:44368/api/role";

        public async Task<bool> Add(RoleDTO t)
        {
            string obj = JsonConvert.SerializeObject(t);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RoleDTO> FindById(int id)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"{url}/{id}");
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RoleDTO>(content);
        }

        public async Task<List<RoleDTO>> GetAll()
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            string content =  await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<RoleDTO>>(content);
        }

        public async Task<bool> Update(RoleDTO t)
        {
            string obj = JsonConvert.SerializeObject(t);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }
    }
}
