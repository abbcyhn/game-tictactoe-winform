using obj.abstracts;
using System.Drawing;

namespace obj.impl
{
    class FigureO: AFigure
    {
        public FigureO(string name, Color line_color, float line_width) : base(name, line_color, line_width){}
        public override void Draw(Graphics graphics, Point mouse)
        {
            base.Draw(graphics, mouse);
            //dairənin_koordinatları_genişliyi_və_hündürlüyü
            int x1 = Board.Width / Board.ROW / 10,
                y1 = Board.Height / Board.COLUMN / 10,
                width = (Board.Width / Board.ROW) - (Board.Width / Board.ROW / 5) - 5,
                height = (Board.Height / Board.COLUMN) - (Board.Height / Board.COLUMN / 5) - 5;
            //graphics.DrawEllipse(new Pen(Line_Color, Line_Width), x + x1, y + y1, width, height);
            graphics.DrawEllipse(new Pen(Line_Color, Line_Width), new Rectangle(x + x1, y + y1, width, height));
            graphics.FillEllipse(new SolidBrush(Line_Color), new Rectangle(x + x1, y + y1, width, height));
        }

        public override void Draw(Graphics graphics, int panelWidth, int panelHeight)
        {
            int x1 = panelWidth / 10,
                y1 = panelHeight / 10,
                width = panelWidth - panelWidth / 5 - 5,
                height = panelHeight - panelHeight / 5 - 5;
            //graphics.DrawEllipse(new Pen(Line_Color, Line_Width), x1, y1, width, height);
            //graphics.FillEllipse(new SolidBrush(Line_Color), new Rectangle(x1, y1, width, height));
      
        }
    }
}