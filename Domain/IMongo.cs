using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IMongo<T>
    {
        void Add(T e);
        List<T> FindAll();
        int GetLastId();
    }
}
