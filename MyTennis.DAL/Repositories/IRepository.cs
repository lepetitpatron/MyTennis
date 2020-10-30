using System.Collections.Generic;

namespace MyTennis.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        bool Add(TEntity t);
        TEntity FindById(int? id);
        bool Modify(TEntity t);
        List<TEntity> GetAll();
        void Remove(TEntity t);
    }
}