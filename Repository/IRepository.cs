using System.Collections.Generic;
using ClassMiBlog.Entities;

namespace ClassMiBlog.Repository
{
    interface IRepository<T> where T:Entity
    {
        #region CRUD
        void Insert(T entidad);

        void Delete(T entidad);

        void Update(T entidad);
      
        IEnumerable<T> FindAll();

        #endregion
    }
}
