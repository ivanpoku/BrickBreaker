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
    public partial class EndCredits : UserControl
    {
        Image minecraftLogo = Properties.Resources.minecraftLogo;
        Rectangle logoRect = new Rectangle(75, 200, 800, 500);
        Rectangle textRect = new Rectangle(75, 700, 800, 1000);

        string spacer = "\n\n\n";

        public EndCredits()
        {
            InitializeComponent();
            endTimer.Enabled = true;
        }

        private void EndCredits_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(minecraftLogo, logoRect);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            using (Font font1 = new Font("Minecraft", 16, FontStyle.Bold, GraphicsUnit.Point))
            {
                e.Graphics.DrawString("I see the player you mean.", font1, Brushes.LightSeaGreen, textRect, stringFormat);

                e.Graphics.DrawString("\nSTEVE?", font1, Brushes.Green, textRect, stringFormat);

                e.Graphics.DrawString("\n\nYes. Take care. It has reached a higher level now. It can read our thoughts.", font1, Brushes.LightSeaGreen, textRect, stringFormat);
            }
                
        }

        private void endTimer_Tick(object sender, EventArgs e)
        {
            logoRect.Y -= 2;
            textRect.Y -= 2;
            Refresh();
        }
    }
}
