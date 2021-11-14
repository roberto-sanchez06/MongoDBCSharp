using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infraestructure
{
    public class EmpleadoMongo : AbstractMongo<Empleado>,IEmpleadoMongo
    {
        IMongoCollection<Empleado> empleadosDespedidos;
        public EmpleadoMongo() : base("Empleados")
        {
            empleadosDespedidos = db.GetCollection<Empleado>("EmpleadosDespedidos");
        }
        public Empleado FindAny(int id)
        {
            var filter = Builders<Empleado>.Filter.Eq("idObjeto", id);
            return collection.Find(filter).First();
        }
        public void Update(Empleado e)
        {
            try
            {
                //con replace da errores, actualizar el idObjeto no es necesario
                var filter = Builders<Empleado>.Filter.Eq("IdObjeto", e.IdObjeto);
                var updateFilter = Builders<Empleado>.Update.Set("idObjeto", e.IdObjeto)
                .Set("nombre", e.Nombre).Set("salario",e.Salario).Set("direccion",e.Direccion);    
                var emp=collection.FindOneAndUpdate(filter, updateFilter);
                if (emp == null)
                {
                    throw new Exception();
                }
            }catch(Exception)
            {
                throw new ArgumentException("No se ha podido actualizar al empleado");
            }
        }
        public bool Delete(Empleado e)
        {
            try
            {
                var filter = Builders<Empleado>.Filter.Eq("idObjeto", e.IdObjeto);
                var emp= collection.FindOneAndDelete(filter);
                if (emp == null)
                {
                    throw new Exception();
                }
                empleadosDespedidos.InsertOne(e);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Empleado> GetDespedidos()
        {
            return empleadosDespedidos.Find(x => true).ToList();
        }
    }
}
