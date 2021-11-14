using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace AppCore
{
    public interface IEmpleadoService : IMongoService<Empleado>
    {
        Empleado FindAny(int id);
        void Update(Empleado e);
        bool Delete(Empleado e);
        List<Empleado> GetDespedidos();
    }
}
