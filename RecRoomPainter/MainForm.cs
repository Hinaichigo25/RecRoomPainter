using KGySoft.CoreLibraries;
using KGySoft.Drawing;
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

        public class UserSettingVars {
            public int DrawW {
                get; set;
            }
            public int DrawH {
                get; set;
            }
            public int DrawX {
                get; set;
            }
            public int DrawY {
                get; set;
            }
            public int CropW {
                get; set;
            }
            public int CropH {
                get; set;
            }
            public int CropX {
                get; set;
            }
            public int CropY {
                get; set;
            }

            public double Pixelation {
                get; set;
            }
            public int MaxColors {
                get; set;
            }
            public int SkipColors {
                get; set;
            }
            public bool FillFirstLayer {
                get; set;
            }
            public int DitherPattern {
                get; set;
            }
            public float PenSizeX {
                get; set;
            }
            public float PenSizeY {
                get; set;
            }
        }

        public static UserSettingVars UserSettings = new UserSettingVars {
            DrawW = 0,
            DrawH = 0,
            DrawX = 0,
            DrawY = 0,
            CropW = 0,
            CropH = 0,
            CropX = 0,
            CropY = 0,
            Pixelation = 1,
            MaxColors = 16,
            SkipColors = 0,
            FillFirstLayer = false,
            DitherPattern = 0,
            PenSizeX = 1,
            PenSizeY = 1,
        };


        public static Bitmap imageFile;
        public static Bitmap imageModified;
        public static Bitmap imagePreview;

        bool scanDirection = false;
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
            CropButton.Enabled = enable;
            CropHBox.Enabled = enable;
            CropWBox.Enabled = enable;
            CropXBox.Enabled = enable;
            CropYBox.Enabled = enable;
        }

        public void UpdateUITextValues() {
            widthInput.Text = UserSettings.DrawW.ToString();
            heightInput.Text = UserSettings.DrawH.ToString();
            skipColorBox.Text = UserSettings.SkipColors.ToString();
            maxColorsBox.Text = UserSettings.MaxColors.ToString();
            XBox.Text = UserSettings.DrawX.ToString();
            YBox.Text = UserSettings.DrawY.ToString();
            GapXBox.Text = (UserSettings.PenSizeX - 1).ToString();
            GapYBox.Text = (UserSettings.PenSizeY - 1).ToString();
            CropHBox.Text = UserSettings.CropH.ToString();
            CropWBox.Text = UserSettings.CropW.ToString();
            CropXBox.Text = UserSettings.CropX.ToString();
            CropYBox.Text = UserSettings.CropY.ToString();
        }


        public void ProcessImage() {
            try {
                EnableControls(false);
                progressBar1.Value = 0;
                imageModified = (Bitmap)imageFile.Clone();
                imageModified = ResizeImage(imageFile, new Size(UserSettings.DrawW, UserSettings.DrawH), UserSettings.Pixelation);
                progressBar1.Value = 10;

                IDitherer dither = OrderedDitherer.Bayer2x2;

                IQuantizer quantizer = OptimizedPaletteQuantizer.Wu(UserSettings.MaxColors);
                switch (UserSettings.DitherPattern) {
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
                if (UserSettings.DitherPattern > 0) {
                    BitmapExtensions.Dither(imageModified, quantizer, dither);
                }
                else {
                    imageModified = imageModified.ConvertPixelFormat(PixelFormat.Format32bppArgb, quantizer);
                }
                progressBar1.Value = 50;
                imageModified = BitmapExtensions.Resize(imageModified, imageFile.Size, ScalingMode.NearestNeighbor);
                imageModified = CropImageSet(imageModified);
                imageModified = BitmapExtensions.Resize(imageModified, new Size((int)Math.Round(UserSettings.DrawW / UserSettings.PenSizeX), (int)Math.Round(UserSettings.DrawH / UserSettings.PenSizeY)), ScalingMode.NearestNeighbor);
                SetPreview();

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

        List<List<int>> CoverageMatrix(Bitmap img, Color color) {
            List<List<int>> matrix = new List<List<int>>(img.Width);

            // Initialize the 2D list with rows and columns filled with 0
            for (int i = 0; i < img.Width; i++) {
                List<int> row = new List<int>(img.Height);
                for (int j = 0; j < img.Height; j++) {
                    if (img.GetPixel(i, j) == color) {
                        row.Add(1);
                    }
                    else {
                        row.Add(0);
                    }
                }
                matrix.Add(row);
            }
            return matrix;
        }

        void MoveMouse(int x, int y, int delay, bool estMode) {
            if (!estMode) {
                SetCursorPos(x, y);
                Thread.Sleep(delay);
            }
            estimatedTime += delay;
        }


        int NeighborLineDraw(List<List<int>> matrix, int x, int y, int changes, bool est) {

            int CheckNeighbor(int cx, int cy, int count) {
                int relx = x + cx;
                int rely = y + cy;
                if (relx >= 0 && rely >= 0 && relx < matrix.Count && rely < matrix[0].Count) {
                    if (matrix[relx][rely] > 0) {
                        x = relx;
                        y = rely;
                        return CheckNeighbor(cx, cy, count + 1);
                    }
                }
                return count;
            }
            void DrawLine(int dirX, int dirY, int steps) {
                changes += steps;
                matrix[x][y] = 0;
                for (int i = 0; i < steps; i++) {
                    if (x + dirX >= 0 && y + dirY >= 0 && x + dirX < matrix.Count && y + dirY < matrix[0].Count) {
                        x += dirX;
                        y += dirY;
                        matrix[x][y] = 0;
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
                    dirCount[i] = CheckNeighbor(addXValues[i], addYValues[i], 0);
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
                    MoveMouse(UserSettings.DrawX + (int)Math.Round(x * UserSettings.PenSizeX), UserSettings.DrawY + (int)Math.Round(y * UserSettings.PenSizeY), speed, est);
                }
            }
            return changes;
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
            estimatedTime += delay;

        }

        void LeftMouseUp(int x, int y, int delay, bool estMode) {
            if (!estMode) {
                SetCursorPos(x, y);
                mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                System.Threading.Thread.Sleep(delay);
            }
            estimatedTime += delay;

        }


        int DrawPixel(List<List<int>> matrix, int px, int py, bool est) {
            int xpos = UserSettings.DrawX + (int)Math.Round(px * UserSettings.PenSizeX);
            int ypos = UserSettings.DrawY + (int)Math.Round(py * UserSettings.PenSizeY);

            LeftMouseDown(xpos, ypos, MOUSEDELAY, est);
            int changes = NeighborLineDraw(matrix, px, py, 0, est);
            if (changes == 0) {
                matrix[px][py] = 0;
                for (int i = 0; i < 6; i++) {
                    LeftMouseDown(xpos, ypos, MOUSEDELAY / 2, est);
                    LeftMouseUp(xpos, ypos, 2, est);
                }
                changes = 1;
            }
            LeftMouseUp(xpos, ypos, MOUSEDELAY / 2, est);
            return changes;
        }

        void CountEdgesMatrix(List<List<int>> matrix) {

            for (int i = 0; i < matrix.Count; i++) {
                for (int j = 0; j < matrix[i].Count; j++) {
                    if (matrix[i][j] > 0) {
                        if (i + 1 < matrix.Count) {

                            if (matrix[i + 1][j] == 0)
                                matrix[i][j]++;
                        }
                        else
                            matrix[i][j]++;
                        if (j + 1 < matrix.Count) {
                            if (matrix[i][j + 1] == 0)
                                matrix[i][j]++;
                        }
                        else
                            matrix[i][j]++;
                        if (i - 1 >= 0) {

                            if (matrix[i - 1][j] == 0)
                                matrix[i][j]++;
                        }
                        else
                            matrix[i][j]++;
                        if (j - 1 >= 0) {

                            if (matrix[i][j - 1] == 0)
                                matrix[i][j]++;
                        }
                        else
                            matrix[i][j]++;
                    }
                }
            }
        }

        private bool Draw(bool est) {
            if (!est) {
                ActivateWindow("Rec Room");
                Thread.Sleep(1000);
            }
            estimatedTime += 1000;

            Color[] pallet = ImageToPallet(imageModified);

            for (int c = 0; c < pallet.Length; c++) {
                float progress = (float)(c / (float)pallet.Length) * 100;
                progressBar1.Value = (int)progress;
                if (c < UserSettings.SkipColors || pallet[c] == Color.FromArgb(255, 255, 0, 255)) {
                    continue;
                }

                List<List<int>> cMatrix = new List<List<int>>(imageModified.Width);
                if (UserSettings.FillFirstLayer && c == 0) {
                    // Initialize the 2D list with rows and columns filled with 0
                    for (int i = 0; i < imageModified.Width; i++) {
                        List<int> row = new List<int>(imageModified.Height);
                        for (int j = 0; j < imageModified.Height; j++) {
                            row.Add(1);
                        }
                        cMatrix.Add(row);
                    }
                }
                else {
                    cMatrix = CoverageMatrix(imageModified, pallet[c]);
                }

                if (!est) {
                    SetPenColor($"{pallet[c].R:X2}{pallet[c].G:X2}{pallet[c].B:X2}");
                }
                estimatedTime += COLORCHANGEDELAY * 5;
                for (int i2 = 0; i2 < cMatrix.Count; i2++) {
                    for (int j2 = 0; j2 < cMatrix[i2].Count; j2++) {
                        if (!est) {
                            Application.DoEvents();
                            if (ModifierKeys == Keys.Alt)
                                return false;
                        }
                        if (cMatrix[i2][j2] >= 1) {
                            DrawPixel(cMatrix, i2, j2, est);
                        }

                    }
                }
                if (!est) {
                    UserSettings.SkipColors = c;
                    UpdateUITextValues();
                }
            }
            if (!est) {
                UserSettings.SkipColors = 0;
                UpdateUITextValues();
            }
            return true;
        }

        private void UploadButton_Click(object sender, EventArgs e) {
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                imageFile = new Bitmap(openFileDialog1.FileName);
                imageFile = imageFile.ConvertPixelFormat(PixelFormat.Format32bppArgb);
                UserSettings.DrawW = imageFile.Width;
                UserSettings.DrawH = imageFile.Height;
                UserSettings.DrawX = 0;
                UserSettings.DrawY = 0;
                UserSettings.CropW = imageFile.Width;
                UserSettings.CropH = imageFile.Height;
                UserSettings.CropX = 0;
                UserSettings.CropY = 0;
                UpdateUITextValues();
                imageModified = imageFile;
                ProcessImage();
                pictureBox1.Image = BitmapExtensions.Resize(imageModified, new Size(1920, 1080), scaleType, true);
                imagePreview = imageModified;
                EnableControls(true);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e) {
            pictureBox1.Image = null;
            imageFile = null;
            imageModified = null;
            imageModified = null;
            imagePreview = null;
            EnableControls(false);
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


        private void firstLayerFill_CheckedChanged(object sender, EventArgs e) {
            try {
                UserSettings.FillFirstLayer = firstLayerFill.Checked;
            }
            catch (Exception) {
                UserSettings.FillFirstLayer = true;
            }
        }

        private void ditherBox_SelectedIndexChanged(object sender, EventArgs e) {
            try {

                UserSettings.DitherPattern = ditherBox.SelectedIndex;
                ProcessImage();
            }
            catch (Exception) {
                UserSettings.DitherPattern = 0;
            }
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {

        }

        public static Bitmap CropImageSet(Bitmap img) {
            Bitmap newImg = (Bitmap)img.Clone();
            for (int i = 0; i < newImg.Width; i++) {
                for (int j = 0; j < newImg.Height; j++) {
                    if (i < UserSettings.CropX) {
                        newImg.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 0, 255));
                    }
                    if (i > UserSettings.CropW) {
                        newImg.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 0, 255));
                    }
                    if (j < UserSettings.CropY) {
                        newImg.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 0, 255));
                    }
                    if (j > UserSettings.CropH) {
                        newImg.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 0, 255));
                    }
                }
            }
            return newImg;
        }
        public void SetPreview() {
            imagePreview = (Bitmap)imageModified.Clone();
            pictureBox1.Image = BitmapExtensions.Resize(imagePreview, new Size((int)Math.Round(imagePreview.Width * UserSettings.PenSizeX), (int)Math.Round(imagePreview.Height * UserSettings.PenSizeY)), scaleType, true);
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
            // Change in width of image
            try {
                UserSettings.DrawW = Convert.ToInt32(widthInput.Text);
                UserSettings.DrawW = int.Parse(widthInput.Text);
            }
            catch (Exception) {
                UserSettings.DrawW = imageModified.Width;
            }
            ProcessImage();

        }

        private void heightInput_Leave(object sender, EventArgs e) {
            // Change in height of image
            try {
                UserSettings.DrawH = Convert.ToInt32(heightInput.Text);
                UserSettings.DrawH = int.Parse(heightInput.Text);
            }
            catch (Exception) {
                UserSettings.DrawH = imageModified.Height;
            }
            ProcessImage();
        }

        private void GapYBox_Leave(object sender, EventArgs e) {
            try {
                UserSettings.PenSizeY = (float)Convert.ToDouble(GapYBox.Text) + 1;
                UserSettings.PenSizeY = float.Parse(GapYBox.Text) + 1;
            }
            catch (Exception) {
                UserSettings.PenSizeY = 1;
            }
        }

        private void GapXBox_Leave(object sender, EventArgs e) {
            try {
                UserSettings.PenSizeX = (float)Convert.ToDouble(GapXBox.Text) + 1;
                UserSettings.PenSizeX = float.Parse(GapXBox.Text) + 1;
            }
            catch (Exception) {
                UserSettings.PenSizeX = 1;
            }
        }

        private void maxColorsBox_Leave(object sender, EventArgs e) {
            try {
                UserSettings.MaxColors = Convert.ToInt32(maxColorsBox.Text);
                UserSettings.MaxColors = int.Parse(maxColorsBox.Text);
            }
            catch (Exception) {
                UserSettings.MaxColors = 1;
            }
            ProcessImage();
        }

        private void label6_Click(object sender, EventArgs e) {

        }

        private void pixelateBar_Scroll(object sender, EventArgs e) {
            UserSettings.Pixelation = (double)pixelateBar.Value / 100;
            Console.WriteLine(UserSettings.Pixelation);
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
                m.Size = new Size(UserSettings.DrawW + sizeOffset, UserSettings.DrawH + sizeOffset);
                m.Location = new Point(UserSettings.DrawX - locationOffset, UserSettings.DrawY - locationOffset);
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

                    UserSettings.DrawX = m.Location.X + locationOffset;
                    UserSettings.DrawY = m.Location.Y + locationOffset;
                    UpdateUITextValues();

                    if (m.Size != lastSize) {
                        int newx = m.Size.Width - sizeOffset;
                        int newy = m.Size.Height - sizeOffset;
                        UserSettings.DrawW = newx;
                        UserSettings.DrawH = newy;
                        UpdateUITextValues();
                        ProcessImage();
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

        private void CropButton_Click(object sender, EventArgs e) {
            MouseEventArgs mouse = e as MouseEventArgs;
            CropWindow m = new CropWindow(mouse);
            m.Show();
            WindowState = FormWindowState.Minimized;
            m.pictureBox1.Image = imagePreview;
            m.Size = new Size(m.pictureBox1.Location.X + imageModified.Width, m.pictureBox1.Location.Y + imageModified.Height);
            m.StartPosition = FormStartPosition.CenterScreen;

        }

        private void CropYBox_Leave(object sender, EventArgs e) {
            try {
                UserSettings.CropY = Convert.ToInt32(CropYBox.Text);
                UserSettings.CropY = int.Parse(CropYBox.Text);
            }
            catch (Exception) {
                UserSettings.CropY = 0;
            }
        }

        private void CropXBox_Leave(object sender, EventArgs e) {
            try {
                UserSettings.CropX = Convert.ToInt32(CropXBox.Text);
                UserSettings.CropX = int.Parse(CropXBox.Text);
            }
            catch (Exception) {
                UserSettings.CropX = 0;
            }
        }

        private void CropHBox_Leave(object sender, EventArgs e) {
            try {
                UserSettings.CropH = Convert.ToInt32(CropHBox.Text);
                UserSettings.CropH = int.Parse(CropHBox.Text);
            }
            catch (Exception) {
                UserSettings.CropH = 0;
            }
        }

        private void CropWBox_Leave(object sender, EventArgs e) {
            try {
                UserSettings.CropW = Convert.ToInt32(CropWBox.Text);
                UserSettings.CropW = int.Parse(CropWBox.Text);
            }
            catch (Exception) {
                UserSettings.CropW = 0;
            }
        }

        private void YBox_Leave(object sender, EventArgs e) {
            // Delay interval between the drawing of each pixel
            try {
                UserSettings.DrawY = Convert.ToInt32(YBox.Text);
                UserSettings.DrawY = int.Parse(YBox.Text);
            }
            catch (Exception) {
                UserSettings.DrawY = 0;
            }
        }

        private void XBox_Leave(object sender, EventArgs e) {
            // Delay interval between the drawing of each pixel
            try {
                UserSettings.DrawX = Convert.ToInt32(XBox.Text);
                UserSettings.DrawX = int.Parse(XBox.Text);
            }
            catch (Exception) {
                UserSettings.DrawX = 0;
            }
        }

        private void skipColorBox_Leave(object sender, EventArgs e) {
            try {
                UserSettings.SkipColors = Convert.ToInt32(skipColorBox.Text);
                UserSettings.SkipColors = int.Parse(skipColorBox.Text);
            }
            catch (Exception) {
                UserSettings.SkipColors = 0;
            }
        }

        private void MainForm_Enter(object sender, EventArgs e) {

        }

        private void MainForm_Activated(object sender, EventArgs e) {
            UpdateUITextValues();
            if (imageModified != null)
                ProcessImage();
        }
    }
}
