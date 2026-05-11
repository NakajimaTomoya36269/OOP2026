using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class Song {

        //2.1.2(引数付きコンストラクタ)
        public Song(string title, string artistname, int length) {
            Title = title;
            ArtistName = artistname;
            Length = length;
        }

        //2.1.1
        //プロパティ
        public string Title { get; set; } = string.Empty;

        public string ArtistName { get; set; } = string.Empty;

        public int Length { get; set; }
    }
}
