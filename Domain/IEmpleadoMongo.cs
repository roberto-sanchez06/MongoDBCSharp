using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IEmpleadoMongo : IMongo<Empleado>
    {
        Empleado FindAny(int id);
        void Update(Empleado e);
        bool Delete(Empleado e);
        List<Empleado> GetDespedidos();
    }
}
