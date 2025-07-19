using System;
using System.Collections.Generic;

namespace ParqueDiversiones
{
    // Clase Persona
    public class Persona
    {
        public string Nombre { get; set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    // Clase Atracción genérica con nombre personalizado
    public class Atraccion
    {
        private Queue<Persona> colaEspera;
        private const int capacidadMaxima = 30;
        public string NombreAtraccion { get; set; }

        public Atraccion(string nombreAtraccion)
        {
            NombreAtraccion = nombreAtraccion;
            colaEspera = new Queue<Persona>();
        }

        // Método para agregar persona a la cola
        public void AgregarPersona(Persona persona)
        {
            if (colaEspera.Count < capacidadMaxima)
            {
                colaEspera.Enqueue(persona);
                Console.WriteLine($"{persona.Nombre} ha sido agregado(a) a la cola.");
            }
            else
            {
                Console.WriteLine($"🎡 {NombreAtraccion} está llena. {persona.Nombre} no puede entrar.");
            }
        }

        // Método para iniciar la atracción
        public void IniciarAtraccion()
        {
            Console.WriteLine($"\n🎢 Inicia {NombreAtraccion}. Suben las siguientes personas:");

            int numeroAsiento = 1;
            while (colaEspera.Count > 0)
            {
                Persona persona = colaEspera.Dequeue();
                Console.WriteLine($"Asiento {numeroAsiento}: {persona.Nombre}");
                numeroAsiento++;
            }

            Console.WriteLine($"\n✅ Todos los asientos han sido ocupados. ¡{NombreAtraccion} ha comenzado!");
        }
    }

    // Clase Principal
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el nombre de la atracción o juego: ");
            string nombreJuego = Console.ReadLine();

            Atraccion atraccion = new Atraccion(nombreJuego);

            Console.WriteLine($"\n🎡 Bienvenido a *{nombreJuego}*. Ingrese los nombres en orden de llegada (máximo 30 personas).\n");

            for (int i = 0; i < 35; i++) // Intentamos agregar 35 personas
            {
                Console.Write($"Ingrese el nombre de la persona #{i + 1}: ");
                string nombre = Console.ReadLine();

                Persona nuevaPersona = new Persona(nombre);
                atraccion.AgregarPersona(nuevaPersona);
            }

            // Inicia la atracción
            atraccion.IniciarAtraccion();

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
