using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public sealed class Settings {

        private const string FileName = "settings.xml";

        //唯一のSettingオブジェクト
        private static readonly Settings _instance = new Settings();

        //メイン画面に設定した色情報
        public int MainFormBackColor { get; set; }
            = SystemColors.Control.ToArgb();

        //唯一のオブジェクトを取得する
        public static Settings Instance {
            get { return _instance; }
        }

        private Settings() { }

        public void Save() {
            var data = new SettingsData {
                MainFormBackColor = MainFormBackColor
            };

            using var writer = XmlWriter.Create(FileName);
            var serializer = new XmlSerializer(typeof(SettingsData));
            serializer.Serialize(writer, data);
        }
    }

    //XML保存用クラス
    public class SettingsData { 
        public int MainFormBackColor { get; set; }
    }
}
