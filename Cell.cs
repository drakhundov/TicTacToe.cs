using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    class Cell
    {
        public static char sign = 'o';

        public bool pressed = false;
        public Button button;

        public void OnClick (object sender, EventArgs e)
        {
            if (!this.pressed)
            {
                this.button.Text = Cell.sign.ToString();
                sign = (sign == 'o') ? 'x' : 'o';
                this.pressed = true;
            }
        }

        public Cell (int width = 50, int height = 50)
        {
            this.button = new Button();
            this.button.Size = new System.Drawing.Size(width, height);
            this.button.Font = new Font("Impact", 50);
            this.button.BackColor = Color.Red;
            this.button.Click += new EventHandler(OnClick);
        }
    }
}
