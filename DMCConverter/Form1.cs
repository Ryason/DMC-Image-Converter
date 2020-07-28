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
        public bool converted = false;

        public int maxSize = 100;
        public int tickedCount = 0;
        public int threadAmount = 0;
        public int imageGridSize;

        public Image image;
        public Image toConvert;
        public Image resized;

        public Color[,] rgbArray;

        public List<String> allDMCValues;
        public List<String> selectedDMCValues;

        public DataGridView DMCDataGrid;

        public string[,] dmcDataStore;

        public Graphics g;



        public Form1()
        {
            InitializeComponent();

            paletteCount.Text = "Palette Count\n0 / " + dmcPaletteBox.Items.Count.ToString();
            DMCDataGrid = dataGridView1;

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

            //if user converts a second image, we have to clear the data from the first conversion
            if (DMCDataGrid.RowCount > 0 )
            {
                DMCDataGrid.Rows.Clear();
            }

            //if threadAmount is greater than 0, the user wants to auto generate the best matching DMC colours
            //throw out the selected DMC values, and make a new empty list to store the auto generated DMC colours in.
            if (threadAmount > 0)
            {
                selectedDMCValues = new List<string>();
            }

            //call the process image method the convert our image to DMC values and display the values on a grid
            //store the returned dmc pixel array and rgbArray to recall them if user accidentally double clicks to mark a grid cell
            Tuple<string[,],Color[,]> tupleReturn = ConvertImg.processImage(threadAmount, resized, selectedDMCValues, progressBar, ProgressBarText, DMCDataGrid, AlgorithmType.SelectedIndex, allDMCValues, dmcPaletteBox);
            dmcDataStore = tupleReturn.Item1;
            rgbArray = tupleReturn.Item2;

            //update palette counter, just in case user generated threads and didnt pick any
            tickedCount = dmcPaletteBox.CheckedItems.Count;
            paletteCount.Text = "Palette Count\n" + tickedCount.ToString() + " / " + dmcPaletteBox.Items.Count.ToString();

            //tell program that a conversion has just taken place
            //this is here to prevent drawing the grid colors, before the grid colours have been established
            //DrawImage function checks for this
            converted = true;

            //re-draw the graphics to update changes made
            pictureBox1.Refresh();

            ProgressBarText.Text = "Conversion Complete";
        }

        private void DrawImage()
        {
            Brush red = new SolidBrush(Color.FromArgb(20,20,20));
            Pen redPen = new Pen(red, 1);

            int Height = (int)numericUpDown1.Value;
            int Width = (int)WidthValue.Value;

            for (int i = 0; i < Width + 1; i++)
            {
                g.DrawLine(redPen, i * imageGridSize, 0, i * imageGridSize, Height * imageGridSize);
            }
            for (int i = 0; i < Height + 1; i++)
            {
                g.DrawLine(redPen, 0, i * imageGridSize, Width * imageGridSize, i * imageGridSize);
            }

            pictureBox1.Width = Width  * imageGridSize + 1;
            pictureBox1.Height = Height * imageGridSize + 1;

            if (converted)
            {
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    for (int j = 0; j < WidthValue.Value; j++)
                    {
                        Brush DMCcolour = new SolidBrush(rgbArray[i, j]);

                        g.FillRectangle(DMCcolour, j * imageGridSize + 1, i * imageGridSize + 1, imageGridSize -1 , imageGridSize -1);
                    }
                }
            }
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
            converted = false;
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
            numericUpDown1.Value = resized.Height;

            pictureBox1.Refresh();
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            DrawImage();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            imageGridSize = (int)numericUpDown3.Value;
            pictureBox1.Refresh();
        }

        //when user clicks on image grid, show the grid co-ordinates of the mouse click
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            label5.Text = "x:" + ((me.X / imageGridSize) + 1).ToString() + ", y:" + ((me.Y / imageGridSize) + 1).ToString();
        }
    }
}
