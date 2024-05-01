using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Tests.ServiceTests.ReadStrategy;

public class PdfReadTests
{
    [Fact]
    public void ReadAsync_ValidPdfFile_Succeeds()
    {
        var (formFile, pdfRead) = SetupMock();

        StringBuilder text = pdfRead.ReadAsync(formFile).Result;

        text.Should().NotBeNull();
    }

    [Fact]
    public void ReadAsync_WhenNullFormFile_NullReferenceException()
    {
        var (_, pdfRead) = SetupMock();

        Func<Task> func = () => pdfRead.ReadAsync(null!);

        func.Should().ThrowAsync<NullReferenceException>();
    }

    private (IFormFile, PdfRead) SetupMock()
    {
        var byteArray = Properties.Resources.Pride_and_Prejudice_by_Jane_Austen_6;

        var stream = new MemoryStream(byteArray);

        var file = new FormFile(stream, 0, stream.Length, null!, "PdfTest");

        return (file, new PdfRead());
    }
}