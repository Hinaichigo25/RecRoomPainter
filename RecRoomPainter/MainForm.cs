﻿using KGySoft.Drawing;
using KGySoft.Drawing.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace RecRoomPainter {

    public partial class MainForm : Form {
        public static ScalingMode scaleType = ScalingMode.Box;

        const int MOUSEDELAY = 40;
        const int COLORCHANGEDELAY = 2000;

        Bitmap imageFile;
        Bitmap image;
        public static Bitmap imagePreview;
        int drawWidth = 0;
        int drawHeight = 0;
        int drawLocationX = 0;
        int drawLocationY = 0;
        double pixelation = 1;
        int maxColors = 8;
        int skipColors = 0;
        bool fillFirstLayer = false;
        bool scanDirection = false;
        int ditherPattern = 0;
        float penSizeX = 1;
        float penSizeY = 1;
        long estimatedTime = 0;


        //This is a replacement for Cursor.Position in WinForms
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;

        public MainForm() {
            InitializeComponent();
        }

        public static void ActivateWindow(string windowTitle) {
            IntPtr windowHandle = FindWindow(null, windowTitle);

            if (windowHandle != IntPtr.Zero) {
                // Bring the window to the foreground
                SetForegroundWindow(windowHandle);

                // Set focus to the window
                SetFocus(windowHandle);
            }
            else {
                Console.WriteLine("Window not found with the specified title.");
            }
        }


        void EnableControls(bool enable) {
            widthInput.Enabled = enable;
            heightInput.Enabled = enable;
            pixelateBar.Enabled = enable;
            DrawPositionButton.Enabled = enable;
            skipColorBox.Enabled = enable;
            maxColorsBox.Enabled = enable;
            firstLayerFill.Enabled = enable;
            ditherBox.Enabled = enable;
            startButton.Enabled = enable;
            clearButton.Enabled = enable;
            XBox.Enabled = enable;
            YBox.Enabled = enable;
            GapXBox.Enabled = enable;
            GapYBox.Enabled = enable;
        }


        void ProcessImage() {
            try {
                EnableControls(false);
                progressBar1.Value = 0;
                image = imageFile;
                image = ResizeImage(imageFile, new Size(drawWidth, drawHeight), pixelation);
                progressBar1.Value = 10;

                IDitherer dither = OrderedDitherer.Bayer2x2;

                IQuantizer quantizer = OptimizedPaletteQuantizer.Wu(maxColors);
                switch (ditherPattern) {
                    case 1:
                        dither = OrderedDitherer.Bayer2x2;
                        break;
                    case 2:
                        dither = OrderedDitherer.Bayer3x3;
                        break;
                    case 3:
                        dither = OrderedDitherer.Bayer4x4;
                        break;
                    case 4:
                        dither = OrderedDitherer.Bayer8x8;
                        break;
                    case 5:
                        dither = OrderedDitherer.BlueNoise;
                        break;
                    case 6:
                        dither = OrderedDitherer.DottedHalftone;
                        break;
                    case 7:
                        dither = ErrorDiffusionDitherer.Atkinson;
                        break;
                    case 8:
                        dither = ErrorDiffusionDitherer.Burkes;
                        break;
                    case 9:
                        dither = ErrorDiffusionDitherer.FloydSteinberg;
                        break;
                    case 10:
                        dither = ErrorDiffusionDitherer.JarvisJudiceNinke;
                        break;
                    case 11:
                        dither = ErrorDiffusionDitherer.Sierra2;
                        break;
                    case 12:
                        dither = ErrorDiffusionDitherer.Sierra3;
                        break;
                    case 13:
                        dither = ErrorDiffusionDitherer.SierraLite;
                        break;
                    case 14:
                        dither = ErrorDiffusionDitherer.StevensonArce;
                        break;
                    case 15:
                        dither = ErrorDiffusionDitherer.Stucki;
                        break;
                }
                if (ditherPattern > 0) {
                    BitmapExtensions.Dither(image, quantizer, dither);
                }
                else {
                    image = image.ConvertPixelFormat(PixelFormat.Format64bppArgb, quantizer);
                }
                progressBar1.Value = 50;

                image = BitmapExtensions.Resize(image, new Size(drawWidth, drawHeight), ScalingMode.NearestNeighbor);

                pictureBox1.Image = BitmapExtensions.Resize(image, new Size(1920, 1080), scaleType, true);
                imagePreview = image;

                progressBar1.Value = 100;
                EnableControls(true);

            }
            catch (Exception) {
                MessageBox.Show(new Form() { TopMost = true }, "No image was found", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void Start() {
            try {
                if (Draw(false))
                    MessageBox.Show(new Form() { TopMost = true }, "Drawing Complete", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show(new Form() { TopMost = true }, "Drawing halted", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception) {
                MessageBox.Show(new Form() { TopMost = true }, "No image was found", "Drawing Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }



        public static Bitmap ResizeImage(Bitmap imgToResize, Size size, double scale) {
            if (imgToResize != null) {
                return BitmapExtensions.Resize(imgToResize, new Size((int)Math.Round(size.Width * scale), (int)Math.Round(size.Height * scale)), scaleType);

            }
            else {
                return null;
            }
        }


        public void SetPenColor(string hex) {
            Clipboard.SetText(hex);

            const int CCLocationX = 1334;
            const int CCLocationY = 836;
            const int HexCLocationX = 1366;
            const int HexCLocationY = 652;
            const int DoneCLocationX = 1320;
            const int DoneCLocationY = 756;



            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            Thread.Sleep(COLORCHANGEDELAY);
            SetCursorPos(CCLocationX, CCLocationY);
            mouse_event(MOUSEEVENTF_LEFTDOWN, CCLocationX, CCLocationY, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, CCLocationX, CCLocationY, 0, 0);
            Thread.Sleep(COLORCHANGEDELAY);
            SetCursorPos(HexCLocationX, HexCLocationY);
            mouse_event(MOUSEEVENTF_LEFTDOWN, HexCLocationX, HexCLocationY, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, HexCLocationX, HexCLocationX, 0, 0);
            Thread.Sleep(COLORCHANGEDELAY);
            SendKeys.Send("^(v)");
            Thread.Sleep(COLORCHANGEDELAY);
            SetCursorPos(DoneCLocationX, DoneCLocationY);
            mouse_event(MOUSEEVENTF_LEFTDOWN, DoneCLocationX, DoneCLocationY, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, DoneCLocationX, DoneCLocationY, 0, 0);
            Thread.Sleep(COLORCHANGEDELAY);
        }

        public static int GetMaxDirIndex(int[] arr) {
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("Array is null or empty");

            int maxIndex = 0;
            for (int i = 1; i < arr.Length; i++) {
                if (i > 3) {
                    if (arr[i] > arr[maxIndex] * 2)
                        maxIndex = i;
                }
                else {
                    if (arr[i] > arr[maxIndex])
                        maxIndex = i;
                }
            }

            return maxIndex;
        }

        bool[,] CoverageMatrix(Bitmap img, Color color) {
            bool[,] matrix = new bool[img.Width, img.Height];
            for (int i = 0; i < img.Width; i++) {
                for (int j = 0; j < img.Height; j++) {
                    if (img.GetPixel(i, j) == color) {
                        matrix[i, j] = true;
                    }
                }
            }
            return matrix;
        }

        void MoveMouse(int x, int y, int delay, bool estMode) {
            if (!estMode) {
                SetCursorPos(x, y);
                Thread.Sleep(delay);
            }
            else {
                estimatedTime += delay;
            }
        }


        bool NeighborLineDraw(bool[,] matrix, int x, int y, bool est) {

            bool didItDraw = false;

            bool CheckNeighbor(int relx, int rely) {
                if (relx >= 0 && rely >= 0 && relx < matrix.GetLength(0) && rely < matrix.GetLength(1)) {
                    if (matrix[relx, rely]) {
                        x = relx;
                        y = rely;
                        return true;
                    }
                }
                return false;
            }
            void DrawLine(int dirX, int dirY, int steps) {
                didItDraw = true;
                matrix[x, y] = false;
                for (int i = 0; i < steps; i++) {
                    if (x + dirX >= 0 && y + dirY >= 0 && x + dirX < matrix.GetLength(0) && y + dirY < matrix.GetLength(1)) {
                        x += dirX;
                        y += dirY;
                        matrix[x, y] = false;
                    }
                }
            }
            while (true) {
                if (!est) {
                    Application.DoEvents();
                    if (ModifierKeys == Keys.Alt) {
                        break;
                    }
                }

                int moveStep = 1;

                int[] addXValues = { moveStep, 0, -moveStep, 0 };
                int[] addYValues = { 0, moveStep, 0, -moveStep };
                int[] dirCount = Enumerable.Repeat(0, addXValues.Length).ToArray();


                for (int i = 0; i < dirCount.Length; i++) {
                    while (CheckNeighbor(x + addXValues[i], y + addYValues[i])) {
                        dirCount[i]++;
                    }
                    x -= addXValues[i] * dirCount[i];
                    y -= addYValues[i] * dirCount[i];
                }

                int max = GetMaxDirIndex(dirCount);

                if (dirCount[max] == 0) {
                    break;
                }
                for (int i = 0; i < 5; i++) {
                    int speed = 1;
                    if (i == 4) {
                        speed = 20;
                    }
                    if (i % 2 == 1) {
                        DrawLine(-addXValues[max], -addYValues[max], dirCount[max]);
                    }
                    else {
                        DrawLine(addXValues[max], addYValues[max], dirCount[max]);
                    }
                    MoveMouse(drawLocationX + (int)Math.Round(x * penSizeX), drawLocationY + (int)Math.Round(y * penSizeY), speed, est);
                }
            }
            return didItDraw;
        }

        Color[] ImageToPallet(Bitmap img) {
            // Create a HashSet to store unique numbers
            HashSet<Color> uniqueColorSet = new HashSet<Color>();
            for (int j = 0; j < img.Height; j++) {
                for (int i = 0; i < img.Width; i++) {
                    // Add each unique number to the HashSet
                    if (!uniqueColorSet.Contains(img.GetPixel(i, j))) {
                        uniqueColorSet.Add(img.GetPixel(i, j));
                    }

                }
            }
            // Convert the HashSet to an array
            Color[] pallet = new Color[uniqueColorSet.Count];
            uniqueColorSet.CopyTo(pallet);

            for (int lenMod = 1; lenMod < pallet.Length; lenMod++) {
                for (int i = 0; i < pallet.Length - lenMod; i++) {
                    if (pallet[i].GetBrightness() < pallet[i + 1].GetBrightness()) {
                        Color temp = pallet[i];
                        pallet[i] = pallet[i + 1];
                        pallet[i + 1] = temp;

                    }
                }
            }
            return pallet;
        }

        void LeftMouseDown(int x, int y, int delay, bool estMode) {
            if (!estMode) {
                SetCursorPos(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                System.Threading.Thread.Sleep(delay);
            }
            else {
                estimatedTime += delay;
            }

        }

        void LeftMouseUp(int x, int y, int delay, bool estMode) {
            if (!estMode) {
                SetCursorPos(x, y);
                mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                System.Threading.Thread.Sleep(delay);
            }
            else {
                estimatedTime += delay;
            }

        }


        void DrawPixel(bool[,] matrix, int px, int py, bool est) {
            int xpos = drawLocationX + (int)Math.Round(px * penSizeX);
            int ypos = drawLocationY + (int)Math.Round(py * penSizeY);

            LeftMouseDown(xpos, ypos, MOUSEDELAY, est);

            if (!NeighborLineDraw(matrix, px, py, est)) {
                for (int i = 0; i < 6; i++) {
                    LeftMouseDown(xpos, ypos, MOUSEDELAY / 2, est);
                    LeftMouseUp(xpos, ypos, 2, est);
                }
            }
            LeftMouseUp(xpos, ypos, MOUSEDELAY / 2, est);

        }

        private bool Draw(bool est) {
            if (!est) {
                ActivateWindow("Rec Room");
                Thread.Sleep(1000);
            }
            else {
                estimatedTime += 1000;
            }

            Color[] pallet = ImageToPallet(image);

            for (int c = 0; c < pallet.Length; c++) {
                float progress = (float)(c / (float)pallet.Length) * 100;
                progressBar1.Value = (int)progress;
                if (c < skipColors || pallet[c] == Color.FromArgb(255, 255, 255)) {
                    continue;
                }
                bool[,] sMatrix = new bool[image.Width, image.Height];
                if (fillFirstLayer && c == 0) {
                    for (int i = 0; i < sMatrix.GetLength(0); i++) {
                        for (int j = 0; j < sMatrix.GetLength(1); j++) {
                            sMatrix[i, j] = true;
                        }
                    }
                }
                else {
                    sMatrix = CoverageMatrix(image, pallet[c]);
                }
                bool[,] cMatrix = new bool[image.Width, image.Height];
                Array.Copy(sMatrix, cMatrix, sMatrix.Length);

                if (!est) {
                    SetPenColor($"{pallet[c].R:X2}{pallet[c].G:X2}{pallet[c].B:X2}");
                }
                else {
                    estimatedTime += COLORCHANGEDELAY * 5;
                }
                int iResetNumber = 0;
                int jResetNumber = 0;
                for (int j = jResetNumber, i = iResetNumber; j < cMatrix.GetLength(1) && i < cMatrix.GetLength(0);) {
                    if (!est) {
                        Application.DoEvents();
                        if (ModifierKeys == Keys.Alt)
                            return false;
                    }
                    if (cMatrix[i, j]) {
                        DrawPixel(cMatrix, i, j, est);
                    }
                    if (!scanDirection) {
                        i++;
                        if (i >= cMatrix.GetLength(0)) {
                            jResetNumber++;
                            i = iResetNumber;
                            j = jResetNumber;
                            scanDirection = !scanDirection;
                        }
                    }
                    else {
                        j++;
                        if (j >= cMatrix.GetLength(1)) {
                            iResetNumber++;
                            i = iResetNumber;
                            j = jResetNumber;
                            scanDirection = !scanDirection;
                        }
                    }
                }
                if (!est) {
                    skipColorBox.Text = c.ToString();
                }
            }
            if (!est) {
                skipColorBox.Text = 0.ToString();
            }
            return true;
        }

        private void UploadButton_Click(object sender, EventArgs e) {
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                imageFile = new Bitmap(openFileDialog1.FileName);
                drawWidth = imageFile.Width;
                drawHeight = imageFile.Height;
                widthInput.Text = drawWidth.ToString();
                heightInput.Text = drawHeight.ToString();
                image = imageFile;
                ProcessImage();
                pictureBox1.Image = BitmapExtensions.Resize(image, new Size(1920, 1080), scaleType, true);
                imagePreview = image;
                EnableControls(true);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e) {
            pictureBox1.Image = null;
            imageFile = null;
            image = null;
            imagePreview = null;
            EnableControls(false);
        }



        private void WidthInput_TextChanged(object sender, EventArgs e) {
            // Change in width of image
            try {
                drawWidth = Convert.ToInt32(widthInput.Text);
                drawWidth = int.Parse(widthInput.Text);
            }
            catch (Exception) {
                drawWidth = image.Width;
            }
        }


        private void DrawPositionButton_Click(object sender, EventArgs e) {

        }


        private void StartButton_Click(object sender, EventArgs e) {
            // Set Drawing Position
            try {
                ProcessImage();
                Start();
            }
            catch (Exception) {
                MessageBox.Show(new Form() { TopMost = true }, "No image was found", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void HeightInput_TextChanged(object sender, EventArgs e) {
            // Change in height of image
            try {
                drawHeight =


                    Convert.ToInt32(heightInput.Text);
                drawHeight = int.Parse(heightInput.Text);
            }
            catch (Exception) {
                drawHeight = image.Height;
            }
        }

        private void XBox_TextChanged(object sender, EventArgs e) {
            // Delay interval between the drawing of each pixel
            try {
                drawLocationX = Convert.ToInt32(XBox.Text);
                drawLocationX = int.Parse(XBox.Text);
            }
            catch (Exception) {
                drawLocationX = 0;
            }
        }

        private void YBox_TextChanged(object sender, EventArgs e) {
            // Delay interval between the drawing of each pixel
            try {
                drawLocationY = Convert.ToInt32(YBox.Text);
                drawLocationY = int.Parse(YBox.Text);
            }
            catch (Exception) {
                drawLocationY = 0;
            }
        }


        private void maxColorsBox_TextChanged(object sender, EventArgs e) {
            try {
                maxColors = Convert.ToInt32(maxColorsBox.Text);
                maxColors = int.Parse(maxColorsBox.Text);
            }
            catch (Exception) {
                maxColors = 1;
            }
        }


        private void skipColorBox_TextChanged(object sender, EventArgs e) {
            try {
                skipColors = Convert.ToInt32(skipColorBox.Text);
                skipColors = int.Parse(skipColorBox.Text);
            }
            catch (Exception) {
                skipColors = 0;
            }
        }


        private void firstLayerFill_CheckedChanged(object sender, EventArgs e) {
            try {
                fillFirstLayer = firstLayerFill.Checked;
            }
            catch (Exception) {
                fillFirstLayer = true;
            }
        }

        private void ditherBox_SelectedIndexChanged(object sender, EventArgs e) {
            try {

                ditherPattern = ditherBox.SelectedIndex;
                ProcessImage();
            }
            catch (Exception) {
                ditherPattern = 0;
            }
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {

        }

        private void estButton_Click(object sender, EventArgs e) {
            estimatedTime = 0;
            progressBar1.Value = 0;
            ProcessImage();
            Draw(true);
            progressBar1.Value = 100;
            estTime.Text = ConvertMillisecondsToTimeFormat(estimatedTime);
        }

        public static string ConvertMillisecondsToTimeFormat(long milliseconds) {
            // Convert milliseconds to a TimeSpan
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);

            // Format the TimeSpan as "dd:hh:mm:ss"
            string formattedTime = $"D{timeSpan.Days:D2}:H{timeSpan.Hours:D2}:M{timeSpan.Minutes:D2}:S{timeSpan.Seconds:D2}";

            return formattedTime;
        }

        private void widthInput_Leave(object sender, EventArgs e) {
            ProcessImage();
            pictureBox1.Image = BitmapExtensions.Resize(image, new Size(1920, 1080), scaleType, true);
            imagePreview = image;


        }

        private void heightInput_Leave(object sender, EventArgs e) {
            ProcessImage();
            pictureBox1.Image = BitmapExtensions.Resize(image, new Size(1920, 1080), scaleType, true);
            imagePreview = image;
        }

        private void GapYBox_Leave(object sender, EventArgs e) {
            try {
                penSizeY = (float)Convert.ToDouble(GapYBox.Text) + 1;
                penSizeY = float.Parse(GapYBox.Text) + 1;
            }
            catch (Exception) {
                penSizeY = 1;
            }
        }

        private void GapXBox_Leave(object sender, EventArgs e) {
            try {
                penSizeX = (float)Convert.ToDouble(GapXBox.Text) + 1;
                penSizeX = float.Parse(GapXBox.Text) + 1;
            }
            catch (Exception) {
                penSizeX = 1;
            }
        }

        private void maxColorsBox_Leave(object sender, EventArgs e) {
            ProcessImage();
        }

        private void label6_Click(object sender, EventArgs e) {

        }

        private void pixelateBar_Scroll(object sender, EventArgs e) {
            pixelation = (double)pixelateBar.Value / 100;
            Console.WriteLine(pixelation);
        }

        private void pixelateBar_MouseCaptureChanged(object sender, EventArgs e) {
            ProcessImage();
        }

        private void DrawPositionButton_Click_1(object sender, EventArgs e) {
            // Set Drawing Position
            MouseEventArgs mouse = e as MouseEventArgs;
            try {
                ProcessImage();
                DrawPreviewForm m = new DrawPreviewForm(mouse) { Opacity = 0.5 };
                m.Show();
                WindowState = FormWindowState.Minimized;
                const int locationOffset = 20;
                const int sizeOffset = 40;
                m.Location = new Point(drawLocationX - locationOffset, drawLocationY - locationOffset);
                m.Size = new Size((int)Math.Round((drawWidth * penSizeX) + sizeOffset), (int)Math.Round((drawHeight * penSizeY) + sizeOffset));
                var lastSize = m.Size;
                var isSet = true;
                while (isSet) {
                    Application.DoEvents();

                    void setPosition() {
                        WindowState = FormWindowState.Normal;
                        m.Close();
                        isSet = false;
                    }

                    m.setButton.Click += (buttonSender, buttonEventArgs) => {
                        setPosition();
                    };
                    m.setButtonTop.Click += (buttonSender, buttonEventArgs) => {
                        setPosition();
                    };

                    XBox.Text = Convert.ToString(m.Location.X + locationOffset);
                    YBox.Text = Convert.ToString(m.Location.Y + locationOffset);

                    if (m.Size != lastSize) {
                        int newx = (int)Math.Round(m.Size.Width / penSizeX - sizeOffset);
                        int newy = (int)Math.Round(m.Size.Height / penSizeY - sizeOffset);
                        widthInput.Text = newx.ToString();
                        heightInput.Text = newy.ToString();
                        m.UpdateImage(imagePreview);
                    }
                    lastSize = m.Size;
                    m.TopMost = true;
                }
            }
            catch (Exception) {
                MessageBox.Show(new Form() { TopMost = true }, "No image was found", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}