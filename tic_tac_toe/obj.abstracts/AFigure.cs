using obj.impl;
using obj.interfaces;
using System.Drawing;

namespace obj.abstracts
{
    abstract class AFigure : IFigure
    {
        protected int x = 0;
        protected int y = 0;

        private string name;        //fiqurun_adı__vəya__cari_fiqur_ilə_oynayan_oyunçunun_adı
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Color line_color;   //fiqurun_rəngi
        public Color Line_Color
        {
            get { return line_color; }
            set { line_color = value; }
        }

        private float line_width;   //fiqurun_qalınlığı
        public float Line_Width
        {
            get { return line_width; }
            set { line_width = value; }
        }

        public AFigure(string name, Color line_color, float line_width)
        {
            this.name = name;
            this.line_color = line_color;
            this.line_width = line_width;
        }
        public virtual void Draw(Graphics graphics, Point mouse)
        {
            x = mouse.X * Board.Width / Board.ROW;
            y = mouse.Y * Board.Height / Board.COLUMN;
        }
        public virtual void Draw(Graphics graphics, int panelWidth, int panelHeight) { }
    }
}