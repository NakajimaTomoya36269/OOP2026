using System.Text.RegularExpressions;

namespace Section01 {
    internal class Program {

        static void Main(string[] args) {

            var cities = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            var exists = cities.Exists(s => s.Length >= 6 && s.Contains("o") && s.EndsWith("n"));
            var isexists = cities.Any(c => c.Length >= 6 && c.Contains("o") && c.EndsWith("n"));
            Console.WriteLine(exists);
        }
    }
}
