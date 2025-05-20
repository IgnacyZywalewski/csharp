class Obserwator
{
    public string Nazwa { get; }
    public double X { get; }
    public double Y { get; }
    private record Sasiad(string Nazwa, double X, double Y, double Odleglosc);

    private List<Sasiad> sasiedzi = new();

    public Obserwator(string nazwa, double x, double y)
    {
        Nazwa = nazwa;
        X = x;
        Y = y;
    }
    public void NowyObserwator(object? sender, Obserwator nowy)
    {
        if (nowy == this) return;

        double odl = ObliczOdleglosc(nowy);
        sasiedzi.Add(new Sasiad(nowy.Nazwa, nowy.X, nowy.Y, odl));

        sasiedzi = sasiedzi.OrderBy(s => s.Odleglosc).Take(2).ToList();
    }

    public void Wypisz()
    {
        Console.WriteLine($"Jestem {Nazwa} – lista sąsiadów:");
        foreach (Sasiad s in sasiedzi)
        {
            Console.WriteLine($" {s.Nazwa} x = {s.X:0.###} y = {s.Y:0.###} odl = {s.Odleglosc:0.###}");
        }
    }

    private double ObliczOdleglosc(Obserwator inny)
    {
        return Math.Sqrt(Math.Pow(X - inny.X, 2) + Math.Pow(Y - inny.Y, 2));
    }
}


class Tworca
{
    private Random rand = new();
    private List<Obserwator> obserwatorzy = new();

    public event EventHandler<Obserwator>? NowyObserwatorUtworzony;

    public void StworzObserwatora(string nazwa)
    {
        double x = rand.NextDouble();
        double y = rand.NextDouble();

        var nowy = new Obserwator(nazwa, x, y);
        
        NowyObserwatorUtworzony += nowy.NowyObserwator;
        NowyObserwatorUtworzony?.Invoke(this, nowy);
        obserwatorzy.Add(nowy);
    }

    public void WypiszWszystkich()
    {
        foreach (Obserwator obs in obserwatorzy)
        {
            obs.Wypisz();
        }
    }
}


class Program
{
    static void Main()
    {
        Tworca tworca = new Tworca();

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"\n--------------------krok {i}-------------------");
            tworca.StworzObserwatora($"Obs {i}");
            tworca.WypiszWszystkich();
        }
    }
}