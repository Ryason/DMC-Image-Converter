using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static void processImage(Image img, List<String> vals, ProgressBar progressBar)
        {

            Image image = img;
            List<String> DMCValues = vals;
            
            foreach (var item in DMCValues)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(item.Split('	')[2]);
                Console.WriteLine(item.Split('	')[3]);
                Console.WriteLine(item.Split('	')[4]);
            }

            Bitmap convert = new Bitmap(image);
            Bitmap convertedIMG = new Bitmap(image);
            int w = convert.Width;
            int h = convert.Height;

            float distance = 999999999;
            string closestDMC = "";

            int count = 0;
            int total = w * h;

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Console.WriteLine(convert.GetPixel(i, j).ToString());

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

                        float match = (float)Math.Sqrt(((rVal - rImg) * (rVal - rImg)) +
                                                       ((gVal - gImg) * (gVal - gImg)) +
                                                       ((bVal - bImg) * (bVal - bImg)));
                        
                        //check if current value is close in coler than the previous 
                        if (match < distance)
                        {
                            distance = match;

                            closestDMC = item.Split('	')[0];
                            convertedIMG.SetPixel(i, j, Color.FromArgb( rVal, gVal, bVal));
                        }
                    }
                    count += 1;
                    progressBar.Value = Convert.ToInt32(Math.Round((count / total)*100f)) ;
                    distance = 999999999999999;
                    Console.WriteLine("DMC match = " + closestDMC.ToString());
                } 
            }
            //save the created image to the exe directory
            convertedIMG.Save("Converted.png");
            
        }

        /// <summary>
        /// Resizes the images to users specified width
        /// </summary>
        /// <param name="img">Image to resize</param>
        /// <param name="w">Width of current image</param>
        /// <param name="h">Height of current image</param>
        /// <param name="resizeWidth">Desired width of resized image</param>
        public static Image resizeImage(Image img, int w, int h, int resizeWidth)
        {
            Image imageToResize = img;

            int aspectRatio = h / w;

            int resizedHeight = resizeWidth * aspectRatio;

            Image resized = new Bitmap(imageToResize, new Size(resizeWidth, resizedHeight));

            return resized;
        }
    }
}
