using System.Net.WebSockets;

namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();

        static void Main(string[] args) {
            string? pref, prefCaptalLocation;

            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + 'Z'】");

            while (true) {
                //①都道府県の入力
                Console.Write("都道府県:");
                pref = Console.ReadLine();

                if (pref == null) break;    //無限ループを抜ける（Ctrl + 'Z'）

                //②県庁所在地の入力
                Console.Write("県庁所在地:");
                prefCaptalLocation = Console.ReadLine();

                //③県庁所在地登録処理
                string? overwrite = null;
                if (prefOfficeDict.ContainsKey(pref)) {
                    Console.WriteLine("上書きしますか?(Y/N)");
                    overwrite = Console.ReadLine();
                }
                if (!prefOfficeDict.ContainsKey(pref) || overwrite == "Y")
                    prefOfficeDict[pref] = prefCaptalLocation;

                Console.WriteLine();
            }

            Console.WriteLine();

            while (true) {
                var menu_number = menuDisp();

                if (menu_number == "1") {
                    allDisp();
                }

                if (menu_number == "2") {
                    searchPrefCaptalLocation();
                }
                if (menu_number == "9") break;

                Console.WriteLine();
            }
        }

        private static string? menuDisp() {
            Console.WriteLine("**** メニュー ****");
            Console.WriteLine("1:一覧表示");
            Console.WriteLine("2:検索");
            Console.WriteLine("9:終了");

            Console.Write(">");
            var menu_number = Console.ReadLine();

            return menu_number;
        }

        private static void allDisp() {
            foreach (var item in prefOfficeDict) {
                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
            }
        }

        private static void searchPrefCaptalLocation() {
            Console.Write("都道府県:");
            var pref_key = Console.ReadLine();
            if (prefOfficeDict.Any(p => p.Key == pref_key)) {
                Console.WriteLine($"{pref_key}の県庁所在地は{prefOfficeDict[pref_key]}です。");
            } else {
                Console.WriteLine("見つかりませんでした");
            }
        }
    }
}
