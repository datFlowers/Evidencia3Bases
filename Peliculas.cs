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
    public class Peliculas
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement("Nombre")]
    public string Nombre { get; set; }

    [BsonElement("Duracion_minutos")]
    public int Duracion_minutos { get; set; }

    [BsonElement("Genero")]
    public string[] Genero { get; set; }

    [BsonElement("Clasificacion")]
    public string Clasificacion { get; set; }

    [BsonElement("Tipo_sala")]
    public string Tipo_sala { get; set; }

    [BsonElement("Sala")]
    public int Sala { get; set; }
}

public class VentaBoletos
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement("Tipo_sala")]
    public string Tipo_sala { get; set; }

    [BsonElement("Nombre_cliente")]
    public string Nombre_cliente { get; set; }

    [BsonElement("Num_tarjeta")]
    public string Num_tarjeta { get; set; }

    [BsonElement("Pelicula")]
    public string Pelicula { get; set; }

    [BsonElement("fecha")]
    public string fecha { get; set; }

    [BsonElement("Sala")]
    public int Sala { get; set; }
}
}
