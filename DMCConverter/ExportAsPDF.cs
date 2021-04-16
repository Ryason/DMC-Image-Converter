using System;
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



            //Create multiple pages to fit an entire conversion prjoect on
            ///first need to break up the image, using the DMCgridarray's width and height.
            ///then calculate how many pages it needs by breaking it up into chunks of a set width and height
            ///create a page for each chunk using a set of starting co-ordinates that reference the DMCgrid

            //starting by assigning each dmc value an id
            //assemble the dictionary of dmc values and assign them a short text code

            #region Assign DMC values a short text code

            //sets how wide the grid is on the page
            int gridsize = 18;

            //stores what letters are accessed when creating the dict of dmc codes
            int xyzID = 0;
            int numID = 0;

            //string which is indexed for the creation of short dmc codes
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //itterate over each grid, if the dmc value is not present in the dict, add it as a key
            //and make its value a letter from the alphabet and a number. starting at A0.
            //increment the latter, so the next time a new value is stored it is the next letter of alphabet
            //if alphabet gets to Z, increase the number by 1 and start from A again
            for (int i = 0; i < dmcGrid.GetLength(0); i++)
            {
                for (int j = 0; j < dmcGrid.GetLength(1); j++)
                {
                    if (!dmcToShortText.ContainsKey(dmcGrid[i, j]))
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

            for (int i = 0; i < gridCellNumW / cellNumWPerPage; i++)
            {
                for (int j = 0; j < gridCellNumH / cellNumHPerPage; j++)
                {
                    chunkTopLeft.Add(new int[] { i * cellNumWPerPage, j * cellNumHPerPage });
                }
            }
            #endregion

            #region This is where the drawing happens
            //This needs to be done for each page
            //Starting with the first, as it is different every time.
            //After page one, the page drawing can be itterated through, as they all follow the same procedure

            #region Page One
            //Create intro page, including image of conversion and a map showing the area each page covers

            //Add a new page (page1)
            document.AddPage();

            //first page graphics, and brushes/fonts
            XGraphics gfx = XGraphics.FromPdfPage(document.Pages[0]);
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode);

            //create image var (img) from users image, that will be shown on the first page of the pdf
            MemoryStream strm = new MemoryStream();

            //resize image
            //if image is taller than is wide, resize it based on its height
            if (image.Width > image.Height)
            {
                image = ConvertImg.resizeImage(image, image.Width, image.Height, 765);
            }
            else
            {
                image = ConvertImg.resizeImage(image, image.Width, image.Height, 765/2);
            }
            image.Save(strm, System.Drawing.Imaging.ImageFormat.Png);
            XImage img = XImage.FromStream(strm);

            //create fonts for text, and brushes for the colours of text and grid
            XFont font = new XFont("Consolas", 10, XFontStyle.Regular, options);
            XBrush brush = XBrushes.Black;
            XPen thinLine = new XPen(XColor.FromArgb(Color.Black.ToArgb()), 1);
            XPen wideLine = new XPen(XColor.FromArgb(Color.Black.ToArgb()), 3);

            //draw the image (since gfx is referencing page 1, this is where it is drawn)
            int imgOffX = 10;
            int imgOffY = 10;
            gfx.DrawImage(img, imgOffX, imgOffY);

            //draw the text codes for each dmc value that is used in the project
            //convert dict of dmc text codes to a string for drawing
            int startX = imgOffX;
            int lineSpace = 10;
            int startY = imgOffY + img.PixelHeight;
            int count = 1;

            foreach (var item in dmcToShortText.Keys)
            {
                string keyString = $"{dmcToShortText[item]} = {item}";
                gfx.DrawString(keyString, font, brush, startX, (count * lineSpace) + startY - 50);
                count++;
            }
            #endregion End of page one region

            #region Pages with chart
            //add second page for testing
            //This is where the grid will be broken down to make it readable across multiple pages.


            //These 2 variables determine how many cells there are (width and height)
            //currently it is the maximum, but i should be able to set it to say 30 and 30,
            //and have the page only display 30 across and 30 down
            int h = 30;
            int w = 30;

            //first, break down the grid into 30 by 30 chunks.
            //store chunk start positions in a list
            List<int[]> chunks = new List<int[]>();

            //calculate how many chunks wide and high
            int chunkH = (int)Math.Ceiling(dmcGrid.GetLength(0) / (float)h);
            int chunkW = (int)Math.Ceiling(dmcGrid.GetLength(1) / (float)w);

            for (int i = 0; i < chunkH; i++)
            {
                for (int j = 0; j < chunkW; j++)
                {
                    chunks.Add(new int[] {j*w, i*h});
                    Console.WriteLine($"new chunk at {j * w},{i * h}");
                }
            }

            //create a page for every chunk
            for (int a = 0; a < chunks.Count; a++)
            {
                document.AddPage();

                gfx = XGraphics.FromPdfPage(document.Pages[a+1]); //a+1 because first page already exists
                int textwOffset = 20;
                int texthOffset = 20;

                int linewOffset = textwOffset + -4;
                int linehOffset = texthOffset + -12;

                //debug!!!
                //right now things arent being drawn in the correct positions.
                //because when drawing, i and j are starting at 30 multiples.
                //and when setting the poitns in the gfx draw function, those 30 multiples are being used
                //i need to normalise them to 0 or something

                //drawtext in a grid that shows short text code of each dmc pixel
                //start at chunk location and go up to chunk location +h,w
                int y = 0;
                int x = 0;
                for (int i = chunks[a][1]; i < chunks[a][1] + h; i++)
                {
                    for (int j = chunks[a][0]; j < chunks[a][0] + w; j++)
                    {
                        if (i < dmcGrid.GetLength(0) && j < dmcGrid.GetLength(1))
                        {
                            gfx.DrawString(dmcToShortText[dmcGrid[i, j]], font, brush, (x * gridsize) + textwOffset, (y * gridsize) + texthOffset);
                        }
                        x++;
                    }
                    y++;
                    x=0;
                }

                //draw a line grid over the text grid


                //horizontal lines, with 10th line being thicker
                y = 0;
                x = 0;
                for (int i = chunks[a][1]; i < chunks[a][1] + h + 1; i++)
                {
                    if (i % 10 == 0)
                    {
                        if (i <= dmcGrid.GetLength(0))
                        {
                            gfx.DrawLine(wideLine, new XPoint(0 + linewOffset, (y * gridsize) + linehOffset), new XPoint((w * gridsize) + linewOffset, (y * gridsize) + linehOffset));
                        }
                    }
                    else
                    {
                        if (i <= dmcGrid.GetLength(0))
                        {
                            gfx.DrawLine(thinLine, new XPoint(0 + linewOffset, (y * gridsize) + linehOffset), new XPoint((w * gridsize) + linewOffset, (y * gridsize) + linehOffset));
                        }
                    }
                    y++;
                }

                //vertical lines, with 10th line being thicker
                for (int i = chunks[a][0]; i < chunks[a][0] + w + 1; i++)
                {
                    if (i % 10 == 0)
                    {
                        if (i <= dmcGrid.GetLength(1))
                        {
                            gfx.DrawLine(wideLine, new XPoint((x * gridsize) + linewOffset, linehOffset), new XPoint((x * gridsize) + linewOffset, (h * gridsize) + linehOffset));
                        }
                    }
                    else
                    {
                        if (i <= dmcGrid.GetLength(1))
                        {
                            gfx.DrawLine(thinLine, new XPoint((x * gridsize) + linewOffset, linehOffset), new XPoint((x * gridsize) + linewOffset, (h * gridsize) + linehOffset));
                        }
                    }
                    x++;
                }
            }


            

            #endregion End of chart region

            #endregion End of drawing region

            //save the pdf
            string filename = "test.pdf";
            document.Save(filename);

            //opens the pdf for the user
            Process.Start("test.pdf");
        }
    }
}
