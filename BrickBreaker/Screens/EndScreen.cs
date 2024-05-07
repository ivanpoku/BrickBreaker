using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker.Screens
{
    public partial class EndScreen : UserControl
    {
        public EndScreen(double score)
        {
            InitializeComponent();
            Form1.SetLevelFonts(this);
            scoreLabel.Text = score + "%";
        }

        private void replayButton_Click(object sender, EventArgs e)
        {
            GameScreen gs = new GameScreen(true);
            Form form = this.FindForm();

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }

        private void levelButton_Click(object sender, EventArgs e)
        {
            // Goes to the level screen
            LevelScreen ls = new LevelScreen();
            Form form = this.FindForm();

            form.Controls.Add(ls);
            form.Controls.Remove(this);

            ls.Location = new Point((form.Width - ls.Width) / 2, (form.Height - ls.Height) / 2);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
