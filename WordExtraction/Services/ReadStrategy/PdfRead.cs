using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace WordExtraction.Services.ReadStrategy;

public class PdfRead : ITypeRead
{
    public StringBuilder Read(IFormFile formFile)
    {
        PdfReader reader = new PdfReader(formFile.OpenReadStream());
        StringBuilder text = new StringBuilder();
        
        for (int page = 1; page <= reader.NumberOfPages; page++)
        {
            text.Append(PdfTextExtractor.GetTextFromPage(reader, page));
        }
        
        reader.Close();
        
        return text;
    }
}