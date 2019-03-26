using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace SuperSaver
{
    public partial class Display : Form
    {
        public static Random Random = new Random();
        public static System.Timers.Timer Timer = new System.Timers.Timer();
        public Display()
        {
            InitializeComponent();
            RainDrop.CanvasWidth = Screen.PrimaryScreen.Bounds.Width;
            RainDrop.CanvasHeight = Screen.PrimaryScreen.Bounds.Height;
            RainDrop.StopWatch.Start();
            Timer.Interval = 200;
            Timer.Elapsed += Timer_Tick;
            Timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            int x = Random.Next(-100, Canvas.Width + 100);
            double speed = ((Random.NextDouble() * 2) + 3) / 16;
            new RainDrop(Properties.Resources.bonbon, speed, x, -100, 100, 50);
        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach(RainDrop RainDrop in RainDrop.RainDrops.ToArray())
            {
                RainDrop.UpdateLocation();
            }
            foreach (RainDrop RainDrop in RainDrop.RainDrops.ToArray())
            {
                g.DrawImage(RainDrop.Image, RainDrop.X, RainDrop.Y, RainDrop.Width, RainDrop.Height);
            }
            Canvas.Invalidate();
        }
    }
    public class RainDrop
    {
        public static List<RainDrop> RainDrops = new List<RainDrop>();
        public static Stopwatch StopWatch = new Stopwatch();
        public static int CanvasWidth;
        public static int CanvasHeight;
        public float X;
        public float Y;
        public int Width;
        public int Height;
        public double Speed;
        public Image Image;
        private float LastUpdated;
        public RainDrop(Image image, double speed, float x, float y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Speed = speed;
            Image = image;
            LastUpdated = StopWatch.ElapsedMilliseconds;
            RainDrops.Add(this);
        }
        public void UpdateLocation()
        {
            float time = StopWatch.ElapsedMilliseconds;
            Y = Y + ((time - LastUpdated) * (float)Speed);
            LastUpdated = StopWatch.ElapsedMilliseconds;
            if(Y > CanvasHeight)
            {
                RainDrops.Remove(this);
            }
        }
    }
}
