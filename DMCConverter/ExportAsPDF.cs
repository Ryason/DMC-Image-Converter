using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DMCConverter
{
    public class ExportAsPDF
    {
        public void Create(Image image, string[,] dmcGrid)
        {
            Dictionary<string, string> dmcToShortText = new Dictionary<string, string>();
            

            PdfDocument document = new PdfDocument();

            int wOffset = 10;
            int hOffset = 5;

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


            //
            //gfx.DrawString($"{i}{j}", font, brush, i * 40, j * 40);
            //

            //Create multiple pages to fit an entire conversion prjoect on
            ///first need to break up the image, using the DMCgridarray's width and height.
            ///then calculate how many pages it needs by breaking it up into chunks of a set width and height
            ///create a page for each chunk using a set of starting co-ordinates that reference the DMCgrid

            //starting by assigning each dmc value an id
            //assemble the dictionary of dmc values and assign them a short text code



            #region Assign DMC values a short text code

            //sets how wide the grid is on the page
            int gridsize = 15;
            
            //stores what letters are accessed when creating the dict of dmc codes
            int xyzID = 0;
            int numID = 0;

            for (int i = 0; i < dmcGrid.GetLength(0); i++)
            {
                for (int j = 0; j < dmcGrid.GetLength(1); j++)
                {
                    if (!dmcToShortText.ContainsKey(dmcGrid[i,j]))
                    {
                        dmcToShortText.Add(dmcGrid[i, j], $"{alphabet[xyzID]}{numID}");
                        if (alphabet[xyzID] == 'Z')
                        {
                            xyzID = 0;
                            numID++;
                        }
                        else
                        {
                            xyzID++;
                        }
                    }
                }
            }
            #endregion



            #region This is where the image is broken into chunks

            //store the width and height of the grid
            int gridCellNumW = dmcGrid.GetLength(0);
            int gridCellNumH = dmcGrid.GetLength(1);

            //Set how many grid cells you want on each page(width and height)
            int cellNumWPerPage = 20;
            int cellNumHPerPage = 20;

            //create a list of each top left coordinate in each chunk
            List<int[]> chunkTopLeft = new List<int[]>();

            for (int i = 0; i < gridCellNumW/cellNumWPerPage; i++)
            {
                for (int j = 0; j < gridCellNumH / cellNumHPerPage; j++)
                {
                    chunkTopLeft.Add(new int[] { i* cellNumWPerPage, j* cellNumHPerPage });
                }
            }
            #endregion



            #region This is where the drawing happens
            //This needs to be done for each page
            //Starting with the first, as it is different every time.
            //After page one, the page drawing can be itterated through, as they all follow the same procedure
            //
            //
            #region Page One
            ///Create intro page, including image of conversion and a map showing the area each page covers
            
            //Add a new page (page1)
            document.AddPage();

            //first page graphics, and brushes/fonts
            XGraphics gfx = XGraphics.FromPdfPage(document.Pages[0]);
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode);
           
            //create image var (img) from users image, that will be shown on the first page of the pdf
            MemoryStream strm = new MemoryStream();
            image = ConvertImg.resizeImage(image, image.Width, image.Height, 765);
            image.Save(strm, System.Drawing.Imaging.ImageFormat.Png);
            XImage img = XImage.FromStream(strm);


            XFont font = new XFont("Consolas", 10, XFontStyle.Regular, options);
            XBrush brush = XBrushes.Black;
            XPen thinLine = new XPen(XColor.FromArgb(Color.Black.ToArgb()), 1);
            XPen wideLine = new XPen(XColor.FromArgb(Color.Black.ToArgb()), 3);


            int imgOffX = 10;
            int imgOffY = 10;
            //draw the image (since gfx is referencing page 1, this is where it is drawn)
            gfx.DrawImage(img, imgOffX, imgOffY);

            //draw the text codes for each dmc value that is used in the project
            //convert dict of dmc text codes to a string for drawing

            int startX = imgOffX;
            int lineSpace = 10;
            int startY = imgOffY + img.PixelHeight + lineSpace;

            int count = 1;
            foreach (var item in dmcToShortText.Keys)
            {
                string keyString = $"{dmcToShortText[item]} = {item}";
                gfx.DrawString(keyString, font, brush, startX, (lineSpace * count) + startY);
                count++;
            }

            #endregion End of page one region
            //
            //
            #region Pages with chart
            //add second page for testing

            document.AddPage();

            gfx = XGraphics.FromPdfPage(document.Pages[1]);

            //drawtext in a grid that shows short text code of each dmc pixel
            for (int i = 0; i < dmcGrid.GetLength(0); i++)
            {
                for (int j = 0; j < dmcGrid.GetLength(1); j++)
                {
                    gfx.DrawString(dmcToShortText[dmcGrid[i,j]], font, brush, j * gridsize + wOffset, (i * gridsize) + hOffset);
                }
            }

            //draw a line grid over the text grid

            int h = dmcGrid.GetLength(0);
            int w = dmcGrid.GetLength(1);
            //horizontal lines, with 10th line being thicker
            for (int i = 0; i < h+1; i++)
            {
                if (i % 10 == 0)
                {
                    gfx.DrawLine(wideLine, new XPoint(0,(i * gridsize) + hOffset), new XPoint(w*gridsize, (i * gridsize) + hOffset));
                }
                else
                {
                    gfx.DrawLine(thinLine, new XPoint(0, (i * gridsize) + hOffset), new XPoint(w * gridsize, (i * gridsize) + hOffset));
                }
            }

            //vertical lines, with 10th line being thicker
            for (int i = 0; i < w+1; i++)
            {
                if (i % 10 == 0)
                {
                    gfx.DrawLine(wideLine, new XPoint(i * gridsize, wOffset), new XPoint(i*gridsize, (h * gridsize) + wOffset));
                }
                else
                {
                    gfx.DrawLine(thinLine, new XPoint(i * gridsize, wOffset), new XPoint(i * gridsize, (h * gridsize) + wOffset));
                }
            }

            #endregion End of chart region
            //
            //
            #endregion End of drawing region



            //save the pdf
            string filename = "test.pdf";
            document.Save(filename);

            //opens the pdf for the user
            Process.Start("test.pdf");
        }
    }
}
