
using System.Runtime.InteropServices;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            // 2.1.3
            //var songs = new Song[] {
            //    new Song("Let it be", "The Beatles", 243),
            //    new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
            //    new Song("Close To You", "Carpenters", 276),
            //    new Song("Honesty", "Billy Joel", 231),
            //    new Song("I Will Always Love You", "Whitney Houston", 273),
            //};

            Console.WriteLine("**** 曲の登録 ****");

            var songs = new List<Song>();

            while (true) {
                Console.Write("曲名：");
                var title = Console.ReadLine();
                //タイトルにend(大文字、小文字の区別なし)が入力されたらループを抜ける
                if ("end".Equals(title, StringComparison.OrdinalIgnoreCase)) {
                    break;
                }
                Console.Write("アーティスト名：");
                var artistname = Console.ReadLine();
                Console.Write("演奏時間（秒）：");
                var length = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                var song = new Song(title, artistname, length);

                songs.Add(song);
            }

            PrintSongs(songs);
        }

        //2.1.4
        private static void PrintSongs(IEnumerable<Song> songs) {

            foreach (var song in songs) {
                int minute = song.Length / 60;
                int second = song.Length % 60;

                Console.WriteLine($"{song.Title}, {song.ArtistName}, {minute}:{second:00}");
            }
        }
    }
}
