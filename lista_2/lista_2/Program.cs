using System.Security.Cryptography;
using System.Collections.Generic;
using System;


//Zadanie 1
class Lista
{
    protected List<int> liczby = [];
    private static Random random = new();

    public Lista()
    {
        int zakres = random.Next(1, 6);
        for (int i = 0; i < zakres; i++)
        {
            liczby.Add(random.Next(1, 101));
        }
    }

    public Lista(int n)
    {
        for (int i = 0; i < n; i++)
        {
            liczby.Add(random.Next(1, 101));
        }
    }

    public override string ToString()
    {
        return "{" + string.Join(", ", liczby) + "}";
    }
}

class Lista1 : Lista, IComparable<Lista1>
{
    public int CompareTo(Lista1? other)
    {
        if (other == null) return 1;

        int min_len = Math.Min(this.liczby.Count, other.liczby.Count);

        for (int i = 0; i < min_len; i++)
        {
            int a = this.liczby[i];
            int b = other.liczby[i];
            if (a != b) return a.CompareTo(b);
        }

        return this.liczby.Count.CompareTo(other.liczby.Count);
    }
}

class Lista2 : Lista, IComparable<Lista2>
{
    public int CompareTo(Lista2? other)
    {
        if (other == null) return 1;

        if (this.liczby.Count != other.liczby.Count)
        {
            return this.liczby.Count.CompareTo(other.liczby.Count);
        }

        for (int i = 0; i < this.liczby.Count; i++)
        {
            if (this.liczby[i] != other.liczby[i])
            {
                return this.liczby[i].CompareTo(other.liczby[i]);
            }
        }

        return 0;
    }
}


//Zadanie 2
class PlanLekcji
{
    private string[][] plan;

    public PlanLekcji()
    {
        plan = new string[5][];

        plan[0] = new string[] { "Algorytmy i struktury danych", "Modelowanie komputerowe" };
        plan[1] = new string[] { "Bazy danych", "Podstawy przedsiębiorczości", "Języki programowania i GIU" };
        plan[2] = new string[] { };
        plan[3] = new string[] { "Projekt aplikacji mobilnej" };
        plan[4] = new string[] { "Pracownia pomiarów i sterowania" };
    }

    public void PrintPlan()
    {
        string[] dni = { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek" };
        Console.WriteLine("Plan zajęć: ");

        for (int i = 0; i < plan.Length; i++)
        {
            Console.WriteLine("{0}: ", dni[i]);

            if (plan[i].Length == 0) { Console.WriteLine(" - Brak zajęć"); }

            for (int j = 0; j < plan[i].Length; j++)
            {
                Console.WriteLine(" - {0}", plan[i][j]); 
            }

            Console.WriteLine();
        }
    }

}

class Program
{
    static void Main()
    {
        //Zadanie 1
        Lista lista_1 = new(10);
        Console.Write("lista 1: {0}\n", lista_1.ToString());
        Lista lista_2 = new();
        Console.Write("lista 2: {0}\n\n", lista_2.ToString());

        //lista 1
        Console.WriteLine("Lista 1:");
        List<Lista1> kolekcja_1 = new();
        for(int i = 0; i < 5; i++)
        {
            kolekcja_1.Add(new Lista1());
        }

        Console.WriteLine("Przed sortowaniem: ");
        kolekcja_1.ForEach(lista => Console.WriteLine(lista.ToString()));

        kolekcja_1.Sort();

        Console.WriteLine("\nPo sortowaniu: ");
        kolekcja_1.ForEach(lista => Console.WriteLine(lista.ToString()));


        //lista 2
        Console.WriteLine("\nLista 2:");
        List<Lista2> kolekcja_2 = new();
        for (int i = 0; i < 5; i++)
        {
            kolekcja_2.Add(new Lista2());
        }

        Console.WriteLine("Przed sortowaniem: ");
        kolekcja_2.ForEach(lista => Console.WriteLine(lista.ToString()));

        kolekcja_2.Sort();

        Console.WriteLine("\nPo sortowaniu: ");
        kolekcja_2.ForEach(lista => Console.WriteLine(lista.ToString()));


        //Zadanie 2
        Console.WriteLine();
        PlanLekcji plan = new();
        plan.PrintPlan();

    } 
}