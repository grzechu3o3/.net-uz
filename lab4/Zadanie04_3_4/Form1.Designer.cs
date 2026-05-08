namespace Zadanie04_3_4
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
            this.treeViewOsoby = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // treeViewOsoby
            // 
            this.treeViewOsoby.Location = new System.Drawing.Point(12, 12);
            this.treeViewOsoby.Name = "treeViewOsoby";
            this.treeViewOsoby.Size = new System.Drawing.Size(967, 658);
            this.treeViewOsoby.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(985, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 658);
            this.button1.TabIndex = 1;
            this.button1.Text = "Wczytaj XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 682);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeViewOsoby);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewOsoby;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

