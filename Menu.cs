using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TestGameCS {
    public partial class Menu : Form {

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }


        private void Broswe_File(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "C# Corner Open File Dialog";
            openFileDialog.InitialDirectory = @"C:\Users\1212o\Desktop\TestGLevels\";
            openFileDialog.Filter = "tgl files (*.tgl)|*.tgl";
            DialogResult result = openFileDialog.ShowDialog();
            file_box.Text = openFileDialog.FileName.Split("\\").Last();
            Game.flevel = file_box.Text;
        }

        private void Launch_Game(object sender, EventArgs e)
        {
            Program.game = new Game();
            Program.game.Show();
            Hide();
            consoleBox.Text = "Launching the game...";
        }

        private void OnMake(object sender, EventArgs e)
        {
            Program.level_editor = new LevelEditor();
            Program.level_editor.Show();
            Hide();
        }
    }
}
