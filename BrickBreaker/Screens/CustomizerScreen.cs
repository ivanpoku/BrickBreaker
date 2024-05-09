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
    public partial class CustomizerScreen : UserControl
    {

        public static Paddle skinViewer;
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        public CustomizerScreen()
        {
            InitializeComponent();
        }

        public void CustomizerScreen_Paint(object sender, PaintEventArgs e)
        { 
            Rectangle skinPaddle = new Rectangle(((this.Width / 6) - 40), (this.Height / 2), 160, 40);
            e.Graphics.DrawImage(GameScreen.player, skinPaddle);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MenuScreen ms = new MenuScreen();
            Form form = this.FindForm();

            form.Controls.Add(ms);
            form.Controls.Remove(this);

            ms.Location = new Point((form.Width - ms.Width) / 2, (form.Height - ms.Height) / 2);
        }


        #region skinsEditor 
        private void skin1_Click(object sender, EventArgs e)
        {
            GameScreen.player = Properties.Resources.big_pig_face;
            Refresh();
        }

        private void skin2_Click(object sender, EventArgs e)
        {
            GameScreen.player = Properties.Resources.fighters;
            Refresh();
        }

        private void skin3_Click(object sender, EventArgs e)
        {
            GameScreen.player = Properties.Resources.snowmanFace;
            Refresh();
        }

        private void skinDeafult_Click(object sender, EventArgs e)
        {
            GameScreen.player = Properties.Resources.Friend2;
            Refresh();
        }

        private void skin4_Click(object sender, EventArgs e)
        {
            GameScreen.player = Properties.Resources.cake_side;
            Refresh();
        }
        #endregion

        #region background Display

        private void backgroundDisplay1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.minecraftBkgd;
            Refresh();
        }

        private void backgroundDisplay2_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.netherBackground;
            Refresh();
        }

        private void backgroundDisplay3_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.endBackground;
            Refresh();
        }
        #endregion
    }
}
