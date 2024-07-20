using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace TestGameCS {

    public class GameLevel {
        public static PointF GetTile(PointF p) {
            return new Point(
                (int)Math.Floor((double)(p.X / Tile.TILE_SIZE)),
                (int)Math.Floor((double)(p.Y / Tile.TILE_SIZE))
            );
        }

        public static Rectangle GetTileRect(PointF p) {
            return new Rectangle((int)p.X,(int)p.Y, Tile.TILE_SIZE, Tile.TILE_SIZE);
        }

        public bool IsOnGround(PointF p) {
            PointF lp = GetTile(p);
            lp += new Size(0, 1);
            if (!g_map.ContainsKey(lp)) return false;
            //if (g_map.ContainsKey(lp - new Size(0, 1)) && g_map[lp - new Size(0, 1)].isSolid) return true;
            return g_map[lp].isSolid;
        }

        public PointF? GetHighestSolidTile(int x) {
            for (int y = 0; y < size.Height; y++) {
                if (g_map[new PointF(x,y)].isSolid) return new PointF(x,y);
            }
            return null;
        }

        private Dictionary<PointF, Tile> g_map;
        private ReadOnlyDictionary<PointF, Tile> g_mapReadOnly;
        public IReadOnlyDictionary<PointF, Tile> map => g_mapReadOnly;
        public Size size;
        public void AddTile(PointF p, Tile t) {
            if (g_map.ContainsKey(p))
                g_map[p] = t;
            else
                g_map.Add(p, t);
            g_mapReadOnly = new ReadOnlyDictionary<PointF, Tile>(g_map);
            if (p.X > size.Width) size.Width = (int)p.X;
            if (p.Y > size.Height) size.Height = (int)p.Y;
        }

        public void setMap(Dictionary<PointF, Tile> m, Size s) {
            g_map = m;
            g_mapReadOnly = new ReadOnlyDictionary<PointF, Tile>(g_map);
            size = s;
        }

        public GameLevel() {
            g_map = new Dictionary<PointF, Tile>();
            g_mapReadOnly = new ReadOnlyDictionary<PointF, Tile>(g_map);
            size = new Size(0, 0);
        }

        public static Dictionary<PointF, Tile> GetMapFromFile(string path, out Size s) {
            s = new Size(0, 0);
            Dictionary<PointF, Tile> map = new Dictionary<PointF, Tile>();
            if (File.Exists(path)) {
                string[] lines = File.ReadAllLines(path);
                s = new Size(lines[0].Length, lines.Length);
                for (int n = 0; n < lines.Length; n++) {
                    for (int pos = 0; lines[n].Length > pos; pos+=Tile.TILE_LENGTH){
                        //int k = int.Parse(lines[n][pos] + "");
                        /*
                        Tile t = new Tile(Color.Aqua, false);
                        if (k == 1) {
                            t.color = Color.DarkGreen;
                            t.isSolid = true;
                        }*/
                        map.Add(new PointF(pos/7, s.Height-n), Tile.ParseTile(lines[n].Substring(pos, Tile.TILE_LENGTH)));
                    }
                }
            }
            return map;
        }

        public static GameLevel LoadFromFile(string path) {
            GameLevel level = new GameLevel();
            if (File.Exists(path)) {
                level.g_map = GetMapFromFile(path, out level.size);
                level.g_mapReadOnly = new ReadOnlyDictionary<PointF, Tile>(level.g_map);
            } else if (File.Exists("C:\\Users\\1212o\\Desktop\\TestGLevels\\"+path)) {
                return LoadFromFile("C:\\Users\\1212o\\Desktop\\TestGLevels\\" + path);
            }
            return level;
        }
        
    }
}
