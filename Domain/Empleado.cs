using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class Empleado
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("idObjeto")]
        public int IdObjeto { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("salario")]
        public decimal Salario { get; set; }
        [BsonElement("direccion")]
        public Direccion Direccion { get; set; }
    }
}
