namespace BrickBreaker.Screens
{
    partial class EndScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndScreen));
            this.levelButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.replayButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // levelButton
            // 
            this.levelButton.BackColor = System.Drawing.Color.DimGray;
            this.levelButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.levelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.levelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelButton.ForeColor = System.Drawing.Color.White;
            this.levelButton.Location = new System.Drawing.Point(210, 386);
            this.levelButton.Margin = new System.Windows.Forms.Padding(4);
            this.levelButton.Name = "levelButton";
            this.levelButton.Size = new System.Drawing.Size(542, 49);
            this.levelButton.TabIndex = 5;
            this.levelButton.Text = "L E V E L";
            this.levelButton.UseVisualStyleBackColor = false;
            this.levelButton.Click += new System.EventHandler(this.levelButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.DimGray;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(210, 452);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(542, 49);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "E X I T";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // replayButton
            // 
            this.replayButton.BackColor = System.Drawing.Color.DimGray;
            this.replayButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.replayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.replayButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.replayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replayButton.ForeColor = System.Drawing.Color.White;
            this.replayButton.Location = new System.Drawing.Point(210, 317);
            this.replayButton.Margin = new System.Windows.Forms.Padding(4);
            this.replayButton.Name = "replayButton";
            this.replayButton.Size = new System.Drawing.Size(542, 49);
            this.replayButton.TabIndex = 3;
            this.replayButton.Text = "P L A Y    A G A I N";
            this.replayButton.UseVisualStyleBackColor = false;
            this.replayButton.Click += new System.EventHandler(this.replayButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.BackColor = System.Drawing.Color.Transparent;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.resultLabel.Location = new System.Drawing.Point(360, 149);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(235, 55);
            this.resultLabel.TabIndex = 6;
            this.resultLabel.Text = "You Died.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(338, 249);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "Your Score:";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.scoreLabel.Location = new System.Drawing.Point(581, 249);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(31, 33);
            this.scoreLabel.TabIndex = 8;
            this.scoreLabel.Text = "#";
            // 
            // EndScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.levelButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.replayButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EndScreen";
            this.Size = new System.Drawing.Size(975, 667);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button levelButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button replayButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label scoreLabel;
    }
}
