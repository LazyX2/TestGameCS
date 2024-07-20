using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace TestGameCS {
    public partial class Game : Form {
        //Entity player;
        public static string flevel = "example.tgl";
        List<Entity> entities;
        public GameLevel level;
        float gravity = 9.8f;
        int jump = 300;
        public static Font fnt_bold = new Font("Bold", 10);
        public Game() {
            InitializeComponent();
            entities = new List<Entity>();
            player = new Player(new Point(0, 0), 20, 10);
            game_loop.Start();
            level = GameLevel.LoadFromFile(flevel);
        }

        private void OnPaint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.Clear(Color.Aqua);
            int ts = Tile.TILE_SIZE;
            /*
            Pen bp = new Pen(Color.Black);
            for (int y = 0; y < screen.Height; y+=ts) {
                for (int x = 0; x < screen.Width; x+= ts) {
                    g.DrawRectangle(bp, new Rectangle(x,y, ts, ts));
                }
            }*/
            
            Brush t_c = new SolidBrush(Color.FromArgb(200,255,0,0));
            g.FillRectangle(t_c, new Rectangle((int)Math.Floor((double)player.loc.X/ts)*ts, (int)Math.Floor((double)player.loc.Y / ts)*ts, ts,ts));

            //Gravity
            Brush br, c_b = new SolidBrush(Color.Black);
            PointF ig = player.loc;
            player.loc = new PointF(ig.X, ig.Y % screen.Height);
            ig.Y = Height - ig.Y - ts;
            if (!level.map.GetValueOrDefault(GameLevel.GetTile(ig), new Tile(Color.Black, false)).isSolid) {
                player.loc += new SizeF(0, gravity);
            }
            for (int _ = 0; _ < gravity; _++) {
                if (level.map.GetValueOrDefault(GameLevel.GetTile(ig + new Size(0, 1)), new Tile(Color.Black, false)).isSolid) {
                    player.loc -= new SizeF(0, 1);
                }
            }

            foreach (KeyValuePair<PointF, Tile> pt in level.map) {
                br = new SolidBrush(pt.Value.color);

                RectangleF rectF = new RectangleF(pt.Key.X * ts, Height - ts - pt.Key.Y * ts, ts, ts);
                g.FillRectangle(
                    br,
                    rectF
                );
                g.DrawString(pt.Key.Y+"", fnt_bold, c_b, new PointF(rectF.Left,rectF.Top));
                
            }

            player.Draw(g);
            PointF p = MousePosition;
            Tile t;
            p.Y = screen.Height - p.Y;
            p = GameLevel.GetTile(p);
            //g.FillRectangle(c_b, GameLevel.GetTileRect(MousePosition-new Size(0,50)));
            if (Bounds.Contains(MousePosition)) {
                if (!level.map.TryGetValue(p, out t))
                    t = new Tile(Color.AliceBlue, false);
                string point_text = p + "|" + t.isSolid;//ig + "|" + GameLevel.GetTileRect(player.loc).IntersectsWith(GameLevel.GetTileRect(ig));
                g.DrawString(
                    point_text, fnt_bold,
                    new SolidBrush(Color.Black), MousePosition - new Size(0, 50)
                );
            }
        }

        private void OnTick(object sender, EventArgs e) {
            if (ActiveForm != null) screen.Size = ActiveForm.Size;
            screen.Invalidate();
            player.Update();
            foreach (Entity en in entities)
            {
                en.Update();
            }
        }

        private void OnKey(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
            int player_speed = (int)(float)player.attributes.GetValueOrDefault("Speed", 10);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;

                case Keys.Space:
                    player.loc += new Size(0, -jump);
                    break;

                case Keys.A:
                    player.loc += new Size(-player_speed, 0);
                    break;
                case Keys.D:
                    player.loc += new Size(player_speed, 0);
                    break;

                case Keys.T:
                    if (game_loop.Enabled)
                        game_loop.Stop();
                    else
                        game_loop.Start();
                    break;

                default:
                    break;

            }
            screen.Invalidate();
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) Application.Exit();
        }
    }
}