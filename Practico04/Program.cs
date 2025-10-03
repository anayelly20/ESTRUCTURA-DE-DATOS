using System;
using System.Collections.Generic;
using System.Linq;

namespace BusquedaVuelos
{
    public class Vuelo
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal Precio { get; set; }
        public Vuelo(string origen, string destino, decimal precio) { Origen = origen.ToUpper(); Destino = destino.ToUpper(); Precio = precio; }
        public override string ToString() => $"{Origen} → {Destino}: ${Precio}";
    }

    public class BaseDatosVuelos
    {
        private List<Vuelo> vuelos = new List<Vuelo>
        {
            new Vuelo("GUAYAQUIL", "LOJA", 45), new Vuelo("MANTA", "QUITO", 55), new Vuelo("CUENCA", "QUITO", 60),
            new Vuelo("PUYO", "CUENCA", 65), new Vuelo("TENA", "QUITO", 70)
        };
        public List<Vuelo> ObtenerTodos() => vuelos;
        public List<Vuelo> BuscarOrigen(string o) => vuelos.Where(v => v.Origen == o.ToUpper()).ToList();
        public List<Vuelo> BuscarDestino(string d) => vuelos.Where(v => v.Destino == d.ToUpper()).ToList();
        public List<Vuelo> BuscarRuta(string o, string d) => vuelos.Where(v => v.Origen == o.ToUpper() && v.Destino == d.ToUpper()).ToList();
        public List<Vuelo> BuscarPrecio(decimal p) => vuelos.Where(v => v.Precio <= p).OrderBy(v => v.Precio).ToList();
        public Vuelo MasBarato() => vuelos.OrderBy(v => v.Precio).FirstOrDefault();
        public List<Vuelo> Ordenados() => vuelos.OrderBy(v => v.Precio).ToList();
    }

    class Program
    {
        static BaseDatosVuelos bd = new BaseDatosVuelos();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("╔════════════════════════════════════════════════╗\n║   SISTEMA DE BÚSQUEDA DE VUELOS BARATOS        ║\n╚════════════════════════════════════════════════╝\n\n🛫 Opciones disponibles:\n");
                Console.WriteLine("1. Ver todos los vuelos\n2. Buscar por origen\n3. Buscar por destino\n4. Buscar por ruta\n5. Buscar por precio máximo\n6. Vuelo más barato\n7. Ver ordenados por precio\n8. Salir");
                Console.Write("\nSeleccione: ");
                switch (Console.ReadLine())
                {
                    case "1": Mostrar("\n✈️  TODOS LOS VUELOS", bd.ObtenerTodos()); break;
                    case "2": Console.Write("\nOrigen: "); string o = Console.ReadLine(); Mostrar($"\n✈️  VUELOS DESDE {o.ToUpper()}", bd.BuscarOrigen(o)); break;
                    case "3": Console.Write("\nDestino: "); string d = Console.ReadLine(); Mostrar($"\n✈️  VUELOS HACIA {d.ToUpper()}", bd.BuscarDestino(d)); break;
                    case "4": Console.Write("\nOrigen: "); string o2 = Console.ReadLine(); Console.Write("Destino: "); string d2 = Console.ReadLine(); Mostrar($"\n✈️  {o2.ToUpper()} → {d2.ToUpper()}", bd.BuscarRuta(o2, d2)); break;
                    case "5": Console.Write("\nPrecio máximo $"); if (decimal.TryParse(Console.ReadLine(), out decimal p)) Mostrar($"\n✈️  HASTA ${p}", bd.BuscarPrecio(p)); else Console.WriteLine("\n❌ Precio no válido"); break;
                    case "6": var v = bd.MasBarato(); Console.WriteLine("\n💰 MÁS BARATO\n════════════════════════════════════════"); Console.WriteLine(v != null ? $"✓ {v}" : "No hay vuelos"); break;
                    case "7": Mostrar("\n✈️  ORDENADOS POR PRECIO", bd.Ordenados()); break;
                    case "8": continuar = false; Console.WriteLine("\n¡Gracias por usar el sistema!"); break;
                    default: Console.WriteLine("\n Opción no válida"); break;
                }
                if (continuar) { Console.WriteLine("\nPresione cualquier tecla..."); Console.ReadKey(); Console.Clear(); }
            }
        }
        static void Mostrar(string titulo, List<Vuelo> vuelos)
        {
            Console.WriteLine($"{titulo}\n════════════════════════════════════════");
            if (vuelos.Count > 0) { vuelos.ForEach(v => Console.WriteLine($"✓ {v}")); Console.WriteLine($"\nTotal: {vuelos.Count}"); }
            else Console.WriteLine("No se encontraron vuelos");
        }
    }
}