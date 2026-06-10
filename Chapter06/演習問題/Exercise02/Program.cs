namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("整数文字列：");
            var str = Console.ReadLine();

            if(int.TryParse(str, out int num)) {
                Console.WriteLine(string.Format("{0,10:#,0}", num));
            } else {
                Console.WriteLine("整数文字列でありません");
            }
        }
    }
}
