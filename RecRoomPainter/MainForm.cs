using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using KGySoft.CoreLibraries;
using KGySoft.Drawing;
using KGySoft.Drawing.Imaging;

namespace RecRoomPainter
{

    public partial class MainForm : Form
    {
        public static ScalingMode scaleType = ScalingMode.Box;
        public static ScalingMode processScaleType = ScalingMode.NearestNeighbor;

        const int MOUSEUPDELAY = 40;
        const int MOUSEDOWNDELAY = 20;
        const int MOUSETURNDELAY = 20;
        int COLORCHANGEDELAY = 1000;

        public static class UserSettings
        {
            static UserSettings()
            {
                DrawW = 0;
                DrawH = 0;
                DrawX = 0;
                DrawY = 0;
                CropW = 0;
                CropH = 0;
                CropX = 0;
                CropY = 0;
                Pixelation = 1;
                MaxColors = 16;
                SkipColors = 0;
                Passes = 1;
                FillFirstLayer = false;
                DitherPattern = 0;
                QuantType = 0;
                PenSize = 4;
                RandomOrder = false;
                VectorMode = false;
                DirectDraw = false;
            }
            public static int DrawW { get; set; }
            public static int DrawH { get; set; }
            public static int DrawX { get; set; }
            public static int DrawY { get; set; }
            public static int CropW { get; set; }
            public static int CropH { get; set; }
            public static int CropX { get; set; }
            public static int CropY { get; set; }
            public static double Pixelation { get; set; }
            public static int MaxColors { get; set; }
            public static int SkipColors { get; set; }

            public static int Passes { get; set; }
            public static bool FillFirstLayer { get; set; }
            public static int DitherPattern { get; set; }
            public static int QuantType { get; set; }
            public static float PenSize { get; set; }
            public static bool VectorMode { get; set; }
            public static bool DirectDraw { get; set;}
            public static bool RandomOrder { get; set;}

        }

        public static class DrawImage
        {
            public static Bitmap Original { get; set; }
            public static Bitmap Modified { get; set; }
            public static Bitmap Preview { get; set; }
        }


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

        public MainForm()
        {
            InitializeComponent();
        }

        public static void ActivateWindow(string windowTitle)
        {
            IntPtr windowHandle = FindWindow(null, windowTitle);

            if (windowHandle != IntPtr.Zero)
            {
                // Bring the window to the foreground
                SetForegroundWindow(windowHandle);

                // Set focus to the window
                SetFocus(windowHandle);
            }
            else
            {
                Console.WriteLine("Window not found with the specified title.");
            }
        }


        void EnableControls(bool enable)
        {
            widthInput.Enabled = enable;
            heightInput.Enabled = enable;
            pixelateBar.Enabled = enable;
            DrawPositionButton.Enabled = enable;
            skipColorBox.Enabled = enable;
            maxColorsBox.Enabled = enable;
            firstLayerFill.Enabled = enable;
            ditherBox.Enabled = enable;
            quantBox.Enabled = enable;
            startButton.Enabled = enable;
            clearButton.Enabled = enable;
            XBox.Enabled = enable;
            YBox.Enabled = enable;
            GapXBox.Enabled = enable;
            CropButton.Enabled = enable;
            cropXnum.Enabled = enable;
            cropYnum.Enabled = enable;
            cropWnum.Enabled = enable;
            cropHnum.Enabled = enable;
        }

        public void UpdateUITextValues()
        {
            widthInput.Text = UserSettings.DrawW.ToString();
            heightInput.Text = UserSettings.DrawH.ToString();
            skipColorBox.Text = UserSettings.SkipColors.ToString();
            maxColorsBox.Text = UserSettings.MaxColors.ToString();
            XBox.Text = UserSettings.DrawX.ToString();
            YBox.Text = UserSettings.DrawY.ToString();
            GapXBox.Text = (UserSettings.PenSize - 1).ToString();
            cropXnum.Value = UserSettings.CropX;
            cropYnum.Value = UserSettings.CropY;
            cropWnum.Value = UserSettings.CropW;
            cropHnum.Value = UserSettings.CropH;
        }


        public void ProcessImage()
        {
            try
            {
                EnableControls(false);
                progressBar1.Value = 0;
                DrawImage.Modified = (Bitmap)DrawImage.Original.Clone();
                DrawImage.Modified = BitmapExtensions.Resize(DrawImage.Original, new Size((int)Math.Round(UserSettings.DrawW * UserSettings.Pixelation), (int)Math.Round(UserSettings.DrawH * UserSettings.Pixelation)), processScaleType);

                progressBar1.Value = 10;
                IDitherer dither = OrderedDitherer.Bayer2x2;

                IQuantizer quantizer = OptimizedPaletteQuantizer.MedianCut(UserSettings.MaxColors);
                switch (UserSettings.QuantType)
                {
                    case 1:
                        quantizer = OptimizedPaletteQuantizer.Wu(UserSettings.MaxColors);
                        break;
                    case 2:
                        quantizer = OptimizedPaletteQuantizer.Octree(UserSettings.MaxColors);
                        break;
                }

                switch (UserSettings.DitherPattern)
                {
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
                if (UserSettings.DitherPattern > 0)
                {
                    BitmapExtensions.Dither(DrawImage.Modified, quantizer, dither);
                }
                else
                {
                    DrawImage.Modified = DrawImage.Modified.ConvertPixelFormat(PixelFormat.Format32bppArgb, quantizer);
                }
                progressBar1.Value = 50;
                //DrawImage.Modified = BitmapExtensions.Resize(DrawImage.Modified, DrawImage.Original.Size, ScalingMode.NearestNeighbor);
                DrawImage.Modified = CropImageSet(DrawImage.Modified);
                DrawImage.Modified = BitmapExtensions.Resize(DrawImage.Modified, new Size((int)Math.Round(UserSettings.DrawW / UserSettings.PenSize), (int)Math.Round(UserSettings.DrawH / UserSettings.PenSize)), ScalingMode.NearestNeighbor);
                SetPreview();

                progressBar1.Value = 100;
                EnableControls(true);

            }
            catch (Exception)
            {
                MessageBox.Show(new Form() { TopMost = true }, "No image was found", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void Start()
        {
            try
            {
                if (Draw(false))
                    MessageBox.Show(new Form() { TopMost = true }, "Drawing Complete", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show(new Form() { TopMost = true }, "Drawing halted", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                MessageBox.Show(new Form() { TopMost = true }, "No image was found", "Drawing Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void SetPenColor(string hex)
        {
            COLORCHANGEDELAY += 80;

            bool UserForceQuit()
            {
                Application.DoEvents();
                if (ModifierKeys == Keys.Alt)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            Clipboard.SetText(hex);

            const int CCLocationX = 1334;
            const int CCLocationY = 836;
            const int HexCLocationX = 1366;
            const int HexCLocationY = 652;
            const int DoneCLocationX = 1320;
            const int DoneCLocationY = 756;



            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            if (UserForceQuit())
            {
                return;
            }
            Thread.Sleep(COLORCHANGEDELAY);
            SetCursorPos(CCLocationX, CCLocationY);
            mouse_event(MOUSEEVENTF_LEFTDOWN, CCLocationX, CCLocationY, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, CCLocationX, CCLocationY, 0, 0);
            if (UserForceQuit())
            {
                return;
            }
            Thread.Sleep(COLORCHANGEDELAY);
            SetCursorPos(HexCLocationX, HexCLocationY);
            mouse_event(MOUSEEVENTF_LEFTDOWN, HexCLocationX, HexCLocationY, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, HexCLocationX, HexCLocationX, 0, 0);
            if (UserForceQuit())
            {
                return;
            }
            Thread.Sleep(COLORCHANGEDELAY);
            SendKeys.Send("^(a)");
            if (UserForceQuit())
            {
                return;
            }
            Thread.Sleep(COLORCHANGEDELAY);
            SendKeys.Send("^(v)");
            if (UserForceQuit())
            {
                return;
            }
            Thread.Sleep(COLORCHANGEDELAY);
            SetCursorPos(DoneCLocationX, DoneCLocationY);
            mouse_event(MOUSEEVENTF_LEFTDOWN, DoneCLocationX, DoneCLocationY, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, DoneCLocationX, DoneCLocationY, 0, 0);
            if (UserForceQuit())
            {
                return;
            }
            Thread.Sleep(COLORCHANGEDELAY);
        }

        public static int GetMaxDirIndex(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("Array is null or empty");

            int maxIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (i > 3)
                {
                    if (arr[i] > arr[maxIndex] * 2)
                        maxIndex = i;
                }
                else
                {
                    if (arr[i] > arr[maxIndex])
                        maxIndex = i;
                }
            }

            return maxIndex;
        }

        int[,] CoverageMatrix(Bitmap img, Color color)
        {
            int[,] matrix = new int[img.Width, img.Height];

            // Initialize the 2D array with values filled based on color match
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    if (img.GetPixel(i, j) == color)
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            return matrix;
        }


        void MoveMouse(int x, int y, int delay, bool estMode)
        {
            if (!estMode)
            {
                SetCursorPos(x, y);
                Thread.Sleep(delay);
                System.Threading.Thread.Sleep(delay);
            }
            estimatedTime += delay;
        }

        int NeighborLineDraw(int[,] tMatrix, int[,] matrix, int x, int y, int changes, bool est)
        {

            int[] CheckNeighbor(int cx, int cy, int count, int end, int total)
            {
                int relx = x + cx;
                int rely = y + cy;
                if (relx >= 0 && rely >= 0 && relx < matrix.GetLength(0) && rely < matrix.GetLength(1))
                {
                    if (matrix[relx, rely] > 0)
                    {
                        x = relx;
                        y = rely;
                        return CheckNeighbor(cx, cy, count + 1, total + 1, total + 1);
                    }
                    else if (tMatrix[relx, rely] == 0 && !UserSettings.DirectDraw)
                    {
                        x = relx;
                        y = rely;
                        return CheckNeighbor(cx, cy, count, end, total + 1);
                    }
                }
                int[] pack = { count, end, total };
                return pack;
            }
            void DrawLine(int dirX, int dirY, int steps)
            {
                changes += steps;
                matrix[x, y] = 0;
                for (int i = 0; i < steps; i++)
                {
                    if (x + dirX >= 0 && y + dirY >= 0 && x + dirX < matrix.GetLength(0) && y + dirY < matrix.GetLength(1))
                    {
                        x += dirX;
                        y += dirY;
                        matrix[x, y] = 0;
                    }
                }
            }

            DrawSinglePixel(UserSettings.DrawX + (int)Math.Round(x * UserSettings.PenSize), UserSettings.DrawY + (int)Math.Round(y * UserSettings.PenSize), est);
            LeftMouseDown(UserSettings.DrawX + (int)Math.Round(x * UserSettings.PenSize), UserSettings.DrawY + (int)Math.Round(y * UserSettings.PenSize), MOUSEDOWNDELAY, est);

            while (true)
            {
                if (!est)
                {
                    Application.DoEvents();
                    if (ModifierKeys == Keys.Alt)
                    {
                        break;
                    }
                }

                List<int> addXValues = new List<int>();
                List<int> addYValues = new List<int>();

                //Up
                addXValues.Add(0);
                addYValues.Add(1);

                //Down
                addXValues.Add(0);
                addYValues.Add(-1);

                //Right
                addXValues.Add(1);
                addYValues.Add(0);

                //Left
                addXValues.Add(-1);
                addYValues.Add(0);

                if (UserSettings.VectorMode)
                {
                    //TopRight
                    addXValues.Add(1);
                    addYValues.Add(1);

                    //BottomRight
                    addXValues.Add(1);
                    addYValues.Add(-1);

                    //TopLeft
                    addXValues.Add(-1);
                    addYValues.Add(1);

                    //BottomLeft
                    addXValues.Add(-1);
                    addYValues.Add(-1);

                }

                int[] dirLength = Enumerable.Repeat(0, addXValues.Capacity).ToArray();
                int[] pixCount = Enumerable.Repeat(0, addXValues.Capacity).ToArray();


                for (int i = 0; i < addXValues.Capacity; i++)
                {

                    int xSave = x;
                    int ySave = y;
                    int[] pack = CheckNeighbor(addXValues[i], addYValues[i], 0, 0, 0);
                    dirLength[i] = pack[1];
                    pixCount[i] = pack[0];
                    x = xSave;
                    y = ySave;
                }

                int max = GetMaxDirIndex(pixCount);

                if (pixCount[max] == 0)
                {
                    break;
                }
                for (int i = 0; i < UserSettings.Passes; i++)
                {
                    if (i % 2 == 1)
                    {
                        DrawLine(-addXValues[max], -addYValues[max], dirLength[max]);
                    }
                    else
                    {
                        DrawLine(addXValues[max], addYValues[max], dirLength[max]);
                    }
                    MoveMouse(UserSettings.DrawX + (int)Math.Round(x * UserSettings.PenSize), UserSettings.DrawY + (int)Math.Round(y * UserSettings.PenSize), MOUSETURNDELAY, est);
                }
            }
            if (changes > 0)
            {
                DrawSinglePixel(UserSettings.DrawX + (int)Math.Round(x * UserSettings.PenSize), UserSettings.DrawY + (int)Math.Round(y * UserSettings.PenSize), est);
            }
            return changes;
        }

        Color[] ImageToPallet(Bitmap img)
        {
            // Create a HashSet to store unique numbers
            HashSet<Color> uniqueColorSet = new HashSet<Color>();
            for (int j = 0; j < img.Height; j++)
            {
                for (int i = 0; i < img.Width; i++)
                {
                    // Add each unique number to the HashSet
                    if (!uniqueColorSet.Contains(img.GetPixel(i, j)))
                    {
                        uniqueColorSet.Add(img.GetPixel(i, j));
                    }

                }
            }
            // Convert the HashSet to an array
            Color[] pallet = new Color[uniqueColorSet.Count];
            uniqueColorSet.CopyTo(pallet);

            for (int lenMod = 1; lenMod < pallet.Length; lenMod++)
            {
                for (int i = 0; i < pallet.Length - lenMod; i++)
                {
                    if (pallet[i].GetBrightness() < pallet[i + 1].GetBrightness())
                    {
                        Color temp = pallet[i];
                        pallet[i] = pallet[i + 1];
                        pallet[i + 1] = temp;

                    }
                }
            }
            return pallet;
        }

        void LeftMouseDown(int x, int y, int delay, bool estMode)
        {
            if (!estMode)
            {
                SetCursorPos(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                System.Threading.Thread.Sleep(delay);
            }
            estimatedTime += delay;

        }

        void LeftMouseUp(int x, int y, int delay, bool estMode)
        {
            if (!estMode)
            {
                SetCursorPos(x, y);
                mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                System.Threading.Thread.Sleep(delay);
            }
            estimatedTime += delay;

        }

        void DrawSinglePixel(int xpos, int ypos, bool est)
        {
            for (int i = 0; i < UserSettings.Passes; i++)
            {
                LeftMouseDown(xpos, ypos, MOUSEDOWNDELAY, est);
                LeftMouseUp(xpos, ypos, 2, est);
            }
        }

        int DrawPixel(int[,] tMatrix, int[,] matrix, int px, int py, bool est)
        {
            int xpos = UserSettings.DrawX + (int)Math.Round(px * UserSettings.PenSize);
            int ypos = UserSettings.DrawY + (int)Math.Round(py * UserSettings.PenSize);

            LeftMouseDown(xpos, ypos, MOUSEDOWNDELAY, est);
            int changes = NeighborLineDraw(tMatrix, matrix, px, py, 0, est);
            if (changes == 0)
            {
                matrix[px, py] = 0;
                changes = 1;
            }
            LeftMouseUp(xpos, ypos, MOUSEUPDELAY, est);
            return changes;
        }

        private bool Draw(bool est)
        {
            COLORCHANGEDELAY = 1000;
            if (!est)
            {
                ActivateWindow("Rec Room");
                Thread.Sleep(1000);
            }
            estimatedTime += 1000;

            Color[] pallet = ImageToPallet(DrawImage.Modified);

            int[,] tMatrix = new int[DrawImage.Modified.Width, DrawImage.Modified.Height];

            // Initialize the 2D array with values filled with 0
            for (int i = 0; i < DrawImage.Modified.Width; i++)
            {
                for (int j = 0; j < DrawImage.Modified.Height; j++)
                {
                    tMatrix[i, j] = 0;
                }
            }

            for (int c = 0; c < pallet.Length; c++)
            {

                float progress = (float)(c / (float)pallet.Length) * 100;
                progressBar1.Value = (int)progress;


                if (c > 0)
                {
                    for (int i = 0; i < DrawImage.Modified.Width; i++)
                    {
                        for (int j = 0; j < DrawImage.Modified.Height; j++)
                        {
                            if (DrawImage.Modified.GetPixel(i, j) == pallet[c - 1])
                            {
                                tMatrix[i, j] = 1;
                            }
                        }
                    }
                }

                if (c < UserSettings.SkipColors || pallet[c] == Color.FromArgb(255, 255, 0, 255))
                {
                    continue;
                }

                List<int[]> pixelList = new List<int[]>(0);

                int[,] cMatrix = new int[DrawImage.Modified.Width, DrawImage.Modified.Height];

                if (UserSettings.FillFirstLayer && c == 0)
                {
                    // Initialize the 2D array with values filled with 1
                    for (int i = 0; i < DrawImage.Modified.Width; i++)
                    {
                        for (int j = 0; j < DrawImage.Modified.Height; j++)
                        {
                            cMatrix[i, j] = 1;
                        }
                    }
                }
                else
                {
                    cMatrix = CoverageMatrix(DrawImage.Modified, pallet[c]);
                }

                if (!est)
                {
                    SetPenColor($"{pallet[c].R:X2}{pallet[c].G:X2}{pallet[c].B:X2}");
                }
                estimatedTime += COLORCHANGEDELAY * 6;


                Random rng = new Random();

                var coords = Enumerable.Range(0, cMatrix.GetLength(0))
                    .SelectMany(i2 => Enumerable.Range(0, cMatrix.GetLength(1)),
                                (i2, j2) => new { i2, j2 });

                if (UserSettings.RandomOrder)
                {
                    coords = coords.OrderBy(x => rng.Next()).ToList();
                }
                else
                {
                    coords = coords.ToList();
                }

                    foreach (var coord in coords)
                {
                    Application.DoEvents();

                    if (ModifierKeys == Keys.Alt)
                    {
                        goto stopdrawing;
                    }

                    if (cMatrix[coord.i2, coord.j2] >= 1)
                    {
                        int[] row = { coord.i2, coord.j2 };
                        pixelList.Add(row);
                        DrawPixel(tMatrix, cMatrix, coord.i2, coord.j2, est);
                    }
                }

                foreach (int[] p in pixelList)
                {
                    if (!est)
                    {
                        Application.DoEvents();
                        if (ModifierKeys == Keys.Alt)
                            return false;
                    }
                    if (cMatrix[p[0], p[1]] >= 1)
                    {
                        DrawPixel(tMatrix, cMatrix, p[0], p[1], est);
                    }
                }

                if (!est)
                {
                    UserSettings.SkipColors = c;
                    UpdateUITextValues();
                }
            }
            if (!est)
            {
                UserSettings.SkipColors = 0;
                UpdateUITextValues();
            }
        stopdrawing:
            return true;
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DrawImage.Original = new Bitmap(openFileDialog1.FileName);
                DrawImage.Original = DrawImage.Original.ConvertPixelFormat(PixelFormat.Format32bppArgb);
                UserSettings.DrawW = DrawImage.Original.Width;
                UserSettings.DrawH = DrawImage.Original.Height;
                UserSettings.DrawX = 0;
                UserSettings.DrawY = 0;
                UserSettings.CropW = DrawImage.Original.Width;
                UserSettings.CropH = DrawImage.Original.Height;
                UserSettings.CropX = 0;
                UserSettings.CropY = 0;
                UserSettings.DirectDraw = false;
                UpdateUITextValues();
                DrawImage.Modified = DrawImage.Original;
                ProcessImage();
                pictureBox1.Image = BitmapExtensions.Resize(DrawImage.Modified, new Size(1920, 1080), scaleType, true);
                DrawImage.Preview = DrawImage.Modified;
                EnableControls(true);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            DrawImage.Original = null;
            DrawImage.Modified = null;
            DrawImage.Modified = null;
            DrawImage.Preview = null;
            EnableControls(false);
        }


        private void StartButton_Click(object sender, EventArgs e)
        {
            // Set Drawing Position
            try
            {
                ProcessImage();
                Start();
            }
            catch (Exception)
            {
                MessageBox.Show(new Form() { TopMost = true }, "No image was found", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void firstLayerFill_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UserSettings.FillFirstLayer = firstLayerFill.Checked;
            }
            catch (Exception)
            {
                UserSettings.FillFirstLayer = true;
            }
        }

        private void ditherBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                UserSettings.DitherPattern = ditherBox.SelectedIndex;
                ProcessImage();
            }
            catch (Exception)
            {
                UserSettings.DitherPattern = 0;
            }
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        public static Bitmap CropImageSet(Bitmap img)
        {
            Bitmap newImg = (Bitmap)img.Clone();
            for (int i = 0; i < newImg.Width; i++)
            {
                for (int j = 0; j < newImg.Height; j++)
                {
                    if (i < UserSettings.CropX)
                    {
                        newImg.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 0, 255));
                    }
                    if (i > UserSettings.CropW)
                    {
                        newImg.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 0, 255));
                    }
                    if (j < UserSettings.CropY)
                    {
                        newImg.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 0, 255));
                    }
                    if (j > UserSettings.CropH)
                    {
                        newImg.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 0, 255));
                    }
                }
            }
            return newImg;
        }
        public void SetPreview()
        {
            DrawImage.Preview = (Bitmap)DrawImage.Modified.Clone();
            pictureBox1.Image = BitmapExtensions.Resize(DrawImage.Preview, new Size((int)Math.Round(DrawImage.Preview.Width * UserSettings.PenSize), (int)Math.Round(DrawImage.Preview.Height * UserSettings.PenSize)), scaleType, true);
        }

        private void estButton_Click(object sender, EventArgs e)
        {
            estimatedTime = 0;
            progressBar1.Value = 0;
            ProcessImage();
            Draw(true);
            progressBar1.Value = 100;
            estTime.Text = ConvertMillisecondsToTimeFormat(estimatedTime);
        }

        public static string ConvertMillisecondsToTimeFormat(long milliseconds)
        {
            // Convert milliseconds to a TimeSpan
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);

            // Format the TimeSpan as "dd:hh:mm:ss"
            string formattedTime = $"D{timeSpan.Days:D2}:H{timeSpan.Hours:D2}:M{timeSpan.Minutes:D2}:S{timeSpan.Seconds:D2}";

            return formattedTime;
        }

        private void widthInput_Leave(object sender, EventArgs e)
        {
            // Change in width of image
            try
            {
                UserSettings.DrawW = Convert.ToInt32(widthInput.Text);
                UserSettings.DrawW = int.Parse(widthInput.Text);
            }
            catch (Exception)
            {
                UserSettings.DrawW = DrawImage.Modified.Width;
            }
            ProcessImage();

        }

        private void heightInput_Leave(object sender, EventArgs e)
        {
            // Change in height of image
            try
            {
                UserSettings.DrawH = Convert.ToInt32(heightInput.Text);
                UserSettings.DrawH = int.Parse(heightInput.Text);
            }
            catch (Exception)
            {
                UserSettings.DrawH = DrawImage.Modified.Height;
            }
            ProcessImage();
        }

        private void GapXBox_Leave(object sender, EventArgs e)
        {
            try
            {
                UserSettings.PenSize = (float)Convert.ToDouble(GapXBox.Text) + 1;
                UserSettings.PenSize = float.Parse(GapXBox.Text) + 1;
            }
            catch (Exception)
            {
                UserSettings.PenSize = 1;
            }
        }

        private void maxColorsBox_Leave(object sender, EventArgs e)
        {
            try
            {
                UserSettings.MaxColors = Convert.ToInt32(maxColorsBox.Text);
                UserSettings.MaxColors = int.Parse(maxColorsBox.Text);
                if (UserSettings.MaxColors < 2)
                {
                    UserSettings.MaxColors = 2;
                    maxColorsBox.Text = "2";
                }

            }
            catch (Exception)
            {
                UserSettings.MaxColors = 2;
            }
            ProcessImage();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pixelateBar_Scroll(object sender, EventArgs e)
        {
            UserSettings.Pixelation = Math.Pow(0.5, pixelateBar.Value - 1);
        }

        private void pixelateBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            ProcessImage();
        }

        private void DrawPositionButton_Click_1(object sender, EventArgs e)
        {
            // Set Drawing Position
            MouseEventArgs mouse = e as MouseEventArgs;
            try
            {
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
                while (isSet)
                {
                    Application.DoEvents();

                    void setPosition()
                    {
                        WindowState = FormWindowState.Normal;
                        m.Close();
                        isSet = false;
                    }

                    m.setButton.Click += (buttonSender, buttonEventArgs) =>
                    {
                        setPosition();
                    };
                    m.setButtonTop.Click += (buttonSender, buttonEventArgs) =>
                    {
                        setPosition();
                    };

                    UserSettings.DrawX = m.Location.X + locationOffset;
                    UserSettings.DrawY = m.Location.Y + locationOffset;
                    UpdateUITextValues();

                    if (m.Size != lastSize)
                    {
                        int newx = m.Size.Width - sizeOffset;
                        int newy = m.Size.Height - sizeOffset;
                        UserSettings.DrawW = newx;
                        UserSettings.DrawH = newy;
                        UserSettings.CropW = newx;
                        UserSettings.CropH = newy;
                        UpdateUITextValues();
                        ProcessImage();
                        m.UpdateImage(DrawImage.Preview);
                    }
                    lastSize = m.Size;
                    m.TopMost = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(new Form() { TopMost = true }, "No image was found", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void CropButton_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            CropWindow m = new CropWindow(mouse);
            m.Show();
            WindowState = FormWindowState.Minimized;
            m.pictureBox1.Image = DrawImage.Preview;
            m.Size = new Size(m.pictureBox1.Location.X + DrawImage.Modified.Width, m.pictureBox1.Location.Y + DrawImage.Modified.Height);
            m.StartPosition = FormStartPosition.CenterScreen;

        }

        private void YBox_Leave(object sender, EventArgs e)
        {
            // Delay interval between the drawing of each pixel
            try
            {
                UserSettings.DrawY = Convert.ToInt32(YBox.Text);
                UserSettings.DrawY = int.Parse(YBox.Text);
            }
            catch (Exception)
            {
                UserSettings.DrawY = 0;
            }
        }

        private void XBox_Leave(object sender, EventArgs e)
        {
            // Delay interval between the drawing of each pixel
            try
            {
                UserSettings.DrawX = Convert.ToInt32(XBox.Text);
                UserSettings.DrawX = int.Parse(XBox.Text);
            }
            catch (Exception)
            {
                UserSettings.DrawX = 0;
            }
        }

        private void skipColorBox_Leave(object sender, EventArgs e)
        {
            try
            {
                UserSettings.SkipColors = Convert.ToInt32(skipColorBox.Text);
                UserSettings.SkipColors = int.Parse(skipColorBox.Text);
            }
            catch (Exception)
            {
                UserSettings.SkipColors = 0;
            }
        }

        private void MainForm_Enter(object sender, EventArgs e)
        {

        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            UpdateUITextValues();
            if (DrawImage.Modified != null)
                ProcessImage();
        }

        private void bicubic_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (bicubicBox.Checked)
                {
                    processScaleType = ScalingMode.Bicubic;
                }
                else
                {
                    processScaleType = ScalingMode.NearestNeighbor;
                }
                ProcessImage();

            }
            catch (Exception)
            {
                processScaleType = ScalingMode.Box;
            }

        }

        private void tableLayoutPanel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vectorBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UserSettings.VectorMode = vectorBox.Checked;
            }
            catch (Exception)
            {
                UserSettings.VectorMode = false;
            }
        }

        private void directDrawBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UserSettings.DirectDraw = directDrawBox.Checked;
            }
            catch (Exception)
            {
                UserSettings.DirectDraw = false;
            }
        }

        private void quantBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                UserSettings.QuantType = quantBox.SelectedIndex;
                ProcessImage();
            }
            catch (Exception)
            {
                UserSettings.QuantType = 0;
            }
        }

        private void randomBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UserSettings.RandomOrder = randomBox.Checked;
            }
            catch (Exception)
            {
                UserSettings.RandomOrder = false;
            }
        }

        private void cropHnum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                UserSettings.CropH = (int)cropHnum.Value;
            }
            catch (Exception)
            {
                UserSettings.CropH = 0;
            }
            ProcessImage();
        }

        private void cropYnum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                UserSettings.CropY = (int)cropYnum.Value;
            }
            catch (Exception)
            {
                UserSettings.CropY = 0;
            }
            ProcessImage();
        }

        private void cropWnum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                UserSettings.CropW = (int)cropWnum.Value;
            }
            catch (Exception)
            {
                UserSettings.CropW = 0;
            }
            ProcessImage();
        }

        private void cropXnum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                UserSettings.CropX = (int)cropXnum.Value;
            }
            catch (Exception)
            {
                UserSettings.CropX = 0;
            }
            ProcessImage();
        }
    }
}
