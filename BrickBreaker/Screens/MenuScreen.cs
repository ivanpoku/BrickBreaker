﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrickBreaker.Screens;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {

        Image minecraftLogo = Properties.Resources.minecraftLogo;
        Rectangle titleRec = new Rectangle(25, -150, 800, 500);

        public MenuScreen()
        {
            InitializeComponent();
            Form1.SetLevelFonts(this);
            Form1.titleMusic.Play();

            titleRec = new Rectangle(0,-50,this.Right, 500);
        }

        //closes game
        private void exitButton_Click(object sender, EventArgs e)
        {
            Form1.clickSound.Play();
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //Goes to game screen
            Form1.clickSound.Play();

            // Goes to the game screen
            GameScreen gs = new GameScreen(false);
            Form form = this.FindForm();

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }

        private void MenuScreen_Paint(object sender, PaintEventArgs e)
        {
            //Draws title screen
            e.Graphics.DrawImage(minecraftLogo, titleRec);
        }

        private void levelButton_Click(object sender, EventArgs e)
        {
            Form1.clickSound.Play();

            // Goes to the level screen
            LevelScreen ls = new LevelScreen();
            Form form = this.FindForm();

            form.Controls.Add(ls);
            form.Controls.Remove(this);

            ls.Location = new Point((form.Width - ls.Width) / 2, (form.Height - ls.Height) / 2);
        }

        private void skinsButton_Click(object sender, EventArgs e)
        {
            // Goes to the skin viewer
            CustomizerScreen cs = new CustomizerScreen();
            Form form = this.FindForm();

            form.Controls.Add(cs);
            form.Controls.Remove(this);

            cs.Location = new Point((form.Width - cs.Width) / 2, (form.Height - cs.Height) / 2);
        }
    }
}
