using enums;
using obj.impl;
using tic_tac_toe.helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class FormMain : Form
    {
        private Board board;
        private FigureX figureX;
        private FigureO figureO;
        private PlayerMove move;
        private Graphics graphics;

        private DialogResult dialogResult;
        private const string NEW_GAME_QUESTION = "Yenidən oynamaq istəyirsən mi?";
        private const string NEW_GAME_QUESTION_TITLE = "Yeni Oyun";
        private const string WINNER_TEXT = "oyunu qazandı";
        private const string DRAW_TEXT = "Oyun bərabərədir.";

        public FormMain()
        {
            InitializeComponent();
            /***        Obyektlər yaradılır     ***/
            move = PlayerMove.Player1;

            /***        Formların ortaq tənzimləmələri(eyni ikon, eyni yerdə yerləşmələri) hazırlanır       ***/
            this.SetIcon();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            graphics = panel.CreateGraphics();                                              //qrafiki_əməliyyatlar_üçün_graphics_obyekti yaradılır
            board = new Board(panel.Width, panel.Height, Color.Bisque, Color.Azure, 5);     //oyun_lövhəsi_yaradılır
            figureX = new FigureX("X", Color.Red, 5);                                       //x_obyekti_yaradılır
            figureO = new FigureO("O", Color.Blue, 5);                                      //o_obyekti_yaradılır

            board.Draw(graphics);                          //lövhə_panelin_üzərinə_çəkilir
        }
        private void panel_Click(object sender, EventArgs e)
        {
            Point mouse = Cursor.Position;
            mouse = panel.PointToClient(mouse);
            Play(DetectHits(mouse));
        }

        private void RestartGame()
        {
            dialogResult = MessageBox.Show(NEW_GAME_QUESTION, NEW_GAME_QUESTION_TITLE, MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
                Application.Restart();
        }
        private void Play(int[] coordinate)
        {
            int x = coordinate[0];
            int y = coordinate[1];
            Point mouse = new Point(x, y);

            if (move == PlayerMove.Player1 &&
                Board.Holders[x, y] == Figures.B)
            {
                figureX.Draw(graphics, mouse);
                Board.Holders[x, y] = Figures.X;
                move = PlayerMove.Player2;
            }
            if (move == PlayerMove.Player2 &&
                Board.Holders[x, y] == Figures.B)
            {
                figureO.Draw(graphics, mouse);
                Board.Holders[x, y] = Figures.O;
                move = PlayerMove.Player1;
            }

            Winner winner = CheckWinner.whoIsWin();
            if (winner == Winner.X)
            {
                MessageBox.Show($"{figureX.Name} {WINNER_TEXT}");
                panel.Click -= panel_Click;
                RestartGame();
            }
            if (winner == Winner.O)
            {
                MessageBox.Show($"{figureO.Name} {WINNER_TEXT}");
                panel.Click -= panel_Click;
                RestartGame();
            }
            if (winner == Winner.Draw)
            {
                MessageBox.Show(DRAW_TEXT);
                panel.Click -= panel_Click;
                RestartGame();
            }
        }
        public int[] DetectHits(Point mouse)
        {
            int mouseX = 0,
                mouseY = 0;

            if (mouse.X < Board.Width / Board.ROW)
                mouseX = 0;
            else if (mouse.X > Board.Width / Board.ROW && mouse.X < Board.Width / Board.ROW * (Board.ROW - 1))
                mouseX = 1;
            else if (mouse.X > Board.Width / Board.ROW * (Board.ROW - 1))
                mouseX = 2;

            if (mouse.Y < Board.Height / Board.COLUMN)
                mouseY = 0;
            else if (mouse.Y > Board.Height / Board.COLUMN && mouse.Y < Board.Height / Board.COLUMN * (Board.COLUMN - 1))
                mouseY = 1;
            else if (mouse.Y > Board.Height / Board.COLUMN * (Board.COLUMN - 1))
                mouseY = 2;

            return new int[] { mouseX, mouseY };
        }
    }
}