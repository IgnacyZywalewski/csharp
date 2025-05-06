class Program
{
    class Integer
    {
        public Integer(int new_counter, int new_value)
        {
            get_counter_limit = new_counter;
            set_counter_limit = new_counter;
            _value = new_value;
        }

        public int Value
        {
            get 
            {
                if (get_counter < get_counter_limit)
                {
                    get_counter++;
                    return _value;
                }
                else
                {
                    Console.WriteLine("Przekroczono limit pobierania wartosc");
                    return -1;
                }
                    
            }

            set 
            {
                if (set_counter < set_counter_limit)
                {
                    set_counter++;
                    _value = value;
                }
                else
                {
                    Console.WriteLine("Przekroczono limit nadawania wartosc");
                }
            }
        }

        public void Ureguluj()
        {
            get_counter = 0;
            set_counter = 0;
        }

        public void WypiszStan()
        {
            Console.WriteLine("Licznik pobierania wartości: {0}. Licznik nadawania wartości {1}\n", get_counter, set_counter);
        }


        private int _value = 0;
        private int get_counter_limit = 0;
        private int set_counter_limit = 0;
        private int get_counter = 0;
        private int set_counter = 0;
    }


    static void Main(string[] args)
    {
        //Zadanie 1
        int input = 0;

        while (true)
        {
            Console.WriteLine("Podaj liczbe naturalna: ");
            input = int.Parse(Console.ReadLine());
            if (input < 0)
            {
                Console.Write("Podana przez ciebie liczba {0} nie jest naturala\nSprobuj ponownie\n\n", input);
            }

            else
            {
                break;
            }
        }

        int width = 5;
        Console.Write("".PadLeft(width));
        for (int i = 1; i <= input; i++)
        {
            Console.Write(i.ToString().PadLeft(width));
        }
        Console.WriteLine();

        for (int i = 1; i <= input; i++)
        {
            Console.Write(i.ToString().PadLeft(width));
            for (int j = 1; j <= input; j++)
            {
                int product = i * j;
                Console.Write(product.ToString().PadLeft(width));
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        //Zadanie 2
        Integer integer = new Integer(5, 10);
        integer.WypiszStan();
        Console.WriteLine("Aktualna wartość: {0}", integer.Value);
        integer.Value = 5;
        Console.WriteLine("Zmiana wartości: {0}", integer.Value);
        integer.WypiszStan();
        integer.Ureguluj();
        Console.WriteLine("Po resecie liczników:");
        integer.WypiszStan();
    }
}
