using System;
using System.Collections.Generic;
using System.Linq;

namespace TorneoFutbol
{
    public record Jugador(int Id, string Nombre, string Posicion, int Edad, int NumeroCamiseta, string EquipoId)
    {
        public override string ToString() => $"[ID:{Id}] {Nombre} ({Posicion}) - #{NumeroCamiseta}, {Edad} años";
    }

    public record Equipo(string Id, string Nombre, string Ciudad, string Entrenador, DateTime FechaFundacion)
    {
        public override string ToString() => $"[{Id}] {Nombre} ({Ciudad}) - {Entrenador}, {FechaFundacion:yyyy}";
    }

    public class SistemaTorneo
    {
        private Dictionary<string, Equipo> equipos = new();
        private Dictionary<int, Jugador> jugadores = new();
        private HashSet<string> nombresEquipos = new();
        private HashSet<int> numerosCamiseta = new();
        private Dictionary<string, HashSet<int>> jugadoresPorEquipo = new();
        private Dictionary<string, HashSet<int>> jugadoresPorPosicion = new();
        private int siguienteIdJugador = 1;

        public bool RegistrarEquipo(string id, string nombre, string ciudad, string entrenador, DateTime fecha)
        {
            if (equipos.ContainsKey(id) || nombresEquipos.Contains(nombre.ToLower()))
            {
                Console.WriteLine("❌ Equipo duplicado."); return false;
            }
            equipos[id] = new Equipo(id, nombre, ciudad, entrenador, fecha);
            nombresEquipos.Add(nombre.ToLower());
            jugadoresPorEquipo[id] = new();
            Console.WriteLine($"✅ Equipo {nombre} registrado.");
            return true;
        }

        public bool RegistrarJugador(string nombre, string posicion, int edad, int numeroCamiseta, string equipoId)
        {
            if (!equipos.ContainsKey(equipoId)) { Console.WriteLine("❌ Equipo inexistente."); return false; }
            if (numerosCamiseta.Contains(numeroCamiseta)) { Console.WriteLine("❌ Número en uso."); return false; }
            if (jugadoresPorEquipo[equipoId].Count >= 25) { Console.WriteLine("❌ Equipo completo."); return false; }

            int id = siguienteIdJugador++;
            var jugador = new Jugador(id, nombre, posicion, edad, numeroCamiseta, equipoId);
            jugadores[id] = jugador; numerosCamiseta.Add(numeroCamiseta);
            jugadoresPorEquipo[equipoId].Add(id);

            if (!jugadoresPorPosicion.ContainsKey(posicion))
                jugadoresPorPosicion[posicion] = new HashSet<int>();
            jugadoresPorPosicion[posicion].Add(id);

            Console.WriteLine($"✅ Jugador {nombre} registrado (ID {id}).");
            return true;
        }

        public void MostrarEquipos() =>
            MostrarLista("📋 EQUIPOS REGISTRADOS", equipos.Values.OrderBy(e => e.Nombre),
                e => $"{e} | Jugadores: {jugadoresPorEquipo[e.Id].Count}");

        public void MostrarJugadores() =>
            MostrarLista("👥 JUGADORES REGISTRADOS", jugadores.Values.OrderBy(j => j.Nombre),
                j => $"{j} - Equipo: {equipos[j.EquipoId].Nombre}");

        public void MostrarJugadoresPorEquipo(string equipoId)
        {
            if (!equipos.ContainsKey(equipoId)) { Console.WriteLine("❌ Equipo no encontrado."); return; }
            var eq = equipos[equipoId];
            var lista = jugadoresPorEquipo[equipoId].OrderBy(i => jugadores[i].NumeroCamiseta).Select(i =>
                $"#{jugadores[i].NumeroCamiseta:D2} - {jugadores[i].Nombre} ({jugadores[i].Posicion}) - {jugadores[i].Edad} años");
            MostrarLista($"👥 JUGADORES DEL EQUIPO: {eq.Nombre}", lista);
        }

        private void MostrarLista<T>(string titulo, IEnumerable<T> items, Func<T, string>? format = null)
        {
            Console.WriteLine($"\n=== {titulo} ===");
            if (!items.Any()) { Console.WriteLine("No hay registros."); return; }
            foreach (var item in items) Console.WriteLine(format?.Invoke(item) ?? item!.ToString());
        }

        public List<string> ObtenerIdsEquipos() => equipos.Keys.ToList();
    }

    class Program
    {
        static SistemaTorneo sistema = new();

        static void Main()
        {
            Console.WriteLine("🏆 SISTEMA DE TORNEO DE FÚTBOL\n");
            while (true)
            {
                Console.WriteLine("\n1. Registrar Equipo\n2. Registrar Jugador\n3. Ver Equipos\n4. Ver Jugadores\n5. Ver Jugadores por Equipo\n0. Salir");
                Console.Write("Seleccione: ");
                switch (Console.ReadLine())
                {
                    case "1": RegistrarEquipo(); break;
                    case "2": RegistrarJugador(); break;
                    case "3": sistema.MostrarEquipos(); break;
                    case "4": sistema.MostrarJugadores(); break;
                    case "5": ConsultarJugadoresPorEquipo(); break;
                    case "0": return;
                    default: Console.WriteLine("❌ Opción inválida."); break;
                }
            }
        }

        static void RegistrarEquipo()
        {
            Console.Write("ID: "); string id = Console.ReadLine()?.ToUpper();
            Console.Write("Nombre: "); string nombre = Console.ReadLine();
            Console.Write("Ciudad: "); string ciudad = Console.ReadLine();
            Console.Write("Entrenador: "); string entrenador = Console.ReadLine();
            Console.Write("Año fundación: "); int.TryParse(Console.ReadLine(), out int anio);
            sistema.RegistrarEquipo(id, nombre, ciudad, entrenador, new DateTime(anio, 1, 1));
        }

        static void RegistrarJugador()
        {
            var equipos = sistema.ObtenerIdsEquipos();
            if (equipos.Count == 0) { Console.WriteLine("❌ No hay equipos."); return; }

            Console.Write("Nombre: "); string nombre = Console.ReadLine();
            Console.Write("Posición (1-Portero,2-Defensa,3-Centrocampista,4-Delantero): ");
            string[] pos = { "Portero", "Defensa", "Centrocampista", "Delantero" };
            int.TryParse(Console.ReadLine(), out int p);

            if (p < 1 || p > pos.Length)
            {
                Console.WriteLine("❌ Opción inválida de posición."); 
                return;
            }

            Console.Write("Edad: "); int.TryParse(Console.ReadLine(), out int edad);
            Console.Write("N° Camiseta: "); int.TryParse(Console.ReadLine(), out int num);
            Console.WriteLine("Equipos: " + string.Join(", ", equipos));
            Console.Write("Seleccione ID: "); string equipoId = Console.ReadLine();

            sistema.RegistrarJugador(nombre, pos[p - 1], edad, num, equipoId);
        }

        static void ConsultarJugadoresPorEquipo()
        {
            var equipos = sistema.ObtenerIdsEquipos();
            if (!equipos.Any()) { Console.WriteLine("❌ No hay equipos."); return; }
            Console.WriteLine("Equipos: " + string.Join(", ", equipos));
            Console.Write("Seleccione ID: "); sistema.MostrarJugadoresPorEquipo(Console.ReadLine());
        }
    }
}
