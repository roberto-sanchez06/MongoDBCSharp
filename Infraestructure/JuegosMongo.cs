using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using MongoDB.Driver;

namespace Infraestructure
{
    public class JuegosMongo : AbstractMongo<Juego>, IJuegoMongo
    {
        public JuegosMongo() : base("Juegos")
        {
        }

        public List<Juego> BuscarPorPlataforma(string plataforma)
        {
            var filter = Builders<Juego>.Filter.Eq("plataforma", plataforma);
            return collection.Find(filter).ToList();
        }
    }
}
