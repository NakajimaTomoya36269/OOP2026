namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter(@"data\sales.csv");
            Dictionary<string, int> amoutPerStore = sales.GetPerStoreSales();
            foreach (KeyValuePair<string, int> obj in amoutPerStore) {
                Console.WriteLine($"{obj.Key} {obj.Value}");
            }
        }
    }
}
