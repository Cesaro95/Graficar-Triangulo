using Graficar_Triangulo.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graficar_Triangulo
{
    public partial class Form1 : Form
    {
        Triangulo triangulo;
        int cont = 0;
        Random myObject = new Random();
        private int ranNum;

        public Form1()
        {
            InitializeComponent();
            triangulo = new Triangulo(tbx_x1, tbx_x2, tbx_x3, tbx_y1, tbx_y2, tbx_y3, tbx_rotar, pictureBox);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int xcentro = pictureBox.Width / 2;
            int ycentro = pictureBox.Height / 2;
            Pen lapiz = new Pen(Color.White, 2);
            e.Graphics.TranslateTransform(xcentro, ycentro);
            e.Graphics.ScaleTransform(1, -1); //convertimos a coordenadas normales

            //DIBUJAMOS EJES X-Y
            //LINEA HORIZONTAL
            e.Graphics.DrawLine(lapiz, xcentro * -1, 0, xcentro * 2, 0); // eje X
            //LINEA HORIZONTAL
            e.Graphics.DrawLine(lapiz, 0, ycentro, 0, ycentro * -1); // eje Y
            lapiz.Color = Color.Blue;
            //CICLO FOR QUE GRAFICARA LAS LINEAS QUE RECORRERAN LAS
            //LINEAS HORIZONTAL Y VERTICAL
            lapiz = new Pen(Color.Blue, 0.5f);
            for (int i = -xcentro; i < xcentro; i += 50)
            {
                //lineas para linea vertical
                //punto -y
                e.Graphics.DrawLine(lapiz, 600, i, -600, i);
                //lineas para linea horizontal
                //punto x
                e.Graphics.DrawLine(lapiz, i, 600, i, -600);
            }
            lapiz = new Pen(Color.Red, 2);
            e.Graphics.DrawLine(lapiz, xcentro * -1, 0, xcentro * 2, 0); // eje X
            //LINEA HORIZONTAL
            e.Graphics.DrawLine(lapiz, 0, ycentro, 0, ycentro * -1); // eje Y
        }

        private void btn_dibujar_Click(object sender, EventArgs e)
        {
            triangulo.Graficar();
        }

        private void btn_rotar_Click(object sender, EventArgs e)
        {
            triangulo.rotarTriangulo();
        }

        private void btn_girar_Click(object sender, EventArgs e)
        {
            timer1.Start();
            ranNum = myObject.Next(0, 6);
        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            triangulo.borrar();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            triangulo.girarTriangulo(ranNum);
            if (cont == 72)
            {
                timer1.Stop();
                cont = 0;
            }
            cont++;
        }
    }
}
