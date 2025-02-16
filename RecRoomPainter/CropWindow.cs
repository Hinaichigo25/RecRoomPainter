using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RecRoomPainter
{
    public partial class CropWindow : Form
    {


        Point newCropXY = new Point(0, 0);
        Size newCropWH = new Size(0, 0);
        Point oldCropXY = new Point(0, 0);
        Size oldCropWH = new Size(0, 0);


        int state = 0;
        public CropWindow(MouseEventArgs mouse)
        {
            InitializeComponent();
            this.instruct.Text = "Set First Point!";
            oldCropXY.X = 0;
            oldCropXY.Y = 0;
            oldCropWH.Width = MainForm.DrawImage.Original.Width;
            oldCropWH.Height = MainForm.DrawImage.Original.Height;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            switch (state)
            {
                case 0:
                    newCropXY = new Point(mouse.Location.X + 10, mouse.Location.Y + 20);
                    this.instruct.Text = "Set Second Point!";
                    state = 1;
                    break;
                case 1:

                    newCropWH = new Size(mouse.Location.X + 10, mouse.Location.Y + 20);
                    this.instruct.Text = "Finished!";
                    state = 2;
                    MainForm.Settings.CropX = newCropXY.X;
                    MainForm.Settings.CropY = newCropXY.Y;
                    MainForm.Settings.CropH = newCropWH.Height;
                    MainForm.Settings.CropW = newCropWH.Width;
                    pictureBox1.Image = MainForm.CropImageSet(MainForm.DrawImage.Original);
                    break;
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {

            MainForm.Settings.CropX = newCropXY.X;
            MainForm.Settings.CropY = newCropXY.Y;
            MainForm.Settings.CropH = newCropWH.Height;
            MainForm.Settings.CropW = newCropWH.Width;


            Form mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            if (mainForm != null)
            {
                // If the main form is minimized, restore it
                if (mainForm.WindowState == FormWindowState.Minimized)
                {
                    mainForm.WindowState = FormWindowState.Normal;
                }

                // Activate the main form to bring it to the front and give it focus
                mainForm.Activate();
            }
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MainForm.Settings.CropX = oldCropXY.X;
            MainForm.Settings.CropY = oldCropXY.Y;
            MainForm.Settings.CropH = oldCropWH.Height;
            MainForm.Settings.CropW = oldCropWH.Width;

            Form mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            if (mainForm != null)
            {
                // If the main form is minimized, restore it
                if (mainForm.WindowState == FormWindowState.Minimized)
                {
                    mainForm.WindowState = FormWindowState.Normal;
                }

                // Activate the main form to bring it to the front and give it focus
                mainForm.Activate();
            }

            this.Close();
        }

        private void CropWindow_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            state = 0;
            this.instruct.Text = "Set First Point!";
            MainForm.Settings.CropX = oldCropXY.X;
            MainForm.Settings.CropY = oldCropXY.Y;
            MainForm.Settings.CropH = oldCropWH.Height;
            MainForm.Settings.CropW = oldCropWH.Width;
            pictureBox1.Image = MainForm.DrawImage.Original;
        }
    }
}
