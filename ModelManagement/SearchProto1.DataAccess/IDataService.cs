using SearchProto1.Model;
using System;
using System.Collections.Generic;

namespace SearchProto1.DataAccess
{
    public interface IDataService<T> : IDisposable where T:IPersistable
    {
        IList<T> GetAll();
        void Save(T persistable);
        void Delete(int Id);
        T GetById(int Id);


    }
}