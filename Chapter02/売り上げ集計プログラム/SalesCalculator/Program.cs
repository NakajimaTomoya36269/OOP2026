namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter(@"data\sales.csv");
            var amoutPerStore = sales.GetPerStoreSales();
            foreach (var obj in amoutPerStore) {
                Console.WriteLine($"{obj.Key} {obj.Value}");
            }
        }
    }
}
