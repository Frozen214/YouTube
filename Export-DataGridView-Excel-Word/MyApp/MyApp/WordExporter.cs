using Microsoft.Office.Interop.Word;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MyApp
{
    public class WordExporter
    {
        public void WordExport(DataGridView myGrid)
        {
            if (myGrid == null || myGrid.Rows.Count <= 0)
            {
                MessageBox.Show("Данные для экспорта не обнаружены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;
            var wordDoc = wordApp.Documents.Add();

            try
            {
                InsertDataWord(wordDoc, myGrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Marshal.ReleaseComObject(wordDoc);
                Marshal.ReleaseComObject(wordApp);
            }
        }
        private void InsertDataWord(Document doc, DataGridView dgv)
        {
            var table = doc.Tables.Add(doc.Range(), dgv.Rows.Count + 1, dgv.Columns.Count);

            for (int j = 0; j < dgv.Columns.Count; j++)
            {
                table.Rows[1].Cells[j + 1].Range.Text = dgv.Columns[j].HeaderText;
            }

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv[j, i].Value != null)
                    {
                        table.Rows[i + 2].Cells[j + 1].Range.Text = dgv[j, i].Value.ToString();
                    }
                }
            }

            table.Rows[1].Range.Font.Bold = 1;
            table.Rows[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            table.Range.ParagraphFormat.SpaceAfter = 6;
            table.Borders.Enable = 1;
        }
    }
}
