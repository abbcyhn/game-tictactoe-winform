using obj.abstracts;
using System.Drawing;

namespace obj.impl
{
    class FigureX: AFigure
    {
        public FigureX(string name, Color line_color, float line_width) : base(name, line_color, line_width){}

        public override void Draw(Graphics graphics, Point mouse)
        {
            base.Draw(graphics, mouse);

            //birinci_xəttrin_koordinatları
            int x1 = Board.Width / Board.ROW / 10,
                y1 = Board.Height / Board.COLUMN / 10,
                x2 = (Board.Width / Board.ROW) - (Board.Width / Board.ROW / 5),
                y2 = (Board.Height / Board.COLUMN) - (Board.Height / Board.COLUMN / 5);

            //ikinci_xəttin_koordinatları
            int x3 = (Board.Width / Board.ROW) - (Board.Width / Board.ROW / 5),
                y3 = Board.Height / Board.COLUMN / 10,
                x4 = Board.Width / Board.ROW / 10,
                y4 = (Board.Height / Board.COLUMN) - (Board.Height / Board.COLUMN / 5);


            graphics.DrawLine(new Pen(Line_Color, Line_Width), x + x1, y + y1, x + x2, y + y2);
            graphics.DrawLine(new Pen(Line_Color, Line_Width), x + x3, y + y3, x + x4, y + y4);
        }

        public override void Draw(Graphics graphics, int panelWidth, int panelHeight)
        {
            //birinci_xəttrin_koordinatları
            int x1 = panelWidth / 10,
                y1 = panelHeight / 10,
                x2 = panelWidth - panelWidth / 5,
                y2 = panelHeight - panelHeight / 5;

            //ikinci_xəttin_koordinatları
            int x3 = panelWidth - panelWidth / 5,
                y3 = panelHeight / 10,
                x4 = panelWidth / 10,
                y4 = panelHeight - panelHeight / 5;


            graphics.DrawLine(new Pen(Line_Color, Line_Width), x1, y1, x2, y2);
            graphics.DrawLine(new Pen(Line_Color, Line_Width), x3, y3, x4, y4);
        }
    }
}