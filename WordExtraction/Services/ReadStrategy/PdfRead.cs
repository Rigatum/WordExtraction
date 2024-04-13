using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace WordExtraction.Services.ReadStrategy;

public class PdfRead : ITypeRead
{
    public async Task<StringBuilder> ReadAsync(IFormFile formFile)
    {
        return await Task.Run(() =>
        {
            using (var reader = new PdfReader(formFile.OpenReadStream()))
            {
                var text = new StringBuilder();
                var pdfDoc = new PdfDocument(reader);

                for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), new SimpleTextExtractionStrategy()));
                }

                pdfDoc.Close();

                return text;
            }
        });
        
    }
}