using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace AppCore
{
    public interface IJuegoService : IMongoService<Juego>
    {
        List<Juego> BuscarPorPlataforma(string plataforma);
    }
}
