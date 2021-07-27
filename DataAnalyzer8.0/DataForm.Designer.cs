namespace DataAnalyzer8._0
{
    partial class DataForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataForm));
            this.FormPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DataMenu = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.GraphMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Average = new System.Windows.Forms.ToolStripMenuItem();
            this.Median = new System.Windows.Forms.ToolStripMenuItem();
            this.Deviation = new System.Windows.Forms.ToolStripMenuItem();
            this.Variance = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Graphic = new System.Windows.Forms.ToolStripMenuItem();
            this.FormPanel.SuspendLayout();
            this.DataMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPanel
            // 
            this.FormPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.FormPanel.ColumnCount = 1;
            this.FormPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FormPanel.Controls.Add(this.DataMenu, 0, 0);
            this.FormPanel.Controls.Add(this.DataGrid, 0, 1);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.RowCount = 2;
            this.FormPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.111111F));
            this.FormPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.88889F));
            this.FormPanel.Size = new System.Drawing.Size(800, 450);
            this.FormPanel.TabIndex = 0;
            // 
            // DataMenu
            // 
            this.DataMenu.BackColor = System.Drawing.Color.AliceBlue;
            this.DataMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DataMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.Average,
            this.Median,
            this.Deviation,
            this.Variance});
            this.DataMenu.Location = new System.Drawing.Point(0, 0);
            this.DataMenu.Name = "DataMenu";
            this.DataMenu.Size = new System.Drawing.Size(800, 31);
            this.DataMenu.TabIndex = 0;
            this.DataMenu.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile,
            this.GraphMenu,
            this.Graphic,
            this.ExitMenu});
            this.menuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("menuToolStripMenuItem.Image")));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(80, 27);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // OpenFile
            // 
            this.OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("OpenFile.Image")));
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(224, 26);
            this.OpenFile.Text = "Open File";
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // GraphMenu
            // 
            this.GraphMenu.Image = ((System.Drawing.Image)(resources.GetObject("GraphMenu.Image")));
            this.GraphMenu.Name = "GraphMenu";
            this.GraphMenu.Size = new System.Drawing.Size(224, 26);
            this.GraphMenu.Text = "Histogram";
            this.GraphMenu.Click += new System.EventHandler(this.GraphMenu_Click);
            // 
            // ExitMenu
            // 
            this.ExitMenu.Image = ((System.Drawing.Image)(resources.GetObject("ExitMenu.Image")));
            this.ExitMenu.Name = "ExitMenu";
            this.ExitMenu.Size = new System.Drawing.Size(224, 26);
            this.ExitMenu.Text = "Exit";
            this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // Average
            // 
            this.Average.Name = "Average";
            this.Average.Size = new System.Drawing.Size(81, 27);
            this.Average.Text = "Average:";
            // 
            // Median
            // 
            this.Median.Name = "Median";
            this.Median.Size = new System.Drawing.Size(76, 27);
            this.Median.Text = "Median:";
            // 
            // Deviation
            // 
            this.Deviation.Name = "Deviation";
            this.Deviation.Size = new System.Drawing.Size(90, 27);
            this.Deviation.Text = "Deviation:";
            // 
            // Variance
            // 
            this.Variance.Name = "Variance";
            this.Variance.Size = new System.Drawing.Size(82, 27);
            this.Variance.Text = "Variance:";
            // 
            // DataGrid
            // 
            this.DataGrid.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.DataGrid.Location = new System.Drawing.Point(3, 34);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.RowHeadersWidth = 51;
            this.DataGrid.RowTemplate.Height = 24;
            this.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.DataGrid.Size = new System.Drawing.Size(794, 413);
            this.DataGrid.TabIndex = 1;
            this.DataGrid.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.DataGrid_RowStateChanged);
            this.DataGrid.SelectionChanged += new System.EventHandler(this.DataGrid_SelectionChanged);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // Graphic
            // 
            this.Graphic.Image = ((System.Drawing.Image)(resources.GetObject("Graphic.Image")));
            this.Graphic.Name = "Graphic";
            this.Graphic.Size = new System.Drawing.Size(224, 26);
            this.Graphic.Text = "Graph";
            this.Graphic.Click += new System.EventHandler(this.Graphic_Click);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FormPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.DataMenu;
            this.Name = "DataForm";
            this.Text = "Data Analyzer";
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.DataMenu.ResumeLayout(false);
            this.DataMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel FormPanel;
        private System.Windows.Forms.MenuStrip DataMenu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem GraphMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitMenu;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.ToolStripMenuItem Average;
        private System.Windows.Forms.ToolStripMenuItem Median;
        private System.Windows.Forms.ToolStripMenuItem Deviation;
        private System.Windows.Forms.ToolStripMenuItem Variance;
        private System.Windows.Forms.ToolStripMenuItem Graphic;
    }
}

