using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DMCConverter
{
    [Serializable]
    public partial class Form1 : Form
    {
        public bool imageLoaded;
        public bool converted;
        public bool loading = false;
        public bool dither = false;

        public int maxSize;
        public int tickedCount;
        public int threadAmount;
        public int imageGridSize;
        public int imgHeight;
        public int imgWidth;
        public int[] coord;
        public float ditherFactor;

        public Image image;
        public Image toConvert;
        public Image resized;

        public Color[,] rgbArray;
        public Color[,] rgbArrayToDrawFrom;

        public List<string> allDMCValues;
        public List<string> selectedDMCValues;
        public List<int[]> markedPositions = new List<int[]>();

        public string sourceFile;
        public string[,] dmcDataStore;

        public Graphics g;

        public Form1()
        {
            imageLoaded = false;
            converted = false;

            maxSize = 100;
            tickedCount = 0;
            threadAmount = 0;
            ditherFactor = 1;

            InitializeComponent();

            paletteCount.Text = "Palette Count\n0 / " + dmcPaletteBox.Items.Count.ToString();
            
            //my attepmt at enabling doublebuffering, to speed up the datagridview scrolling/rendering slowness.
            //mostly coppied code form stack overflow and an article on 10tec.com that explains the issue and gives some workaround code.
            EnableDoubleBuffering();

            //sets starting algorithm type to CIE2000
            AlgorithmType.SelectedIndex = 3;

            //sets all DMC values as a variable
            allDMCValues = new List<String>(dmcPaletteBox.Items.Cast<String>());

            //create graphics for the picture box. Used for drawing the converted image
            g = pictureBox1.CreateGraphics();

            //initialize the size of the display grid
            imageGridSize = (int)numericUpDown3.Value;
            coord = new int[2];
        }
        
        /// <summary>
        /// Allows the user to set the image they want to convert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadImageButon_Click(object sender, EventArgs e)
        {
            #region Load Image
            if (!loading)
            {
                //sets current progress bar to 0
                progressBar.Value = 0;

                //only allows user to pick and load image files
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                //assigns the picked file a variable name 'imageToConvert'
                DialogResult imageToConvert = openFileDialog1.ShowDialog();

                //get path of selected file, and change file to png
                sourceFile = openFileDialog1.FileName;
                string targetFile = Path.ChangeExtension(sourceFile, "png");
            }

            //load image png and assign it to an Image variable
            //this is here to catch the event a user opens the load dialogue and presses the cancel button, without loading an image.
            try
            {
                image = Image.FromFile(sourceFile);
            }
            catch (Exception)
            {
                return;
            }

            //load image to image display box
            UserImageBox.Image = image;
            toConvert = image;

            //resize image to 100 stitches
            resized = ConvertImg.resizeImage(toConvert,
                                             toConvert.Width,
                                             toConvert.Height,
                                             maxSize);
            WidthValue.Value = 100;
            #endregion
        }

        /// <summary>
        /// called when user selects or deselects a dmc value from the selection box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dmcPaletteBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gets how many DMC values the user has selected
            tickedCount = dmcPaletteBox.CheckedItems.Count;

            //displays how many DMC values the user has selected
            paletteCount.Text = "Palette Count\n" + tickedCount.ToString() + " / " + dmcPaletteBox.Items.Count.ToString();

            //stores selected values as a list, later used in converting the iamge to DMC
            selectedDMCValues = new List<String>(dmcPaletteBox.CheckedItems.Cast<String>());
        }

        /// <summary>
        /// Upon clicking the convert button, invoke the processImage method of the convertImage class
        /// This will perfom the matching of DMC values to the pixels of the resized image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ConvertButton_Click(object sender, EventArgs e)
        {
            //checking ticked count, and wether the user wants to auto match threads, makes sure we don't try and run the conversion without any DMC values to match against
            if (tickedCount == 0 && threadAmount == 0)
            {
                return;
            }

            //checking if image is null makes sure we dont run the conversion without an image present
            if (UserImageBox.Image == null)
            {
                return;
            }

            //if threadAmount is greater than 0, the user wants to auto generate the best matching DMC colours
            //throw out the selected DMC values, and make a new empty list to store the auto generated DMC colours in.
            if (threadAmount > 0)
            {
                selectedDMCValues = new List<string>();
            }

            //clear any previously marked grid co-ordinated
            markedPositions.Clear();

            //call the process image method the convert our image to DMC values and display the values on a grid
            //store the returned dmc pixel array and rgbArray to recall them if user accidentally marks the wrong grid cell
            Tuple<string[,],Color[,]> tupleReturn = ConvertImg.processImage(threadAmount, resized, selectedDMCValues, progressBar, ProgressBarText, AlgorithmType.SelectedIndex, allDMCValues, dmcPaletteBox, dither, ditherFactor, commonColourSensitivity.Value);
            dmcDataStore = tupleReturn.Item1;
            rgbArray = tupleReturn.Item2;
            rgbArrayToDrawFrom = tupleReturn.Item2;

            //update palette counter, just in case user generated threads and didnt pick any
            tickedCount = dmcPaletteBox.CheckedItems.Count;
            paletteCount.Text = "Palette Count\n" + tickedCount.ToString() + " / " + dmcPaletteBox.Items.Count.ToString();

            //tell program that a conversion has just taken place
            //this is here to prevent drawing the grid colors, before the grid colours have been established
            //DrawImage function checks for this
            converted = true;
            selectedDMCValues = new List<String>(dmcPaletteBox.CheckedItems.Cast<String>());
            //re-draw the graphics to update changes made
            Invalidate();

            ProgressBarText.Text = "Conversion Complete";

            //Commented out to test if this is causing the out of bounds crash when doing a second conversion
            //SaveSession();
            //LoadSession();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush black = new SolidBrush(Color.FromArgb(20, 20, 20));
            Pen blackPen = new Pen(black, 1);
            Pen marker = new Pen(black, (imageGridSize / 10) + 1.5f);
            Pen thickBlackPen = new Pen(black, (imageGridSize / 10) + 2f);

            imgHeight = (int)numericUpDown1.Value;
            imgWidth = (int)WidthValue.Value;

            //draw here
            Bitmap bm = new Bitmap(imgWidth * imageGridSize + 1, imgHeight * imageGridSize + 1);
            Graphics gr = Graphics.FromImage(bm);

            if (converted)
            {
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    for (int j = 0; j < WidthValue.Value; j++)
                    {
                        Brush DMCcolour = new SolidBrush(rgbArrayToDrawFrom[i, j]);

                        gr.FillRectangle(DMCcolour, j * imageGridSize + 1, i * imageGridSize + 1, imageGridSize - 1, imageGridSize - 1);
                    }
                }

                //here is where we should draw red marker squares
                if (markedPositions.Count > 0)
                {
                    foreach (var coord in markedPositions)
                    {
                        gr.FillRectangle(new SolidBrush(Color.Red), (coord[0]-1) * imageGridSize, (coord[1]-1) * imageGridSize, imageGridSize - 1, imageGridSize - 1);
                        gr.DrawLine(marker, (coord[0]) * imageGridSize, (coord[1]) * imageGridSize, (coord[0] - 1) * imageGridSize, (coord[1] - 1) * imageGridSize);
                    }
                }

                //activates the mouse toolTip
                toolTip1.Active = true;
            }

            //create a grid over the image, with a thicker grid, every 10 squares
            //thickness of grid lines are determined by the selected gridSize
            for (int i = 0; i < Width + 1; i++)
            {
                if (i % 10 == 0)
                {
                    gr.DrawLine(thickBlackPen, i * imageGridSize, 0, i * imageGridSize, imgHeight * imageGridSize);
                }
                else
                {
                    gr.DrawLine(blackPen, i * imageGridSize, 0, i * imageGridSize, imgHeight * imageGridSize);
                }
            }

            for (int i = 0; i < imgHeight + 1; i++)
            {
                if (i % 10 == 0)
                {
                    gr.DrawLine(thickBlackPen, 0, i * imageGridSize, Width * imageGridSize, i * imageGridSize);
                }
                else
                {
                    gr.DrawLine(blackPen, 0, i * imageGridSize, Width * imageGridSize, i * imageGridSize);
                }
            }

            pictureBox1.Width = imgWidth * imageGridSize + 1;
            pictureBox1.Height = imgHeight * imageGridSize + 1;

            //draw image;
            pictureBox1.Image = bm;
        }

        public void EnableDoubleBuffering()
        {
            // Set the value of the double-buffering style bits to true.
            this.SetStyle(ControlStyles.DoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint,
                          true);
            this.UpdateStyles();

            
        }

        /// <summary>
        /// Converts the users image to the size they specify
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WidthValue_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                converted = false;
                //if no image is present, don't try to resize
                if (UserImageBox.Image == null)
                {
                    return;
                }

                //maxSize needs to be set to the new resized with value
                //if not, upon second conversion attempt it will still be the original width of 100
                maxSize = Convert.ToInt32(Math.Round(WidthValue.Value, 0));
                //if image is present, resize it to specified width.
                resized = ConvertImg.resizeImage(toConvert,
                                                 toConvert.Width,
                                                 toConvert.Height,
                                                 maxSize);

                //store resized image, ready to be colour matched and converted to DMC olny colours
                UserImageBox.Image = resized;
                numericUpDown1.Value = resized.Height;

                //redraw the image
                Invalidate();
            }
        }

        /// <summary>
        /// stores the value of threadAmount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            threadAmount = (int)numericUpDown2.Value;
            System.Diagnostics.Debug.WriteLine(threadAmount);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            imageGridSize = (int)numericUpDown3.Value;
            Invalidate();
        }

        //when user clicks on image grid, show the grid co-ordinates of the mouse click
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            int xVal = ((me.X / imageGridSize) + 1);
            int yVal = ((me.Y / imageGridSize) + 1);
            coord[0] = xVal;
            coord[1] = yVal;
            if (converted && me.Button == MouseButtons.Left)
            {
                label5.Text = "x:" + xVal.ToString() + ", y:" + yVal.ToString() + "\n" + "DMC: " + dmcDataStore[yVal - 1, xVal - 1].ToString() + "\n" + rgbArrayToDrawFrom[yVal - 1, xVal - 1].ToArgb().ToString();
            }

            //dont modify the array, just draw a red rectangle over the grid
            //can store an array of marked positions. and cycle through them at the end of image drawing.
            if (converted && me.Button == MouseButtons.Right)
            {
                if (markedPositions.Any(x => x.SequenceEqual(new int[] {xVal,yVal})))
                {
                    markedPositions.Remove(markedPositions.First(x => x.SequenceEqual(new int[] { xVal, yVal })));
                }
                else
                {
                    markedPositions.Add(new int[] { xVal, yVal });
                }

                //redraw to draw new marked positions
                Invalidate();
            }
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (converted)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                int xVal = Math.Min(((me.X / imageGridSize) + 1), imgWidth);
                int yVal = Math.Min(((me.Y / imageGridSize) + 1), imgHeight);

                toolTip1.SetToolTip(pictureBox1, $"x:{xVal} y:{yVal} \n" + "DMC:" + dmcDataStore[yVal - 1, xVal - 1].ToString());
            }
        }

        //try and open a link to information about the colour difference algorithm
        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Color_difference");
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        //Allow the saving of converted images (save as json file?)
        //
        //THINGS TO STORE
        //  image file path (string)
        //  Height, Width of converted image (int)
        //  rgbArray and rgbArrayToDrawFrom (Color[,])
        //  selectedDMCValues (List<string>)
        //  dmcDataStore (string[,])
        //  threadAmount
        //  imageGridSize
        //  algorithmType
        public void SaveSession()
        {
            ApplicationData appdata = new ApplicationData();

            appdata.sourceFile = sourceFile;
            appdata.dmcDataStrore = dmcDataStore;
            appdata.rgbArray = rgbArray;
            appdata.rgbArrayToDrawFrom = rgbArrayToDrawFrom;
            appdata.selectedDMCValues = selectedDMCValues;
            appdata.maxSize = maxSize;
            appdata.tickedCount = tickedCount;
            appdata.threadAmount = threadAmount;
            appdata.imageGridSize = imageGridSize;
            appdata.imgHeight = imgHeight;
            appdata.imgWidth = imgWidth;
            appdata.markedPositions = markedPositions;

            string save = JsonConvert.SerializeObject(appdata, Formatting.Indented);

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/Save.json", save);

            Console.WriteLine(save);
        }

        //Load everything from save file
        public void LoadSession()
        {
            ApplicationData loadData = new ApplicationData();
            string json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/Save.json");
            loadData = JsonConvert.DeserializeObject<ApplicationData>(json);

            loading = true;
            converted = true;
            imageLoaded = true;
            sourceFile = loadData.sourceFile;
            resized = ConvertImg.resizeImage(Image.FromFile(loadData.sourceFile),
                                             loadData.imgWidth,
                                             loadData.imgHeight,
                                             maxSize);
            toConvert = resized;
            UserImageBox.Image = resized;
            dmcDataStore = loadData.dmcDataStrore;
            rgbArray = loadData.rgbArray;
            rgbArrayToDrawFrom = loadData.rgbArrayToDrawFrom;
            selectedDMCValues = loadData.selectedDMCValues;
            maxSize = loadData.maxSize;
            tickedCount = loadData.tickedCount;
            numericUpDown2.Value = loadData.threadAmount;
            threadAmount = loadData.threadAmount;
            numericUpDown3.Value = loadData.imageGridSize;
            numericUpDown1.Value = loadData.imgHeight;
            WidthValue.Value = loadData.imgWidth;
            markedPositions = loadData.markedPositions;

            Console.WriteLine(loadData.sourceFile);

            Invalidate();

            loading = false;
        }

        private void saveButton_MouseClick(object sender, MouseEventArgs e)
        {
            SaveSession();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadSession();
        }

        private void CreatePDF_Click(object sender, EventArgs e)
        {
            //only create a pdf if an image has been converted
            if (converted)
            {
                ExportAsPDF export = new ExportAsPDF();
                export.Create(image, dmcDataStore, selectedDMCValues);
            }
        }

        private void ditherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dither = ditherCheckBox.Checked;
            Console.WriteLine($"Dithering = {dither}");
        }

        private void ditherFac_ValueChanged(object sender, EventArgs e)
        {
            ditherFactor = (float)ditherFac.Value;
        }
    }
}

public class ApplicationData
{
    public string sourceFile { get; set; }
    public string[,] dmcDataStrore { get; set; }
    public Color[,] rgbArray { get; set; }
    public Color[,] rgbArrayToDrawFrom { get; set; }
    public List<string> selectedDMCValues { get; set; }
    public int maxSize { get; set; }
    public int tickedCount { get; set; }
    public int threadAmount { get; set; }
    public int imageGridSize { get; set; }
    public int imgHeight { get; set; }
    public int imgWidth { get; set; }
    public List<int[]> markedPositions { get; set; }
}
