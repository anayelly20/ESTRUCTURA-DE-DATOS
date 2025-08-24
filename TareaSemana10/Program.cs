using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Generando datos de la campaña de vacunación...\n");

        // Crear 500 ciudadanos
        var conjuntoU = new HashSet<string>();
        for (int i = 1; i <= 500; i++) conjuntoU.Add("Ciudadano " + i);

        // Asignaciones fijas
        var conjuntoA = new HashSet<string>(); // Pfizer
        var conjuntoB = new HashSet<string>(); // AstraZeneca

        var lista = conjuntoU.ToList();
        var random = new Random(123); // Semilla fija para consistencia

        // 9 ciudadanos con ambas dosis
        var ambas = new HashSet<string>();
        while (ambas.Count < 9)
            ambas.Add(lista[random.Next(lista.Count)]);

        // 66 solo Pfizer
        var soloPfizer = new HashSet<string>();
        while (soloPfizer.Count < 66)
        {
            var c = lista[random.Next(lista.Count)];
            if (!ambas.Contains(c)) soloPfizer.Add(c);
        }

        // 66 solo AstraZeneca
        var soloAstra = new HashSet<string>();
        while (soloAstra.Count < 66)
        {
            var c = lista[random.Next(lista.Count)];
            if (!ambas.Contains(c) && !soloPfizer.Contains(c)) soloAstra.Add(c);
        }

        // Construir conjuntos finales
        conjuntoA.UnionWith(ambas);
        conjuntoA.UnionWith(soloPfizer);

        conjuntoB.UnionWith(ambas);
        conjuntoB.UnionWith(soloAstra);

        var vacunados = new HashSet<string>(conjuntoA);
        vacunados.UnionWith(conjuntoB);

        var noVacunados = new HashSet<string>(conjuntoU);
        noVacunados.ExceptWith(vacunados);

        // Resultados
        Console.WriteLine("=== CAMPAÑA DE VACUNACIÓN COVID-19 ===");
        Console.WriteLine($"Total ciudadanos: {conjuntoU.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {conjuntoA.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {conjuntoB.Count}");
        Console.WriteLine($"Total vacunados: {vacunados.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ambas dosis: {ambas.Count}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstra.Count}");
        Console.WriteLine();
        Console.WriteLine("=== VERIFICACIÓN ===");
        Console.WriteLine($"Total calculado: {soloPfizer.Count + soloAstra.Count + ambas.Count}");
        Console.WriteLine($"Total real: {vacunados.Count}");

        Console.ReadKey();
    }
}
