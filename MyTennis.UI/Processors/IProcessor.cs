using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTennis.UI.Processors
{
    public interface IProcessor<T> where T : class
    {
        Task<bool> Add(T t);
        Task<T> FindById(int id);
        Task<List<T>> GetAll();
        Task<bool> Update(T t);
        Task<bool> Delete(int id);
    }
}