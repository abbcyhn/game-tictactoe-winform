using System.Drawing;

namespace obj.interfaces
{
    interface IFigure
    {
        string Name { get; set; }
        Color Line_Color { get; set; }
        float Line_Width { get; set; }
        void Draw(Graphics graphics, Point mouse);
        void Draw(Graphics graphics, int panelWidth, int panelHeight);
    }
}