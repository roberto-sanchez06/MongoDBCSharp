using System;
using System.Collections.Generic;

namespace AppCore
{
    public interface IMongoService<T>
    {
        void Add(T e);
        List<T> FindAll();
        int GetLastId();
    }
}
