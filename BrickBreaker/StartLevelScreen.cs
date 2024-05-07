using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class StartLevelScreen : UserControl
    {
        GameScreen parentScreen;
        public StartLevelScreen(GameScreen _parentScreen)
        {
            parentScreen = _parentScreen;
            InitializeComponent();
            Form1.SetLevelFonts(this);
        }

        private void StartLevelScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space || (Keys)e.KeyChar == Keys.Enter) 
            {
                parentScreen.gameTimer.Enabled = true;
                parentScreen.Focus();
                parentScreen.Controls.Remove(this);
            }
        }
    }
}
