namespace Zadanie04_1_2
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
            this.zegarControl1 = new Zadanie04_1_2.ZegarControl();
            this.SuspendLayout();
            // 
            // zegarControl1
            // 
            this.zegarControl1.Location = new System.Drawing.Point(248, 54);
            this.zegarControl1.Name = "zegarControl1";
            this.zegarControl1.Size = new System.Drawing.Size(645, 674);
            this.zegarControl1.TabIndex = 0;
            this.zegarControl1.Text = "zegarControl1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 796);
            this.Controls.Add(this.zegarControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ZegarControl zegarControl1;
    }
}

