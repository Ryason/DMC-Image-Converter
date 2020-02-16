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
        public DataGridView DMCDataGrid;
        
        
        public Form1()
        {
            InitializeComponent();
            paletteCount.Text = "Palette Count\n0 / " + dmcPaletteBox.Items.Count.ToString();
            DMCDataGrid = dataGridView1;
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
            //if user converts a second image, we have to clear the data from the first conversion
            if (DMCDataGrid.RowCount > 0 )
            {
                DMCDataGrid.Rows.Clear();
            }

            //call the process image method the convert our image to DMC values and display the values on a grid
            ConvertImg.processImage(resized, selectedDMCValues, progressBar, DMCDataGrid);
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
