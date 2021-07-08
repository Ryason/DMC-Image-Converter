using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using ColorMine.ColorSpaces;
using ColorMine.ColorSpaces.Comparisons;

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
        public static Tuple<string[,],Color[,]> processImage(int threadAmount, Image img, List<String> vals, ProgressBar progressBar, Label progressBarText, DataGridView DMCDataGrid, int AlgorithmType, List<String> allDMCValues, CheckedListBox checkBox, bool dither, float ditherFactor)
        {
            progressBar.Value = 0;
            //dictionary for storing pixel values, to determine most frequesnt colours.
            Dictionary<Color, int> BestMatchedColours = new Dictionary<Color, int>();
            
            //image that we are processing
            Image image = img;

            //creates a bitmap of the image we're converting
            Bitmap convert = new Bitmap(image);

            //creates an empty bitmap for the converted image.
            //this will be used when we have a dmc match for each pixel
            //we will assign each pixel the rgb value of its corresponding dmc match
            Bitmap convertedIMG = new Bitmap(image);

            Bitmap ditheredIMG = new Bitmap(image);

            //width and height of image we are converting
            //used in looping over each pixel
            int w = convert.Width;
            int h = convert.Height;

            //also to track progress of completed matches, and used in displaying total number of stiches
            int total = w * h;

            //this double always ensures that the first DMC value check will be stored as the closest match
            double distance = 999999999d;

            //creates the closest dmc value string
            string closestDMC = "";

            //creata a w by h sized array to hold the DMC data (string) for each pixel.
            string[,] dmcPixelDataArray = new string[h, w];
            Color[,] rgbArray = new Color[h, w];

            //initialize DMCValues list
            List<String> DMCValues = new List<string>();

            //if selecting our own threads and not auto generating, store selected threads
            if (vals.Count > 0)
            {
                DMCValues = vals;
            }
            else
            {
                DMCValues = allDMCValues;
            }

            Dictionary<String, int> colourCount = new Dictionary<String, int>();

            //list for all DMC's used
            List<string> allUsedDMC = new List<string>();

            int counter = 0;
            //check if wanting to auto generate best threads to use in the image conversion
            if (threadAmount > 0)
            {
                
                progressBarText.Text = "Finding Best Thread Colours";
                Application.DoEvents();
                //remove all checked DMC values, as new finding best matches
                for (int i = 0; i < checkBox.Items.Count; i++)
                {
                    checkBox.SetItemCheckState(i, 0);
                }

                //loop over all pixels in the image that we want to convert
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        Color currentPixel = convert.GetPixel(i, j);
                        String currentDMC = FindClosestDMC(currentPixel, allDMCValues, AlgorithmType);

                        //if current pixel DMC is stored in our colour tracking dictionary, increment its count value by 1
                        if (colourCount.ContainsKey(currentDMC))
                        {
                            colourCount[currentDMC]++;
                        }
                        //else add it to the dictionary and give add one to its count value
                        else
                        {
                            colourCount.Add(currentDMC, 1);
                        }

                        //increase the value of the progress bar
                        counter++;
                        progressBar.Value = Convert.ToInt32(Math.Round(((float)counter / (float)total) * 100f));
                    }
                }

                //sort the dictionary by value so most used colours are at the start of the dictionary
                colourCount =  colourCount.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                List <String> commonColours = new List<String>();
                counter = 0;
                foreach (var item in colourCount.OrderByDescending(x => x.Value))
                {
                    if (counter >= threadAmount)
                    {
                        break;
                    }
                    else
                    {
                        commonColours.Add(item.Key);
                        counter++;
                    }
                }

                List<string> mostCommonDMC = new List<string>();

                
                foreach(var item in commonColours)
                {
                    mostCommonDMC.Add(item);

                    //for each of the common dmc values, check their checkbox in the selection panel, 
                    //so user knows which ones have been suggested
                    for (int i = 0; i < checkBox.Items.Count; i++)
                    {
                        if (item.Split(' ')[0].ToString() == checkBox.Items[i].ToString())
                        {
                            checkBox.SetItemChecked(i, true);
                        }
                    }
                    
                }

                //set the dmc values to be used in the image conversion
                DMCValues = mostCommonDMC;
            }

            //loop over all pixels and compare every dmc rgb value to the pixel's rgb value.
            //calculate the closest matching dmc value, and store it in an array.
            progressBar.Value = 0;
            counter = 0;
            progressBarText.Text = "Matching Each Pixel To DMC";
            Application.DoEvents();

            //algorithm error values and their xy positions
            List<Object[]> errorMatrix = new List<Object[]>() { new object[] { 1, 0, 7f/16f},
                                                                new object[] { -1, 1, 3f/16f},
                                                                new object[] { 0, 1, 5f/16f},
                                                                new object[] { 1, 1, 1f/16f}};

            List<Object[]> errorMatrix2 = new List<Object[]>() { new object[] { 1, 0, 7f/48f},
                                                                 new object[] { 2, 1, 5f/48f},
                                                                 new object[] { -2, 0, 3f/48f},
                                                                 new object[] { -1, 1, 5f/48f},
                                                                 new object[] { 0, 1, 7f/48f},
                                                                 new object[] { 1, 1, 5f/48f},
                                                                 new object[] { 2, 1, 3f/48f},
                                                                 new object[] { -2, 2, 1f/48f},
                                                                 new object[] { -1, 2, 3f/48f},
                                                                 new object[] { 0, 2, 5f/48f},
                                                                 new object[] { 1, 2, 3f/48f},
                                                                 new object[] { 2, 2, 1f/48f} };

            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    foreach (var item in DMCValues)
                    {
                        //Use colorMine library to convert RGB to CIELAB colour space
                        //And finding the closest matching colour with the shortest CIELAB ΔE
                        //https://en.wikipedia.org/wiki/Color_difference
                        //https://github.com/muak/ColorMine
                        //Also using the colorMine's comparison algorithm

                        //split each item and convert strings to ints
                        List<string> splitItem = item.Split('\t').ToList();

                        //current in-loop DMC rgb values
                        int rVal = Convert.ToInt32(splitItem[2]);
                        int gVal = Convert.ToInt32(splitItem[3]);
                        int bVal = Convert.ToInt32(splitItem[4]);

                        Color DMCcolour = Color.FromArgb(rVal, gVal, bVal);

                        //current in-loop pixel rgb value
                        int rImg = convert.GetPixel(i, j).R;
                        int gImg = convert.GetPixel(i, j).G;
                        int bImg = convert.GetPixel(i, j).B;

                        //set up new rgb values for use in the colormine deltaE calculation
                        Rgb DMC = new Rgb { R = rVal, G = gVal, B = bVal };
                        Rgb IMG = new Rgb { R = rImg, G = gImg, B = bImg };

                        //create double for deltaE result
                        double deltaE = 0d;

                        //find closest mathcing dmc value to current pixel in the image that will be converted (convert)

                        //set up a switch statement for switching between selected matching algorithm
                        // 0 CIE76
                        // 1 CIE94
                        // 2 CMC l: C
                        // 3 CIE2000
                        switch (AlgorithmType)
                        {
                            case 0:
                                deltaE = DMC.Compare(IMG, new Cie1976Comparison());
                                break;
                            case 1:
                                deltaE = DMC.Compare(IMG, new Cie94Comparison());
                                break;
                            case 2:
                                deltaE = DMC.Compare(IMG, new CmcComparison());
                                break;
                            case 3:
                                deltaE = DMC.Compare(IMG, new CieDe2000Comparison());
                                break;
                        }

                        //check if current value is close in colour than the previous 
                        if (deltaE < distance)
                        {
                            //if the new match is closer, set it as the new distance benchmark
                            distance = deltaE;

                            //set the corresponding dmc value as the new closest match for the current pixel
                            closestDMC = splitItem[0];
                            convertedIMG.SetPixel(i, j, Color.FromArgb(rVal, gVal, bVal));
                            dmcPixelDataArray[j, i] = closestDMC;
                        }
                    }
                    //if dithering is required, modify convert image with appropriate error
                    //based on newly matched pixel value
                    if (dither)
                    {
                        Color oldPixel = convert.GetPixel(i, j);
                        Color newPixel = convertedIMG.GetPixel(i, j);
                        float factor = ditherFactor;

                        //convert.SetPixel(i, j, newPixel);
                        //compute errors and set pixels in image accordingly
                        foreach (var error in errorMatrix)
                        {
                            //if not on the image edge
                            //normal i > 0 && i < w - 1 && j > 0 && j < h - 1
                            if (i > 1 && i < w - 2 && j > 1 && j < h - 2)
                            {
                                int x = i + (int)error[0];
                                int y = j + (int)error[1];
                                float errVal = (float)error[2] * factor;

                                float oldR = oldPixel.R;
                                float oldG = oldPixel.G;
                                float oldB = oldPixel.B;

                                float newR = newPixel.R;
                                float newG = newPixel.G;
                                float newB = newPixel.B;

                                float errR = oldR - newR;
                                float errG = oldG - newG;
                                float errB = oldB - newB;

                                Color xyCol = convert.GetPixel(i + (int)error[0], j + (int)error[1]);

                                float r = (xyCol.R + errR * errVal);
                                float g = (xyCol.G + errG * errVal);
                                float b = (xyCol.B + errB * errVal);

                                //new error diffused colour
                                convert.SetPixel(x, y, Color.FromArgb(Clamp(0, 255, (int)r),
                                                                      Clamp(0, 255, (int)g),
                                                                      Clamp(0, 255, (int)b)));
                            }
                        }
                    }
                    

                    //increase the value of the progress bar
                    counter += 1;
                    progressBar.Value = Convert.ToInt32(Math.Round(((float)counter / (float)total)*100f));

                    //again, this ensures the first comparison will always be stored as the closest matching dmc value
                    distance = 999999999999999;
                } 
            }

            //save the created image to the exe directory
            convertedIMG.Save("Converted.png");

            //set the datagrid width to that of the resized image
            DMCDataGrid.ColumnCount = w;

            progressBar.Value = 0;
            progressBarText.Text = "Drawing Converted Image";

            Application.DoEvents();

            counter = 0;
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
                    row.Cells[j].Style.BackColor = convertedIMG.GetPixel(j, i);
                    rgbArray[i, j] = convertedIMG.GetPixel(j, i);

                    //increase the value of the progress bar
                    counter += 1;
                    progressBar.Value = Convert.ToInt32(Math.Round(((float)counter / (float)total) * 100f));
                }

                //add populated row to the datagridview
                DMCDataGrid.Rows.Add(row);
            }

            //God bless this son of a bitch tuple return!!!!!
            //allows to return both image data and converted image data to the form class
            //useful when user makes a mistake and marks the wrong grid cell
            //unmarked coour is now available to switch it from marked red to the correct colour.
            return new Tuple<string[,],Color[,]>(dmcPixelDataArray,rgbArray);
        }

        public static string FindClosestDMC(Color RGBToDMC, List<string> DMCValues, int AlgorithmType)
        {
            double distance = 99999999999d;

            string closestDMC = "";
            for (int i = 0; i < DMCValues.Count; i++)
            {
                string itemString = DMCValues[i];
                string[] item = DMCValues[i].Split('\t');

                //current in-loop DMC rgb values
                int rDMC = Convert.ToInt32(item[2]);
                int gDMC = Convert.ToInt32(item[3]);
                int bDMC = Convert.ToInt32(item[4]);
                int r = RGBToDMC.R;
                int g = RGBToDMC.G;
                int b = RGBToDMC.B;

                //set up new rgb values for use in the colormine deltaE calculation
                Rgb DMC = new Rgb { R = rDMC, G = gDMC, B = bDMC };
                Rgb rgb = new Rgb { R = r, G = g, B = b };

                //create double for deltaE result
                double deltaE = 0d;

                //set up a switch statement for switching between selected matching algorithm
                // 0 CIE76
                // 1 CIE94
                // 2 CMC l: C
                // 3 CIE2000
                switch (AlgorithmType)
                {
                    case 0:
                        deltaE = DMC.Compare(rgb, new Cie1976Comparison());
                        break;
                    case 1:
                        deltaE = DMC.Compare(rgb, new Cie94Comparison());
                        break;
                    case 2:
                        deltaE = DMC.Compare(rgb, new CmcComparison());
                        break;
                    case 3:
                        deltaE = DMC.Compare(rgb, new CieDe2000Comparison());
                        break;
                }

                //check if current value is close in colour than the previous 
                if (deltaE < distance)
                {
                    //if the new match is closer, set it as the new distance benchmark
                    distance = deltaE;

                    //set the corresponding dmc value as the new closest match for the current pixel
                    closestDMC = itemString;
                }
            }

            return closestDMC;
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

            //simple way of resizing the image
            //need to look into image resizing methods that include Anti aliasing and other resizing techniques, plus maybe look into upscaling too.
            Image resized = new Bitmap(imageToResize, new Size(resizedWidth, resizedHeight));

            //returns the new resized iamge
            return resized;
        }

        public static int Clamp(int min, int max, int val)
        {
            if (val < min)
            {
                return min;
            }
            if (val > max)
            {
                return max;
            }
            else
            {
                return val;
            }
        }
    }
}
