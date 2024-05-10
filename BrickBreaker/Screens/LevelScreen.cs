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
    public partial class LevelScreen : UserControl
    {
        public LevelScreen()
        {
            InitializeComponent();
            Form1.SetLevelFonts(this);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1.clickSound.Play();

            //goes to title screen
            MenuScreen ms = new MenuScreen();
            Form form = this.FindForm();

            form.Controls.Add(ms);
            form.Controls.Remove(this);

            ms.Location = new Point((form.Width - ms.Width) / 2, (form.Height - ms.Height) / 2);
        }
        public void ToGameScreen()
        {
            Form1.clickSound.Play();

            GameScreen gs = new GameScreen(false);
            Form form = this.FindForm();

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }

        #region label clicks
        private void level1_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 1;
            ToGameScreen();
        }
        private void level2_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 2;
            ToGameScreen();
        }
        private void level3_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 3;
            ToGameScreen();
        }
        private void level4_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 4;
            ToGameScreen();
        }
        private void level5_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 5;
            ToGameScreen();
        }
        private void level6_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 6;
            ToGameScreen();
        }
        private void level7_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 7;
            ToGameScreen();
        }
        private void level8_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 8;
            ToGameScreen();
        }
        private void level9_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 9;
            ToGameScreen();
        }
        private void level10_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 10;
            ToGameScreen();
        }
        private void level11_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 11;
            ToGameScreen();
        }
        private void level12_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 12;
            ToGameScreen();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 1;
            ToGameScreen();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 2;
            ToGameScreen();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 3;
            ToGameScreen();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 4;
            ToGameScreen();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 5;
            ToGameScreen();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 6;
            ToGameScreen();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 7;
            ToGameScreen();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 8;
            ToGameScreen();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 9;
            ToGameScreen();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 10;
            ToGameScreen();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 11;
            ToGameScreen();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form1.currentLevel = 12;
            ToGameScreen();
        }
        #endregion
    }
}
