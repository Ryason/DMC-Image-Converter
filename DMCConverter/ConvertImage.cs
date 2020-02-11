using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCConverter
{
    public static class ConvertImg
    {
        /// <summary>
        /// This is called when the convert button is presses
        /// And is the main method for matching each pixel to a DMC colour
        /// </summary>
        /// <param name="img">The image the user wants to convert to DMC</param>
        /// <param name="vals"> List of selected DMC values </param>

        public static void processImage(Image img, List<String> vals)
        {
            Image image = img;
            List<String> DMCValues = vals;

            foreach (var item in DMCValues)
            {
                Console.WriteLine(item.ToString());
            }
        }

        /// <summary>
        /// Resizes the images to users specified width
        /// </summary>
        /// <param name="img">Image to resize</param>
        /// <param name="width">Width of current image</param>
        /// <param name="height">Height of current image</param>
        /// <param name="resizeWidth">Desired width of resized image</param>
        public static Image resizeImage(Image img, int width, int height, int resizeWidth)
        {
            Image imageToResize = img;
            int aspectRatio = height / width;

            int resizedHeight = resizeWidth * aspectRatio;

            Image resized = new Bitmap(imageToResize, new Size(resizeWidth, resizedHeight));

            return resized;
        }
    }
}
