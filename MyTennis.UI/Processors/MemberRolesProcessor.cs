using MyTennis.Core.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyTennis.UI.Processors
{
    class MemberRolesProcessor
    {
        private readonly string url = "https://localhost:44368/api/memberrole";

        public async Task<bool> Add(MemberRoleDTO t)
        {
            string obj = JsonConvert.SerializeObject(t);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int memberId, int roleId)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync($"{url}/{memberId}/{roleId}");
            await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode;
        }

        public async Task<List<MemberRoleDTO>> GetAllMembers(int role)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"{url}/{role}");
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<MemberRoleDTO>>(content);
        }

        public async Task<List<MemberRoleDTO>> GetAllRoles(int member)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync($"{url}/{member}", null);
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<MemberRoleDTO>>(content);
        }
    }
}