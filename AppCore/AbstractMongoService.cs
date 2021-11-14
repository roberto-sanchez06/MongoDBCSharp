using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace AppCore
{
    public abstract class AbstractMongoService<T> : IMongoService<T>
    {
        private IMongo<T> model;

        protected AbstractMongoService(IMongo<T> model)
        {
            this.model = model;
        }

        public void Add(T e)
        {
            model.Add(e);
        }

        public List<T> FindAll()
        {
            return model.FindAll();
        }

        public int GetLastId()
        {
            return model.GetLastId();
        }
    }
}
