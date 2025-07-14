using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    static void MostrarEstado(Stack<int> torreA, Stack<int> torreB, Stack<int> torreC)
    {
        Console.WriteLine("\nEstado actual de las torres:");
        ImprimirTorre("Torre A", torreA);
        ImprimirTorre("Torre B", torreB);
        ImprimirTorre("Torre C", torreC);
        Console.WriteLine("-----------------------------");
    }

    static void ImprimirTorre(string nombre, Stack<int> torre)
    {
        Console.Write($"{nombre}: ");
        foreach (var disco in torre)
        {
            Console.Write(disco + " ");
        }
        Console.WriteLine();
    }

    static void MoverDiscos(
        int n,
        Stack<int> origen,
        Stack<int> destino,
        Stack<int> auxiliar,
        string nombreOrigen,
        string nombreDestino,
        string nombreAuxiliar,
        Stack<int> torreA,
        Stack<int> torreB,
        Stack<int> torreC)
    {
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            MostrarEstado(torreA, torreB, torreC);
            return;
        }

        MoverDiscos(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino,
                    torreA, torreB, torreC);

        int discoMovido = origen.Pop();
        destino.Push(discoMovido);
        Console.WriteLine($"Mover disco {discoMovido} de {nombreOrigen} a {nombreDestino}");
        MostrarEstado(torreA, torreB, torreC);

        MoverDiscos(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen,
                    torreA, torreB, torreC);
    }

    static void Main()
    {
        Console.Write("Ingrese el número de discos: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 1)
        {
            Console.WriteLine("Número inválido. Intente con un número mayor o igual a 1.");
            return;
        }

        Stack<int> torreA = new Stack<int>();
        Stack<int> torreB = new Stack<int>();
        Stack<int> torreC = new Stack<int>();

        for (int i = n; i >= 1; i--)
        {
            torreA.Push(i);
        }

        Console.WriteLine($"\nResolviendo Torres de Hanoi con {n} discos:\n");
        MostrarEstado(torreA, torreB, torreC);

        MoverDiscos(n, torreA, torreC, torreB, "Torre A", "Torre C", "Torre B",
                    torreA, torreB, torreC);

        Console.WriteLine("\n¡Problema resuelto!");
    }
}

