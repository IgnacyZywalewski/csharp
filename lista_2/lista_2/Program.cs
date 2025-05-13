using System.Security.Cryptography;
using System.Collections.Generic;

class Program
{
    class Lista
    {
        protected List<int> liczby = [];

        public Lista()
        {
            Random random = new();
            int zakres = random.Next(1, 6);

            for (int i = 0; i < zakres; i++)
            {
                liczby.Add(random.Next(1, 101));
            }
        }

        public Lista(int n)
        {
            Random random = new();
            for(int i = 0; i < n; i++)
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
            if(other == null) return 1;
            
            int max_len = Math.Max(this.liczby.Count, other.liczby.Count);

            for (int i = 0; i < max_len; i++)
            {
                int a = (i < this.liczby.Count) ? this.liczby[i] : int.MinValue;
                int b = (i < other.liczby.Count) ? other.liczby[i] : int.MinValue;

                if (a != b) return a.CompareTo(b);
            }

            return 0;
        }
    }

    class Lista2 : Lista, IComparable<Lista2> 
    {
        public int CompareTo(Lista2? other)
        {
            if (other == null) return 1;

            if(this.liczby.Count != other.liczby.Count) 
            {
                return this.liczby.Count.CompareTo(other.liczby.Count);
            }

            for(int i = 0; i < this.liczby.Count; i++)
            {
                if (this.liczby[i] != other.liczby[i])
                {
                    return this.liczby[i].CompareTo(other.liczby[i]);
                }
            }

            return 0;
        }
    }

    static void Main()
    {
        //Zadanie 1
        Lista lista_1 = new Lista(10);
        Console.Write("lista 1: {0}\n", lista_1.ToString());
        Lista lista_2 = new Lista();
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

    } 
}