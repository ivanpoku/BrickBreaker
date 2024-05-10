using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker.Screens
{
    public partial class WinScreen : UserControl
    {
        Image minecraftLogo = Properties.Resources.minecraftLogo;
        Rectangle titleRec;

        SoundPlayer winSound = new SoundPlayer(Properties.Resources.boss);

        public WinScreen()
        {
            InitializeComponent();
            Form1.SetLevelFonts(this);
            winSound.Play();
        }

        private void WinScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(minecraftLogo, titleRec);
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
    }
}
