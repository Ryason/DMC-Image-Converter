using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMCConverter
{
    public partial class Form1 : Form
    {
        public int maxSize = 100;
        public int tickedCount = 0;
        public Image toConvert;
        public Image resized;
        public List<String> selectedDMCValues;
        
        public Form1()
        {
            InitializeComponent();
            paletteCount.Text = "Palette Count\n0 / " + dmcPaletteBox.Items.Count.ToString();
        }
        
        /// <summary>
        /// Allows the user to set the image they want to convert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadImageButon_Click(object sender, EventArgs e)
        {
            #region Load Image
            //sets current progress bar to 0
            progressBar.Value = 0;

            //only allows user to pick and load image files
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            //assigns the picked file a variable name 'imageToConvert'
            DialogResult imageToConvert = openFileDialog1.ShowDialog();

            //get path of selected file, and change file to png
            string sourceFile = openFileDialog1.FileName;
            string targetFile = Path.ChangeExtension(sourceFile, "png");

            //load image png and assign it to an Image variable
            Image image = Image.FromFile(sourceFile);
            Console.WriteLine("loading " + openFileDialog1.FileName.ToString());

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

        public void dmcPaletteBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tickedCount = dmcPaletteBox.CheckedItems.Count;
            paletteCount.Text = "Palette Count\n" + tickedCount.ToString() + " / " + dmcPaletteBox.Items.Count.ToString();
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
            
            ConvertImg.processImage(resized, selectedDMCValues, progressBar);
        }

        public void WidthValue_ValueChanged(object sender, EventArgs e)
        {
            resized = ConvertImg.resizeImage(toConvert, 
                                             toConvert.Width, 
                                             toConvert.Height, 
                                             Convert.ToInt32(Math.Round(WidthValue.Value,0)));
            UserImageBox.Image = resized;
        }
    }
}
