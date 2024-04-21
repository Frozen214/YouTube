using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using Document = Microsoft.Office.Interop.Word.Document;

namespace PurchaseReceiptAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string inputFilePath = $@"{System.Windows.Forms.Application.StartupPath}\Receipt\Example.docx";
            string outputFilePath = $@"{System.Windows.Forms.Application.StartupPath}\Receipt\receipt {DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss")}.pdf";

            var replacements = new System.Collections.Generic.Dictionary<string, string>
            {
             { "<Num>", "465837" },
             { "<Cashier>", "Eва Эльфи" },
             { "<InfoService1>", "Молоко домашнее" },  { "<Quantity1>", "2шт." },  { "<Cost1>", "150руб." },
             { "<InfoService2>", "Колбаса варенка" },  { "<Quantity2>", "3шт." },  { "<Cost2>", "550руб." },
             { "<InfoService3>", "Мука" },              { "<Quantity3>", "1шт." },  { "<Cost3>", "90руб." },
             { "<NumFD>", "77237" },  {  "<NumFP>", "37558" },
             { "<NumCash>", "12" },  { "<NumСoming>", "П-30-61" },
             { "<NDS>", "18" },
             { "<DateTime>", $"{DateTime.Now.ToString("dd.mm.yyyy hh.mm.ss")}" },
             { "<Sum>", "800" },
            };
            if (ReplaceTags(inputFilePath, outputFilePath, replacements) == true)
            {
                MessageBox.Show("Чек успешно сформирован.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static bool ReplaceTags(string inputFilePath, string outputFilePath, System.Collections.Generic.Dictionary<string, string> replacements)
        {
            Application wordApp = new Application();

            try
            {
                Document doc = wordApp.Documents.Open(inputFilePath, ReadOnly: true);

                Range range = doc.Content;
                Document newDoc = wordApp.Documents.Add();
                range.Copy();
                newDoc.Range().Paste();

                foreach (var replacement in replacements)
                {
                    newDoc.Content.Find.Execute(FindText: replacement.Key, ReplaceWith: replacement.Value, Replace: WdReplace.wdReplaceAll);
                }

                newDoc.SaveAs2(outputFilePath, WdSaveFormat.wdFormatPDF);
                newDoc.Close(SaveChanges: false);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при формировании чека: " + ex.Message, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            finally
            {
                wordApp.Quit();
            }
        }
    }
}