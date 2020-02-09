using enums;
using obj.abstracts;
using System.Drawing;

namespace obj.impl
{
    class Board
    {
        private Color bg_color;             //arxafon_rəngi
        public Color Bg_Color
        {
            get { return bg_color; }
            set { bg_color = value; }
        }

        private Color line_color;           //xəttin_rəngi
        public Color Line_Color
        {
            get { return line_color; }
            set { line_color = value; }
        }

        private float line_width;           //xəttin_qalınlığı
        public float Line_Width
        {
            get { return line_width; }
            set { line_width = value; }
        }

        public static int Width;            //lövhənin_genişliyi
        public static int Height;           //lövhənin_uzunluğu
        public const int ROW = 3;           //sətirlərin_sayı
        public const int COLUMN = 3;        //sütunların_sayı
        public static Figures[,] Holders;   //xanaları_indeksləmək_üçün


        public Board(int width, int height) : this(width, height, Color.Yellow, Color.White, 5) { }
        public Board(int width, int height, Color bg_color, Color line_color, float line_width )
        {
            Width = width;
            Height = height;
            this.bg_color = bg_color;
            this.line_color = line_color;
            this.line_width = line_width;
            Holders = new Figures[ROW, COLUMN];
            for (int x = 0; x < ROW; x++)
                for (int y = 0; y < COLUMN; y++)
                    Holders[x, y] = Figures.B;
        }
        public void Draw(Graphics graphics)
        {
            /* yuxarıdan_aşağıya_çəkilən_birinci_xəttin_koordinatları */
            int x1 = Width / ROW,
                y1 = 0,
                x2 = Width / ROW,
                y2 = Height;

            /* yuxarıdan_aşağıya_çəkilən_ikinci_xəttin_koordinatları */
            int x3 = Width / ROW * (ROW - 1),
                y3 = 0,
                x4 = Width / ROW * (ROW - 1),
                y4 = Height;

            /* soldan_sağa_çəkilən_birinci_xəttin_koordinatları */
            int x5 = 0,
                y5 = Height / COLUMN,
                x6 = Width,
                y6 = Height / COLUMN;

            /* soldan_sağa_çəkilən_ikinci_xəttin_koordinatları */
            int x7 = 0,
                y7 = Height - Height / COLUMN,
                x8 = Width,
                y8 = Height - Height / COLUMN;


            graphics.FillRectangle(new SolidBrush(bg_color), 0, 0, Width, Height);  //arxafon_çəkilir
            Pen pen = new Pen(new SolidBrush(line_color), line_width);              //xətlərin_qalığını_və_rəngi_hazırlanır
            graphics.DrawLine(pen, x1, y1, x2, y2);                                 //yuxarıdan_aşağıya_birinci_xətt_çəkilir
            graphics.DrawLine(pen, x3, y3, x4, y4);                                 //yuxarıdan_aşağıya_ikinci_xətt_çəkilir
            graphics.DrawLine(pen, x5, y5, x6, y6);                                 //soldan_sağa_birinci_xətt_çəkilir
            graphics.DrawLine(pen, x7, y7, x8, y8);                                 //soldan_sağa_ikinci_xətt_çəkilir
        }
    }
}