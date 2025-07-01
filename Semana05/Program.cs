using System;
using System.Collections.Generic;
using System.Linq;

class Programa
{
    static void Main()
    {
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("==== MENÚ DE OPCIONES ====");
            Console.WriteLine("1. Mostrar asignaturas de un curso");
            Console.WriteLine("2. Números ganadores de la lotería primitiva");
            Console.WriteLine("3. Mostrar números del 1 al 10 en orden inverso");
            Console.WriteLine("4. Mostrar abecedario eliminando múltiplos de 3");
            Console.WriteLine("5. Verificar si una palabra es un palíndromo");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

        } while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 5);

        Console.Clear();

        switch (opcion)
        {
            case 1:
                MostrarAsignaturas();
                break;
            case 2:
                NumerosLoteria();
                break;
            case 3:
                InversoNumeros();
                break;
            case 4:
                AbecedarioFiltrado();
                break;
            case 5:
                VerificarPalindromo();
                break;
            case 0:
                Console.WriteLine("Programa finalizado.");
                break;
        }

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    static void MostrarAsignaturas()
    {
        List<string> asignaturas = new List<string> { "Matemáticas", "ofimatica", "Química", "Historia", "Lengua" };
        Console.WriteLine("Asignaturas del curso:");
        foreach (string a in asignaturas)
        {
            Console.WriteLine("- " + a);
        }
    }

    static void NumerosLoteria()
    {
        List<int> numerosGanadores = new List<int>();
        Console.WriteLine("Ingrese los 6 números ganadores de la lotería primitiva (entre 1 y 49):");

        for (int i = 1; i <= 6; i++)
        {
            Console.Write($"Número {i}: ");
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero) || numero < 1 || numero > 49 || numerosGanadores.Contains(numero))
            {
                Console.Write("Entrada inválida. Ingrese un número único entre 1 y 49: ");
            }
            numerosGanadores.Add(numero);
        }

        numerosGanadores.Sort();
        Console.WriteLine("Números ganadores ordenados:");
        Console.WriteLine(string.Join(", ", numerosGanadores));
    }

    static void InversoNumeros()
    {
        List<int> numeros = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i);
        }

        numeros.Reverse();
        Console.WriteLine("Números del 1 al 10 en orden inverso:");
        Console.WriteLine(string.Join(", ", numeros));
    }

    static void AbecedarioFiltrado()
    {
        List<char> abecedario = new List<char>();
        for (char letra = 'A'; letra <= 'Z'; letra++)
        {
            abecedario.Add(letra);
        }

        List<char> resultado = new List<char>();
        for (int i = 0; i < abecedario.Count; i++)
        {
            if ((i + 1) % 3 != 0)
            {
                resultado.Add(abecedario[i]);
            }
        }

        Console.WriteLine("Abecedario sin letras en posiciones múltiplos de 3:");
        Console.WriteLine(string.Join(", ", resultado));
    }

    static void VerificarPalindromo()
    {
        Console.Write("Ingrese una palabra: ");
        string palabra = Console.ReadLine().ToLower().Replace(" ", "");

        string invertida = new string(palabra.Reverse().ToArray());

        if (palabra == invertida)
        {
            Console.WriteLine("La palabra es un palíndromo.");
        }
        else
        {
            Console.WriteLine("La palabra NO es un palíndromo.");
        }
    }
}
