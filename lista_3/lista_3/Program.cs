using System;
using System.Collections.Generic;
using System.Linq;

class Obserwator
{
    public string Nazwa { get; }
    public double X { get; }
    public double Y { get; }
    public Obserwator(string nazwa, double x, double y)
    {
        Nazwa = nazwa;
        X = x;
        Y = y;
    }
    private record Sasiad(string Nazwa, double X, double Y, double Odleglosc);
    private List<Sasiad> sasiedzi = new();
    public void Nowy(object? sender, Obserwator nowy)
    {
        if (nowy == this) return;

        double odl = Math.Sqrt(Math.Pow(X - nowy.X, 2) + Math.Pow(Y - nowy.Y, 2));
        sasiedzi.Add(new Sasiad(nowy.Nazwa, nowy.X, nowy.Y, odl));

        sasiedzi = sasiedzi.OrderBy(s => s.Odleglosc).Take(2).ToList();
    }
    public void Wypisz(object? sender, EventArgs e)
    {
        Console.WriteLine($"Jestem {Nazwa} – lista sąsiadów:");
        foreach (var s in sasiedzi)
        {
            Console.WriteLine($" {s.Nazwa} x={s.X:0.###} y={s.Y:0.###} odl={s.Odleglosc:0.###}");
        }
    }
}

class Tworca
{
    private Random rand = new();
    private List<Obserwator> obserwatorzy = new();

    public event EventHandler<Obserwator>? NowyObsZdarzenie;
    public event EventHandler? WypiszObsZdarzenie;

    public void StworzObserwatora(string nazwa)
    {
        double x = rand.NextDouble();
        double y = rand.NextDouble();
        var nowyObs = new Obserwator(nazwa, x, y);

        NowyObsZdarzenie += nowyObs.Nowy;
        WypiszObsZdarzenie += nowyObs.Wypisz;

        obserwatorzy.Add(nowyObs);

        NowyObsZdarzenie?.Invoke(this, nowyObs);
    }
    public void WypiszWszystkich()
    {
        WypiszObsZdarzenie?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main()
    {
        Tworca tworca = new();

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"\n--------------------krok {i}-------------------");
            tworca.StworzObserwatora($"Obs {i}");
            tworca.WypiszWszystkich();
        }
    }
}
