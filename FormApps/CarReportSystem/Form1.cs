using System.ComponentModel;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用クラス
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        private readonly CarReportRepository _repository = new();

        //Settings settings = Settings.Instance;

        public Form1() {
            InitializeComponent();
            dgvRecords.AutoGenerateColumns = true;
            dgvRecords.DataSource = listCarReports;
            ReloadCarReports();
            tsslbMessage.Text = $"DB: {Database.FilePath}";
        }

        private void Form1_Load(object sender, EventArgs e) {

            try {
                Settings.Instance.Load();
                BackColor = Color.FromArgb(Settings.Instance.MainFormBackColor);
            }
            catch (Exception ex) {
                tsslbMessage.Text = "設定ファイル読み込みエラー";
                MessageBox.Show(ex.Message);
            }
        }

        //追加ボタン
        private void btAddRecord_Click(object sender, EventArgs e) {

            //入力値が不正なら処理を終了する
            if (!TryGetInput(out DateTime date, out string author, out CarReport.MakerGroup maker,
                    out string carName, out string report, out Image? picture)) {
                return;
            }

            try {
                _repository.Add(date, author, maker, carName, report, picture);
                ReloadCarReports();
                SetCbAuthor(author.Trim());
                SetCbCarName(carName.Trim());
                InputItemsUpdate();

                tsslbMessage.Text = "レポートを登録しました。";
            }
            catch (Exception ex) {
                tsslbMessage.Text = "登録エラー";
                MessageBox.Show(ex.Message);
            }
        }

        private MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return MakerGroup.日産;
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
            if (rbImport.Checked)
                return MakerGroup.輸入者;

            return MakerGroup.その他;
        }

        private void btOpenPicture_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btNewInput_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = String.Empty;
            rbOther.Checked = true;
            cbCarName.Text = String.Empty;
            tbReport.Text = String.Empty;
            pbPicture.Image = null;

            dgvRecords.ClearSelection();    //セルの選択を削除する
        }

        private void SetRadioButtonMaker(MakerGroup targetMaker) {

            switch (targetMaker) {
                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.輸入者:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }

        //記録者の入力履歴をコンボボックスへ登録（重複なし）
        private void SetCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }

        //車名の入力履歴をコンボボックスへ登録（重複なし）
        private void SetCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btDeleteRecord_Click(object sender, EventArgs e) {

            if (dgvRecords.CurrentRow is null || !dgvRecords.CurrentRow.Selected) return;

            if (dgvRecords.CurrentRow?.DataBoundItem is not CarReport selectedCarReport) {
                tsslbMessage.Text = "削除するレポートを選択してください";
                return;
            }

            if (MessageBox.Show(
                $"「{selectedCarReport.CarName}」を削除しますか？",
                "削除確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) {
                return;
            }

            try {
                _repository.Delete(selectedCarReport.Id);

                ReloadCarReports();
                InputItemsUpdate();

                tsslbMessage.Text = "レポートを削除しました。";
            }
            catch (Exception ex) {
                tsslbMessage.Text = "削除エラー";
                MessageBox.Show(ex.Message);
            }
        }

        private void InputItemsUpdate() {
            if (dgvRecords.CurrentRow is null || !dgvRecords.CurrentRow.Selected)
                InputItemsAllClear();
        }

        private void btModifyRecord_Click(object sender, EventArgs e) {
            if (dgvRecords.SelectedRows.Count == 0) {
                tsslbMessage.Text = "修正するレポートを選択してください";
                return;
            }

            //記録者と車名が未入力だった場合は追加しない
            if (String.IsNullOrWhiteSpace(cbAuthor.Text) || String.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            if (dgvRecords.CurrentRow?.DataBoundItem is not CarReport selectedCarReport) {
                tsslbMessage.Text = "修正するレポートを選択してください";
                return;
            }

            //入力値が不正なら処理を終了する
            if (!TryGetInput(out DateTime date, out string author, out CarReport.MakerGroup maker,
                    out string carName, out string report, out Image? picture)) {
                return;
            }

            try {
                //選択中の商品のオブジェクトのデータを更新する
                selectedCarReport.Date = date;
                selectedCarReport.Author = author;
                selectedCarReport.Maker = maker;
                selectedCarReport.CarName = carName;
                selectedCarReport.Report = report;
                selectedCarReport.Picture = picture;

                _repository.Update(selectedCarReport);

                SetCbAuthor(selectedCarReport.Author.Trim());
                SetCbCarName(selectedCarReport.CarName.Trim());

                ReloadCarReports();
                InputItemsUpdate();

                tsslbMessage.Text = "レポートを修正しました。";
            }
            catch (Exception ex) {
                tsslbMessage.Text = "修正エラー";
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e) {
            if (dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport || !dgvRecords.CurrentRow.Selected) return;

            dtpDate.Value = carReport.Date;
            cbAuthor.Text = carReport.Author;
            SetRadioButtonMaker(carReport.Maker);
            cbCarName.Text = carReport.CarName;
            tbReport.Text = carReport.Report;
            pbPicture.Image = carReport.Picture;

            InputItemsUpdate();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK)
                BackColor = cdColor.Color;

            Settings.Instance.MainFormBackColor = cdColor.Color.ToArgb();
        }

        //フォームが閉じたら呼ばれるイベントハンドラ
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            Settings.Instance.Save();
        }

        private void ReloadCarReports() {
            listCarReports.Clear();
            foreach (var report in _repository.GetAll()) {
                listCarReports.Add(report);
            }
            dgvRecords.ClearSelection();
        }

        private bool TryGetInput(out DateTime date, out string author, out CarReport.MakerGroup maker,
                                    out string carName, out string report, out Image? picture) {

            date = dtpDate.Value.Date;
            author = cbAuthor.Text.Trim();
            maker = GetRadioButtonMaker();
            carName = cbCarName.Text.Trim();
            report = tbReport.Text;
            picture = pbPicture.Image;

            if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(carName)) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return false;
            }
            return true;
        }
    }
}
