﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using KGySoft.CoreLibraries;
using KGySoft.Drawing;
using KGySoft.Drawing.Imaging;
using Microsoft.VisualBasic.Logging;
using Windows.Security.Cryptography.Certificates;
using static RecRoomPainter.MainForm;

namespace RecRoomPainter
{

    public partial class MainForm : Form
    {
        private RunningProgressBar RunPBar;

        public static ScalingMode scaleType = ScalingMode.Box;
        public static ScalingMode processScaleType = ScalingMode.NearestNeighbor;

        public static class Time
        {
            static Time()
            {
                MouseUpDelay = 40;
                MouseDownDelay = 40;
                MouseTurnDelay = 45;
                ColorChangeDelay = 1000;
                EstimatedTime = 0;
            }
            public static int MouseUpDelay { get; }
            public static int MouseDownDelay { get; }
            public static int MouseTurnDelay { get; }
            public static int ColorChangeDelay { get; set; }
            public static long EstimatedTime { get; set; }

            public static void ColorChangeDefault()
            {
                ColorChangeDelay = 1000;
            }
        }



        public static class Settings
        {
            static Settings()
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
                Depth = 0;
                FillFirstLayer = false;
                DitherPattern = 0;
                QuantType = 0;
                PenSize = 3;
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

            public static int Depth { get; set; }
            public static bool FillFirstLayer { get; set; }
            public static int DitherPattern { get; set; }
            public static int QuantType { get; set; }
            public static float PenSize { get; set; }
            public static bool VectorMode { get; set; }
            public static bool DirectDraw { get; set; }
            public static bool RandomOrder { get; set; }

        }

        public static class DrawImage
        {
            public static Bitmap Original { get; set; }
            public static Bitmap Modified { get; set; }
            public static Bitmap Preview { get; set; }
        }




        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public static class ActionQueue
        {
            static ActionQueue()
            {
                AQueue = new Queue<Action>();
            }

            public static Queue<Action> AQueue { get; set; }

            public static void EmptyQueue()
            {
                AQueue.Clear();
            }

            public static void LeftDown(int x, int y, int delay)
            {
                ActionQueue.AQueue.Enqueue((() => Mouse.DrawClick(0x02, x, y, delay)));
                Time.EstimatedTime += delay;

            }
            public static void LeftUp(int x, int y, int delay)
            {
                ActionQueue.AQueue.Enqueue((() => Mouse.DrawClick(0x04, x, y, delay)));
                Time.EstimatedTime += delay;
            }
            public static void RightDown(int x, int y, int delay)
            {
                ActionQueue.AQueue.Enqueue((() => Mouse.DrawClick(0x08, x, y, delay)));
                Time.EstimatedTime += delay;
            }
            public static void RightUp(int x, int y, int delay)
            {
                ActionQueue.AQueue.Enqueue((() => Mouse.DrawClick(0x10, x, y, delay)));
                Time.EstimatedTime += delay;
            }
            public static void Move(int x, int y, int delay)
            {
                ActionQueue.AQueue.Enqueue((() => Mouse.Move(x, y, delay)));
                Time.EstimatedTime += delay;
            }
            public static void Sleep(int delay)
            {
                ActionQueue.AQueue.Enqueue((() => Thread.Sleep(delay)));
                Time.EstimatedTime += delay;
            }
            public static void KeyPress(string key) => ActionQueue.AQueue.Enqueue((() => SendKeys.Send(key)));
            public static void SetClipboard(string text) => ActionQueue.AQueue.Enqueue((() => Clipboard.SetText(text)));
            public static void SetColorSkipValue(int value) => ActionQueue.AQueue.Enqueue((() => Settings.SkipColors = value));

        }
        public static class Mouse
        {

            [DllImport("user32.dll")]
            private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

            // This is a replacement for Cursor.Position in WinForms
            [DllImport("user32.dll")]
            private static extern bool SetCursorPos(int x, int y);
            public static void Move(int x, int y, int delay)
            {
                SetCursorPos(x, y);
                Thread.Sleep(delay);
            }

            public static void DrawClick(int id, int x, int y, int delay)
            {

                SetCursorPos(x, y);
                mouse_event(id, x, y, 0, 0);
                Thread.Sleep(delay);
            }


        }


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
            cropXnum.Enabled = enable;
            cropYnum.Enabled = enable;
            cropWnum.Enabled = enable;
            cropHnum.Enabled = enable;
        }

        public void UpdateUITextValues()
        {
            widthInput.Text = Settings.DrawW.ToString();
            heightInput.Text = Settings.DrawH.ToString();
            skipColorBox.Text = Settings.SkipColors.ToString();
            maxColorsBox.Text = Settings.MaxColors.ToString();
            XBox.Text = Settings.DrawX.ToString();
            YBox.Text = Settings.DrawY.ToString();
            cropXnum.Value = Settings.CropX;
            cropYnum.Value = Settings.CropY;
            cropWnum.Value = Settings.CropW;
            cropHnum.Value = Settings.CropH;
        }


        public void ProcessImage()
        {
            try
            {
                EnableControls(false);
                progressBar1.Value = 0;
                DrawImage.Modified = (Bitmap)DrawImage.Original.Clone();
                DrawImage.Modified = BitmapExtensions.Resize(DrawImage.Original, new Size((int)Math.Round(Settings.DrawW * Settings.Pixelation), (int)Math.Round(Settings.DrawH * Settings.Pixelation)), processScaleType);

                progressBar1.Value = 10;
                IDitherer dither = OrderedDitherer.Bayer2x2;

                IQuantizer quantizer = OptimizedPaletteQuantizer.MedianCut(Settings.MaxColors);
                switch (Settings.QuantType)
                {
                    case 1:
                        quantizer = OptimizedPaletteQuantizer.Wu(Settings.MaxColors);
                        break;
                    case 2:
                        quantizer = OptimizedPaletteQuantizer.Octree(Settings.MaxColors);
                        break;
                }

                switch (Settings.DitherPattern)
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
                if (Settings.DitherPattern > 0)
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
                DrawImage.Modified = BitmapExtensions.Resize(DrawImage.Modified, new Size((int)Math.Round(Settings.DrawW / Settings.PenSize), (int)Math.Round(Settings.DrawH / Settings.PenSize)), ScalingMode.NearestNeighbor);
                SetPreview();

                progressBar1.Value = 100;
                EnableControls(true);

            }
            catch (Exception)
            {
                MessageBox.Show(new Form() { TopMost = true }, "Image could not be processed", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void Start()
        {
            try
            {
                if (Draw())
                    RunQueue();
                else
                    MessageBox.Show(new Form() { TopMost = true }, "Drawing halted", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                MessageBox.Show(new Form() { TopMost = true }, "Drawing Failed", "Drawing Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public static void SetPenColor(string hex)
        {
            Time.ColorChangeDelay += 80;
            ActionQueue.SetClipboard(hex);

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            int CCLocationX = (int)(screenWidth * 0.7);
            int CCLocationY = (int)(screenHeight * 0.75);
            int HexCLocationX = (int)(screenWidth * 0.7);
            int HexCLocationY = (int)(screenHeight * 0.6);
            int DoneCLocationX = (int)(screenWidth * 0.7);
            int DoneCLocationY = (int)(screenHeight * 0.7);

            void FullLeftClick(int x, int y)
            {
                ActionQueue.Sleep(Time.ColorChangeDelay);
                ActionQueue.Move(x, y, 0);
                ActionQueue.LeftDown(x, y, 0);
                ActionQueue.LeftUp(x, y, 0);
            }

            ActionQueue.RightDown(CCLocationX, CCLocationY, 0);
            ActionQueue.RightUp(CCLocationX, CCLocationY, 0);
            FullLeftClick(CCLocationX, CCLocationY);
            FullLeftClick(HexCLocationX, HexCLocationY);
            ActionQueue.Sleep(Time.ColorChangeDelay);
            ActionQueue.KeyPress("^(a)");
            ActionQueue.Sleep(Time.ColorChangeDelay);
            ActionQueue.KeyPress("^(v)");
            FullLeftClick(DoneCLocationX, DoneCLocationY);
            ActionQueue.Sleep(Time.ColorChangeDelay);
        }

        private static bool[,] CoverageMatrix(Bitmap img, Color color, bool[,] matrix)
        {
            int width = img.Width;
            int height = img.Height;

            // Define the rectangle and lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData bmpData = img.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                int stride = bmpData.Stride;
                int bytes = Math.Abs(stride) * height;
                byte[] pixelData = new byte[bytes];

                // Copy the pixel data into our array.
                Marshal.Copy(bmpData.Scan0, pixelData, 0, bytes);

                // The expected color components (32bppArgb stores pixels in BGRA order).
                byte targetB = color.B;
                byte targetG = color.G;
                byte targetR = color.R;
                byte targetA = color.A;

                // Iterate through each pixel.
                for (int y = 0; y < height; y++)
                {
                    int rowStart = y * stride;
                    for (int x = 0; x < width; x++)
                    {
                        int index = rowStart + x * 4;
                        byte b = pixelData[index];
                        byte g = pixelData[index + 1];
                        byte r = pixelData[index + 2];
                        byte a = pixelData[index + 3];

                        matrix[x, y] = (b == targetB && g == targetG && r == targetR && a == targetA) ? true : matrix[x, y];
                    }
                }
            }
            finally
            {
                // Always unlock the bits when done.
                img.UnlockBits(bmpData);
            }

            return matrix;
        }

        public struct PathStep
        {
            public Point Location { get; set; }
            public long Score { get; set; }

            public PathStep()
            {
                Location = new Point(0, 0);
                Score = 0;
            }

            public PathStep(Point location, long score)
            {
                Location = location;
                Score = score;
            }
        }
        public static class Path
        {


            private static bool IsWithinBounds(bool[,] matrix, Point loc)
            {
                return loc.X >= 0 && loc.X < matrix.GetLength(0) &&
                       loc.Y >= 0 && loc.Y < matrix.GetLength(1);
            }

            private static PathStep GetPathScore(bool[,] tMatrix, bool[,] matrix, Point startLocation, Point direction)
            {
                var step = new PathStep(startLocation, 0);

                while (true)
                {
                    Point newLoc = new Point(startLocation.X + direction.X, startLocation.Y + direction.Y);

                    if (!IsWithinBounds(matrix, newLoc) || tMatrix[newLoc.X, newLoc.Y])
                        break;

                    startLocation = newLoc;
                    if (matrix[startLocation.X, startLocation.Y])
                    {
                        step.Score++;
                        step.Location = startLocation;
                    }
                    else if (Settings.DirectDraw)
                    {
                        break;
                    }

                }
                return step;
            }

            private static List<PathStep> GetAllPathValues(bool[,] tMatrix, bool[,] matrix, Point startLocation, List<Point> directions)
            {
                var paths = new List<PathStep>();
                if (directions == null || directions.Count == 0)
                    return paths;

                foreach (var dir in directions)
                {
                    paths.Add(GetPathScore(tMatrix, matrix, startLocation, dir));
                }
                // Best score first
                paths.Sort((a, b) => b.Score.CompareTo(a.Score));
                return paths;
            }

            public static PathStep PathSearch(bool[,] tMatrix, bool[,] matrix, Point startLocation, List<Point> directions)
            {
                return PathSearchHelper(tMatrix, matrix, startLocation, startLocation, directions, 0);
            }
            private static PathStep PathSearchHelper(bool[,] tMatrix, bool[,] matrix, Point start, Point end, List<Point> directions, int currentDepth)
            {
                var moves = ClearPath(matrix, start, end);
                var paths = GetAllPathValues(tMatrix, matrix, end, directions);
                paths.Sort((a, b) => b.Score.CompareTo(a.Score));

                if (paths[0].Score == 0)
                {
                    RestoreMoves(matrix, moves);
                    return paths[0];
                }

                if (currentDepth < Settings.Depth)
                {
                    for (int i = 0; i < paths.Count; i++)
                    {
                        PathStep currentPath = paths[i];
                        currentPath.Score += PathSearchHelper(tMatrix, matrix, end, currentPath.Location, directions, currentDepth + 1).Score;
                        paths[i] = currentPath;
                    }
                }
                paths.Sort((a, b) => b.Score.CompareTo(a.Score));
                RestoreMoves(matrix, moves);
                return paths[0];
            }

            public static List<Point> ClearPath(bool[,] matrix, Point start, Point end)
            {
                int dx = Math.Sign(end.X - start.X);
                int dy = Math.Sign(end.Y - start.Y);

                List<Point> moves = [];

                while (IsWithinBounds(matrix, start))
                {
                    if (matrix[start.X, start.Y])
                    {
                        moves.Add(start);
                        matrix[start.X, start.Y] = false;
                    }

                    // Break after processing the endpoint
                    if (start.X == end.X && start.Y == end.Y)
                        break;

                    start.X += dx;
                    start.Y += dy;

                }
                return moves;
            }

            public static void RestoreMoves(bool[,] matrix, List<Point> moves)
            {
                foreach (var p in moves)
                {
                    matrix[p.X, p.Y] = true;
                }

            }
        }



        public static void NeighborLineDraw(bool[,] tMatrix, bool[,] matrix, Point loc, List<Point> directions)
        {
            while (true)
            {
                PathStep path = Path.PathSearch(tMatrix, matrix, loc, directions);

                if (path.Score > 0)
                {
                    Path.ClearPath(matrix, loc, path.Location);

                    loc = path.Location;
                    ActionQueue.Move(Settings.DrawX + (int)Math.Round(loc.X * Settings.PenSize),
                               Settings.DrawY + (int)Math.Round(loc.Y * Settings.PenSize),
                               Time.MouseTurnDelay);
                }
                else
                {
                    break;
                }
            }
            ActionQueue.LeftUp(Settings.DrawX + (int)Math.Round(loc.X * Settings.PenSize),
                         Settings.DrawY + (int)Math.Round(loc.Y * Settings.PenSize),
                         Time.MouseDownDelay);
        }

        private static Color[] ImageToPallet(Bitmap img)
        {
            HashSet<Color> uniqueColors = new HashSet<Color>();

            // Lock the bitmap
            Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
            BitmapData bmpData = img.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                int stride = bmpData.Stride;
                byte[] pixelData = new byte[Math.Abs(stride) * img.Height];
                Marshal.Copy(bmpData.Scan0, pixelData, 0, pixelData.Length);

                for (int y = 0; y < img.Height; y++)
                {
                    int rowStart = y * stride;
                    for (int x = 0; x < img.Width; x++)
                    {
                        int index = rowStart + x * 4;
                        byte b = pixelData[index];
                        byte g = pixelData[index + 1];
                        byte r = pixelData[index + 2];
                        byte a = pixelData[index + 3];

                        uniqueColors.Add(Color.FromArgb(a, r, g, b));
                    }
                }
            }
            finally
            {
                img.UnlockBits(bmpData);
            }

            // Convert HashSet to array
            Color[] palette = uniqueColors.ToArray();

            // Sort colors by brightness (descending)
            Array.Sort(palette, (c1, c2) => c2.GetBrightness().CompareTo(c1.GetBrightness()));

            return palette;
        }


        static void DrawPixel(bool[,] tMatrix, bool[,] matrix, Point loc, List<Point> directions)
        {
            int xpos = Settings.DrawX + (int)Math.Round(loc.X * Settings.PenSize);
            int ypos = Settings.DrawY + (int)Math.Round(loc.Y * Settings.PenSize);

            ActionQueue.LeftDown(xpos, ypos, Time.MouseDownDelay);
            NeighborLineDraw(tMatrix, matrix, loc, directions);
            matrix[loc.X, loc.Y] = false;
            ActionQueue.LeftUp(xpos, ypos, Time.MouseUpDelay);
        }

        private bool Draw()
        {
            ActionQueue.EmptyQueue();
            List<Point> directions = new()
                {
                    new(0, 1),  // Up
                    new(0, -1), // Down
                    new(1, 0),  // Left
                    new(-1, 0)  // Right
                };

            if (Settings.VectorMode)
            {
                directions.Add(new(1, 1)); //TopRight
                directions.Add(new(1, -1)); //BottomRight
                directions.Add(new(-1, 1)); //TopLeft
                directions.Add(new(-1, -1)); //BottomLeft
            }

            Time.ColorChangeDefault();

            Color[] pallet = ImageToPallet(DrawImage.Modified);

            bool[,] tMatrix = new bool[DrawImage.Modified.Width, DrawImage.Modified.Height];

            for (int c = 0; c < pallet.Length; c++)
            {

                float progress = (float)(c / (float)pallet.Length) * 100;
                progressBar1.Value = (int)progress;


                if (c > 0)
                {
                    tMatrix = CoverageMatrix(DrawImage.Modified, pallet[c - 1], tMatrix);
                }

                if (c < Settings.SkipColors || pallet[c] == Color.FromArgb(255, 255, 0, 255))
                {
                    continue;
                }

                List<int[]> pixelList = new List<int[]>(0);

                bool[,] cMatrix = new bool[DrawImage.Modified.Width, DrawImage.Modified.Height];

                if (Settings.FillFirstLayer && c == 0)
                {
                    for (int i = 0; i < DrawImage.Modified.Width; i++)
                    {
                        for (int j = 0; j < DrawImage.Modified.Height; j++)
                        {
                            cMatrix[i, j] = true;
                        }
                    }
                }
                else
                {
                    cMatrix = CoverageMatrix(DrawImage.Modified, pallet[c], new bool[DrawImage.Modified.Width, DrawImage.Modified.Height]);
                }

                SetPenColor($"{pallet[c].R:X2}{pallet[c].G:X2}{pallet[c].B:X2}");



                Random rng = new Random();

                var coords = Enumerable.Range(0, cMatrix.GetLength(0))
                    .SelectMany(i2 => Enumerable.Range(0, cMatrix.GetLength(1)),
                                (i2, j2) => new { i2, j2 });

                if (Settings.RandomOrder)
                {
                    coords = coords.OrderBy(x => rng.Next()).ToList();
                }
                else
                {
                    coords = coords.ToList();
                }

                foreach (var coord in coords)
                {

                    if (cMatrix[coord.i2, coord.j2])
                    {
                        int[] row = { coord.i2, coord.j2 };
                        pixelList.Add(row);
                        DrawPixel(tMatrix, cMatrix, new Point(coord.i2, coord.j2), directions);
                    }
                }

                foreach (int[] p in pixelList)
                {
                    if (cMatrix[p[0], p[1]])
                    {
                        DrawPixel(tMatrix, cMatrix, new Point(p[0], p[1]), directions);
                    }
                }
                ActionQueue.SetColorSkipValue(c);
            }
            ActionQueue.SetColorSkipValue(0);
            return true;
        }
        public void RunQueue()
        {
            int startLength = ActionQueue.AQueue.Count;
            var drawingStartTime = DateTime.Now;
            var drawingCurrentTime = DateTime.Now;

            if (RunPBar == null || RunPBar.IsDisposed)
            {
                RunPBar = new RunningProgressBar();
                RunPBar.UpdateProgress(0, startLength, 0);
                RunPBar.Show();
            }
            Application.DoEvents();

            ActivateWindow("Rec Room");
            Thread.Sleep(1000);

            bool finished = true;
            DateTime previousTime = DateTime.Now;
            while (ActionQueue.AQueue.Count > 0)
            {
                if ((DateTime.Now - previousTime).TotalSeconds >= 1.0)
                {
                    drawingCurrentTime = DateTime.Now;
                    Application.DoEvents();
                    RunPBar.UpdateProgress(ActionQueue.AQueue.Count, startLength, (int)(drawingCurrentTime - drawingStartTime).TotalMilliseconds);
                }
                if (GetAsyncKeyState(0x12) < 0) // 0x12 is the virtual key code for Alt
                {
                    Mouse.DrawClick(0x04, Cursor.Position.X, Cursor.Position.Y, 0);
                    MessageBox.Show(new Form() { TopMost = true }, $"Drawing stopped by user.\nALT key was pressed.\n{ConvertMillisecondsToTimeFormat((int)(drawingCurrentTime - drawingStartTime).TotalMilliseconds)}", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    finished = false;
                    break;
                }


                Action action = ActionQueue.AQueue.Dequeue();
                action();
            }
            RunPBar.Close();

            if (finished)
            {
                MessageBox.Show(new Form() { TopMost = true }, "Drawing finished", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            UpdateUITextValues();
        }


        private void UploadButton_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DrawImage.Original = new Bitmap(openFileDialog1.FileName);
                DrawImage.Original = DrawImage.Original.ConvertPixelFormat(PixelFormat.Format32bppArgb);
                Settings.DrawW = DrawImage.Original.Width;
                Settings.DrawH = DrawImage.Original.Height;
                Settings.DrawX = 0;
                Settings.DrawY = 0;
                Settings.CropW = DrawImage.Original.Width;
                Settings.CropH = DrawImage.Original.Height;
                Settings.CropX = 0;
                Settings.CropY = 0;
                Settings.DirectDraw = false;
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
                Settings.FillFirstLayer = firstLayerFill.Checked;
            }
            catch (Exception)
            {
                Settings.FillFirstLayer = true;
            }
        }

        private void ditherBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Settings.DitherPattern = ditherBox.SelectedIndex;
                ProcessImage();
            }
            catch (Exception)
            {
                Settings.DitherPattern = 0;
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
                    if (i < Settings.CropX)
                    {
                        newImg.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 0, 255));
                    }
                    if (i > Settings.CropW)
                    {
                        newImg.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 0, 255));
                    }
                    if (j < Settings.CropY)
                    {
                        newImg.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 0, 255));
                    }
                    if (j > Settings.CropH)
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
            pictureBox1.Image = BitmapExtensions.Resize(DrawImage.Preview, new Size((int)Math.Round(DrawImage.Preview.Width * Settings.PenSize), (int)Math.Round(DrawImage.Preview.Height * Settings.PenSize)), scaleType, true);
        }

        private void estButton_Click(object sender, EventArgs e)
        {
            Time.EstimatedTime = 0;
            progressBar1.Value = 0;
            ProcessImage();
            Draw();
            progressBar1.Value = 100;
            estTime.Text = ConvertMillisecondsToTimeFormat(Time.EstimatedTime);
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
                Settings.DrawW = Convert.ToInt32(widthInput.Text);
                Settings.DrawW = int.Parse(widthInput.Text);
            }
            catch (Exception)
            {
                Settings.DrawW = DrawImage.Modified.Width;
            }
            ProcessImage();

        }

        private void heightInput_Leave(object sender, EventArgs e)
        {
            // Change in height of image
            try
            {
                Settings.DrawH = Convert.ToInt32(heightInput.Text);
                Settings.DrawH = int.Parse(heightInput.Text);
            }
            catch (Exception)
            {
                Settings.DrawH = DrawImage.Modified.Height;
            }
            ProcessImage();
        }

        private void maxColorsBox_Leave(object sender, EventArgs e)
        {
            try
            {
                Settings.MaxColors = Convert.ToInt32(maxColorsBox.Text);
                Settings.MaxColors = int.Parse(maxColorsBox.Text);
                if (Settings.MaxColors < 2)
                {
                    Settings.MaxColors = 2;
                    maxColorsBox.Text = "2";
                }

            }
            catch (Exception)
            {
                Settings.MaxColors = 2;
            }
            ProcessImage();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pixelateBar_Scroll(object sender, EventArgs e)
        {
            Settings.Pixelation = Math.Pow(0.5, pixelateBar.Value - 1);
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
                m.Size = new Size(Settings.DrawW + sizeOffset, Settings.DrawH + sizeOffset);
                m.Location = new Point(Settings.DrawX - locationOffset, Settings.DrawY - locationOffset);
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

                    Settings.DrawX = m.Location.X + locationOffset;
                    Settings.DrawY = m.Location.Y + locationOffset;
                    UpdateUITextValues();

                    if (m.Size != lastSize)
                    {
                        int newx = m.Size.Width - sizeOffset;
                        int newy = m.Size.Height - sizeOffset;
                        Settings.DrawW = newx;
                        Settings.DrawH = newy;
                        Settings.CropW = newx;
                        Settings.CropH = newy;
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

        private void YBox_Leave(object sender, EventArgs e)
        {
            // Delay interval between the drawing of each pixel
            try
            {
                Settings.DrawY = Convert.ToInt32(YBox.Text);
                Settings.DrawY = int.Parse(YBox.Text);
            }
            catch (Exception)
            {
                Settings.DrawY = 0;
            }
        }

        private void XBox_Leave(object sender, EventArgs e)
        {
            // Delay interval between the drawing of each pixel
            try
            {
                Settings.DrawX = Convert.ToInt32(XBox.Text);
                Settings.DrawX = int.Parse(XBox.Text);
            }
            catch (Exception)
            {
                Settings.DrawX = 0;
            }
        }

        private void skipColorBox_Leave(object sender, EventArgs e)
        {
            try
            {
                Settings.SkipColors = Convert.ToInt32(skipColorBox.Text);
                Settings.SkipColors = int.Parse(skipColorBox.Text);
            }
            catch (Exception)
            {
                Settings.SkipColors = 0;
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
                Settings.VectorMode = vectorBox.Checked;
            }
            catch (Exception)
            {
                Settings.VectorMode = false;
            }
        }

        private void directDrawBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Settings.DirectDraw = directDrawBox.Checked;
            }
            catch (Exception)
            {
                Settings.DirectDraw = false;
            }
        }

        private void quantBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Settings.QuantType = quantBox.SelectedIndex;
                ProcessImage();
            }
            catch (Exception)
            {
                Settings.QuantType = 0;
            }
        }

        private void randomBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Settings.RandomOrder = randomBox.Checked;
            }
            catch (Exception)
            {
                Settings.RandomOrder = false;
            }
        }

        private void cropHnum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Settings.CropH = (int)cropHnum.Value;
            }
            catch (Exception)
            {
                Settings.CropH = 0;
            }
            ProcessImage();
        }

        private void cropYnum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Settings.CropY = (int)cropYnum.Value;
            }
            catch (Exception)
            {
                Settings.CropY = 0;
            }
            ProcessImage();
        }

        private void cropWnum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Settings.CropW = (int)cropWnum.Value;
            }
            catch (Exception)
            {
                Settings.CropW = 0;
            }
            ProcessImage();
        }

        private void cropXnum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Settings.CropX = (int)cropXnum.Value;
            }
            catch (Exception)
            {
                Settings.CropX = 0;
            }
            ProcessImage();
        }

        private void depthNumBox_ValueChanged(object sender, EventArgs e)
        {
            Settings.Depth = (int)depthNumBox.Value;
        }
    }
}
