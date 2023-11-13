using PersonalTVShows.Models.Documents;

namespace PersonalTVShows.Helpers
{
    public static class PdfHelper
    {
        public static PdfList CreatePdfList()
        {
            PdfList PdfList = new()
            {
                new PdfDocument { Index = 1, PdfName = "Murach CSharp", PdfPath = @"" },
                new PdfDocument { Index = 2, PdfName = "Murach Sql", PdfPath = @"" },
                new PdfDocument { Index = 3, PdfName = "Blazor Web Development", PdfPath = @"" }
            };

            return PdfList;
        }
    }
}