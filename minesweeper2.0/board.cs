using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper2._0
{
    public partial class board : Form
    {
        int height = 0;
        int width = 0;
        int mines = 0;
        tile[,] tilefield;

        bool started = false;

        public board(int height, int width, int mines)
        {
            this.height = height;
            this.width = width;
            this.mines = mines;
            tilefield = new tile[width, height];
            InitializeComponent();
        }

        private void board_Load(object sender, EventArgs e)
        {
            //Initialize a field of tiles based on the input height and width
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tilefield[x, y] = new tile();
                    tilefield[x, y].image.Location = new Point(x * 32, y * 32);
                    tilefield[x, y].image.Click += new EventHandler(tileClicked);
                    Controls.Add(tilefield[x, y].image);
                }
            }
        }

        private void generate()
        {
            //Disribute mines
            Random rng = new Random();
            for (int i = 0; i < mines; i++)
            {
                int x = rng.Next(width);
                int y = rng.Next(height);
                if (tilefield[x, y].mined == 0 && tilefield[x, y].state != 3)
                {
                    tilefield[x, y].mined = 1;
                    //Uncomment this line to reveal all mines at start
                    //tilefield[x, y].image.Image = Properties.Resources.mine;
                }
                else
                {
                    i--;
                }
            }

            //Set values for each tile
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    byte val = 0;
                    //Manage edge/corner cases separately
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        //Top left corner case
                        if (x == 0 && y == 0)
                        {
                            val += tilefield[x, y + 1].mined;
                            val += tilefield[x + 1, y].mined;
                            val += tilefield[x + 1, y + 1].mined;
                        }
                        //Top right corner case
                        else if (x == width - 1 && y == 0)
                        {
                            val += tilefield[x - 1, y].mined;
                            val += tilefield[x - 1, y + 1].mined;
                            val += tilefield[x, y + 1].mined;
                        }
                        //Bottom left corner case
                        else if (x == 0 && y == height - 1)
                        {
                            val += tilefield[x, y - 1].mined;
                            val += tilefield[x + 1, y].mined;
                            val += tilefield[x + 1, y - 1].mined;
                        }
                        //Bottom right corner case
                        else if (x == width - 1 && y == height - 1)
                        {
                            val += tilefield[x - 1, y].mined;
                            val += tilefield[x - 1, y - 1].mined;
                            val += tilefield[x, y - 1].mined;
                        }
                        //Left side case
                        else if (x == 0)
                        {
                            val += tilefield[x, y - 1].mined;
                            val += tilefield[x, y + 1].mined;
                            val += tilefield[x + 1, y].mined;
                            val += tilefield[x + 1, y - 1].mined;
                            val += tilefield[x + 1, y + 1].mined;
                        }
                        //Top side case
                        else if (y == 0)
                        {
                            val += tilefield[x - 1, y].mined;
                            val += tilefield[x - 1, y + 1].mined;
                            val += tilefield[x, y + 1].mined;
                            val += tilefield[x + 1, y].mined;
                            val += tilefield[x + 1, y + 1].mined;
                        }
                        //Right side case
                        else if (x == width - 1)
                        {
                            val += tilefield[x - 1, y].mined;
                            val += tilefield[x - 1, y - 1].mined;
                            val += tilefield[x - 1, y + 1].mined;
                            val += tilefield[x, y - 1].mined;
                            val += tilefield[x, y + 1].mined;
                        }
                        //Bottom side case
                        else if (y == height - 1)
                        {
                            val += tilefield[x - 1, y].mined;
                            val += tilefield[x - 1, y - 1].mined;
                            val += tilefield[x, y - 1].mined;
                            val += tilefield[x + 1, y].mined;
                            val += tilefield[x + 1, y - 1].mined;
                        }
                    }
                    else
                    {
                        val += tilefield[x - 1, y].mined;
                        val += tilefield[x - 1, y - 1].mined;
                        val += tilefield[x - 1, y + 1].mined;
                        val += tilefield[x, y - 1].mined;
                        val += tilefield[x, y + 1].mined;
                        val += tilefield[x + 1, y].mined;
                        val += tilefield[x + 1, y - 1].mined;
                        val += tilefield[x + 1, y + 1].mined;
                    }
                    tilefield[x, y].value = val;
                }
            }
        }

        private void tileClicked(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs) e;
            PictureBox send = (PictureBox)sender;
            int x = send.Location.X / 32;
            int y = send.Location.Y / 32;
            tile selected = tilefield[x, y];

            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (started == false)
                {
                    started = true;
                    tilefield[x + 1, y].state = 3;
                    tilefield[x + 1, y + 1].state = 3;
                    tilefield[x + 1, y - 1].state = 3;
                    tilefield[x, y].state = 3;
                    tilefield[x, y + 1].state = 3;
                    tilefield[x, y - 1].state = 3;
                    tilefield[x - 1, y].state = 3;
                    tilefield[x - 1, y + 1].state = 3;
                    tilefield[x - 1, y - 1].state = 3;
                    generate();
                }
                if (selected.state != 1)
                {
                    if (selected.mined == 1)
                    {
                        MessageBox.Show("Lose");
                    }
                    else
                    {
                        selected.state = 2;
                        selected.image.Enabled = false;

                        switch (selected.value)
                        {
                            case 0:
                                selected.image.Image = Properties.Resources.zero;
                                try
                                {
                                    simulClick(x + 1, y);
                                    simulClick(x + 1, y + 1);
                                    simulClick(x + 1, y - 1);
                                    simulClick(x, y + 1);
                                    simulClick(x, y - 1);
                                    simulClick(x - 1, y);
                                    simulClick(x - 1, y + 1);
                                    simulClick(x - 1, y - 1);
                                }
                                catch { }
                                break;
                            case 1:
                                selected.image.Image = Properties.Resources.one;
                                break;
                            case 2:
                                selected.image.Image = Properties.Resources.two;
                                break;
                            case 3:
                                selected.image.Image = Properties.Resources.three;
                                break;
                            case 4:
                                selected.image.Image = Properties.Resources.four;
                                break;
                            case 5:
                                selected.image.Image = Properties.Resources.five;
                                break;
                            case 6:
                                selected.image.Image = Properties.Resources.six;
                                break;
                            case 7:
                                selected.image.Image = Properties.Resources.seven;
                                break;
                            case 8:
                                selected.image.Image = Properties.Resources.eight;
                                break;
                        }
                    }
                }
            }
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (started)
                {
                    if (selected.state == 0)
                    {
                        selected.state = 1;
                        selected.image.Image = Properties.Resources.flag;
                    }
                    else if (selected.state == 1)
                    {
                        selected.state = 0;
                        selected.image.Image = Properties.Resources.blank;
                    }
                }
            }
        }

        private void simulClick(int x, int y)
        {
            tile selected = tilefield[x, y];
            if (selected.state != 1 && selected.state != 2)
            {
                selected.state = 2;
                selected.image.Enabled = false;

                switch (selected.value)
                {
                    case 0:
                        selected.image.Image = Properties.Resources.zero;
                        try
                        {
                            simulClick(x + 1, y);
                            simulClick(x + 1, y + 1);
                            simulClick(x + 1, y - 1);
                            simulClick(x, y + 1);
                            simulClick(x, y - 1);
                            simulClick(x - 1, y);
                            simulClick(x - 1, y + 1);
                            simulClick(x - 1, y - 1);
                        }
                        catch { }
                        break;
                    case 1:
                        selected.image.Image = Properties.Resources.one;
                        break;
                    case 2:
                        selected.image.Image = Properties.Resources.two;
                        break;
                    case 3:
                        selected.image.Image = Properties.Resources.three;
                        break;
                    case 4:
                        selected.image.Image = Properties.Resources.four;
                        break;
                    case 5:
                        selected.image.Image = Properties.Resources.five;
                        break;
                    case 6:
                        selected.image.Image = Properties.Resources.six;
                        break;
                    case 7:
                        selected.image.Image = Properties.Resources.seven;
                        break;
                    case 8:
                        selected.image.Image = Properties.Resources.eight;
                        break;
                }
            }
        }
    }

    public class tile
    {
        public PictureBox image;
        public int value;
        /*
         * States:
         * 
         * 0: Unrevealed, no flag
         * 1: Unrevealed, flagged
         * 2: Revealed
         * 3: Safe state: mines cannot generate here on initialization
         * 
        */
        public int state;
        public byte mined;

        public tile()
        {
            state = 0;
            image = new PictureBox();
            image.Image = Properties.Resources.blank;
            image.SizeMode = PictureBoxSizeMode.Zoom;
            image.Size = new Size(32, 32);
        }
    }
}
