using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace AppCore
{
    public class EmpleadoService : AbstractMongoService<Empleado>, IEmpleadoService
    {
        private IEmpleadoMongo empleadoMongo;

        public EmpleadoService(IEmpleadoMongo empleadoMongo) : base(empleadoMongo)
        {
            this.empleadoMongo = empleadoMongo;
        }

        public bool Delete(Empleado e)
        {
            return empleadoMongo.Delete(e);
        }

        public Empleado FindAny(int id)
        {
            return empleadoMongo.FindAny(id);
        }

        public List<Empleado> GetDespedidos()
        {
            return empleadoMongo.GetDespedidos();
        }

        public void Update(Empleado e)
        {
            empleadoMongo.Update(e);
        }
    }
}
