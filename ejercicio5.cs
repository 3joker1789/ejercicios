using System;
using System.Collections.Generic;

class Nodo
{
    public int Dato;
    public Nodo Siguiente;

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

class ListaEnlazada
{
    public Nodo Cabeza;
    public int Contador;

    public void InsertarInicio(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        nuevo.Siguiente = Cabeza;
        Cabeza = nuevo;
        Contador++;
    }

    public void InsertarFinal(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        if (Cabeza == null)
        {
            Cabeza = nuevo;
        }
        else
        {
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
        Contador++;
    }

    public List<int> ObtenerElementos()
    {
        List<int> elementos = new List<int>();
        Nodo actual = Cabeza;
        while (actual != null)
        {
            elementos.Add(actual.Dato);
            actual = actual.Siguiente;
        }
        return elementos;
    }
}

class Program
{
    static bool EsPrimo(int numero)
    {
        if (numero < 2) return false;
        for (int i = 2; i <= Math.Sqrt(numero); i++)
        {
            if (numero % i == 0) return false;
        }
        return true;
    }

    static bool EsArmstrong(int numero)
    {
        int original = numero;
        int suma = 0;
        int digitos = numero.ToString().Length;

        while (numero > 0)
        {
            int digito = numero % 10;
            suma += (int)Math.Pow(digito, digitos);
            numero /= 10;
        }

        return suma == original;
    }

    static void Main(string[] args)
    {
        ListaEnlazada listaPrimos = new ListaEnlazada();
        ListaEnlazada listaArmstrong = new ListaEnlazada();

        Console.WriteLine("Ingrese números enteros (uno por línea). Ingrese -1 para terminar:");

        while (true)
        {
            Console.Write("Número: ");
            string entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out int numero))
            {
                Console.WriteLine("Entrada inválida. Intente de nuevo.");
                continue;
            }

            if (numero == -1)
                break;

            if (EsPrimo(numero))
            {
                listaPrimos.InsertarFinal(numero);
            }

            if (EsArmstrong(numero))
            {
                listaArmstrong.InsertarInicio(numero);
            }
        }

        // Mostrar resultados
        Console.WriteLine($"\na. Cantidad de primos: {listaPrimos.Contador}");
        Console.WriteLine($"   Cantidad de Armstrong: {listaArmstrong.Contador}");

        if (listaPrimos.Contador > listaArmstrong.Contador)
            Console.WriteLine("b. La lista de números primos tiene más elementos.");
        else if (listaArmstrong.Contador > listaPrimos.Contador)
            Console.WriteLine("b. La lista de números Armstrong tiene más elementos.");
        else
            Console.WriteLine("b. Ambas listas tienen la misma cantidad de elementos.");

        Console.WriteLine("c. Lista de números primos:");
        foreach (int num in listaPrimos.ObtenerElementos())
            Console.Write(num + " ");

        Console.WriteLine("\n   Lista de números Armstrong:");
        foreach (int num in listaArmstrong.ObtenerElementos())
            Console.Write(num + " ");

        Console.WriteLine("\nFin del programa.");
    }
}
