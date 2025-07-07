using System;

class Nodo
{
    public int Valor;           // Dato almacenado en el nodo
    public Nodo Siguiente;      // Referencia al siguiente nodo

    // Constructor que inicializa el nodo con un valor
    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

// Clase ListaEnlazada: gestiona la lista enlazada manualmente 
class ListaEnlazada
{
    public Nodo Cabeza;                 // Nodo inicial de la lista (el primer nodo) 

    // Constructor: inicializa la lista vacía
    public ListaEnlazada()
    {
        Cabeza = null;
    }

    // Método para agregar un nuevo nodo al final de la lista
    public void Agregar(int valor)
    {
        Nodo nuevo = new Nodo(valor);   // Crear un nuevo nodo con el valor dado

        if (Cabeza == null)
        {
            // Si la lista está vacía, el nuevo nodo se convierte en la cabeza
            Cabeza = nuevo;
        }
        else
        {
            // Si la lista ya tiene elementos, recorrer hasta el último nodo
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente; // Avanzar al siguiente nodo
            }
            // Enlazar el último nodo con el nuevo nodo
            actual.Siguiente = nuevo;
        }
    }

    // Método que calcula la longitud de la lista recorriéndola nodo por nodo
    public int CalcularLongitud()
    {
        int contador = 0;               // Contador de nodos
        Nodo actual = Cabeza;           // Empezamos desde la cabeza de la lista

        while (actual != null)
        {
            contador++;                 // Contamos el nodo actual
            actual = actual.Siguiente;  // Avanzamos al siguiente nodo
        }

        return contador;                // Retornamos la cantidad total de nodos
    }

    // Método para imprimir en consola la lista
    public void Mostrar()
    {
        Nodo actual = Cabeza;

        Console.Write("head --> ");
        while (actual != null)
        {
            Console.Write($"[ {actual.Valor} | * ] --> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null\n");
    }
}

// Programa principal para probar la lista
class Programa
{
    static void Main()
    {
        ListaEnlazada lista = new ListaEnlazada();

        lista.Agregar(10);
        lista.Agregar(20);
        lista.Agregar(30);
        lista.Agregar(40);

        lista.Mostrar();

        int longitud = lista.CalcularLongitud();
        Console.WriteLine($"La longitud de la lista es: {longitud}");
    }
}
 