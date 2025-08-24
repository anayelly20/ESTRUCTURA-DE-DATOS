using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Generando datos de la campaña de vacunación...\n");
        
        // 1. Crear conjunto de 500 ciudadanos
        HashSet<string> conjuntoU = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            conjuntoU.Add("Ciudadano " + i);
        }

        // 2. Crear conjuntos ficticios de vacunados
        HashSet<string> conjuntoA = GenerarVacunados(conjuntoU, 75, 1); // Pfizer
        HashSet<string> conjuntoB = GenerarVacunados(conjuntoU, 75, 2); // AstraZeneca

        // 3. Operaciones de conjuntos
        var vacunados = new HashSet<string>(conjuntoA);
        vacunados.UnionWith(conjuntoB);                     // A ∪ B

        var noVacunados = new HashSet<string>(conjuntoU);
        noVacunados.ExceptWith(vacunados);                  // U - vacunados

        var ambasDosis = new HashSet<string>(conjuntoA);
        ambasDosis.IntersectWith(conjuntoB);                // A ∩ B

        var soloPfizer = new HashSet<string>(conjuntoA);
        soloPfizer.ExceptWith(conjuntoB);                   // A - B

        var soloAstra = new HashSet<string>(conjuntoB);
        soloAstra.ExceptWith(conjuntoA);                    // B - A

        // 4. Mostrar resultados
        Console.WriteLine("=== CAMPAÑA DE VACUNACIÓN COVID-19 ===");
        Console.WriteLine($"Total ciudadanos: {conjuntoU.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {conjuntoA.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {conjuntoB.Count}");
        Console.WriteLine($"Total vacunados: {vacunados.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ambas dosis: {ambasDosis.Count}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstra.Count}");

        // 5. Verificación matemática
        Console.WriteLine("\n=== VERIFICACIÓN ===");
        Console.WriteLine($"Total calculado: {soloPfizer.Count + soloAstra.Count + ambasDosis.Count}");
        Console.WriteLine($"Total real: {vacunados.Count}");

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }

    static HashSet<string> GenerarVacunados(HashSet<string> poblacionTotal, int cantidad, int seed)
    {
        HashSet<string> conjunto = new HashSet<string>();
        Random random = new Random(seed * DateTime.Now.Millisecond);
        List<string> listaPoblacion = poblacionTotal.ToList();

        while (conjunto.Count < cantidad)
        {
            int indice = random.Next(0, listaPoblacion.Count);
            conjunto.Add(listaPoblacion[indice]);
        }
        return conjunto;
    }
}