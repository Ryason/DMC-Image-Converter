using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace DMCConverter
{
    public class ConvertImg
    {
        /// <summary>
        /// This is called when the convert button is presses
        /// And is the main method for matching each pixel to a DMC colour
        /// </summary>
        /// <param name="img">The image the user wants to convert to DMC</param>
        /// <param name="vals"> List of selected DMC values </param>

        public static void processImage(Image img, List<String> vals, ProgressBar progressBar, DataGridView DMCDataGrid)
        {
            //image that we are processing
            Image image = img;

            List<String> DMCValues = vals;

            //creates a bitmap of the image we're converting
            Bitmap convert = new Bitmap(image);

            //creates an empty bitmap for the converted image.
            //this will be used when we have a dmc match for each pixel
            //we will assign each pixel the rgb value of its corresponding dmc match
            Bitmap convertedIMG = new Bitmap(image);

            //width and height of image we are converting
            //used in looping over each pixel
            int w = convert.Width;
            int h = convert.Height;

            //starte a counter to help track progress of how many matches we have completed
            int count = 0;

            //also to track progress of completed matches, and used in displaying total number of stiches
            int total = w * h;

            //this float always ensures that the first DMC value check will be stored as the closest match
            float distance = 999999999;

            //creates the closest dmc value string
            string closestDMC = "";

            //creata a w by h sized array to hold the DMC data (string) for each pixel.
            string[,] dmcPixelDataArray = new string[h, w];

            //loop over all pixels and compare every dmc rgb value to the pixel's rgb value.
            //calculate the closest matching dmc value, and store it in an array.
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    foreach (var item in DMCValues)
                    {
                        //current in-lop DMC rgb values
                        int rVal = Convert.ToInt32(item.Split('	')[2]);
                        int gVal = Convert.ToInt32(item.Split('	')[3]);
                        int bVal = Convert.ToInt32(item.Split('	')[4]);
                        
                        //current in-loop pixel rgb value
                        int rImg = convert.GetPixel(i, j).R;
                        int gImg = convert.GetPixel(i, j).G;
                        int bImg = convert.GetPixel(i, j).B;

                        //use pythagoras to get 'distance' value for the two rgb values
                        float match = (float)Math.Sqrt(((rVal - rImg) * (rVal - rImg)) +
                                                       ((gVal - gImg) * (gVal - gImg)) +
                                                       ((bVal - bImg) * (bVal - bImg)));
                        
                        //check if current value is close in colour than the previous 
                        if (match < distance)
                        {
                            //if the new match is closer, set it as the new distance benchmark
                            distance = match;

                            //set the corresponding dmc value as the new closest match for the current pixel
                            closestDMC = item.Split('	')[0];
                            convertedIMG.SetPixel(i, j, Color.FromArgb( rVal, gVal, bVal));
                            dmcPixelDataArray[j,i] = closestDMC;
                        }
                    }

                    //increase the value of the progress bar
                    count += 1;
                    progressBar.Value = Convert.ToInt32(Math.Round((count / total)*100f));

                    //again, this float ensures the first comparison will always be stored as the closest matching dmc value
                    distance = 999999999999999;
                } 
            }

            //save the created image to the exe directory
            convertedIMG.Save("Converted.png");

            //set the datagrid width to that of the resized image
            DMCDataGrid.ColumnCount = w;

            for (int i = 0; i < h; i++)
            {
                //create a new row for each new step in height
                DataGridViewRow row = new DataGridViewRow();
                
                //create cells for the row
                row.CreateCells(DMCDataGrid);

                for (int j = 0; j < w; j++)
                {
                    //populate the row with dmc pixel value data
                    row.Cells[j].Value = dmcPixelDataArray[i, j];
                }

                //add populated row to the datagridview
                DMCDataGrid.Rows.Add(row);
            }  
        }

        /// <summary>
        /// Resizes the images to users specified width
        /// </summary>
        /// <param name="img">Image to resize</param>
        /// <param name="w">Width of current image</param>
        /// <param name="h">Height of current image</param>
        /// <param name="resizedWidth">Desired width of resized image</param>
        public static Image resizeImage(Image img, int w, int h, int resizedWidth)
        {
            //image that we are resizing
            Image imageToResize = img;

            //need to cast h and w as floats for division to not give 0 if w is smaller than h
            //calculate aspect ratio and calculate new height from users given width
            float aspectRatio = (float)w / (float)h;
            int resizedHeight = (int)(resizedWidth / aspectRatio);
;
            //simple way of resizing the image
            //need to look into image resizing methods that include Anti aliasing and other resizing techniques, plus maybe look into upscaling too.
            Image resized = new Bitmap(imageToResize, new Size(resizedWidth, resizedHeight));

            //returns the new resized iamge
            return resized;
        }
    }
}
