using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graficar_Triangulo.clases
{
    public class Triangulo
    {
        private Pen lapiz;
        private Graphics vector;
        private TextBox tbx_x1, tbx_x2, tbx_x3, tbx_y1, tbx_y2, tbx_y3, tbx_rotar;
        private PictureBox pictureBox;

        Color[] paleta = { Color.Red, Color.Purple, Color.DarkGreen, Color.LightBlue, Color.GreenYellow, Color.Orange, Color.Blue};
        
        

        private double x1, y1, x2, y2;
        private int xcentro, ycentro;
        private double atan, atan1, atan2, b, b1, c, c1, d, d1, an, an1, an2, fx, fx1, fx2, fy, fy1, fy2,
            g, g1, g2, j, j1, j2, sqrt, sqrt1, sqrt2, z, z1, calc;
        public Triangulo(TextBox tbx_x1, TextBox tbx_x2, TextBox tbx_x3, TextBox tbx_y1,
                            TextBox tbx_y2, TextBox tbx_y3, TextBox tbx_rotar, PictureBox pictureBox)
        {
            this.tbx_x1 = tbx_x1;
            this.tbx_x2 = tbx_x2;
            this.tbx_x3 = tbx_x3;
            this.tbx_y1 = tbx_y1;
            this.tbx_y2 = tbx_y2;
            this.tbx_y3 = tbx_y3;
            this.tbx_rotar = tbx_rotar;
            this.pictureBox = pictureBox;
            
            lapiz = new Pen(Color.Black, 2);
            xcentro = pictureBox.Width / 2;
            ycentro = pictureBox.Height / 2;
        }
        public void Graficar()
        {
            if(tbx_x1.Text.Replace(" ","") == "")
            {
                tbx_x1.Focus();
                return;
            }else if (tbx_x2.Text.Replace(" ", "") == "")
            {
                tbx_x2.Focus();
                return;
            }
            else if (tbx_x3.Text.Replace(" ", "") == "")
            {
                tbx_x3.Focus();
                return;
            }
            else if (tbx_y1.Text.Replace(" ", "") == "")
            {
                tbx_y1.Focus();
                return;
            }
            else if (tbx_y2.Text.Replace(" ", "") == "")
            {
                tbx_y2.Focus();
                return;
            }
            else if (tbx_y3.Text.Replace(" ", "") == "")
            {
                tbx_y3.Focus();
                return;
            }
            else
            {
                Dibujar();
            }
        }
        private void Dibujar()
        {
            b = Convert.ToDouble(tbx_x1.Text);
            c = Convert.ToDouble(tbx_y1.Text);
            b1 = Convert.ToDouble(tbx_x2.Text);
            c1 = Convert.ToDouble(tbx_y2.Text);
            d = Convert.ToDouble(tbx_x3.Text);
            d1 = Convert.ToDouble(tbx_y3.Text);

            x1 = Convert.ToDouble(xcentro) + Convert.ToDouble(tbx_x1.Text);
            y1 = Convert.ToDouble(ycentro) - Convert.ToDouble(tbx_y1.Text);
            x2 = Convert.ToDouble(xcentro) + Convert.ToDouble(tbx_x2.Text);
            y2 = Convert.ToDouble(ycentro) - Convert.ToDouble(tbx_y2.Text);
            z = Convert.ToDouble(xcentro) + Convert.ToDouble(tbx_x3.Text);
            z1 = Convert.ToDouble(ycentro) - Convert.ToDouble(tbx_y3.Text);

            vector = pictureBox.CreateGraphics();
            lapiz = new Pen(Color.Black);
            lapiz.Color = Color.Orange;

            vector.DrawLine(lapiz, Convert.ToInt32(x1), Convert.ToInt32(y1), Convert.ToInt32(x2), Convert.ToInt32(y2));

            vector.DrawLine(lapiz, Convert.ToInt32(x2), Convert.ToInt32(y2), Convert.ToInt32(z), Convert.ToInt32(z1));

            vector.DrawLine(lapiz, Convert.ToInt32(z), Convert.ToInt32(z1), Convert.ToInt32(x1), Convert.ToInt32(y1));

            lapiz.Dispose();
            vector.Dispose();
        }
        private void trigonometria(int valor)
        {
            atan = Math.Atan((c) / (b));
            an = (atan * 180) / Math.PI;
            sqrt = Math.Sqrt((Math.Pow((b), 2)) + (Math.Pow((c), 2)));
            if (valor == 1)
            {
                g = an + Convert.ToDouble(tbx_rotar.Text);
            }
            else
            {
                g = an + calc;
            }
            j = Math.PI * g / 180;
            fx = (sqrt) * (Math.Cos(j));
            fy = (sqrt) * (Math.Sin(j));

            //--------------------------------------
            atan1 = Math.Atan((c1) / (b1));
            an1 = (atan1 * 180) / Math.PI;
            sqrt1 = Math.Sqrt((Math.Pow((b1), 2)) + (Math.Pow((c1), 2)));
            if (valor == 1)
            {
                g1 = an1 + Convert.ToDouble(tbx_rotar.Text);
            }
            else
            {
                g1 = an1 + calc;
            }
            j1 = Math.PI * g1 / 180;
            fx1 = (sqrt1) * (Math.Cos(j1));
            fy1 = (sqrt1) * (Math.Sin(j1));

            //--------------------------------------
            atan2 = Math.Atan((d1) / (d));
            an2 = (atan2 * 180) / Math.PI;
            sqrt2 = Math.Sqrt((Math.Pow((d), 2)) + (Math.Pow((d1), 2)));
            if (valor == 1)
            {
                g2 = an2 + Convert.ToDouble(tbx_rotar.Text);
            }
            else
            {
                g2 = an2 + calc;
            }
            j2 = Math.PI * g2 / 180;
            fx2 = (sqrt2) * (Math.Cos(j2));
            fy2 = (sqrt2) * (Math.Sin(j2));
        }
        public void rotarTriangulo()
        {
            if(tbx_rotar.Text == "")
            {
                tbx_rotar.Focus();
            }
            else
            {
                trigonometria(1);
                lapiz = new Pen(Color.Black, 1);
                vector = pictureBox.CreateGraphics();
                lapiz.Color = Color.BlueViolet;
                vector.DrawLine(lapiz, xcentro + Convert.ToInt32(fx), ycentro - Convert.ToInt32(fy),
                    xcentro+Convert.ToInt32(fx1), ycentro - Convert.ToInt32(fy1));

                vector.DrawLine(lapiz, xcentro + Convert.ToInt32(fx1), ycentro - Convert.ToInt32(fy1),
                    xcentro + Convert.ToInt32(fx2), ycentro - Convert.ToInt32(fy2));

                vector.DrawLine(lapiz, xcentro + Convert.ToInt32(fx2), ycentro - Convert.ToInt32(fy2),
                    xcentro + Convert.ToInt32(fx), ycentro - Convert.ToInt32(fy));

                lapiz.Dispose();
                vector.Dispose();
            }
        }
        public void girarTriangulo(int ranNum)
        {
            calc = calc + 5;
            trigonometria(2);
            lapiz = new Pen(Color.Black, 1);
            vector = pictureBox.CreateGraphics();
            lapiz.Color = paleta[ranNum];
            vector.DrawLine(lapiz, xcentro + Convert.ToInt32(fx), ycentro - Convert.ToInt32(fy),
                   xcentro + Convert.ToInt32(fx1), ycentro - Convert.ToInt32(fy1));

            vector.DrawLine(lapiz, xcentro + Convert.ToInt32(fx1), ycentro - Convert.ToInt32(fy1),
                xcentro + Convert.ToInt32(fx2), ycentro - Convert.ToInt32(fy2));

            vector.DrawLine(lapiz, xcentro + Convert.ToInt32(fx2), ycentro - Convert.ToInt32(fy2),
                xcentro + Convert.ToInt32(fx), ycentro - Convert.ToInt32(fy));

            

            lapiz.Dispose();
            vector.Dispose();
        }

        public void borrar()
        {
            pictureBox.Image = null;
            lapiz = new Pen(Color.Black, 1);
            //pictureBox.Image = global::Graficar_Triangulo.Properties.Resources.papel;
            vector = pictureBox.CreateGraphics();
            vector.TranslateTransform(xcentro, ycentro);
            vector.ScaleTransform(1, -1);

            //DIBUJAMOS EJES X-Y
            //LINEA HORIZONTAL
            vector.DrawLine(lapiz, xcentro * -1, 0, xcentro * 2, 0); // eje X
            //LINEA HORIZONTAL
            vector.DrawLine(lapiz, 0, ycentro, 0, ycentro * -1); // eje Y
            //CICLO FOR QUE GRAFICARA LAS LINEAS QUE RECORRERAN LAS
            //LINEAS HORIZONTAL Y VERTICAL
            for (int i = -xcentro; i < xcentro; i += 8)
            {
                //lineas para linea vertical
                //punto -y
                vector.DrawLine(lapiz, 5, i, -5, i);
                //lineas para linea horizontal
                //punto x
                vector.DrawLine(lapiz, i, 5, i, -5);
            }
        }
    }
}
