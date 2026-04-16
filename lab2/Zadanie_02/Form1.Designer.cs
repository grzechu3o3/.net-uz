namespace Zadanie_02
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
            this.operation = new System.Windows.Forms.ListBox();
            this.count = new System.Windows.Forms.Button();
            this.num1 = new System.Windows.Forms.NumericUpDown();
            this.num2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num2)).BeginInit();
            this.SuspendLayout();
            // 
            // operation
            // 
            this.operation.FormattingEnabled = true;
            this.operation.ItemHeight = 25;
            this.operation.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.operation.Location = new System.Drawing.Point(423, 170);
            this.operation.Name = "operation";
            this.operation.Size = new System.Drawing.Size(120, 79);
            this.operation.TabIndex = 2;
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(423, 272);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(120, 51);
            this.count.TabIndex = 3;
            this.count.Text = "=";
            this.count.UseVisualStyleBackColor = true;
            this.count.Click += new System.EventHandler(this.count_Click);
            // 
            // num1
            // 
            this.num1.Location = new System.Drawing.Point(277, 195);
            this.num1.Name = "num1";
            this.num1.Size = new System.Drawing.Size(120, 31);
            this.num1.TabIndex = 4;
            // 
            // num2
            // 
            this.num2.Location = new System.Drawing.Point(573, 195);
            this.num2.Name = "num2";
            this.num2.Size = new System.Drawing.Size(120, 31);
            this.num2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 580);
            this.Controls.Add(this.num2);
            this.Controls.Add(this.num1);
            this.Controls.Add(this.count);
            this.Controls.Add(this.operation);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox operation;
        private System.Windows.Forms.Button count;
        private System.Windows.Forms.NumericUpDown num1;
        private System.Windows.Forms.NumericUpDown num2;
    }
}

