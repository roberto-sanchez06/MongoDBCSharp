using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class Direccion
    {
        [BsonElement]
        public string Ciudad { get; set; }
        [BsonElement]
        public string Pais { get; set; }
    }
}
