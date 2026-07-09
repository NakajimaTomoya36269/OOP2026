using System.Globalization;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            DateTime date = dtpDate.Value;
            tbOut.Text = date.AddDays((double)nudDay.Value).ToString();
        }

        private void btBirthCalc_Click(object sender, EventArgs e) {
            DateTime birth = dtpBirth.Value;
            DateTime today = DateTime.Today;

            //int age = today.Year - birth.Year;
            //if(today < birth.AddYears(age)) {
            //    age--;
            //}

            tbOut.Text = $"‚ ‚È‚½‚Í{GetAge(birth, today)}Î‚Å‚·";
            TimeSpan ts = today.Date - birth.Date;
            tbOut2.Text = $"¶‚Ü‚ê‚Ä‚©‚ç{ts.Days}“ú–Ú‚Å‚·";

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(birth.DayOfWeek);

            tbOut3.Text = $"¶‚Ü‚ê‚½{birth.Month}ŒŽ{birth.Day}“ú‚Í‘æ{NthWeek(birth)}T‚Ì{birth.ToString("dddd")}‚Å‚·";

            if (GetNextBirth(birth, today) == 0) {
                tbOut4.Text = "’a¶“ú‚Í¡“ú‚Å‚·";
            } else {
                tbOut4.Text = $"ŽŸ‚Ì’a¶“ú‚Ü‚Å{GetNextBirth(birth, today)}“ú‚Å‚·";
            }
        }
        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }
        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }
        static int GetNextBirth(DateTime birth, DateTime today) {
            DateTime nextBirth;

            if (today.Month < birth.Month || (today.Month == birth.Month && today.Day <= birth.Day)) {
                nextBirth = new DateTime(today.Year, birth.Month, birth.Day);
            } else {
                nextBirth = new DateTime(today.Year + 1, birth.Month, birth.Day);
            }
            return (nextBirth.Date - today.Date).Days;
        }
    }
}
