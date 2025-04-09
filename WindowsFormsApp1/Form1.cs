using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuffmanLib;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private HuffmanEncoder encoder;
        private string loadedText = "";
        private string reportContent = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Loadbutton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    loadedText = File.ReadAllText(ofd.FileName);

                    encoder = new HuffmanEncoder();
                    encoder.AnalyzeText(loadedText);
                    encoder.EncodeText(loadedText);

                    // Получим текст отчета (без записи в файл)
                    using (var sw = new StringWriter())
                    {
                        encoder.SaveReport("temp_output.txt"); // чтобы получить структуру
                        reportContent = File.ReadAllText("temp_output.txt");
                        File.Delete("temp_output.txt");
                    }

                    richTextBox1.Text = reportContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void Savebutton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(reportContent))
            {
                MessageBox.Show("Сначала загрузите файл!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text file (*.txt)|*.txt";
            sfd.FileName = "output.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, reportContent);
                MessageBox.Show("Файл сохранён!");
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            if (encoder == null || encoder.Tree == null)
            {
                MessageBox.Show("Сначала загрузите исходный текст, чтобы построить дерево Хаффмана.");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Title = "Выберите файл с закодированным текстом";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string encodedText = File.ReadAllText(ofd.FileName).Replace("\r", "").Replace("\n", "").Trim();

                    string decoded = encoder.DecodeText(encodedText);

                    // Выводим каждую строку в listBoxDecoded
                    listBoxDecoded.Items.Clear();

                    foreach (string line in decoded.Split('\n'))
                    {
                        listBoxDecoded.Items.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при декодировании: " + ex.Message);
                }
            }
        }
    }
}
