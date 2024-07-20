using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGameCS {
    public partial class LevelEditor : Form {
        public GameLevel level;
        MouseButtons btn = MouseButtons.None;
        
        public LevelEditor() {
            InitializeComponent();
            level = new GameLevel();
        }

        private void LevelEditor_Load(object sender, EventArgs e) {
            screen.MouseDown += (sender, ev) => {
                btn = ev.Button;
            };
            screen.MouseMove += (sender, ev) => {
                if (btn != MouseButtons.None) {
                    int ts = Tile.TILE_SIZE;
                    PointF p = GameLevel.GetTile(MousePosition + new Size(0, ts));
                    p.Y = (int)Math.Floor((double)Height / ts) - p.Y +1;
                    Tile t = new Tile(Color.DarkGreen, true);
                    if (btn == MouseButtons.Right)
                        t = new Tile(Color.Aqua, false);
                    level.AddTile(p, t);
                }
            };
            screen.MouseUp += (sender, ev) => {
                btn = MouseButtons.None;
            };
        }

        private void OnClose(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void OnRender(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;

            g.Clear(Color.Aqua);
            int ts = Tile.TILE_SIZE;
            Brush idk = new SolidBrush(Color.FromArgb(130, 0, 0, 255));
            for (int y = 1; y <= level.size.Height; y++) {
                for (int x = 0; x < level.size.Width; x++) {
                    PointF loc = new PointF(x, y);
                    Rectangle rect = new(x * ts, (int)Math.Floor((double)Height/ts)*ts - y * ts - ts, ts, ts);
                    if (level.map.ContainsKey(loc))
                        g.FillRectangle(new SolidBrush(level.map[loc].color), rect);
                    g.DrawString(y+"", Game.fnt_bold, new SolidBrush(Color.Black), new PointF(x*ts, y*ts));
                }
            }
            PointF p = MousePosition;
            p.Y -= ts;
            p = GameLevel.GetTile(p);
            p.X *= ts;
            p.Y *= ts;
            g.FillRectangle(idk, new Rectangle(new Point((int)p.X, (int)p.Y), new Size(ts, ts)));

            g.DrawString(p.ToString(), new Font("bold", 30), new SolidBrush(Color.Black), MousePosition);
        }

        private void SaveLevel(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "C# Corner Open File Dialog";
            ofd.InitialDirectory = @"C:\Users\1212o\Desktop\TestGLevels\";
            ofd.Filter = "tgl files (*.tgl)|*.tgl|all files (*.*)|*.*";
            DialogResult result = ofd.ShowDialog();
            if (result != DialogResult.OK) return;
            StreamWriter file;
            if (File.Exists(ofd.FileName)) {
                file = new StreamWriter(ofd.FileName);
            }
            else {
                file = new StreamWriter(File.Create(ofd.FileName));
            }
            for (int y = 0; y <= level.size.Height; y++) {
                string line = "";
                for (int x = 0; x <= level.size.Width; x++) {
                    Color c = level.map.GetValueOrDefault(new PointF(x, y), new Tile(Color.Black, false)).color;
                    if (c == Color.DarkGreen)
                        line += "T006400";
                    else
                        line += "F00ffff";
                }
                file.WriteLine(line);
            }
            file.Close();
        }

        private void LoadLevel(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "C# Corner Open File Dialog";
            openFileDialog.InitialDirectory = @"C:\Users\1212o\Desktop\TestGLevels\";
            openFileDialog.Filter = "tgl files (*.tgl)|*.tgl";
            DialogResult result = openFileDialog.ShowDialog();
            level = GameLevel.LoadFromFile(openFileDialog.FileName);
        }

        private void OnUpdate(object sender, EventArgs e) {
            screen.Invalidate();
        }
    }
}
