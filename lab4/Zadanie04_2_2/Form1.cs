using System;
using System.Drawing;
using System.Windows.Forms;
using SharpDX.XInput;

namespace Zadanie04_2_2
{
    public partial class Form1 : Form
    {
        Controller controller;
        Gamepad gamepad;
        Timer timer;

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.Width = 550;
            this.Height = 550;
            this.Text = "Symulator Kierownicy";

            controller = new Controller(UserIndex.One);

            timer = new Timer();
            timer.Interval = 16;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (controller.IsConnected)
            {
                var state = controller.GetState();
                gamepad = state.Gamepad;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(30, 30, 30));

            Font labelFont = new Font("Segoe UI", 10, FontStyle.Bold);

            if (!controller.IsConnected)
            {
                g.DrawString("Pad nie jest podłączony!", new Font("Segoe UI", 14),
                    Brushes.White, new PointF(150, 200));
                return;
            }

            float lx = gamepad.LeftThumbX / 32768f;

            if (Math.Abs(lx) < 0.15f) lx = 0;

            float angle = lx * 180f;

            int wheelCenterX = 260;
            int wheelCenterY = 180;
            int wheelRadius = 110;

            var state = g.Save();

            g.TranslateTransform(wheelCenterX, wheelCenterY);
            g.RotateTransform(angle);

            Pen wheelPen = new Pen(Color.DimGray, 16);
            g.DrawEllipse(wheelPen, -wheelRadius, -wheelRadius, wheelRadius * 2, wheelRadius * 2);
            g.FillEllipse(Brushes.Black, -25, -25, 50, 50);

            Pen spokePen = new Pen(Color.Silver, 12);
            g.DrawLine(spokePen, -25, 0, -wheelRadius, 0);
            g.DrawLine(spokePen, 25, 0, wheelRadius, 0);
            g.DrawLine(spokePen, 0, 25, 0, wheelRadius);

            g.FillRectangle(Brushes.Red, -5, -wheelRadius - 8, 10, 16);

            g.Restore(state);


            int lt = gamepad.LeftTrigger;  
            int rt = gamepad.RightTrigger;

            int maxBarHeight = 150;

            float brakeHeight = (lt / 255f) * maxBarHeight;
            float gasHeight = (rt / 255f) * maxBarHeight;

            int pedalY = 480; 

            g.DrawString("Hamulec (LT)", labelFont, Brushes.White, 40, 310);
            g.DrawRectangle(Pens.White, 60, pedalY - maxBarHeight, 40, maxBarHeight);
            g.FillRectangle(Brushes.Red, 60, pedalY - brakeHeight, 40, brakeHeight);

            g.DrawString("Gaz (RT)", labelFont, Brushes.White, 420, 310);
            g.DrawRectangle(Pens.White, 420, pedalY - maxBarHeight, 40, maxBarHeight);
            g.FillRectangle(Brushes.Lime, 420, pedalY - gasHeight, 40, gasHeight);

            g.DrawString($"Kąt skrętu: {(int)angle}°", labelFont, Brushes.LightGray, wheelCenterX - 55, wheelCenterY + 140);
        }
    }
}