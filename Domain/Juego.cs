using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class Juego
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("idObjeto")]
        public int IdObjeto { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("precio")]
        public decimal Precio { get; set; }
        [BsonElement("plataforma")]
        public string Plataforma { get; set; }
    }
}
