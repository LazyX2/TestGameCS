using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGameCS {
    public class Tile {
        public static int TILE_SIZE = 50;
        public static int TILE_LENGTH = 7;

        public Color color;
        public bool isSolid = true;

        public Tile(Color c, bool solid) {
            color = c;
            isSolid = solid;
        }

        public static Tile ParseTile(string str) {
            return new Tile(
                Color.FromArgb(Convert.ToInt32("0xFF" + str.Substring(1),16)),
                str[0] == 'T' ? true : false
            );
        }

    }
}
