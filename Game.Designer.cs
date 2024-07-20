namespace TestGameCS
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        Entity player;


        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            screen = new PictureBox();
            game_loop = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)screen).BeginInit();
            SuspendLayout();
            // 
            // screen
            // 
            screen.BackgroundImageLayout = ImageLayout.Stretch;
            screen.Location = new Point(0, 0);
            screen.Name = "screen";
            screen.Size = new Size(779, 545);
            screen.TabIndex = 0;
            screen.TabStop = false;
            screen.Paint += OnPaint;
            // 
            // game_loop
            // 
            game_loop.Enabled = true;
            game_loop.Interval = 20;
            game_loop.Tick += OnTick;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 544);
            Controls.Add(screen);
            Name = "Game";
            Text = "Test Game";
            FormClosed += OnClosed;
            KeyDown += OnKey;
            ((System.ComponentModel.ISupportInitialize)screen).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer game_loop;
        public PictureBox screen;
    }
}