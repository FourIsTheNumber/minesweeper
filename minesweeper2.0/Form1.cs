using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper2._0
{
    public partial class Menu : Form
    {
        int tiles = 0;
        int mine = 0;

        public Menu()
        {
            InitializeComponent();
        }

        private void textChanged(object sender, EventArgs e)
        {
            try
            {
                tiles = Convert.ToInt32(height.Text) * Convert.ToInt32(width.Text);
                mine = Convert.ToInt32(mines.Text);
                int dense = 100 / (tiles / mine);
                density.Value = dense;
            }
            catch
            {
                generate.Enabled = false;
                return;
            }
            generate.Enabled = true;
        }

        private void generate_Click(object sender, EventArgs e)
        {
            Form game = new board(Convert.ToInt32(height.Text), Convert.ToInt32(width.Text), Convert.ToInt32(mines.Text));

            var t = new Thread(() => Application.Run(game));
            t.Start();

            Close();
        }
    }
}
