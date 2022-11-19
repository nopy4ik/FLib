using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FLib
{
    public class Square : Rectangle
    {
        public Square(PictureBox p, Bitmap b) : base(p,b)
        {
            Name = "Квадрат " + ++Counters.squareC;
        }
        public Square(int x, int y, int w, PictureBox pictureBox, Bitmap b) : base(x, y, w, w, pictureBox,b)
        {
            Name = "Квадрат " + ++Counters.squareC;
        }
        //рисуем квадрат
        public override void Draw(Pen p)
        {
            if (!((y < 0) || (y + height > pictureBox.Height) || (x < 0) || (x + width > pictureBox.Width)))
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawRectangle(p, x, y, width, width);
                pictureBox.Image = bitmap;
            }
            else throw new Exception("Ошибка границ");
        }
        //изменить размер квадрата
        public void ChangeSizeTo(int w)
        {
            if (!((y < 0) || (y + w > pictureBox.Height) || (x < 0) || (x + w > pictureBox.Width)))
            {
                width = w; height = w;
                DeleteF(this, false);
                Draw(penC);
            }
            else throw new Exception("Ошибка границ");
        }
    }
}
