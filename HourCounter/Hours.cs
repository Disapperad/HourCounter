namespace HourCounter
{
    public partial class Hours : Form
    {
        public Hours()
        {
            InitializeComponent();
        }

        public Point GetRad(double Angles, double Radius, int sm)
        {
            double RadA = (Math.PI / 180.0) * (Angles - 90);

            double rx = Radius * Math.Cos(RadA);
            double ry = Radius * Math.Sin(RadA);
            return new Point((int)rx + sm, (int)ry + sm); ;
        }

        private void Hours_Load(object sender, EventArgs e)
        {
            Pen BlackPen = new Pen(Color.Black);

            System.Timers.Timer HourTimer = new System.Timers.Timer();
            HourTimer.Interval = 1000;
            HourTimer.Start();

            HourTimer.Elapsed += HourTimer_Elapsed;
        }

        private void HourTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Pen BlackPen = new Pen(Color.Black);

            Graphics Graph = pictureBox1.CreateGraphics();
            Graph.Clear(Color.White);
            Graph.DrawEllipse(BlackPen, 100, 100, 200, 200);

            for (int i = 0; i < 360; i += 30)
            {
                Graph.DrawLine(BlackPen, GetRad(i, 80, 200), GetRad(i, 80 + 15, 200));
                
            }
            Graph.DrawLine(BlackPen, new Point(200, 200), GetRad(6 * DateTime.Now.Second, 75, 200));
            Graph.DrawLine(BlackPen, new Point(200, 200), GetRad(6 * DateTime.Now.Hour - DateTime.Now.Minute / 6, 25, 200));
            Graph.DrawLine(BlackPen, new Point(200, 200), GetRad(6 * DateTime.Now.Minute, 50, 200));
        }
    }
}