using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        int width = 350;
        int height = 350;

        Cell[,] cells = new Cell [3, 3];

        public Form1()
        {
            InitializeComponent();

            // width and height of window
            this.Width = width;
            this.Height = height;

            NewGame();

            timer.Interval = 250;
            timer.Tick += new EventHandler(update);
        }

        void NewGame ()
        {
            timer.Start();
            CreateMap();
        }

        void update (object sender, EventArgs e)
        {
            CheckWins();
            CheckNobody();
        }

        void CreateMap ()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Cell cell = new Cell(100, 100);
                    cell.button.Location = new Point(row*100, column*100);
                    cells[row, column] = cell;
                    this.Controls.Add(cell.button);
                }
            }
        }

        bool Equals (string first, string second, string third)
        {
            if (first == second && second == third && first != "" && second != "" && third != "")
                return true;
            else
                return false;
        }

        void CheckNobody ()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (cells[row, column].button.Text == "")
                        return;
                    else if (row == 2 && column == 2)
                        EndGame("Nobody wins!");
                }
            }
        }

        void CheckWins ()
        {
            string first;
            string second;
            string third;

            for (int row = 0; row < 3; row++)
            {
                first = this.cells[row, 0].button.Text;
                second = this.cells[row, 1].button.Text;
                third = this.cells[row, 2].button.Text;


                if (Equals (first, second, third))
                {
                    EndGame("Game Over!");
                }
            }

            for (int column = 0; column < 3; column++)
            {
                first = this.cells[0, column].button.Text;
                second = this.cells[1, column].button.Text;
                third = this.cells[2, column].button.Text;

                if (Equals (first, second, third))
                    EndGame("Game Over!");
            }

            first = cells[0, 0].button.Text;
            second = cells[1, 1].button.Text;
            third = cells[2, 2].button.Text;

            if (Equals (first, second, third))
                EndGame("Game Over!");

            first = cells[0, 2].button.Text;
            second = cells[1, 1].button.Text;
            third = cells[2, 0].button.Text;

            if (Equals(first, second, third))
                EndGame("Game Over!");
        }

        void EndGame (string message)
        {
            timer.Stop();
            MessageBox.Show(message);
            this.Controls.Clear();
            NewGame();
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
