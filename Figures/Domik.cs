using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FLib
{
    public class Domik : Figure
    {
        private Triangle roof;
        private Poly pipe;
        private Rectangle mainBody;
        private Square window;
        public Domik(int x, int y, int w, int h, PictureBox picture, Bitmap bitmap) : base(picture, bitmap)
        {
            this.x = x;
            this.y = y;
            this.width = w;
            this.height = h;
            this.pictureBox = picture;
            this.bitmap = bitmap;
            roof = new Triangle(picture, bitmap, new Point[3] { new Point(x, y + h / 3), new Point(x + w / 2, y), new Point(x + w, y + h / 3)});
            pipe = new Poly(picture, bitmap, new Point[] { new Point(x + w * 6 / 10, y), new Point(x + w * 7 / 10, y), new Point(x + w * 7 / 10, y + 4 * h / 3 / 10), new Point(x + w * 6 / 10, y + 2 * h / 3 / 10) });
            mainBody = new Rectangle(x, y + h / 3, w, h * 2 / 3, picture, bitmap);
            if (width > height) window = new Square(x + width / 3, y + height / 3 + height / 6, height / 3, pictureBox, bitmap);
            else if (height > width) window = new Square(x + width / 3, y + height / 3 + height / 6, width / 3, pictureBox, bitmap);
            else if (height == width) window = new Square(x + width / 3, y + height / 3 + height / 6, width / 3, pictureBox, bitmap);
            Flist.figures.Remove(roof);
            Flist.figures.Remove(pipe);
            Flist.figures.Remove(mainBody);
            Flist.figures.Remove(window);
            Counters.triC--;
            Counters.polyC--;
            Counters.rectC--;
            Counters.squareC--;
            Name = "Домик " + ++Counters.kfC;
        }
        public override void Draw(Pen p)
        {
            roof.Draw(p);
            pipe.Draw(p);
            mainBody.Draw(p);
            window.Draw(p);
            pictureBox.Image = bitmap;
        }
        public void MoveDom(int x, int y)
        {
            if (!((y < 0) || (y + height > pictureBox.Height) || (x < 0) || (x + width > pictureBox.Width)))
            {
                this.x = x;
                this.y = y;
                roof = new Triangle(pictureBox, bitmap, new Point[3] { new Point(x, y + height / 3), new Point(x + width / 2, y), new Point(x + width, y + height / 3) });
                pipe = new Poly(pictureBox, bitmap, new Point[] { new Point(x + width * 6 / 10, y), new Point(x + width * 7 / 10, y), new Point(x + width * 7 / 10, y + 4 * height / 3 / 10), new Point(x + width * 6 / 10, y + 2 * height / 3 / 10) });
                mainBody = new Rectangle(x, y + height / 3, width, height * 2 / 3, pictureBox, bitmap);
                if (width > height) window = new Square(x + width / 3, y + height / 3 + height / 6, height / 3, pictureBox, bitmap);
                else if (height > width) window = new Square(x + width / 3, y + height / 3 + height / 6, width / 3, pictureBox, bitmap);
                else if (height == width) window = new Square(x + width / 3, y + height / 3 + height / 6, width / 3, pictureBox, bitmap);
                Flist.figures.Remove(roof);
                Flist.figures.Remove(pipe);
                Flist.figures.Remove(mainBody);
                Flist.figures.Remove(window);
                Counters.triC--;
                Counters.polyC--;
                Counters.rectC--;
                Counters.squareC--;
                DeleteF(this, false);
                Draw(penC);
            }
            else throw new Exception("Нарушены границы");
        }
        public void ChangeSizeTo(int w, int h)
        {
            if (!((y < 0) || (y + h > pictureBox.Height) || (x < 0) || (x + w > pictureBox.Width)))
            {
                width = w; height = h;
                roof = new Triangle(pictureBox, bitmap, new Point[3] { new Point(x, y + height / 3), new Point(x + width / 2, y), new Point(x + width, y + height / 3) });
                pipe = new Poly(pictureBox, bitmap, new Point[] { new Point(x + width * 6 / 10, y), new Point(x + width * 7 / 10, y), new Point(x + width * 7 / 10, y + 4 * height / 3 / 10), new Point(x + width * 6 / 10, y + 2 * height / 3 / 10) });
                mainBody = new Rectangle(x, y + height / 3, width, height * 2 / 3, pictureBox, bitmap);
                if(width > height) window = new Square(x + width / 3, y + height / 3 + height / 6, height / 3, pictureBox, bitmap);
                else if(height < width) window = new Square(x + width / 3, y + height / 3 + height / 6, width / 3, pictureBox, bitmap);
                else if(height == width) window = new Square(x + width / 3, y + height / 3 + height / 6, width / 3, pictureBox, bitmap);
                Flist.figures.Remove(roof);
                Flist.figures.Remove(pipe);
                Flist.figures.Remove(mainBody);
                Flist.figures.Remove(window);
                Counters.triC--;
                Counters.polyC--;
                Counters.rectC--;
                Counters.squareC--;
                DeleteF(this, false);
                Draw(penC);
            }
            else throw new Exception("Ошибка границ");
        }
    }
}
