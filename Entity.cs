using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGameCS
{
    internal class Entity
    {
        public string name { get; set; }
        public PointF loc { get; set; }
        public int id { get; set; }
        public Dictionary<string, Object> attributes { get; set; }
        //y=(x^3)/50+25
        public Entity(string en_name, PointF location)
        {
            name = en_name;
            loc = location;
            id = new Random().Next(100);
            attributes = new Dictionary<string, Object>();
        }

        public virtual void Update() { }
        public virtual void Draw(Graphics g) { }

    }

    internal class Player : Entity
    {
        public Player(PointF location, float maxhp, float speed) : base("player", location) {
            attributes.Add("MaxHealth", maxhp);
            attributes.Add("Health", maxhp);
            attributes.Add("Speed", speed);
        }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
            g.FillRectangle(brush, loc.X, loc.Y, 20f, 50f);
            g.DrawString(
                "Health: "+((float)attributes.GetValueOrDefault("Health",0)).ToString()
                +"/"+((float)attributes.GetValueOrDefault("MaxHealth",0)).ToString(),
                new Font("Arial", 24, FontStyle.Bold), brush, new PointF(0,0));
        }

        public override void Update()
        {
            /*
            if (0 > loc.X || loc.X > TestGameCS.window.ActiveForm.Width || 0 > loc.Y || loc.Y > TestGameCS.window.ActiveForm.Height) {
                
            }
            */
        }

    }

    internal class Bullet : Entity
    {
        public Bullet(string en_name, PointF location, PointF direction, float speed = 5) : base(en_name, location) {
            
            attributes.Add("direction", new PointF(
                Math.Floor(direction.X/3) == 0 ? 0 : (float)(direction.X / (float)Math.Abs(direction.X)),
                Math.Floor(direction.Y/3) == 0 ? 0 : (float)(direction.Y / (float)Math.Abs(direction.Y))
            ));
            attributes.Add("Color", Color.FromArgb(255,0,0,255));
            attributes.Add("Speed", speed);
        }

        public override void Draw(Graphics g) {
            Brush brush = new SolidBrush((Color)attributes.GetValueOrDefault("Color", Color.FromArgb(255, 0, 0, 255)));
            g.FillRectangle(brush, loc.X,loc.Y, 20f,20f);
        }

        public override void Update() {
            int speed = (int) (float) attributes.GetValueOrDefault("Speed", 5);
            PointF dire = (PointF)attributes.GetValueOrDefault("direction",new PointF(1,1));
            dire.X *= speed;
            dire.Y *= speed;
            loc += new SizeF(dire);
            /*
            if (0 > loc.X || loc.X > TestGameCS.window.ActiveForm.Width || 0 > loc.Y || loc.Y > TestGameCS.window.ActiveForm.Height) {
                
            }
            */
        }

    }

}
