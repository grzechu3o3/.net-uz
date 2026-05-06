using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.XInput;

namespace Zadanie04_2_1
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
            this.Width = 500;
            this.Height = 500;
            this.Text = "Stan kontrolera do gier";

            controller = new Controller(UserIndex.One);

            timer = new Timer();
            timer.Interval = 16;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            if(controller.IsConnected)
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

            Font labelFont = new Font("Segoe UI", 9, FontStyle.Bold);

            if (!controller.IsConnected)
            {
                g.DrawString("Kontroler nie jest podłączony", new Font("Segoe UI", 14),
                    Brushes.White, new PointF(100, 200));
                return;
            }

            // lewa galka
            float lx = gamepad.LeftThumbX / 32768f;
            float ly = gamepad.LeftThumbY / 32768f;

            Point centerL = new Point(120, 150);
            int radius = 60;

            g.FillEllipse(new SolidBrush(Color.FromArgb(50, 50, 50)),
                centerL.X - radius, centerL.Y - radius, radius * 2, radius * 2);

            g.DrawEllipse(Pens.Gray,
                centerL.X - radius, centerL.Y - radius, radius * 2, radius * 2);

            float dotX = centerL.X + lx * 40;
            float dotY = centerL.Y - ly * 40;

            g.FillEllipse(Brushes.Lime, dotX - 6, dotY - 6, 12, 12);

            // klikniecie lewej galki 
            bool ls = gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb);
            g.FillEllipse(ls ? Brushes.Lime : Brushes.DarkGray, centerL.X - 10, centerL.Y - 10, 20, 20);

            g.DrawString("LS", labelFont, Brushes.White, centerL.X - 10, centerL.Y + 70);

            // prawa galka
            float rx = gamepad.RightThumbX / 32768f;
            float ry = gamepad.RightThumbY / 32768f;

            Point centerR = new Point(350, 200);

            g.FillEllipse(new SolidBrush(Color.FromArgb(50, 50, 50)),
                centerR.X - radius, centerR.Y - radius, radius * 2, radius * 2);

            g.DrawEllipse(Pens.Gray,
                centerR.X - radius, centerR.Y - radius, radius * 2, radius * 2);

            float dotRX = centerR.X + rx * 40;
            float dotRY = centerR.Y - ry * 40;

            g.FillEllipse(Brushes.Cyan, dotRX - 6, dotRY - 6, 12, 12);

            bool rs = gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb);
            g.FillEllipse(rs ? Brushes.Cyan : Brushes.DarkGray, centerR.X - 10, centerR.Y - 10, 20, 20);

            g.DrawString("RS", labelFont, Brushes.White, centerR.X - 10, centerR.Y + 70);

            // triggery
            int lt = gamepad.LeftTrigger;
            int rt = gamepad.RightTrigger;

            g.DrawString("LT", labelFont, Brushes.White, 80, 30);
            g.FillRectangle(Brushes.Lime, 80, 50, 20, lt);

            g.DrawString("RT", labelFont, Brushes.White, 400, 30);
            g.FillRectangle(Brushes.Orange, 400, 50, 20, rt);

            // dpad
            int dpx = 100;
            int dpy = 300;

            bool up = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
            bool down = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
            bool left = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
            bool right = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);

            Brush active = Brushes.Lime;
            Brush inactive = Brushes.DimGray;

            g.FillRectangle(up ? active : inactive, dpx + 20, dpy, 20, 20);
            g.FillRectangle(down ? active : inactive, dpx + 20, dpy + 40, 20, 20);
            g.FillRectangle(left ? active : inactive, dpx, dpy + 20, 20, 20);
            g.FillRectangle(right ? active : inactive, dpx + 40, dpy + 20, 20, 20);

            g.DrawString("D-PAD", labelFont, Brushes.White, dpx, dpy + 70);

            // bumpery
            bool lb = gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder);
            bool rb = gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder);

            g.FillRectangle(lb ? Brushes.Lime : Brushes.Gray, 80, 90, 80, 10);
            g.FillRectangle(rb ? Brushes.Lime : Brushes.Gray, 320, 90, 80, 10);

            // przyciski ABXY
            DrawButton(g, 400, 300, "A", gamepad.Buttons.HasFlag(GamepadButtonFlags.A), Color.Lime);
            DrawButton(g, 440, 280, "B", gamepad.Buttons.HasFlag(GamepadButtonFlags.B), Color.Red);
            DrawButton(g, 360, 280, "X", gamepad.Buttons.HasFlag(GamepadButtonFlags.X), Color.Blue);
            DrawButton(g, 400, 260, "Y", gamepad.Buttons.HasFlag(GamepadButtonFlags.Y), Color.Yellow);
        }

        private void DrawButton(Graphics g, int x, int y, string label, bool pressed, Color color)
        {
            Brush brush = pressed ? new SolidBrush(color) : Brushes.Gray;

            g.FillEllipse(brush, x, y, 30, 30);
            g.DrawEllipse(Pens.Black, x, y, 30, 30);

            g.DrawString(label, new Font("Segoe UI", 9, FontStyle.Bold),
                Brushes.Black, x + 8, y + 6);
        }
    }
}
