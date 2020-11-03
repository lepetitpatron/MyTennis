using System.Collections.Generic;

namespace MyTennis.BLL
{
    public interface ILogic<TEntity> where TEntity : class
    {
        bool Create(TEntity entity);
        TEntity FindById(int id);
        bool Delete(int entity);
        List<TEntity> GetAll();
        bool Update(TEntity entity);
    }
}
