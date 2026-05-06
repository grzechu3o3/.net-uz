using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zadanie04_1_2
{
    public class ZegarControl : Control
    {
        private Timer _timer;

        public ZegarControl()
        {
            this.DoubleBuffered = true; // Zapobiega mruganiu
            this.Width = 200;
            this.Height = 250;

            // Konfiguracja Timera
            _timer = new Timer();
            _timer.Interval = 1000; // 1000 milisekund = 1 sekunda
            // Co sekundę odświeżamy kontrolkę (wywołujemy OnPaint)
            _timer.Tick += (s, e) => this.Invalidate();
            _timer.Start();
        }

        // Kiedy zmieniasz rozmiar okna/kontrolki, przerysuj od nowa
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Ładne rysowanie

            // Pobieramy aktualny czas z systemu
            DateTime now = DateTime.Now;

            // --- WYLICZANIE ROZMIARÓW ---
            int padding = 10; // Odstęp od krawędzi
            int digitalHeight = 40; // Miejsce na zegar cyfrowy na dole

            // Średnica tarczy to mniejsza z wartości: szerokość albo wysokość minus miejsce na tekst
            int faceDiameter = Math.Min(this.Width, this.Height - digitalHeight) - (2 * padding);
            if (faceDiameter < 10) return; // Zabezpieczenie przed błędem gdy ktoś zrobi kontrolkę na 1 piksel

            int centerX = this.Width / 2;
            int centerY = padding + (faceDiameter / 2);

            // --- 1. ZEGAR ANALOGOWY (Tradycyjny) ---

            // Rysowanie tarczy (białe koło z czarną ramką)
            g.FillEllipse(Brushes.White, centerX - (faceDiameter / 2), centerY - (faceDiameter / 2), faceDiameter, faceDiameter);
            g.DrawEllipse(new Pen(Color.Black, 2), centerX - (faceDiameter / 2), centerY - (faceDiameter / 2), faceDiameter, faceDiameter);

            // Długość wskazówek
            int secLength = (int)(faceDiameter / 2 * 0.85); // Najdłuższa (85% promienia)
            int minLength = (int)(faceDiameter / 2 * 0.70); // Średnia (70% promienia)
            int hourLength = (int)(faceDiameter / 2 * 0.50); // Najkrótsza (50% promienia)

            // Kąty wskazówek (w radianach). Odejmujemy Math.PI / 2, żeby godzina 12:00 była na górze (a nie po prawej stronie osi)
            double secAngle = (now.Second / 60.0) * 2 * Math.PI - Math.PI / 2;
            double minAngle = (now.Minute / 60.0) * 2 * Math.PI - Math.PI / 2;
            // Kąt dla godzin uwzględnia też upływające minuty (żeby wskazówka była w połowie między godzinami w pół do)
            double hourAngle = ((now.Hour % 12 + now.Minute / 60.0) / 12.0) * 2 * Math.PI - Math.PI / 2;

            // Rysowanie wskazówki GODZIN
            int hX = centerX + (int)(hourLength * Math.Cos(hourAngle));
            int hY = centerY + (int)(hourLength * Math.Sin(hourAngle));
            g.DrawLine(new Pen(Color.Black, 4), centerX, centerY, hX, hY);

            // Rysowanie wskazówki MINUT
            int mX = centerX + (int)(minLength * Math.Cos(minAngle));
            int mY = centerY + (int)(minLength * Math.Sin(minAngle));
            g.DrawLine(new Pen(Color.Black, 2), centerX, centerY, mX, mY);

            // Rysowanie wskazówki SEKUND
            int sX = centerX + (int)(secLength * Math.Cos(secAngle));
            int sY = centerY + (int)(secLength * Math.Sin(secAngle));
            g.DrawLine(new Pen(Color.Red, 1), centerX, centerY, sX, sY);

            // Mała kropka na środku tarczy, żeby ładnie ukryć łączenie wskazówek
            g.FillEllipse(Brushes.Black, centerX - 4, centerY - 4, 8, 8);


            // --- 2. ZEGAR CYFROWY ---

            // Formatowanie czasu (np. 14:05:30)
            string timeText = now.ToString("HH:mm:ss");

            // Tworzenie czcionki do cyfrowego wyświetlacza
            using (Font f = new Font("Segoe UI", 16, FontStyle.Bold))
            {
                // Mierzymy ile miejsca zajmie ten tekst, żeby go idealnie wyśrodkować
                SizeF textSize = g.MeasureString(timeText, f);

                float textX = (this.Width - textSize.Width) / 2;
                float textY = centerY + (faceDiameter / 2) + padding; // Piszemy pod tarczą

                // Rysujemy napis
                g.DrawString(timeText, f, Brushes.DarkBlue, textX, textY);
            }
        }

        // Trzeba posprzątać Timera, gdy zamykamy okno
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_timer != null))
            {
                _timer.Stop();
                _timer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}