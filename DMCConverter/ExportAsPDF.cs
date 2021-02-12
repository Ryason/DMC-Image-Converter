using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DMCConverter
{
    public class ExportAsPDF
    {
        public void Create(string imagePath)
        {
            PdfDocument document = new PdfDocument();

            document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(document.Pages[0]);

            XImage image = XImage.FromFile(imagePath);

            gfx.DrawImage(image, 0,0);
            
            string filename = "test.pdf";

            document.Save(filename);

            //openms the pdf for the user
            Process.Start("test.pdf");
        }
    }
}
