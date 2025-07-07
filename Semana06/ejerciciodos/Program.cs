using System;

// Clase Nodo: representa un nodo en la lista enlazada
class Nodo
{
    public int Valor;           // Valor almacenado en el nodo
    public Nodo Siguiente;      // Referencia al siguiente nodo

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

// Clase ListaEnlazada: gestiona operaciones sobre la lista
class ListaEnlazada
{
    private Nodo cabeza;   // Primer nodo de la lista

    public ListaEnlazada()
    {
        cabeza = null;
    }

    // Agrega un nuevo nodo al final de la lista
    public void Agregar(int valor)
    {
        Nodo nuevo = new Nodo(valor);

        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
    }

    // Retorna la cantidad de nodos en la lista
    public int CalcularLongitud()
    {
        int contador = 0;
        Nodo actual = cabeza;

        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }

        return contador;
    }

    // Muestra el contenido de la lista
    public void Mostrar()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = cabeza;
        Console.Write("head --> ");

        while (actual != null)
        {
            Console.Write($"[ {actual.Valor} | * ] --> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null\n");
    }

    // Invierte la lista enlazada (cambia el orden de los nodos)
    public void Invertir()
    {
        Nodo anterior = null;
        Nodo actual = cabeza;
        Nodo siguiente = null;

        while (actual != null)
        {
            siguiente = actual.Siguiente;   // Guarda el siguiente nodo
            actual.Siguiente = anterior;    // Invierte el enlace
            anterior = actual;              // Avanza 'anterior'
            actual = siguiente;             // Avanza 'actual'
        }

        cabeza = anterior; // El último nodo se convierte en la nueva cabeza
    }
}

// Programa principal de prueba
class Programa
{
    static void Main()
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Agregar elementos a la lista
        lista.Agregar(10);
        lista.Agregar(20);
        lista.Agregar(30);
        lista.Agregar(40);

        Console.WriteLine("Lista original:");
        lista.Mostrar();

        // Invertir la lista
        lista.Invertir();
        Console.WriteLine("Lista invertida:");
        lista.Mostrar();

        // Mostrar longitud
        Console.WriteLine($"Longitud de la lista: {lista.CalcularLongitud()}");
    }
}
