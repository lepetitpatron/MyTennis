using MyTennis.Core.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyTennis.UI.Processors
{
    class MembersProcessor : IProcessor<MemberDTO>
    {
        private readonly string url = "https://localhost:44368/api/member";

        public async Task<bool> Add(MemberDTO t)
        {
            string obj = JsonConvert.SerializeObject(t);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MemberDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MemberDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(MemberDTO t)
        {
            throw new NotImplementedException();
        }
    }
}