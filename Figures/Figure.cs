using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FLib
{
    public struct Counters
    {
        public static int ellipseC { get; set; } = 0;
        public static int rectC { get; set; } = 0;
        public static int circleC { get; set; } = 0;
        public static int squareC { get; set; } = 0;
        public static int polyC { get; set; } = 0;

        public static int triC { get; set; } = 0;
        public static int kfC { get; set; } = 0;
        public static void Reset()
        {
            ellipseC = 0;
            rectC = 0;
            circleC = 0;
            squareC = 0;
            polyC = 0;
            triC = 0;
            kfC = 0;
        }
    }
    public abstract class Figure
    {
        public PictureBox pictureBox;
        public Bitmap bitmap;
        public Pen pen = new Pen(Color.Black, 3);
        public Pen penC = new Pen(Color.Red, 3);
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string Name { get; set; }
        public Figure(PictureBox p, Bitmap b)
        {
            x = 0;y = 0;width = 0;height = 0;
            pictureBox = p;
            bitmap = b;
            Flist.figures.Add(this);
        }
        public Figure(int x, int y, int w, int h, PictureBox p, Bitmap b)
        {
            this.x = x;     this.y = y;
            this.width = w; this.height = h;
            pictureBox = p;
            bitmap = b;
            Flist.figures.Add(this);
        }
        abstract public void Draw(Pen p);
        public void MoveTo(int x, int y)
        {
            if (!((y < 0) || (y + height > pictureBox.Height) || (x < 0) || (x + width > pictureBox.Width)))
            {
                this.x = x; this.y = y;
                DeleteF(this, false);
                Draw(penC);
            }
            else throw new Exception("Ошибка границ");
        }
        public void DeleteF(Figure figure, bool flag)
        {
            int index = 0;
            if(flag == true)
            {
                Flist.figures.Remove(figure);
                Clear();
                foreach (Figure f in Flist.figures)
                {
                    f.Draw(pen);
                }
                pictureBox.Image = bitmap;
            }
            else
            {
                index = Flist.figures.IndexOf(figure);
                Flist.figures.Remove(figure);
                Clear();
                foreach (Figure f in Flist.figures)
                {
                    f.Draw(pen);
                }
                Flist.figures.Insert(index, figure);
                pictureBox.Image = bitmap;
            }
        }
        public void Clear()
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            pictureBox.Image = bitmap;
        }
        //выделить
        public static void Select(Figure f)
        {
            f.DeleteF(f, false);
            f.Draw(f.penC);
        }
        //снять выделение
        public static void RemoveSelect(Figure f)
        {
            f.DeleteF(f, false);
            f.Draw(f.pen);
        }
    }
}
