namespace Zadanie04_3_6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijWszystkoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaskadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sąsiadującePionowoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sąsiadującePoziomoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyjdźToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.widokToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.zamknijWszystkoToolStripMenuItem,
            this.zamknijToolStripMenuItem,
            this.wyjdźToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(71, 38);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.otwórzToolStripMenuItem.Text = "Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // zamknijWszystkoToolStripMenuItem
            // 
            this.zamknijWszystkoToolStripMenuItem.Name = "zamknijWszystkoToolStripMenuItem";
            this.zamknijWszystkoToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.zamknijWszystkoToolStripMenuItem.Text = "Zamknij Wszystko";
            this.zamknijWszystkoToolStripMenuItem.Click += new System.EventHandler(this.zamknijWszystkoToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaskadaToolStripMenuItem,
            this.sąsiadującePionowoToolStripMenuItem,
            this.sąsiadującePoziomoToolStripMenuItem});
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(102, 38);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // kaskadaToolStripMenuItem
            // 
            this.kaskadaToolStripMenuItem.Name = "kaskadaToolStripMenuItem";
            this.kaskadaToolStripMenuItem.Size = new System.Drawing.Size(371, 44);
            this.kaskadaToolStripMenuItem.Text = "Kaskada";
            this.kaskadaToolStripMenuItem.Click += new System.EventHandler(this.kaskadaToolStripMenuItem_Click);
            // 
            // sąsiadującePionowoToolStripMenuItem
            // 
            this.sąsiadującePionowoToolStripMenuItem.Name = "sąsiadującePionowoToolStripMenuItem";
            this.sąsiadującePionowoToolStripMenuItem.Size = new System.Drawing.Size(371, 44);
            this.sąsiadującePionowoToolStripMenuItem.Text = "Sąsiadujące pionowo";
            this.sąsiadującePionowoToolStripMenuItem.Click += new System.EventHandler(this.pionowoToolStripMenuItem_Click);
            // 
            // sąsiadującePoziomoToolStripMenuItem
            // 
            this.sąsiadującePoziomoToolStripMenuItem.Name = "sąsiadującePoziomoToolStripMenuItem";
            this.sąsiadującePoziomoToolStripMenuItem.Size = new System.Drawing.Size(371, 44);
            this.sąsiadującePoziomoToolStripMenuItem.Text = "Sąsiadujące poziomo";
            this.sąsiadującePoziomoToolStripMenuItem.Click += new System.EventHandler(this.poziomoToolStripMenuItem_Click);
            // 
            // wyjdźToolStripMenuItem
            // 
            this.wyjdźToolStripMenuItem.Name = "wyjdźToolStripMenuItem";
            this.wyjdźToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.wyjdźToolStripMenuItem.Text = "Wyjdź";
            this.wyjdźToolStripMenuItem.Click += new System.EventHandler(this.wyjdźToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 570);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijWszystkoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem widokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaskadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sąsiadującePionowoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sąsiadującePoziomoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyjdźToolStripMenuItem;
    }
}

