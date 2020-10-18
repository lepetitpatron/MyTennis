using System.Collections.Generic;

namespace MyTennis.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        int Add(TEntity t);
        TEntity FindById(int? id);
        void Modify(TEntity t);
        List<TEntity> GetAll();
        void Remove(TEntity t);
    }
}