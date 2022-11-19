using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FLib
{
    public class Triangle : Poly
    {
        private Point[] points;
        public Triangle(PictureBox p, Bitmap b, Point[] points) : base(p, b, points)
        {
            Name = "Треугольник " + ++Counters.triC;
            if (points.Length == 3)
            {
                this.points = points;
            }
            else this.points =  new Point[3] { new Point(0,0), new Point(0, 0), new Point(0, 0)};
        }
    }
}
