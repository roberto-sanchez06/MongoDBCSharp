using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace AppCore
{
    public class JuegoService : AbstractMongoService<Juego>, IJuegoService
    {
        private IJuegoMongo juegoMongo;

        public JuegoService(IJuegoMongo juegoMongo) : base(juegoMongo)
        {
            this.juegoMongo = juegoMongo;
        }

        public List<Juego> BuscarPorPlataforma(string plataforma)
        {
            return juegoMongo.BuscarPorPlataforma(plataforma);
        }
    }
}
