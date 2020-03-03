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
using System.Reflection;

namespace DMCConverter
{
    public partial class Form1 : Form
    {
        public bool imageLoaded = false;

        public int maxSize = 100;
        public int tickedCount = 0;

        public Image image;
        public Image toConvert;
        public Image resized;

        public Color[,] rgbArray;

        public List<String> selectedDMCValues;

        public DataGridView DMCDataGrid;

        public string[,] dmcDataStore;



        public Form1()
        {
            InitializeComponent();
            paletteCount.Text = "Palette Count\n0 / " + dmcPaletteBox.Items.Count.ToString();
            DMCDataGrid = dataGridView1;

            //my attepmt at enabling doublebuffering, to speed up the datagridview scrolling/rendering slowness.
            //mostly coppied code form stack overflow and an article on 10tec.com that explains the issue and gives some workaround code.
            EnableDoubleBuffering();

            //sets starting algorithm type to CIE94
            AlgorithmType.SelectedIndex = 1;
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
            //checking ticked count makes sure we dont try and run the conversion without a palette
            if (tickedCount == 0)
            {
                return;
            }
            //checking if image is null makes sure we dont run the conversion without an image present
            if (UserImageBox.Image == null)
            {
                return;
            }

            //if user converts a second image, we have to clear the data from the first conversion
            if (DMCDataGrid.RowCount > 0 )
            {
                DMCDataGrid.Rows.Clear();
            }
            
            //call the process image method the convert our image to DMC values and display the values on a grid
            //store the returned dmc pixel array and rgbArray to recall them if user accidentally double clicks to mark a grid cell
            Tuple<string[,],Color[,]> tupleReturn = ConvertImg.processImage(resized, selectedDMCValues, progressBar, DMCDataGrid, AlgorithmType.SelectedIndex);
            dmcDataStore = tupleReturn.Item1;
            rgbArray = tupleReturn.Item2;
        }

        public void EnableDoubleBuffering()
        {
            // Set the value of the double-buffering style bits to true.
            this.SetStyle(ControlStyles.DoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint,
                          true);
            this.UpdateStyles();

            //from the explanations at https://10tec.com/articles/why-datagridview-slow.aspx
            if (!SystemInformation.TerminalServerSession)
            {
                Type dgvType = dataGridView1.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dataGridView1, true, null);
            }
        }

        /// <summary>
        /// Converts the users image to the size they specify
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WidthValue_ValueChanged(object sender, EventArgs e)
        {
            //if no image is present, don't try to resize
            if (UserImageBox.Image == null)
            {
                return;
            }

            //if image is present, resize it to specified width.
            resized = ConvertImg.resizeImage(toConvert, 
                                             toConvert.Width, 
                                             toConvert.Height, 
                                             Convert.ToInt32(Math.Round(WidthValue.Value,0)));

            //store resized image, ready to be colour matched and converted to DMC olny colours
            UserImageBox.Image = resized;
        }

        /// <summary>
        /// Makes a cell on the grid red when the user double clicks. 
        /// If marked by mistake the user can double click the cell again.
        /// This reverts the cell's background from red to the previous colour and restores the DMC value text to the cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if the cell is empty, i.e. if the user has double clicked and marked it red
            if ((string)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "")
            {
                //set the text value of the cell to be that of the DMC colour name for this cell's colour.
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dmcDataStore[e.RowIndex, e.ColumnIndex];

                //set the background of the cell to the corresponding rgb colour for this cell's DMC value
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = rgbArray[e.RowIndex, e.ColumnIndex];
            }
            else
            {
                //else, if the cell is not red, make the background of the cell red
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.BackColor = Color.Red;

                //and remove the DMC value text
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = cellStyle;
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
        }
    }
}
