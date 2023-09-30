using KGySoft.Drawing;
using System.Drawing;
using System.Windows.Forms;

namespace AutoDrawer {
    public partial class DrawPreviewForm : Form {
        Bitmap imagePreview = MainForm.imagePreview;


        public DrawPreviewForm() {

            imagePreview = BitmapExtensions.Resize(imagePreview, new Size(imagePreview.Width, imagePreview.Height), MainForm.scaleType, false);
            InitializeComponent();
            if (imagePreview.Width < 220) {
                pictureBox1.Anchor = AnchorStyles.None;
                CenterPictureBox(pictureBox1, imagePreview);

            }
            else {
                UpdateImage(imagePreview);
            }
        }

        public void UpdateImage(Bitmap img) {
            pictureBox1.Image = img;
        }

        public void CenterPictureBox(PictureBox picBox, Bitmap picImage) {
            picBox.Image = picImage;
            picBox.Location = new Point((picBox.Parent.ClientSize.Width / 2) - (picImage.Width / 2),
                                        (picBox.Parent.ClientSize.Height / 2) - (picImage.Height / 2));
            picBox.Refresh();
        }

        private void pictureBox1_Click(object sender, System.EventArgs e) {

        }

        private void setButton_Click(object sender, System.EventArgs e) {

        }
    }
}
