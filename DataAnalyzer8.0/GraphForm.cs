using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataAnalyzer8._0
{
    public partial class Histogram : Form
    {
        public Histogram()
        {
            InitializeComponent();
            // Setting the minimum and maximum size of the form.
            MaximumSize = SystemInformation.PrimaryMonitorSize;
            int Width = SystemInformation.PrimaryMonitorSize.Width / 2;
            int Height = SystemInformation.PrimaryMonitorSize.Height / 2;
            MinimumSize = new Size(Width, Height);
            GraphColorDialog.FullOpen = true;
        }
        /// <summary>
        /// Method for saving the graph.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveGraphDialog.ShowDialog() == DialogResult.OK)
            {
                // Temporarily change the background color so that the photo is saved on a white background.
                this.Graph.BackColor = Color.White;
                this.Graph.SaveImage(SaveGraphDialog.FileName + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                this.Graph.BackColor = Color.AliceBlue;
            }
        }
        /// <summary>
        /// Method for changing the color of the histogram.
        /// </summary>
        private void Graph_Click(object sender, EventArgs e)
        {
            if (GraphColorDialog.ShowDialog() == DialogResult.OK)
            {
                // Changing the color to the one selected by the user.
                this.Graph.Series[0].Color = GraphColorDialog.Color;
            } 
        }
    }
}
