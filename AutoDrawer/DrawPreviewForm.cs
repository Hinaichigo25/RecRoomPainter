using KGySoft.Drawing;
using System.Drawing;
using System.Windows.Forms;

namespace RecRoomPainter {
    public partial class DrawPreviewForm : Form {
        Bitmap imagePreview = MainForm.imagePreview;
        Point startWindowLocation = new Point(0, 0);
        Point startMouseLocation = new Point(0, 0);
        private Point initialMousePosition;


        public DrawPreviewForm(MouseEventArgs mouse) {

            imagePreview = BitmapExtensions.Resize(imagePreview, new Size(imagePreview.Width, imagePreview.Height), MainForm.scaleType, false);
            InitializeComponent();

            UpdateImage(imagePreview);
        }

        public void UpdateImage(Bitmap img) {
            pictureBox1.Image = img;
        }

        private void pictureBox1_Click(object sender, System.EventArgs e) {

        }

        private void buttonRD_MouseDown_1(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                initialMousePosition = new Point(e.X, e.Y);  // Store initial mouse position
            }
        }

        private void buttonRD_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // Calculate the new window position relative to the initial mouse position
                int deltaX = e.X - initialMousePosition.X;
                int deltaY = e.Y - initialMousePosition.Y;
                this.Location = new Point(this.Location.X, this.Location.Y);
                this.Size = new Size(this.Size.Width + deltaX, this.Size.Height + deltaY);
            }
        }

        private void buttonRD_MouseUp(object sender, MouseEventArgs e) {

        }

        private void RU_MouseUp(object sender, MouseEventArgs e) {
        }

        private void RU_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // Calculate the new window position relative to the initial mouse position
                int deltaX = e.X - initialMousePosition.X;
                int deltaY = e.Y - initialMousePosition.Y;
                this.Location = new Point(this.Location.X, this.Location.Y + deltaY);
                this.Size = new Size(this.Size.Width + deltaX, this.Size.Height - deltaY);
            }
        }

        private void RU_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                initialMousePosition = new Point(e.X, e.Y);  // Store initial mouse position
            }
        }

        private void buttonLD_MouseUp(object sender, MouseEventArgs e) {
        }

        private void buttonLD_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // Calculate the new window position relative to the initial mouse position
                int deltaX = e.X - initialMousePosition.X;
                int deltaY = e.Y - initialMousePosition.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y);
                this.Size = new Size(this.Size.Width - deltaX, this.Size.Height + deltaY);
            }
        }

        private void buttonLD_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                initialMousePosition = new Point(e.X, e.Y);  // Store initial mouse position
            }
        }

        private void buttonLU_MouseUp(object sender, MouseEventArgs e) {
        }

        private void buttonLU_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // Calculate the new window position relative to the initial mouse position
                int deltaX = e.X - initialMousePosition.X;
                int deltaY = e.Y - initialMousePosition.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
                this.Size = new Size(this.Size.Width - deltaX, this.Size.Height - deltaY);
            }
        }

        private void buttonLU_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                initialMousePosition = new Point(e.X, e.Y);  // Store initial mouse position
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // Calculate the new window position relative to the initial mouse position
                int deltaX = e.X - initialMousePosition.X;
                int deltaY = e.Y - initialMousePosition.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                initialMousePosition = new Point(e.X, e.Y);  // Store initial mouse position
            }
        }
    }
}
