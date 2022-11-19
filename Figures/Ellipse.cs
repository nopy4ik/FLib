using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace FLib
{
    public class Ellipse : Figure
    {
        public Ellipse(PictureBox p, Bitmap b) : base(p, b)
        {
            Name = "Эллипс " + ++Counters.ellipseC;
        }
        public Ellipse(int x, int y, int w, int h, PictureBox pictureBox, Bitmap b) : base(x, y, w, h, pictureBox, b)
        {
            Name = "Эллипс " + ++Counters.ellipseC;
        }
        //рисуем эллипс
        public override void Draw(Pen p)
        {
            if (!((y < 0) || (y + height > pictureBox.Height) || (x < 0) || (x + width > pictureBox.Width)))
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawEllipse(p, x, y, width, height);
                pictureBox.Image = bitmap;
            }
            else throw new Exception("Ошибка границ");
        }
        //изменить размер эллипса
        public void ChangeSizeTo(int w, int h)
        {
            if (!((y < 0) || (y + h > pictureBox.Height) || (x < 0) || (x + w > pictureBox.Width)))
            {
                width = w; height = h;
                DeleteF(this, false);
                Draw(penC);
            }
            else throw new Exception("Ошибка границ");
        }
    }
}
