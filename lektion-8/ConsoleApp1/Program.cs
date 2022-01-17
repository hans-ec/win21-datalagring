namespace ConsoleApp1
{
    public class Program
    {
        private static string filePath = @"c:\documents";

        public static async Task Main()
        {
            var result = await Task.Run(() => GetValue(filePath));
            Console.WriteLine(result);
        }

        public static string GetValue(string filePath)
        {
            Console.WriteLine(filePath);
            return "hejsan";
        }
    }
}





