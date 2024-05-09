namespace BrickBreaker.Screens
{
    partial class EndCredits
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
            this.components = new System.ComponentModel.Container();
            this.endTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // endTimer
            // 
            this.endTimer.Interval = 10;
            this.endTimer.Tick += new System.EventHandler(this.endTimer_Tick);
            // 
            // EndCredits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.minecraftBkgd;
            this.DoubleBuffered = true;
            this.Name = "EndCredits";
            this.Size = new System.Drawing.Size(975, 667);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EndCredits_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer endTimer;
    }
}
