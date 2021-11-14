using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using MongoDB.Driver;

namespace Infraestructure
{
    public abstract class AbstractMongo<T> : IMongo<T>
    {
        protected IMongoDatabase db;
        protected IMongoCollection<T> collection;
        protected AbstractMongo(string nombreColeccion)
        {
            var cliente = new MongoClient();
            db = cliente.GetDatabase("DBPrueba");
            collection = db.GetCollection<T>(nombreColeccion);
        }
        public void Add(T e)
        {
            collection.InsertOne(e);
        }


        public List<T> FindAll()
        {
            return collection.Find(x => true).ToList();
        }

        public int GetLastId()
        {
            var datos = FindAll();
            if (datos.Count == 0)
            {
                return 0;
            }
            else
            {
                try
                {
                    return (int)datos[datos.Count - 1].GetType().GetProperty("IdObjeto").GetValue(datos[datos.Count - 1]);
                }
                catch (Exception)
                {
                    throw new ArgumentException("El objeto no posee la propiedad Id");
                }
            }
        }
    }
}
