using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // =========================================================================
        // 1. Crear conjunto de 500 ciudadanos
        // =========================================================================
        Console.WriteLine("Generando datos de la campaña de vacunación...\n");
        
        HashSet<string> conjuntoU = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            conjuntoU.Add("Ciudadano " + i);
        }

        // =========================================================================
        // 2. Crear conjunto ficticio de 75 vacunados con Pfizer
        // =========================================================================
        HashSet<string> conjuntoA = GenerarVacunados(conjuntoU, 75, 1);

        // =========================================================================
        // 3. Crear conjunto ficticio de 75 vacunados con AstraZeneca
        // =========================================================================
        HashSet<string> conjuntoB = GenerarVacunados(conjuntoU, 75, 2);

        // =========================================================================
        // 4. Operaciones de conjuntos
        // =========================================================================
        
        // vacunados = (A ∪ B)
        var vacunados = new HashSet<string>(conjuntoA);     // copia de A
        vacunados.UnionWith(conjuntoB);                     // ahora A ∪ B

        // no vacunados = U - vacunados
        var noVacunados = new HashSet<string>(conjuntoU);   // copia de U
        noVacunados.ExceptWith(vacunados);                  // U - vacunados

        // ambas dosis = A ∩ B
        var ambasDosis = new HashSet<string>(conjuntoA);    // copia de A 
        ambasDosis.IntersectWith(conjuntoB);

        // solo Pfizer = A - B
        var soloPfizer = new HashSet<string>(conjuntoA);    // copia de A 
        soloPfizer.ExceptWith(conjuntoB);

        // solo AstraZeneca = B - A
        var soloAstra = new HashSet<string>(conjuntoB);     // copia de B
        soloAstra.ExceptWith(conjuntoA);

        // =========================================================================
        // 5. Resultados - Resumen Estadístico
        // =========================================================================
        Console.WriteLine("=== CAMPAÑA DE VACUNACIÓN COVID-19 ===");
        Console.WriteLine("=====================================");
        Console.WriteLine($"Total ciudadanos: {conjuntoU.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {conjuntoA.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {conjuntoB.Count}");
        Console.WriteLine($"Total vacunados: {vacunados.Count}");
        Console.WriteLine("=====================================");
        Console.WriteLine($"1. No vacunados: {noVacunados.Count}");
        Console.WriteLine($"2. Ambas dosis (Pfizer + AstraZeneca): {ambasDosis.Count}");
        Console.WriteLine($"3. Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"4. Solo AstraZeneca: {soloAstra.Count}");
        Console.WriteLine("=====================================");

        // =========================================================================
        // 6. Verificación matemática
        // =========================================================================
        Console.WriteLine("\n=== VERIFICACIÓN MATEMÁTICA ===");
        Console.WriteLine($"Pfizer únicamente: {soloPfizer.Count}");
        Console.WriteLine($"AstraZeneca únicamente: {soloAstra.Count}");
        Console.WriteLine($"Ambas vacunas: {ambasDosis.Count}");
        Console.WriteLine($"Total vacunados calculado: {soloPfizer.Count + soloAstra.Count + ambasDosis.Count}");
        Console.WriteLine($"Total vacunados real: {vacunados.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
        Console.WriteLine($"Total ciudadanos: {noVacunados.Count + vacunados.Count}");

        // =========================================================================
        // 7. Mostrar listados detallados (opcional)
        // =========================================================================
        Console.WriteLine("\n¿Desea ver los listados detallados? (s/n): ");
        var respuesta = Console.ReadLine()?.ToLower();
        
        if (respuesta == "s" || respuesta == "si" || respuesta == "sí")
        {
            MostrarListadosDetallados(noVacunados, ambasDosis, soloPfizer, soloAstra);
        }

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }

    // Método mejorado para generar ciudadanos vacunados de manera aleatoria
    static HashSet<string> GenerarVacunados(HashSet<string> poblacionTotal, int cantidad, int seed)
    {
        HashSet<string> conjunto = new HashSet<string>();
        Random random = new Random(seed * DateTime.Now.Millisecond); // Semilla diferente para cada vacuna
        List<string> listaPoblacion = poblacionTotal.ToList();

        while (conjunto.Count < cantidad)
        {
            int indice = random.Next(0, listaPoblacion.Count);
            conjunto.Add(listaPoblacion[indice]);
        }
        return conjunto;
    }

    // Método para mostrar listados detallados
    static void MostrarListadosDetallados(HashSet<string> noVacunados, HashSet<string> ambasDosis, 
                                        HashSet<string> soloPfizer, HashSet<string> soloAstra)
    {
        Console.WriteLine("\n=== LISTADOS DETALLADOS ===");
        
        Console.WriteLine($"\n-- 1. CIUDADANOS NO VACUNADOS ({noVacunados.Count}) --");
        var noVacunadosOrdenados = noVacunados.OrderBy(x => int.Parse(x.Replace("Ciudadano ", ""))).Take(20);
        foreach (var ciudadano in noVacunadosOrdenados)
        {
            Console.WriteLine($"  • {ciudadano}");
        }
        if (noVacunados.Count > 20)
            Console.WriteLine($"  ... y {noVacunados.Count - 20} más");

        Console.WriteLine($"\n-- 2. CIUDADANOS CON AMBAS DOSIS ({ambasDosis.Count}) --");
        var ambasOrdenados = ambasDosis.OrderBy(x => int.Parse(x.Replace("Ciudadano ", "")));
        foreach (var ciudadano in ambasOrdenados)
        {
            Console.WriteLine($"  • {ciudadano} (Pfizer + AstraZeneca)");
        }

        Console.WriteLine($"\n-- 3. CIUDADANOS SOLO CON PFIZER ({soloPfizer.Count}) --");
        var pfizerOrdenados = soloPfizer.OrderBy(x => int.Parse(x.Replace("Ciudadano ", ""))).Take(15);
        foreach (var ciudadano in pfizerOrdenados)
        {
            Console.WriteLine($"  • {ciudadano}");
        }
        if (soloPfizer.Count > 15)
            Console.WriteLine($"  ... y {soloPfizer.Count - 15} más");

        Console.WriteLine($"\n-- 4. CIUDADANOS SOLO CON ASTRAZENECA ({soloAstra.Count}) --");
        var astraOrdenados = soloAstra.OrderBy(x => int.Parse(x.Replace("Ciudadano ", ""))).Take(15);
        foreach (var ciudadano in astraOrdenados)
        {
            Console.WriteLine($"  • {ciudadano}");
        }
        if (soloAstra.Count > 15)
            Console.WriteLine($"  ... y {soloAstra.Count - 15} más");
    }
}