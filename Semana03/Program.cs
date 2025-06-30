using System;
using RegistroEstudiante; // Importa el namespace para usar la clase Estudiante

class Program
{
    static void Main(string[] args)
    {
        // Crear un nuevo estudiante
        Estudiante estudiante1 = new Estudiante
        {
            Id = 1,
            Nombres = "Anayelly",
            Apellidos = "Lopez",
            Direccion = "Calle Quito 123",
            Telefonos = new string[] { "0991234567", "022123456", "0987654321" }
        };

        // Mostrar los datos
        estudiante1.MostrarDatos();
    }
}
