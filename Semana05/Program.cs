using System;
using System.Collections.Generic;

class Programa
{
    static void Main()
    {
        // Crear una lista de asignaturas
        List<string> asignaturas = new List<string>()
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua"
        };

        // Mostrar las asignaturas por pantalla
        Console.WriteLine("Asignaturas del curso:");
        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine("- " + asignatura);
        }

        // Pausar la consola para ver el resultado
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}