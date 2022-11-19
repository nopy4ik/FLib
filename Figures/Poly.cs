using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FLib
{
    public class Poly : Figure
    {
        private Point[] points;
        public Poly(PictureBox p, Bitmap b, Point[] points) : base(p, b)
        {
            Name = "Многоугольник " + ++Counters.polyC;
            this.points = points;
        }
        public override void Draw(Pen pen)
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawPolygon(pen, points);
            pictureBox.Image = bitmap;
        }
        public bool AddCord(int x, int y)
        {
            for (int i = 0; i < points.Length; i++)
            {
                try
                {
                    if (((points[i].Y + y < 0) || (points[i].Y + y > pictureBox.Height) || (points[i].X + x < 0) || (points[i].X + x > pictureBox.Width))) throw new Exception("Ошибка границ");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X += x;
                points[i].Y += y;
            }
            DeleteF(this, false);
            Draw(penC);
            return true;
        }
    }
}
