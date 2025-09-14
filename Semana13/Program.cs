using System;
using System.Collections.Generic;

class ProgramaCatalogo
{
    // Método principal
    static void Main()
    {
        // Crear catálogo de revistas con 10 títulos
        List<string> catalogoRevistas = new List<string>
        {
            "National Geographic",
            "Time",
            "Forbes",
            "Scientific American",
            "The Economist",
            "Nature",
            "Vogue",
            "Popular Science",
            "Reader's Digest",
            "Wired"
        };

        int opcion;
        do
        {
            // Mostrar menú
            Console.WriteLine("\n--- Catálogo de Revistas ---");
            Console.WriteLine("1. Buscar revista");
            Console.WriteLine("2. Mostrar todas las revistas");
            Console.WriteLine("3. Salir");
            Console.Write("Ingrese su opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el título de la revista a buscar: ");
                    string titulo = Console.ReadLine();
                    
                    // Búsqueda iterativa
                    bool encontrado = BuscarRevistaIterativa(catalogoRevistas, titulo);

                    if (encontrado)
                        Console.WriteLine("Encontrado");
                    else
                        Console.WriteLine("No encontrado");
                    break;

                case 2:
                    Console.WriteLine("\nRevistas en el catálogo:");
                    foreach (var revista in catalogoRevistas)
                    {
                        Console.WriteLine("- " + revista);
                    }
                    break;

                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

        } while (opcion != 3);
    }

    // Método de búsqueda iterativa
    static bool BuscarRevistaIterativa(List<string> catalogo, string titulo)
    {
        foreach (var revista in catalogo)
        {
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true; // Revista encontrada
            }
        }
        return false; // Revista no encontrada
    }

    // Ejemplo de búsqueda recursiva (opcional)
    static bool BuscarRevistaRecursiva(List<string> catalogo, string titulo, int indice = 0)
    {
        if (indice >= catalogo.Count)
            return false; // Fin de la lista, no encontrado

        if (catalogo[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
            return true; // Revista encontrada

        return BuscarRevistaRecursiva(catalogo, titulo, indice + 1); // Llamada recursiva
    }
}
