public class Program
{
    public static void Main()
    {
        var input = Int32.Parse(Console.ReadLine());

        while (input != 42)
        {
            Console.WriteLine(input);
            input = Int32.Parse(Console.ReadLine());
        }
    }
}