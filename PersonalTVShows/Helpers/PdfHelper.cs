using PersonalTVShows.Models.Documents;

namespace PersonalTVShows.Helpers
{
    public static class PdfHelper
    {
        public static PdfList CreatePdfList(string baseLink)
        {
            PdfList PdfList = new()
            {
                new PdfDocument { Index = 1, PdfName = "Murach CSharp", PdfPath = @"" },
                new PdfDocument { Index = 2, PdfName = "Murach Sql", PdfPath = @$"{baseLink}/files/Murach SQL Server 2016.pdf" },
                new PdfDocument { Index = 3, PdfName = "Blazor Web Development", PdfPath = @"" }
            };

            return PdfList;
        }
    }
}