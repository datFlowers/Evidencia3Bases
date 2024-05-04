using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Core.Misc;
using MongoDB;
using P2.Colecciones;
using System.Xml.Serialization;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        
        private static MongoClient client;
        private static IMongoDatabase storeDB;
        private static IMongoCollection<Peliculas> MoviesCollection;
        private static IMongoCollection<VentaBoletos> SalesCollection;

        static Program()
        {
            client = new MongoClient("mongodb://localhost:27017/");
            storeDB = client.GetDatabase("Cinepolis");
            MoviesCollection = storeDB.GetCollection<Peliculas>("Peliculas");
            SalesCollection = storeDB.GetCollection<VentaBoletos>("VentaBoletos");
        }
    
        
        static void Main(string[] args)
        {
            
        }
    }
}