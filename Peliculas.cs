using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using P2.Colecciones;
using System.Xml.Serialization;

namespace P2.Colecciones
{
    internal class Peliculas
    {
        //internal resenas [] Reseñas;
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public ObjectId Id { get; set; }

        [BsonElement("Nombre")]
        public string Nombre{ get; set; }

        [BsonElement("Genero")]
        public string Genero { get; set; }

        [BsonElement("Duracion")]
        public int Duracion { get; set; }

        [BsonElement("Director")]
        public string Director { get; set; }

        [BsonElement("Sinopsis")]
        public string Sinopsis { get; set; }
        
        [BsonElement("reseñas")]
        public resenas[] reseñas { get; set; }
    } 
    internal class VentaBoletos
    {
        [BsonElement("usuario")]
        public string usuario { get; set; }

        [BsonElement("puntaje")]
        public double puntaje { get; set; }

        [BsonElement("reseña")]
        public string reseña { get; set; }
    } 
}
