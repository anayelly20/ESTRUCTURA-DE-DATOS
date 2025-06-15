using System;

namespace RegistroEstudiante
{
    public class Estudiante
    {
        // Atributos
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; } = new string[3];

        // Método para mostrar los datos del estudiante
        public void MostrarDatos()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nombres: " + Nombres);
            Console.WriteLine("Apellidos: " + Apellidos);
            Console.WriteLine("Dirección: " + Direccion);
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($" - Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }
}
