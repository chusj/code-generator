using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

namespace CodeAndTool
{
    /// <summary>
    /// 
    /// </summary>
    public class WritePdfFile
    {
        public static void Write(string filePath, DataTable dataTable)
        {
            // 创建PDF文档，并关联到指定的输出文件流
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

            // 打开文档
            document.Open();

            // 创建PDF表格
            PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count);
            foreach (DataColumn column in dataTable.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                pdfTable.AddCell(cell);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(row[i].ToString()));
                    pdfTable.AddCell(cell);
                }
            }

            // 将表格添加到文档中
            document.Add(pdfTable);

            // 关闭文档
            document.Close();

        }
    }
}
