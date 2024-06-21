using TesteBenner;

class Program
{
    static void Main()
    {
        try
        {
            Network net = new Network(8);
            net.Connect(1, 2);
            net.Connect(6, 2);
            net.Connect(2, 4);
            net.Connect(5, 7);

            Console.WriteLine(net.Query(1, 6));
            Console.WriteLine(net.Query(6, 4));
            Console.WriteLine(net.Query(7, 4));
            Console.WriteLine(net.Query(5, 6));
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Erro: {e.Message}");
        }
    }
}