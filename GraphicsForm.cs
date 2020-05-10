using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using System;

namespace Graphics
{
    public partial class GraphicsForm : Form
    {
        Renderer renderer = new Renderer();
        Thread MainLoopThread;

        float deltaTime;
        public GraphicsForm()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();

            MoveCursor();
            

            initialize();
            deltaTime = 0.005f;
            MainLoopThread = new Thread(MainLoop);
            MainLoopThread.Start();

        }
        void initialize()
        {
            renderer.Initialize();   
        }
        void MainLoop()
        {
            while (true)
            {
                renderer.Draw();
                renderer.Update(deltaTime);
                simpleOpenGlControl1.Refresh();
            }
        }
        private void GraphicsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            renderer.CleanUp();
            MainLoopThread.Abort();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            renderer.Draw();
            renderer.Update(deltaTime);
        }

        private void simpleOpenGlControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            float speed = 0.6f;
            if (e.KeyChar == 'a')
                renderer.cam.Strafe(-speed);
            if (e.KeyChar == 'd')
                renderer.cam.Strafe(speed);
            if (e.KeyChar == 's')
                renderer.cam.Walk(-speed);
            if (e.KeyChar == 'w')
                renderer.cam.Walk(speed);
            if (e.KeyChar == 'z')
                renderer.cam.Fly(-speed);
            if (e.KeyChar == 'c')
                renderer.cam.Fly(speed);

        }

        float prevX, prevY;
        private void simpleOpenGlControl1_MouseMove(object sender, MouseEventArgs e)
        {
            float speed = 0.05f;
            float delta = e.X - prevX;
            if (delta > 2)
                renderer.cam.Yaw(-speed);
            else if (delta < -2)
                renderer.cam.Yaw(speed);


            delta = e.Y - prevY;
            if (delta > 2)
                renderer.cam.Pitch(-speed);
            else if (delta < -2)
                renderer.cam.Pitch(speed);

            MoveCursor();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //float r = float.Parse(textBox1.Text);
            //float g = float.Parse(textBox2.Text);
            //float b = float.Parse(textBox3.Text);
            //float a = float.Parse(textBox4.Text);
            //float s = float.Parse(textBox5.Text);
            //renderer.SendLightData(r, g, b, a, s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            renderer.m.StartAnimation(_3D_Models.animType_LOL.STAND);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            renderer.m.StartAnimation(_3D_Models.animType_LOL.ATTACK1);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            renderer.m.StartAnimation(_3D_Models.animType_LOL.ATTACK2);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            renderer.m.StartAnimation(_3D_Models.animType_LOL.RUN);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            renderer.m.StartAnimation(_3D_Models.animType_LOL.SPELL1);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            renderer.m.StartAnimation(_3D_Models.animType_LOL.SPELL2);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            renderer.m.StartAnimation(_3D_Models.animType_LOL.DEATH);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float res = 0;
            if (float.TryParse(textBox1.Text,out res))
            {
                renderer.m.AnimationSpeed = res;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            float r = float.Parse(textBox1.Text);
            float g = float.Parse(textBox2.Text);
            float b = float.Parse(textBox3.Text);
            float a = float.Parse(textBox4.Text);
            float s = float.Parse(textBox5.Text);
            renderer.SendLightData(r, g, b, a, s);
        }

        private void MoveCursor()
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Point p = PointToScreen(simpleOpenGlControl1.Location);
            Cursor.Position = new Point(simpleOpenGlControl1.Size.Width/2+p.X, simpleOpenGlControl1.Size.Height/2+p.Y);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
            prevX = simpleOpenGlControl1.Location.X+simpleOpenGlControl1.Size.Width/2;
            prevY = simpleOpenGlControl1.Location.Y + simpleOpenGlControl1.Size.Height / 2;
        }
    }
}
