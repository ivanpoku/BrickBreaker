namespace BrickBreaker
{
    partial class MenuScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuScreen));
            this.playButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.levelButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.DimGray;
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Headliner No. 45", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.White;
            this.playButton.Location = new System.Drawing.Point(153, 310);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(549, 40);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.DimGray;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Headliner No. 45", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(153, 361);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(549, 40);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // levelButton
            // 
            this.levelButton.BackColor = System.Drawing.Color.DimGray;
            this.levelButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.levelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.levelButton.Font = new System.Drawing.Font("Headliner No. 45", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelButton.ForeColor = System.Drawing.Color.White;
            this.levelButton.Location = new System.Drawing.Point(153, 415);
            this.levelButton.Name = "levelButton";
            this.levelButton.Size = new System.Drawing.Size(549, 40);
            this.levelButton.TabIndex = 2;
            this.levelButton.Text = "Level";
            this.levelButton.UseVisualStyleBackColor = false;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.titleLabel.Font = new System.Drawing.Font("Headliner No. 45", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.LightGray;
            this.titleLabel.Location = new System.Drawing.Point(-1, 145);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(851, 91);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Brick Breaker";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Headliner No. 45", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(-1, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(851, 100);
            this.label1.TabIndex = 4;
            this.label1.Text = "Brick Breaker";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.levelButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.label1);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(853, 541);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuScreen_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button levelButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
    }
}
