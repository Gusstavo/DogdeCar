using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Car
{
    class Grafico
    {
        private int x_tela, y_tela;
        private PictureBox tela;
        private Bitmap bitmap, comprida;
        private string path;

        public object Controls { get; internal set; }

        public Grafico(PictureBox picturebox)
        {
            tela = picturebox;
            x_tela = tela.Width;
            y_tela = tela.Height;
            path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

            bitmap = new Bitmap(x_tela, y_tela);
            comprida = new Bitmap(path + "img\\Comprida.png");
        }

        public void Desenha(string nome, int posX, int posY, int posX2, int posY2)
        {
            Graphics gra = Graphics.FromImage(bitmap);
            comprida = new Bitmap(path + "img\\" + nome + ".png");
            gra.DrawImage(comprida, posX, posY, posX2, posY2);
            tela.Image = bitmap;
        }

        public void Desenha(Bitmap comprida, int posX, int posY, int posX2, int posY2)
        {
            Graphics gra = Graphics.FromImage(bitmap);
            gra.DrawImage(comprida, posX, posY, posX2, posY2);
            tela.Image = bitmap;
        }

        public void LimpaTela()
        {
            Graphics gra = Graphics.FromImage(bitmap);
            SolidBrush brush = new SolidBrush(Color.ForestGreen);
            gra.FillRectangle(brush, 0, 0, x_tela, y_tela);
            tela.Image = bitmap;
        }

        public void Escreve(string texto, Color cor, FontStyle fontsy, float fs, int posX, int posY)
        {
            Graphics gra = Graphics.FromImage(bitmap);
            Pen pen = new Pen(cor);
            SolidBrush brush = new SolidBrush(cor);
            Font font = new System.Drawing.Font("Microsoft Sans Serif", fs, fontsy, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gra.DrawString(texto, font, brush, posX, posY);
        }

        public Bitmap Rotacionar(Bitmap bitm)
        {
            bitm.RotateFlip(RotateFlipType.Rotate180FlipX);
            return bitm;
        }

        public Bitmap RetornaBitmapa(string nome)
        {
            return new Bitmap(path + "img\\" + nome + ".png");
        }

        public Bitmap Torto(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            //move rotation point to center of image
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            g.RotateTransform(angle, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
            g.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
            return returnBitmap;
        }

        public void testeTorto(string nome, int x, int y, int x1, int y1)
        {
            Graphics gra = Graphics.FromImage(bitmap);
            comprida = new Bitmap(path + "img\\" + nome + ".png");
            gra.DrawImage(Torto(comprida,30), x, y, x1, y1);
            tela.Image = bitmap;
        }

        public int Get_X()
        {
            return x_tela;
        }
        public int Get_Y()
        {
            return y_tela;
        }
    }
}
