using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Core.Misc;
using MongoDB;
using P2.Colecciones;
using System.Xml.Serialization;
using System;
using System.Text.Json;

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
            //Llamar al cliente y a la base de datos, así como sus colecciones
            client = new MongoClient("mongodb://localhost:27017/");
            storeDB = client.GetDatabase("Cinepolis");
            MoviesCollection = storeDB.GetCollection<Peliculas>("Peliculas");
            SalesCollection = storeDB.GetCollection<VentaBoletos>("VentaBoletos");
        }
    
        
        static void Main(string[] args)
        {
            //Agregar información a las colecciones

            /*
            ==============
            = PELICULAS: =
            ==============
            */
            
            var peliculas = new[]
            {
                new Peliculas
                {
                    Nombre = "Challengers",
                    Duracion_minutos = 131,
                    Genero = new[] { "Romance", "Drama" },
                    Clasificacion = "R",
                    Tipo_sala = "VIP",
                    Sala = 1
                },
                new Peliculas
                {
                    Nombre = "Abigail",
                    Duracion_minutos = 90,
                    Genero = new[] { "Terror", "Suspenso" },
                    Clasificacion = "R",
                    Tipo_sala = "Estandar",
                    Sala = 2
                },
                new Peliculas
                {
                    Nombre = "Civil War",
                    Duracion_minutos = 109,
                    Genero = new[] { "Accion" },
                    Clasificacion = "R",
                    Tipo_sala = "IMAX",
                    Sala = 3
                },
                new Peliculas
                {
                    Nombre = "Coraline",
                    Duracion_minutos = 195,
                    Genero = new[] { "Suspenso", "Fantasia" },
                    Clasificacion = "PG-13",
                    Tipo_sala = "VIP",
                    Sala = 4
                },
                new Peliculas
                {
                    Nombre = "Interstellar",
                    Duracion_minutos = 169,
                    Genero = new[] { "Ciencia ficcion", "Aventura" },
                    Clasificacion = "PG-13",
                    Tipo_sala = "IMAX",
                    Sala = 5
                },
                new Peliculas
                {
                    Nombre = "Dune Part Two",
                    Duracion_minutos = 166,
                    Genero = new[] { "Drama", "Accion" },
                    Clasificacion = "PG-13",
                    Tipo_sala = "IMAX",
                    Sala = 6
                }
            };


            /*
            ===========
            = VENTAS: =
            ===========
            */

            var ventas = new []
            {
                new VentaBoletos
                {
                    Tipo_sala = "VIP",
                    Nombre_cliente = "Diego Tamez",
                    Num_tarjeta = "1111-1111-1111-1111",
                    Pelicula = "Challengers",
                    fecha = "2024-05-04",
                    Sala = 1
                },
                new VentaBoletos
                {
                    Tipo_sala = "Estandar",
                    Nombre_cliente = "Mario Rodriguez",
                    Num_tarjeta = "2222-2222-2222-2222",
                    Pelicula = "Abigail",
                    fecha = "2024-05-04",
                    Sala = 2
                },
                new VentaBoletos
                {
                    Tipo_sala = "IMAX",
                    Nombre_cliente = "Montserrat Salazar",
                    Num_tarjeta = "3333-3333-3333-3333",
                    Pelicula = "Dune Part Two",
                    fecha = "2024-05-05",
                    Sala = 6
                },
                new VentaBoletos
                {
                    Tipo_sala = "IMAX",
                    Nombre_cliente = "Mariela Valdez",
                    Num_tarjeta = "4444-4444-4444-4444",
                    Pelicula = "Civil War",
                    fecha = "2024-05-06",
                    Sala = 3
                },
                new VentaBoletos
                {
                    Tipo_sala = "VIP",
                    Nombre_cliente = "Sara Flores",
                    Num_tarjeta = "5555-5555-5555-5555",
                    Pelicula = "Coraline",
                    fecha = "2024-05-05",
                    Sala = 4
                },
                new VentaBoletos
                {
                    Tipo_sala = "IMAX",
                    Nombre_cliente = "Marla Cavazos",
                    Num_tarjeta = "6666-6666-6666-6666",
                    Pelicula = "Interstellar",
                    fecha = "2024-05-07",
                    Sala = 5
                }
            };
            
            //Creamos Lista de los elementos dentro de películas y ventas
            List<Peliculas> peliculasList = MoviesCollection.Find(movie =>true).ToList(); 
            List<VentaBoletos> ventasList = SalesCollection.Find(sales =>true).ToList(); 

            //Si la colección de películas está vacía, inserta los datos
            if (MoviesCollection.CountDocuments(FilterDefinition<Peliculas>.Empty) == 0)
            {
                MoviesCollection.InsertMany(peliculas);
                Console.WriteLine("Datos de películas ingresados correctamente en la colección.");
            }
            //Si no está vacía, no inserta nada
            else
            {
                Console.WriteLine("La colección de películas ya contiene datos.");
            }

            //Si la colección de ventas está vacía, inserta los datos
            if (SalesCollection.CountDocuments(FilterDefinition<VentaBoletos>.Empty) == 0)
            {
                SalesCollection.InsertMany(ventas);
                Console.WriteLine("Datos de ventas ingresados correctamente en la colección.");
            }
            //Si no está vacía, no inserta nada
            else
            {
                Console.WriteLine("La colección de ventas ya contiene datos.");
            }

            //Inicio
            Thread.Sleep(900);
            
            //Nombre
            Console.WriteLine("\nDiego Alonso Tamez Flores");
            
            Thread.Sleep(900);

            Console.WriteLine("\n                          ---------------------");
            Console.WriteLine("                          - ¡¡¡BIENVENIDOS!!! -");
            Console.WriteLine("                          ---------------------\n");

            Thread.Sleep(900);

            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
            Console.WriteLine("  CCCCC   IIII  NN   NN   ÉÉÉÉÉÉÉ  PPPPPP    OOO    LL      IIII   SSSS ");
            Console.WriteLine(" CC        II   NNN  NN   ÉÉ       PP   PP  O   O   LL       II   SS    ");
            Console.WriteLine(" CC        II   NN N NN   ÉÉÉÉÉ    PPPPPP   O   O   LL       II    SSS  ");
            Console.WriteLine(" CC        II   NN  NNN   ÉÉ       PP       O   O   LL       II      SS ");
            Console.WriteLine("  CCCCC   IIII  NN   NN   ÉÉÉÉÉÉÉ  PP        OOO    LLLLLL  IIII  SSSS  ");
            Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            Thread.Sleep(900);

            Console.WriteLine("\n                            *****************");
            Console.WriteLine("                            La magia del cine");
            Console.WriteLine("                            *****************\n");
            
            Thread.Sleep(1000);

            Console.WriteLine("Consultas:\n");

            Thread.Sleep(900);
            
            //Consultas
            while (true)
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("1. Consultar películas");
                Console.WriteLine("2. Consultar Ventas");
                Console.WriteLine("3. Buscar información de películas y ventas relacionadas");
                Console.WriteLine("4. Actualizar película de venta");
                Console.WriteLine("5. Eliminar venta de película");
                Console.WriteLine("6. Salir del programa");
                Console.WriteLine("========================================================\n");
                
                //Leemos la respuesta del usuario
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                //Switch para utilizar las clases respectivas
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

        //Clase para consultar películas
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
            
            //Leemos la respuesta del usuario
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            //Switch para realizar las tareas respectivas
            switch (opcion)
            {
                case "1":
                    //Listar todas las películas
                    ListarPeliculas(MoviesCollection.Find(_ => true).ToList());
                    break;
                
                case "2":
                    //Buscamos el nombre que contenga total o parcialmente lo que ingrese el usuario
                    Console.Write("Ingrese el nombre de la película: ");
                    string nombre = Console.ReadLine();
                    ListarPeliculas(MoviesCollection.Find(p => p.Nombre.Contains(nombre)).ToList());
                    break;
                
                case "3":
                    //Buscamos películas en base a 1 o más géneros ingresados por el usuario
                    Console.Write("Ingrese el género de la película: ");
                    string generoInput = Console.ReadLine();
                    
                    // Divide la entrada del usuario por comas para obtener un array de géneros
                    string[] genero = generoInput.Split(','); 
                    ListarPeliculas(MoviesCollection.Find(p => p.Genero.Any(g => genero.Contains(g))).ToList());
                    break;
                
                case "4":
                    //Buscamos películas en base a la clasificación que ingrese el usuario
                    Console.Write("Ingrese la clasificación de la película: ");
                    string clasificacion = Console.ReadLine();
                    ListarPeliculas(MoviesCollection.Find(p => p.Clasificacion.Contains(clasificacion)).ToList());
                    break;

                case "5":
                    //Buscamos películas en base al tipo de sala de proyección
                    Console.Write("Ingrese el tipo de sala de la película: ");
                    string tipo_sala = Console.ReadLine();
                    ListarPeliculas(MoviesCollection.Find(p => p.Tipo_sala.Contains(tipo_sala)).ToList());
                    break;
                
                case "6":
                    //Buscamos películas en base al número de sala
                    Console.Write("Ingrese el número de sala de la película: ");
                    int numsala = int.Parse(Console.ReadLine());
                    ListarPeliculas(MoviesCollection.Find(p => p.Sala == (numsala)).ToList());
                    break;

                default:
                    //En caso de que el usuario ingrese una opción inválida
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }

        //Clase para mostrar todo el listado de películas
        private static void ListarPeliculas(List<Peliculas> peliculas)
        {
            foreach (var movie in peliculas)
            {
                Console.WriteLine($"Nombre: {movie.Nombre}");
                Console.WriteLine($"Duración: {movie.Duracion_minutos} minutos");

                //Convertir array a cadena separada por comas
                Console.WriteLine($"Género: {string.Join(", ", movie.Genero)}");

                Console.WriteLine($"Clasificación: {movie.Clasificacion}");
                Console.WriteLine($"Tipo de sala: {movie.Tipo_sala}");
                Console.WriteLine($"Número de sala: {movie.Sala}");
                Console.WriteLine();
            }
        }

        //Clase para consultar las ventas registradas
        private static void ConsultarVentas()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("1. Ver todo el listado de ventas");
            Console.WriteLine("2. Filtrar ventas por tipo de sala");
            Console.WriteLine("3. Filtrar ventas por nombre de cliente");
            Console.WriteLine("4. Filtrar ventas por número de tarjeta");
            Console.WriteLine("5. Filtrar ventas por película");
            Console.WriteLine("6. Filtrar ventas por fecha");
            Console.WriteLine("7. Filtrar ventas por número de sala");
            Console.WriteLine("=======================================\n");

            //Leemos la respuesta del usuario
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    //Lista todas las ventas
                    ListarVentas(SalesCollection.Find(_ => true).ToList());
                    break;
                
                case "2":
                    //Buscamos ventas en base al tipo de sala de proyección
                    Console.Write("Ingrese el tipo de sala: ");
                    string tipoSala = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.Tipo_sala == tipoSala).ToList());
                    break;
                
                case "3":
                    //Buscamos ventas en base al nombre del cliente
                    Console.Write("Ingrese el nombre del cliente: ");
                    string nombreCliente = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.Nombre_cliente.Contains(nombreCliente)).ToList());
                    break;
                
                case "4":
                    //Buscamos ventas en base al número de tarjeta del usuario
                    Console.Write("Ingrese el número de tarjeta: ");
                    string numeroTarjeta = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.Num_tarjeta == numeroTarjeta).ToList());
                    break;

                case "5":
                    //Buscamos ventas en base al nombre de la película de la venta
                    Console.Write("Ingrese el nombre de la película: ");
                    string nombrePelicula = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.Pelicula.Contains(nombrePelicula)).ToList());
                    break;
                
                case "6":
                    //Buscamos ventas en base a la fecha de proyección
                    Console.Write("Ingrese la fecha (YYYY-MM-DD): ");
                    string Fecha = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.fecha == Fecha).ToList());
                    break;

                case "7":
                    //Buscamos ventas en base al número de salas
                    Console.Write("Ingrese el número de sala: ");
                    int numSala = int.Parse(Console.ReadLine());
                    ListarVentas(SalesCollection.Find(s => s.Sala == numSala).ToList());
                    break;

                default:
                    //En caso de que el usuario ingrese una opción inválida
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }

        //Clase para listar todas las ventas
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

        //Clase para desplegar colleciones en base a su relación con otra
        private static void Relacion()
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine("1. Desplegar información de la película (en base a la venta)");
            Console.WriteLine("2. Desplegar información de la venta (en base a a la película)");
            Console.WriteLine("==============================================================\n");

            //Leemos la respuesta del usuario
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    //Buscamos la película mediante el nombre del cliente
                    Console.Write("Ingrese nombre de un cliente: ");
                    string nomclient = Console.ReadLine();
                    ListarVentas(SalesCollection.Find(s => s.Nombre_cliente.Contains(nomclient)).ToList());
                    Console.WriteLine("Información de la película:\n");
                    var ventasCliente = SalesCollection.Find(s => s.Nombre_cliente.Contains(nomclient)).ToList();
                    var peliculasVendidas = MoviesCollection.Find(p => ventasCliente.Select(v => v.Pelicula).Contains(p.Nombre)).ToList();
                    ListarPeliculas(peliculasVendidas);
                    break;
                
                case "2":
                    //Buscamos el cliente mediante el nombre de la película
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

        //Clase para actualizar la película de una venta
        private static void ActualizarPelicula()
        {
            //Ingresamos el nombre de la película que ya tenemos
            Console.Write("\nIngrese el nombre del cliente de la venta: ");
            string nombreCliente = Console.ReadLine();
            ListarVentas(SalesCollection.Find(s => s.Nombre_cliente.Contains(nombreCliente)).ToList());

            //Ingresamos la nueva película
            Console.Write("\nIngrese la nueva película: ");
            string nuevoNombrePelicula = Console.ReadLine();
            ActualizarNombrePelicula(SalesCollection, nombreCliente, nuevoNombrePelicula);
        }

        //Clase llamada para actualizar el nombre de la película
        private static void ActualizarNombrePelicula(IMongoCollection<VentaBoletos> collection, string nombreCliente, string nombreNuevo)
        {
            var ventas = collection.Find(s => s.Nombre_cliente.Contains(nombreCliente)).ToList();

            foreach (var venta in ventas)
            {
                venta.Pelicula = nombreNuevo;
                collection.ReplaceOne(s => s.Id == venta.Id, venta);
            }

            Console.WriteLine("Película actualizada correctamente.");
        }

        //Clase para eliminar la venta de alguna película
        private static void EliminarVentaPelicula()
        {
            Console.Write("Ingrese el nombre del cliente para eliminar su venta: ");
            string nombreCliente = Console.ReadLine();
            ListarVentas(SalesCollection.Find(s => s.Nombre_cliente.Contains(nombreCliente)).ToList());
            EliminarVentaPorPelicula(SalesCollection, nombreCliente);
        }

        //Clase que es llamada por la clase anterior para la eliminación de la película
        private static void EliminarVentaPorPelicula(IMongoCollection<VentaBoletos> collection, string nombreCliente)
        {
            collection.DeleteMany(s => s.Nombre_cliente.Contains(nombreCliente));
            Console.WriteLine("Venta eliminada correctamente.");
        }
    }
}