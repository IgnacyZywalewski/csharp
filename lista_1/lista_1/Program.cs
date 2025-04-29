class Program
{
    static void Main(string[] args)
    {
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
    }
}
