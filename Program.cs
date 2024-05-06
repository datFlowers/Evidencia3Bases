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
            List<Peliculas> peliculasList = MoviesCollection.Find(movie =>true).ToList(); 
            List<VentaBoletos> ventasList = SalesCollection.Find(sales =>true).ToList(); 

            while (true)
            {
                Console.WriteLine("================================");
                Console.WriteLine("1. Consultar películas");
                Console.WriteLine("2. Consultar Ventas");
                Console.WriteLine("3. Buscar información de películas y ventas relacionadas");
                Console.WriteLine("4. Actualizar película de venta");
                Console.WriteLine("5. Eliminar venta de película");
                Console.WriteLine("6. Salir del programa");
                Console.WriteLine("================================\n");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ConsultarPeliculas();
                        break;
                    
                    case "2":
                        ConsultarVentas();
                        break;
                    
                    case "3":
                        Relacion();
                        break;
                    
                    case "4":
                        ActualizarPelicula();
                        break;
                    
                    case "5":
                        EliminarVentaPelicula();
                        break;
                    
                    case "6":
                        Console.WriteLine("Saliendo del programa...");
                        return;
                    
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }

        private static void ConsultarPeliculas()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("1. Ver todo el listado de películas");
            Console.WriteLine("2. Filtrar por nombre");
            Console.WriteLine("3. Filtrar por género");
            Console.WriteLine("4. Filtrar por clasificación");
            Console.WriteLine("5. Filtrar por tipo de sala");
            Console.WriteLine("6. Filtrar por número de sala");
            Console.WriteLine("===================================\n");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ListarPeliculas(MoviesCollection.Find(_ => true).ToList());
                    break;
                
                case "2":
                    Console.Write("Ingrese el nombre de la película: ");
                    string nombre = Console.ReadLine();
                    ListarPeliculas(MoviesCollection.Find(p => p.Nombre.Contains(nombre)).ToList());
                    break;
                
                case "3":
                    Console.Write("Ingrese el género de la película: ");
                    string generoInput = Console.ReadLine();
                    string[] genero = generoInput.Split(','); // Divide la entrada por comas para obtener un array de género
                    ListarPeliculas(MoviesCollection.Find(p => p.Genero.Any(g => genero.Contains(g))).ToList());
                    break;
                
                case "4":
                    Console.Write("Ingrese la clasificación de la película: ");
                    string clasificacion = Console.ReadLine();
                    ListarPeliculas(MoviesCollection.Find(p => p.Clasificacion.Contains(clasificacion)).ToList());
                    break;

                case "5":
                    Console.Write("Ingrese el tipo de sala de la película: ");
                    string tipo_sala = Console.ReadLine();
                    ListarPeliculas(MoviesCollection.Find(p => p.Tipo_sala.Contains(tipo_sala)).ToList());
                    break;
                
                case "6":
                    Console.Write("Ingrese el número de sala de la película: ");
                    int numsala = int.Parse(Console.ReadLine());
                    ListarPeliculas(MoviesCollection.Find(p => p.Sala == (numsala)).ToList());
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }

        private static void ListarPeliculas(List<Peliculas> peliculas)
        {
            foreach (var movie in peliculas)
            {
                Console.WriteLine($"Nombre: {movie.Nombre}");
                Console.WriteLine($"Duración: {movie.Duracion_minutos} minutos");
                Console.WriteLine($"Género: {string.Join(", ", movie.Genero)}"); // Convertir array a cadena
                Console.WriteLine($"Clasificación: {movie.Clasificacion}");
                Console.WriteLine($"Tipo de sala: {movie.Tipo_sala}");
                Console.WriteLine($"Número de sala: {movie.Sala}");
                Console.WriteLine();
            }
        }

        private static void ConsultarVentas()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("1. Ver todo el listado de ventas");
            Console.WriteLine("2. Filtrar ventas por tipo de sala");
            Console.WriteLine("3. Filtrar ventas por nombre de cliente");
            Console.WriteLine("4. Filtrar ventas por número de tarjeta");
            Console.WriteLine("5. Filtrar ventas por película");
            Console.WriteLine("6. Filtrar ventas por fecha");
            Console.WriteLine("7. Filtrar ventas por número de sala");
            Console.WriteLine("===================================\n");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ListarVentas(SalesCollection.Find(_ => true).ToList());
                    break;
                
                case "2":
                    Console.Write("Ingrese el tipo de sala: ");
                    string tipoSala = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.Tipo_sala == tipoSala).ToList());
                    break;
                
                case "3":
                    Console.Write("Ingrese el nombre del cliente: ");
                    string nombreCliente = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.Nombre_cliente.Contains(nombreCliente)).ToList());
                    break;
                
                case "4":
                    Console.Write("Ingrese el número de tarjeta: ");
                    string numeroTarjeta = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.Num_tarjeta == numeroTarjeta).ToList());
                    break;

                case "5":
                    Console.Write("Ingrese el nombre de la película: ");
                    string nombrePelicula = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.Pelicula.Contains(nombrePelicula)).ToList());
                    break;
                
                case "6":
                    Console.Write("Ingrese la fecha (YYYY-MM-DD): ");
                    string Fecha = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.fecha == Fecha).ToList());
                    break;

                case "7":
                    Console.Write("Ingrese el número de sala: ");
                    int numSala = int.Parse(Console.ReadLine());
                    ListarVentas(SalesCollection.Find(s => s.Sala == numSala).ToList());
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }


        private static void ListarVentas(List<VentaBoletos> ventas)
        {
            foreach (var venta in ventas)
            {
                Console.WriteLine($"Tipo de sala: {venta.Tipo_sala}");
                Console.WriteLine($"Nombre del cliente: {venta.Nombre_cliente}");
                Console.WriteLine($"Número de tarjeta: {venta.Num_tarjeta}");
                Console.WriteLine($"Película: {venta.Pelicula}");
                Console.WriteLine($"Fecha: {venta.fecha}");
                Console.WriteLine($"Número de sala: {venta.Sala}");
                Console.WriteLine();
            }
        }

        private static void Relacion()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("1. Desplegar información de la película (en base a la venta)");
            Console.WriteLine("2. Desplegar información de la venta (en base a a la película)");
            Console.WriteLine("===================================\n");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese nombre de un cliente: ");
                    string nomclient = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.Nombre_cliente.Contains(nomclient)).ToList());
                    Console.WriteLine("Información de la película:\n");
                    var ventasCliente = SalesCollection.Find(s => s.Nombre_cliente.Contains(nomclient)).ToList();
                    var peliculasVendidas = MoviesCollection.Find(p => ventasCliente.Select(v => v.Pelicula).Contains(p.Nombre)).ToList();
                    ListarPeliculas(peliculasVendidas);
                    break;
                
                case "2":
                    Console.Write("Ingrese nombre de una película: ");
                    string nompeli = Console.ReadLine();
                    ListarPeliculas(MoviesCollection.Find(p => p.Nombre.Contains(nompeli)).ToList());
                    Console.WriteLine("Información de la venta:\n");
                    var ventasPelicula = SalesCollection.Find(s => s.Pelicula.Contains(nompeli)).ToList();
                    ListarVentas(ventasPelicula);
                    break;
                
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }

        private static void ActualizarPelicula()
        {
            Console.Write("\nIngrese el nombre de la película en la venta: ");
            string nombrePelicula = Console.ReadLine();
            ListarVentas(SalesCollection.Find(s => s.Pelicula.Contains(nombrePelicula)).ToList());
            Console.Write("\nIngrese el nuevo nombre de la película: ");
            string nuevoNombrePelicula = Console.ReadLine();
            ActualizarNombrePelicula(SalesCollection, nombrePelicula, nuevoNombrePelicula);
        }

        private static void ActualizarNombrePelicula(IMongoCollection<VentaBoletos> collection, string nombreAntiguo, string nombreNuevo)
        {
            var ventas = collection.Find(s => s.Pelicula.Contains(nombreAntiguo)).ToList();

            foreach (var venta in ventas)
            {
                venta.Pelicula = nombreNuevo;
                collection.ReplaceOne(s => s.Id == venta.Id, venta);
            }

            Console.WriteLine("Película actualizada correctamente.");
        }

        private static void EliminarVentaPelicula()
        {
            Console.Write("Ingrese el nombre de la película para eliminar su venta: ");
            string nombrePelicula = Console.ReadLine();
            ListarVentas(SalesCollection.Find(s => s.Pelicula.Contains(nombrePelicula)).ToList());
            EliminarVentaPorPelicula(SalesCollection, nombrePelicula);
        }

        private static void EliminarVentaPorPelicula(IMongoCollection<VentaBoletos> collection, string nombrePelicula)
        {
            collection.DeleteMany(s => s.Pelicula.Contains(nombrePelicula));
            Console.WriteLine("Venta eliminada correctamente.");
        }
    }
}