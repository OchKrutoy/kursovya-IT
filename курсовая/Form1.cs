using System.Text.Encodings.Web;

namespace курсовая
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private HaffmanCode coder = new HaffmanCode();
        private Dictionary<char, int> frequencies;
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            string text = txtInput.Text;
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Введите текст!");
                return;
            }

            // 1. Подсчёт частот
            frequencies = coder.CountFrequencies(text);

            // 2. Построение дерева и кодов
            coder.BuildTree(frequencies);

            // 3. Заполнение таблицы
            var table = coder.BuildTable(frequencies);
            dgvTable.DataSource = null;
            dgvTable.DataSource = table;

            // 4. Статистика
            int bits = coder.GetEncodedSizeBits(frequencies);
            var maxEntry = table.OrderByDescending(x => x.Frequency).First();
            lblStats.Text = $"Объём: {bits} бит ({bits / 8.0:F1} байт)\n" +
                            $"Макс. частота: '{maxEntry.Symbol}' — {maxEntry.Frequency} раз, " +
                    $"длина кода = {maxEntry.CodeLength}";
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            if (coder.Codes == null)
            {
                MessageBox.Show("Сначала выполните анализ!");
                return;
            }
            string encodedBits = coder.Encode(txtInput.Text);
            coder.SaveToBinaryFile(encodedBits, "encoded.bin");
            MessageBox.Show("Файл encoded.bin успешно сохранен!");
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            if (coder.Root == null)
            {
                MessageBox.Show("Сначала выполните анализ (постройте дерево)!");
                return;
            }

            if (!File.Exists("encoded.bin"))
            {
                MessageBox.Show("Файл encoded.bin не найден!");
                return;
            }
            string bitsFromFile = coder.LoadFromBinaryFile("encoded.bin");
            string decodedText = coder.Decode(bitsFromFile);
            File.WriteAllText("decoded.txt", decodedText);
            MessageBox.Show("Файл успешно расшифрован!");
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (dgvTable.DataSource is List<FA> list)
            {
                var sorted = list.OrderByDescending(x => x.Frequency).ToList();
                dgvTable.DataSource = null;
                dgvTable.DataSource = sorted;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Текстовые файлы|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                    txtInput.Text = System.IO.File.ReadAllText(ofd.FileName);
            }
        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) 
            {
                var row = (FA)dgvTable.Rows[e.RowIndex].DataBoundItem;
                frequencies[row.Symbol] = row.Frequency;
                coder.BuildTree(frequencies);
                dgvTable.DataSource = null;
                dgvTable.DataSource = coder.BuildTable(frequencies);
            }
        }
    }
}
