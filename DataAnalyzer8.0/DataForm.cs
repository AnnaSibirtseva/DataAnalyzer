using System;
using System.Collections.Generic;
using System.Globalization;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataAnalyzer8._0
{
    public partial class DataForm : Form
    {
        // Variable - crutch so that when you first run the table, incorrect values are not displayed.
        private static int NumberOfClicksOnColumn = 0;
        public DataForm()
        {
            InitializeComponent();
            // Setting the minimum and maximum size of the form.
            MaximumSize = SystemInformation.PrimaryMonitorSize;
            int Width = SystemInformation.PrimaryMonitorSize.Width / 2;
            int Height = SystemInformation.PrimaryMonitorSize.Height / 2;
            MinimumSize = new Size(Width, Height);
            // Limiting the files that can be opened.
            OpenFileDialog.Filter = "Comma-Separated Values (*.csv)|*.csv";
        }
        /// <summary>
        /// Method for loading and displaying data in a table.
        /// </summary>
        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Сlearing the table so that the data does not overlap with each other.
                DataGrid.Rows.Clear();
                DataGrid.Columns.Clear();
                string fileName = OpenFileDialog.FileName;
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    if (!streamReader.EndOfStream)
                    {
                        string[] titles = streamReader.ReadLine().Replace(", ", "Wоndеrwall").Split(',');
                        int numberOfColumns = titles.Length;
                        if (numberOfColumns > 1)
                        {
                            for (int i = 0; i < numberOfColumns; i++)
                            {
                                DataGridViewColumn column = new DataGridViewColumn();
                                column.Name = titles[i];
                                column.ReadOnly = true;
                                column.CellTemplate = new DataGridViewTextBoxCell();
                                DataGrid.Columns.Add(column);
                            }
                            if (DataGrid.Columns.Count < 10)
                            {
                                DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            }
                        }
                        while (!streamReader.EndOfStream)
                        {
                            // Replacing ", " with a word, so that everything is correctly divided into columns.
                            string[] row = streamReader.ReadLine().Replace(", ", "Wоndеrwall").Split(',');
                            foreach (string value in row)
                            {
                                value.Replace("Wоndеrwall", ", ");
                            }
                            DataGrid.Rows.Add(row);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Method for numbering rows in a table.
        /// </summary>
        private void DataGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            // Since the index starts with zero, we add one.
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }
        /// <summary>
        /// A method for checking the correctness of data for plotting a graph.
        /// </summary>
        private void GraphMenu_Click(object sender, EventArgs e)
        {
            // Checking that only one column was selected.
            if (this.DataGrid.SelectedColumns.Count == 1 && this.DataGrid.Rows.Count > 1)
            {
                Histogram histogram = new Histogram();
                histogram.Graph.Series[0].ChartType = SeriesChartType.Column;
                histogram.Show();
                int currentColumnIndex = this.DataGrid.SelectedColumns[0].Index;
                Dictionary<string, int> NumberOfValues = new Dictionary<string, int>();
                for (int j = 0; j < this.DataGrid.Rows.Count; j++)
                {
                    if (this.DataGrid.Rows[j].Cells[currentColumnIndex].Value != null)
                    {
                        // Filling the dictionary with the values and the number of their occurrence.
                        string currentKey = (this.DataGrid.Rows[j].Cells[currentColumnIndex].Value).ToString();
                        FillTheDictionary(NumberOfValues, currentKey);
                    }
                }
                if (NumberOfValues.Values.Count > 100)
                {
                    MessageBox.Show("Sorry, but the number of different elements can not be more than 100, because otherwise the histogram is incomprehensible.", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    histogram.Close();
                }
                else
                {
                    string currentColumnName = this.DataGrid.SelectedColumns[0].Name;
                    DrawNewGraph(histogram, NumberOfValues, currentColumnName);
                }
            }
            else if (this.DataGrid.SelectedColumns.Count != 1)
            {
                MessageBox.Show("You need to select ONE column to build a histogram.", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (this.DataGrid.Rows.Count < 2)
            {
                MessageBox.Show("Not enough rows in the data table to build a graph ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        /// <summary>
        /// Method for drawing a graph.
        /// </summary>
        /// <param name="histogram">Current histogram.</param>
        /// <param name="NumberOfValues">Dictionary with values and the number of their occurrence.</param>
        /// <param name="currentColumnName">Current column name.</param>
        private static void DrawNewGraph(Histogram histogram, Dictionary<string, int> NumberOfValues, string currentColumnName)
        {
            int i = 0;
            histogram.Graph.BackColor = Color.AliceBlue;
            Font font = new Font(FontFamily.GenericMonospace, 35.0F, FontStyle.Bold, GraphicsUnit.Pixel);
            Title title = new Title(currentColumnName.Trim('"'), Docking.Top, font, Color.Black);
            // Creating a title.
            histogram.Graph.Titles.Add(title);
            // Going through all the values in the dictionary.
            foreach (var elem in NumberOfValues.Keys)
            {
                // Signing the Y axis.
                histogram.Graph.Series[0].Points.AddY(NumberOfValues[elem]);
                histogram.Graph.Series[0].LegendText = currentColumnName;
                // Signing the X axis.
                histogram.Graph.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i, i + 2, $"{elem}", 0, LabelMarkStyle.LineSideMark));
                histogram.Graph.Series[0].BorderColor = Color.Black;
                i++;
            }
            // Deleting an unnecessary legend.
            histogram.Graph.Legends.Clear();
        }
        /// <summary>
        /// Method for closing the main form.
        /// </summary>
        private void ExitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Method for filling in the dictionary.
        /// </summary>
        /// <param name="NumberOfValues">The dictionary to be filled in.</param>
        /// <param name="currentKey">The current key.</param>
        private static void FillTheDictionary(Dictionary<string, int> NumberOfValues, string currentKey)
        {
            if (NumberOfValues.ContainsKey(currentKey))
            {
                // Adding the number of times encountered, if the key already existed.
                NumberOfValues[currentKey]++;
            }
            else
            {
                // Creating a new dictionary element, if it did not exist before.
                NumberOfValues.Add(currentKey, 1);
            }
        }
        /// <summary>
        /// Method for getting the median.
        /// </summary>
        /// <param name="doubleColumn">List of double numbers from the selected column.</param>
        /// <returns>Rerurns the median of selected column.</returns>
        private static double GetMedian(List<double> doubleColumn)
        {
            // Sorting the list in ascending order.
            doubleColumn.Sort();
            // Calculating the median depending on the number of digits in the list.
            if (doubleColumn.Count % 2 == 1)
            {
                return doubleColumn[doubleColumn.Count / 2];
            }
            else
            {
                return (doubleColumn[doubleColumn.Count / 2 - 1] + doubleColumn[doubleColumn.Count / 2]) / 2;
            }
        }
        /// <summary>
        /// A method for finding the variance.
        /// </summary>
        /// <param name="doubleColumn">Selected column.</param>
        /// <returns>Returns the variance.</returns>
        private static double GetVariance(List<double> doubleColumn)
        {
            // Getting the average number of list.
            double average = doubleColumn.Average();
            double sum = 0;
            for (int i = 0; i < doubleColumn.Count; i++)
            {
                sum += Math.Pow((doubleColumn[i] - average), 2);
            }
            return sum / doubleColumn.Count;
        }
        /// <summary>
        /// A method for showing the mean, median, standard deviation, and variance.
        /// </summary>
        private void DataGrid_SelectionChanged(object sender, EventArgs e)
        {
            // Creating a new list for future work.
            List<double> doubleColumn = new List<double>();
            if (this.DataGrid.SelectedColumns.Count == 1)
            {
                int currentColumnIndex = this.DataGrid.SelectedColumns[0].Index;
                for (int j = 0; j < this.DataGrid.Rows.Count; j++)
                {
                    if (this.DataGrid.Rows[j].Cells[currentColumnIndex].Value != null)
                    {
                        // Removing all unnecessary quotation marks, change the dot to a comma and parse it into a double.
                        if (double.TryParse(((string)this.DataGrid.Rows[j].Cells[currentColumnIndex].Value).Trim('"'), NumberStyles.Float, CultureInfo.InvariantCulture, out double rowValue))
                        {
                            doubleColumn.Add(rowValue);
                        }
                    }
                }
                try
                {
                    // If values were numbers, then writing the mean, median, standard deviation, and variance.
                    if ((this.DataGrid.Rows.Count == doubleColumn.Count + 1) && NumberOfClicksOnColumn != 0)
                    {
                        this.Average.Text = $"Average: {Math.Round(doubleColumn.Average(), 3)}";
                        this.Median.Text = $"Median: {GetMedian(doubleColumn)}";
                        this.Deviation.Text = $"Deviation: {Math.Round((Math.Sqrt(GetVariance(doubleColumn))), 3)}";
                        // Since the root-mean-square is the root of the variance, we just do it.
                        this.Variance.Text = $"Variance: {Math.Round(GetVariance(doubleColumn), 3)}";
                        NumberOfClicksOnColumn = 1;
                    }
                    else
                    {
                        this.Average.Text = $"Average: ";
                        this.Median.Text = $"Median: ";
                        this.Deviation.Text = $"Deviation: ";
                        this.Variance.Text = $"Variance: ";
                        NumberOfClicksOnColumn = 1;
                    }
                }
                catch
                {
                    MessageBox.Show("There were no rows in the data table!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
        /// <summary>
        /// A method for processing data for a two-dimensional graph.
        /// </summary>
        private void Graphic_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DataGrid.SelectedColumns.Count == 2)
                {
                    Histogram histogram = new Histogram();
                    histogram.Graph.Series[0].ChartType = SeriesChartType.Spline;
                    int currentColumnIndex1 = this.DataGrid.SelectedColumns[1].Index;
                    int currentColumnIndex2 = this.DataGrid.SelectedColumns[0].Index;
                    Dictionary<double, double> valuesForGraph = new Dictionary<double, double>();
                    for (int j = 0; j < this.DataGrid.Rows.Count; j++)
                    {
                        if (this.DataGrid.Rows[j].Cells[currentColumnIndex1].Value != null && this.DataGrid.Rows[j].Cells[currentColumnIndex2].Value != null)
                        {
                            // Filling the dictionary with the values and the number of their occurrence.
                            string firstcurrentKey = (this.DataGrid.Rows[j].Cells[currentColumnIndex1].Value).ToString();
                            string secondcurrentKey = (this.DataGrid.Rows[j].Cells[currentColumnIndex2].Value).ToString();
                            FillDoubleDic(valuesForGraph, firstcurrentKey, secondcurrentKey);
                            valuesForGraph = valuesForGraph.OrderBy(key => key.Key).ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                        }
                    }
                    string currentColumnName1 = this.DataGrid.SelectedColumns[1].Name;
                    string currentColumnName2 = this.DataGrid.SelectedColumns[0].Name;
                    // Sending the created data to the method that will draw the graph.
                    DrawNewLineGraph(histogram, valuesForGraph, currentColumnName1, currentColumnName2);
                    // If the expression doesn't pop up anywhere, then we show the form.
                    histogram.Show();
                }
                else
                {
                    MessageBox.Show("You need to select TWO columns to build a graph.", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        /// <summary>
        /// A method for drawing a two-dimensional graph.
        /// </summary>
        /// <param name="histogram">The form on which the graph will be drawn.</param>
        /// <param name="valuesForGraph">An array of numbers that will be used to plot the graph.</param>
        /// <param name="currentColumnName1">The name of the first selected column.</param>
        /// <param name="currentColumnName2">The name of the second selected column.</param>
        private static void DrawNewLineGraph(Histogram histogram, Dictionary<double, double> valuesForGraph, string currentColumnName1, string currentColumnName2)
        {
            int i = 0;
            histogram.Graph.BackColor = Color.AliceBlue;
            Font font = new Font(FontFamily.GenericMonospace, 35.0F, FontStyle.Bold, GraphicsUnit.Pixel);
            string xTitle = currentColumnName1.Trim('"');
            string yTitle = currentColumnName2.Trim('"');
            Title title = new Title(($"{xTitle} -> {yTitle}").Trim('"'), Docking.Top, font, Color.Black);
            // Creating a title.
            histogram.Graph.Titles.Add(title);
            // Going through all the values in the dictionary.
            foreach (var elem in valuesForGraph.Keys)
            {
                // Signing the Y axis.
                histogram.Graph.Series[0].Points.AddY(valuesForGraph[elem]);
                histogram.Graph.Series[0].LegendText = currentColumnName1;
                // Signing the X axis.
                histogram.Graph.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i, i + 2, $"{elem}", 0, LabelMarkStyle.LineSideMark));
                histogram.Graph.Series[0].BorderColor = Color.Black;
                i++;
            }
            histogram.Graph.ChartAreas[0].AxisX.Title = $"{currentColumnName1}";
            histogram.Graph.ChartAreas[0].AxisY.Title = $"{currentColumnName2}";
            // Deleting an unnecessary legend.
            histogram.Graph.Legends.Clear();
        }
        /// <summary>
        /// A method for filling in a numeric dictionary for constructing a two-dimensional graph.
        /// </summary>
        /// <param name="valuesForGraph">An array of numbers that will be used to plot the graph.</param>
        /// <param name="firstcurrentKey">The value of the first variable - X.</param>
        /// <param name="secondcurrentKey">The value of the second variable - Y.</param>
        private static void FillDoubleDic(Dictionary<double, double> valuesForGraph, string firstcurrentKey, string secondcurrentKey)
        {
            // Checking that our values are parsed to double.
            if (double.TryParse(firstcurrentKey.Trim('"'), NumberStyles.Float, CultureInfo.InvariantCulture, out double firstrowValue) && double.TryParse(secondcurrentKey.Trim('"'), NumberStyles.Float, CultureInfo.InvariantCulture, out double secondrowValue))
            {
                if (!valuesForGraph.ContainsKey(firstrowValue))
                {
                    valuesForGraph.Add(firstrowValue, secondrowValue);
                }
                else
                {
                    valuesForGraph[firstrowValue] = (valuesForGraph[firstrowValue] + secondrowValue) / 2;
                }
            }
            else
            {
                // Throwing an exception so that the form does not open.
                throw new ArgumentException("The values in the columns must be INTEGERS");
            }

        }
    }
}
