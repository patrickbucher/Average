
public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("usage: {0} [mean/median/mode] [file]", System.AppDomain.CurrentDomain.FriendlyName);
            System.Environment.Exit(1);
        }
        Console.WriteLine("Hello, World!");
    }
}
