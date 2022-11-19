using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FLib
{
    public class Circle : Ellipse
    {
        public int radius;
        public Circle(PictureBox p, Bitmap b) : base(p,b)
        {
            Name = "Окружность " + ++Counters.circleC;
        }
        public Circle(int x, int y, int r, PictureBox pictureBox, Bitmap b) : base(x, y, r, r, pictureBox,b)
        {
            radius = r;
            Name = "Окружность " + ++Counters.circleC;
        }
        //рисуем круг
        public override void Draw(Pen p)
        {
            if (!((y < 0) || (y + height > pictureBox.Height) || (x < 0) || (x + width > pictureBox.Width)))
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawEllipse(p, x, y, radius*2, radius*2);
                pictureBox.Image = bitmap;
            }
            else throw new Exception("Ошибка границ");
        }
        //изменить радиус круга
        public void ChangeRadiusTo(int r)
        {
            if (!((y < 0) || (y + (2 * r) > pictureBox.Height) || (x < 0) || (x + (2 * r) > pictureBox.Width)))
            {
                radius = r;
                DeleteF(this, false);
                Draw(penC);
            }
            else throw new Exception("Ошибка границ");
        }
    }
}
