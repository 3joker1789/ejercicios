using System;

class Node
{
    public int Data;
    public Node Next;
}

class LinkedList
{
    private Node head;
    private int count;

    public void InsertAtEnd(int data)
    {
        Node newNode = new Node { Data = data };
        if (head == null) head = newNode;
        else
        {
            Node current = head;
            while (current.Next != null) current = current.Next;
            current.Next = newNode;
        }
        count++;
    }

    public void InsertAtBeginning(int data)
    {
        Node newNode = new Node { Data = data, Next = head };
        head = newNode;
        count++;
    }

    public int Count() => count;

    public void Display()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

class Program
{
    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0) return false;
        return true;
    }

    static bool IsArmstrong(int n)
    {
        int sum = 0, temp = n, digits = n.ToString().Length;
        while (temp > 0)
        {
            sum += (int)Math.Pow(temp % 10, digits);
            temp /= 10;
        }
        return sum == n;
    }

    static void Main()
    {
        LinkedList primes = new LinkedList();
        LinkedList armstrongs = new LinkedList();
        Random rand = new Random();

        for (int i = 0; i < 50; i++)
        {
            int num = rand.Next(1, 1000);
            if (IsPrime(num)) primes.InsertAtEnd(num);
            if (IsArmstrong(num)) armstrongs.InsertAtBeginning(num);
        }

        // Resultados
        Console.WriteLine($"Primos: {primes.Count()} elementos");
        Console.WriteLine($"Armstrong: {armstrongs.Count()} elementos");
        
        if (primes.Count() > armstrongs.Count()) 
            Console.WriteLine("Más elementos en lista de primos");
        else if (primes.Count() < armstrongs.Count()) 
            Console.WriteLine("Más elementos en lista de Armstrong");
        else 
            Console.WriteLine("Ambas listas tienen igual cantidad");

        Console.Write("Primos: "); primes.Display();
        Console.Write("Armstrong: "); armstrongs.Display();
    }
}