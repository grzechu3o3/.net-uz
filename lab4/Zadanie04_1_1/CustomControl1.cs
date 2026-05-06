using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zadanie04_1_1
{
    public class CustomControl1 : Control
    {
        private int _state = 0;
        public int State
        {
            get { return _state; }
            set
            {
                _state = value;
                Invalidate();
            }
        }

        public CustomControl1()
        {
            this.DoubleBuffered = true;
            this.Width = 100;
            this.Height = 250;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.FillRectangle(Brushes.DimGray, 0, 0, this.Width, this.Height);
            g.DrawRectangle(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);

            int margin = 10;

            int circleHeight = (this.Height - (4 * margin)) / 3;

            int diameter = Math.Min(circleHeight, this.Width - (2 * margin));

            int startX = (this.Width - diameter) / 2;

            Brush czer = (State == 0 || State == 1) ? Brushes.Red : Brushes.DarkGray;
            Brush zol = (State == 1 || State == 3) ? Brushes.Yellow : Brushes.DarkGray;
            Brush zie = (State == 2) ? Brushes.Lime : Brushes.DarkGray;

          
            int y1 = margin;
            g.FillEllipse(czer, startX, y1, diameter, diameter);
            g.DrawEllipse(Pens.Black, startX, y1, diameter, diameter);

            int y2 = y1 + diameter + margin;
            g.FillEllipse(zol, startX, y2, diameter, diameter);
            g.DrawEllipse(Pens.Black, startX, y2, diameter, diameter);

            int y3 = y2 + diameter + margin;
            g.FillEllipse(zie, startX, y3, diameter, diameter);
            g.DrawEllipse(Pens.Black, startX, y3, diameter, diameter);
        }
    }
}