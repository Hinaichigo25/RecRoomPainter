namespace RecRoomPainter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            startButton = new System.Windows.Forms.Button();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            estButton = new System.Windows.Forms.Button();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            estTimeLabel = new System.Windows.Forms.Label();
            estTime = new System.Windows.Forms.Label();
            clearButton = new System.Windows.Forms.Button();
            uploadButton = new System.Windows.Forms.Button();
            tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            DrawPositionButton = new System.Windows.Forms.Button();
            tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            label6 = new System.Windows.Forms.Label();
            widthInput = new System.Windows.Forms.TextBox();
            tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            XBox = new System.Windows.Forms.TextBox();
            XText = new System.Windows.Forms.Label();
            tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            YBox = new System.Windows.Forms.TextBox();
            YText = new System.Windows.Forms.Label();
            tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            label7 = new System.Windows.Forms.Label();
            heightInput = new System.Windows.Forms.TextBox();
            tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            GapXBox = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            CropButton = new System.Windows.Forms.Button();
            tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel24 = new System.Windows.Forms.TableLayoutPanel();
            cropYnum = new System.Windows.Forms.NumericUpDown();
            CropYlabel = new System.Windows.Forms.Label();
            tableLayoutPanel25 = new System.Windows.Forms.TableLayoutPanel();
            CropXlabel = new System.Windows.Forms.Label();
            cropXnum = new System.Windows.Forms.NumericUpDown();
            tableLayoutPanel26 = new System.Windows.Forms.TableLayoutPanel();
            cropWnum = new System.Windows.Forms.NumericUpDown();
            CropWlabel = new System.Windows.Forms.Label();
            tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            cropHnum = new System.Windows.Forms.NumericUpDown();
            CropHlabel = new System.Windows.Forms.Label();
            tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel29 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            pixelateBar = new System.Windows.Forms.TrackBar();
            label5 = new System.Windows.Forms.Label();
            tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            firstLayerFill = new System.Windows.Forms.CheckBox();
            tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            label3 = new System.Windows.Forms.Label();
            skipColorBox = new System.Windows.Forms.TextBox();
            tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            maxColorsBox = new System.Windows.Forms.TextBox();
            tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            randomBox = new System.Windows.Forms.CheckBox();
            bicubicBox = new System.Windows.Forms.CheckBox();
            vectorBox = new System.Windows.Forms.CheckBox();
            directDrawBox = new System.Windows.Forms.CheckBox();
            tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel30 = new System.Windows.Forms.TableLayoutPanel();
            quantBox = new System.Windows.Forms.ComboBox();
            label10 = new System.Windows.Forms.Label();
            tableLayoutPanel28 = new System.Windows.Forms.TableLayoutPanel();
            ditherBox = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            tableLayoutPanel12.SuspendLayout();
            tableLayoutPanel22.SuspendLayout();
            tableLayoutPanel23.SuspendLayout();
            tableLayoutPanel24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cropYnum).BeginInit();
            tableLayoutPanel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cropXnum).BeginInit();
            tableLayoutPanel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cropWnum).BeginInit();
            tableLayoutPanel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cropHnum).BeginInit();
            tableLayoutPanel21.SuspendLayout();
            tableLayoutPanel29.SuspendLayout();
            tableLayoutPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pixelateBar).BeginInit();
            tableLayoutPanel20.SuspendLayout();
            tableLayoutPanel17.SuspendLayout();
            tableLayoutPanel18.SuspendLayout();
            tableLayoutPanel19.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            tableLayoutPanel14.SuspendLayout();
            tableLayoutPanel30.SuspendLayout();
            tableLayoutPanel28.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "Image File";
            openFileDialog1.Filter = "(*jpeg, *.jpg, *.png, *.bmp)|*jpeg;*.jpg;*.png;*.bmp|All files (*.*)|*.*";
            openFileDialog1.Title = "Select a picture file";
            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(startButton, 1, 1);
            tableLayoutPanel1.Controls.Add(progressBar1, 0, 1);
            tableLayoutPanel1.Controls.Add(pictureBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new System.Drawing.Size(955, 607);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // startButton
            // 
            startButton.AutoSize = true;
            startButton.Dock = System.Windows.Forms.DockStyle.Fill;
            startButton.Enabled = false;
            startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            startButton.Location = new System.Drawing.Point(406, 573);
            startButton.Margin = new System.Windows.Forms.Padding(6);
            startButton.Name = "startButton";
            startButton.Size = new System.Drawing.Size(543, 28);
            startButton.TabIndex = 38;
            startButton.Text = "START";
            startButton.Click += StartButton_Click;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            progressBar1.Location = new System.Drawing.Point(3, 570);
            progressBar1.MarqueeAnimationSpeed = 50;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(394, 34);
            progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 37;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(402, 2);
            pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(551, 563);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 6);
            tableLayoutPanel2.Controls.Add(clearButton, 0, 1);
            tableLayoutPanel2.Controls.Add(uploadButton, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 0, 2);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel21, 0, 3);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel13, 0, 4);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel14, 0, 5);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(394, 561);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 99.99999F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel3.Controls.Add(estButton, 2, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(3, 367);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new System.Drawing.Size(388, 191);
            tableLayoutPanel3.TabIndex = 34;
            // 
            // estButton
            // 
            estButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            estButton.Location = new System.Drawing.Point(291, 3);
            estButton.Name = "estButton";
            estButton.Size = new System.Drawing.Size(94, 185);
            estButton.TabIndex = 26;
            estButton.Text = "Estimate";
            estButton.UseVisualStyleBackColor = true;
            estButton.Click += estButton_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(estTimeLabel, 0, 0);
            tableLayoutPanel4.Controls.Add(estTime, 1, 0);
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel4.Location = new System.Drawing.Point(41, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new System.Drawing.Size(244, 185);
            tableLayoutPanel4.TabIndex = 27;
            // 
            // estTimeLabel
            // 
            estTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            estTimeLabel.AutoSize = true;
            estTimeLabel.Location = new System.Drawing.Point(7, 84);
            estTimeLabel.Name = "estTimeLabel";
            estTimeLabel.Size = new System.Drawing.Size(75, 16);
            estTimeLabel.TabIndex = 24;
            estTimeLabel.Text = "Draw Time:";
            // 
            // estTime
            // 
            estTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            estTime.AutoSize = true;
            estTime.Location = new System.Drawing.Point(111, 84);
            estTime.Name = "estTime";
            estTime.Size = new System.Drawing.Size(112, 16);
            estTime.TabIndex = 23;
            estTime.Text = "D00:H00:M00:S00";
            estTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // clearButton
            // 
            clearButton.AutoSize = true;
            clearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            clearButton.Enabled = false;
            clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            clearButton.Location = new System.Drawing.Point(6, 47);
            clearButton.Margin = new System.Windows.Forms.Padding(6);
            clearButton.Name = "clearButton";
            clearButton.Size = new System.Drawing.Size(382, 30);
            clearButton.TabIndex = 1;
            clearButton.Text = "Clear Picture";
            clearButton.Click += ClearButton_Click;
            // 
            // uploadButton
            // 
            uploadButton.AutoSize = true;
            uploadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            uploadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            uploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            uploadButton.Location = new System.Drawing.Point(6, 6);
            uploadButton.Margin = new System.Windows.Forms.Padding(6);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new System.Drawing.Size(382, 29);
            uploadButton.TabIndex = 0;
            uploadButton.Text = "Upload Picture";
            uploadButton.Click += UploadButton_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.31799F));
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.841F));
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.841F));
            tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 1, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel12, 0, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel22, 2, 0);
            tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel5.Location = new System.Drawing.Point(3, 86);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new System.Drawing.Size(388, 94);
            tableLayoutPanel5.TabIndex = 32;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(DrawPositionButton, 0, 0);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel7, 0, 1);
            tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel6.Location = new System.Drawing.Point(66, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            tableLayoutPanel6.Size = new System.Drawing.Size(156, 88);
            tableLayoutPanel6.TabIndex = 18;
            // 
            // DrawPositionButton
            // 
            DrawPositionButton.AutoSize = true;
            DrawPositionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            DrawPositionButton.Enabled = false;
            DrawPositionButton.Location = new System.Drawing.Point(2, 2);
            DrawPositionButton.Margin = new System.Windows.Forms.Padding(2);
            DrawPositionButton.Name = "DrawPositionButton";
            DrawPositionButton.Size = new System.Drawing.Size(152, 22);
            DrawPositionButton.TabIndex = 17;
            DrawPositionButton.Text = "Set Position";
            DrawPositionButton.UseVisualStyleBackColor = true;
            DrawPositionButton.Click += DrawPositionButton_Click_1;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(tableLayoutPanel8, 1, 0);
            tableLayoutPanel7.Controls.Add(tableLayoutPanel9, 0, 0);
            tableLayoutPanel7.Controls.Add(tableLayoutPanel10, 0, 1);
            tableLayoutPanel7.Controls.Add(tableLayoutPanel11, 1, 1);
            tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel7.Location = new System.Drawing.Point(3, 29);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new System.Drawing.Size(150, 56);
            tableLayoutPanel7.TabIndex = 18;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel8.Controls.Add(label6, 1, 0);
            tableLayoutPanel8.Controls.Add(widthInput, 0, 0);
            tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel8.Location = new System.Drawing.Point(78, 3);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel8.Size = new System.Drawing.Size(69, 22);
            tableLayoutPanel8.TabIndex = 31;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(46, 3);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(21, 16);
            label6.TabIndex = 0;
            label6.Text = "W";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // widthInput
            // 
            widthInput.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            widthInput.Enabled = false;
            widthInput.Location = new System.Drawing.Point(2, 2);
            widthInput.Margin = new System.Windows.Forms.Padding(2);
            widthInput.Name = "widthInput";
            widthInput.Size = new System.Drawing.Size(40, 22);
            widthInput.TabIndex = 1;
            widthInput.Text = "0";
            widthInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            widthInput.Leave += widthInput_Leave;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel9.Controls.Add(XBox, 0, 0);
            tableLayoutPanel9.Controls.Add(XText, 1, 0);
            tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel9.Size = new System.Drawing.Size(69, 22);
            tableLayoutPanel9.TabIndex = 31;
            // 
            // XBox
            // 
            XBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            XBox.Enabled = false;
            XBox.Location = new System.Drawing.Point(2, 2);
            XBox.Margin = new System.Windows.Forms.Padding(2);
            XBox.MaxLength = 10;
            XBox.Name = "XBox";
            XBox.Size = new System.Drawing.Size(40, 22);
            XBox.TabIndex = 13;
            XBox.Text = "0";
            XBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            XBox.Leave += XBox_Leave;
            // 
            // XText
            // 
            XText.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            XText.AutoSize = true;
            XText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            XText.Location = new System.Drawing.Point(46, 3);
            XText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            XText.Name = "XText";
            XText.Size = new System.Drawing.Size(21, 16);
            XText.TabIndex = 16;
            XText.Text = "X";
            XText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 2;
            tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel10.Controls.Add(YBox, 0, 0);
            tableLayoutPanel10.Controls.Add(YText, 1, 0);
            tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel10.Location = new System.Drawing.Point(3, 31);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 1;
            tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel10.Size = new System.Drawing.Size(69, 22);
            tableLayoutPanel10.TabIndex = 31;
            // 
            // YBox
            // 
            YBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            YBox.Enabled = false;
            YBox.Location = new System.Drawing.Point(2, 2);
            YBox.Margin = new System.Windows.Forms.Padding(2);
            YBox.MaxLength = 10;
            YBox.Name = "YBox";
            YBox.Size = new System.Drawing.Size(40, 22);
            YBox.TabIndex = 14;
            YBox.Text = "0";
            YBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            YBox.Leave += YBox_Leave;
            // 
            // YText
            // 
            YText.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            YText.AutoSize = true;
            YText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            YText.Location = new System.Drawing.Point(46, 3);
            YText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            YText.Name = "YText";
            YText.Size = new System.Drawing.Size(21, 16);
            YText.TabIndex = 15;
            YText.Text = "Y";
            YText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.ColumnCount = 2;
            tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel11.Controls.Add(label7, 1, 0);
            tableLayoutPanel11.Controls.Add(heightInput, 0, 0);
            tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel11.Location = new System.Drawing.Point(78, 31);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 1;
            tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel11.Size = new System.Drawing.Size(69, 22);
            tableLayoutPanel11.TabIndex = 32;
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(46, 3);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(21, 16);
            label7.TabIndex = 2;
            label7.Text = "H";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // heightInput
            // 
            heightInput.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            heightInput.Enabled = false;
            heightInput.Location = new System.Drawing.Point(2, 2);
            heightInput.Margin = new System.Windows.Forms.Padding(2);
            heightInput.Name = "heightInput";
            heightInput.Size = new System.Drawing.Size(40, 22);
            heightInput.TabIndex = 2;
            heightInput.Text = "0";
            heightInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            heightInput.Leave += heightInput_Leave;
            // 
            // tableLayoutPanel12
            // 
            tableLayoutPanel12.ColumnCount = 1;
            tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel12.Controls.Add(GapXBox, 0, 1);
            tableLayoutPanel12.Controls.Add(label9, 0, 0);
            tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel12.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel12.Name = "tableLayoutPanel12";
            tableLayoutPanel12.RowCount = 2;
            tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            tableLayoutPanel12.Size = new System.Drawing.Size(57, 88);
            tableLayoutPanel12.TabIndex = 31;
            // 
            // GapXBox
            // 
            GapXBox.Dock = System.Windows.Forms.DockStyle.Fill;
            GapXBox.Enabled = false;
            GapXBox.Location = new System.Drawing.Point(2, 24);
            GapXBox.Margin = new System.Windows.Forms.Padding(2);
            GapXBox.MaxLength = 10;
            GapXBox.Name = "GapXBox";
            GapXBox.Size = new System.Drawing.Size(53, 22);
            GapXBox.TabIndex = 18;
            GapXBox.Text = "3.0";
            GapXBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            GapXBox.Leave += GapXBox_Leave;
            // 
            // label9
            // 
            label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label9.Location = new System.Drawing.Point(10, 0);
            label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(37, 22);
            label9.TabIndex = 17;
            label9.Text = "Pen Size";
            label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tableLayoutPanel22
            // 
            tableLayoutPanel22.ColumnCount = 1;
            tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel22.Controls.Add(CropButton, 0, 0);
            tableLayoutPanel22.Controls.Add(tableLayoutPanel23, 0, 1);
            tableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel22.Location = new System.Drawing.Point(228, 3);
            tableLayoutPanel22.Name = "tableLayoutPanel22";
            tableLayoutPanel22.RowCount = 2;
            tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.06593F));
            tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.93407F));
            tableLayoutPanel22.Size = new System.Drawing.Size(157, 88);
            tableLayoutPanel22.TabIndex = 32;
            // 
            // CropButton
            // 
            CropButton.Dock = System.Windows.Forms.DockStyle.Fill;
            CropButton.Enabled = false;
            CropButton.Location = new System.Drawing.Point(3, 3);
            CropButton.Name = "CropButton";
            CropButton.Size = new System.Drawing.Size(151, 23);
            CropButton.TabIndex = 0;
            CropButton.Text = "Crop Image";
            CropButton.UseVisualStyleBackColor = true;
            CropButton.Click += CropButton_Click;
            // 
            // tableLayoutPanel23
            // 
            tableLayoutPanel23.ColumnCount = 2;
            tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel23.Controls.Add(tableLayoutPanel24, 0, 1);
            tableLayoutPanel23.Controls.Add(tableLayoutPanel25, 0, 0);
            tableLayoutPanel23.Controls.Add(tableLayoutPanel26, 1, 0);
            tableLayoutPanel23.Controls.Add(tableLayoutPanel27, 1, 1);
            tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel23.Location = new System.Drawing.Point(3, 32);
            tableLayoutPanel23.Name = "tableLayoutPanel23";
            tableLayoutPanel23.RowCount = 2;
            tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel23.Size = new System.Drawing.Size(151, 53);
            tableLayoutPanel23.TabIndex = 1;
            // 
            // tableLayoutPanel24
            // 
            tableLayoutPanel24.ColumnCount = 2;
            tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel24.Controls.Add(cropYnum, 0, 0);
            tableLayoutPanel24.Controls.Add(CropYlabel, 1, 0);
            tableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel24.Location = new System.Drawing.Point(3, 29);
            tableLayoutPanel24.Name = "tableLayoutPanel24";
            tableLayoutPanel24.RowCount = 1;
            tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel24.Size = new System.Drawing.Size(69, 21);
            tableLayoutPanel24.TabIndex = 1;
            // 
            // cropYnum
            // 
            cropYnum.Dock = System.Windows.Forms.DockStyle.Fill;
            cropYnum.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            cropYnum.Location = new System.Drawing.Point(3, 3);
            cropYnum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            cropYnum.Name = "cropYnum";
            cropYnum.Size = new System.Drawing.Size(38, 22);
            cropYnum.TabIndex = 3;
            cropYnum.ValueChanged += cropYnum_ValueChanged;
            // 
            // CropYlabel
            // 
            CropYlabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CropYlabel.AutoSize = true;
            CropYlabel.Location = new System.Drawing.Point(47, 2);
            CropYlabel.Name = "CropYlabel";
            CropYlabel.Size = new System.Drawing.Size(19, 16);
            CropYlabel.TabIndex = 1;
            CropYlabel.Text = "Y";
            CropYlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel25
            // 
            tableLayoutPanel25.ColumnCount = 2;
            tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel25.Controls.Add(CropXlabel, 1, 0);
            tableLayoutPanel25.Controls.Add(cropXnum, 0, 0);
            tableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel25.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel25.Name = "tableLayoutPanel25";
            tableLayoutPanel25.RowCount = 1;
            tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel25.Size = new System.Drawing.Size(69, 20);
            tableLayoutPanel25.TabIndex = 2;
            // 
            // CropXlabel
            // 
            CropXlabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CropXlabel.AutoSize = true;
            CropXlabel.Location = new System.Drawing.Point(47, 2);
            CropXlabel.Name = "CropXlabel";
            CropXlabel.Size = new System.Drawing.Size(19, 16);
            CropXlabel.TabIndex = 1;
            CropXlabel.Text = "X";
            CropXlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cropXnum
            // 
            cropXnum.Dock = System.Windows.Forms.DockStyle.Fill;
            cropXnum.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            cropXnum.Location = new System.Drawing.Point(3, 3);
            cropXnum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            cropXnum.Name = "cropXnum";
            cropXnum.Size = new System.Drawing.Size(38, 22);
            cropXnum.TabIndex = 2;
            cropXnum.ValueChanged += cropXnum_ValueChanged;
            // 
            // tableLayoutPanel26
            // 
            tableLayoutPanel26.ColumnCount = 2;
            tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel26.Controls.Add(cropWnum, 0, 0);
            tableLayoutPanel26.Controls.Add(CropWlabel, 1, 0);
            tableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel26.Location = new System.Drawing.Point(78, 3);
            tableLayoutPanel26.Name = "tableLayoutPanel26";
            tableLayoutPanel26.RowCount = 1;
            tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel26.Size = new System.Drawing.Size(70, 20);
            tableLayoutPanel26.TabIndex = 3;
            // 
            // cropWnum
            // 
            cropWnum.Dock = System.Windows.Forms.DockStyle.Fill;
            cropWnum.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            cropWnum.Location = new System.Drawing.Point(3, 3);
            cropWnum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            cropWnum.Name = "cropWnum";
            cropWnum.Size = new System.Drawing.Size(39, 22);
            cropWnum.TabIndex = 3;
            cropWnum.ValueChanged += cropWnum_ValueChanged;
            // 
            // CropWlabel
            // 
            CropWlabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CropWlabel.AutoSize = true;
            CropWlabel.Location = new System.Drawing.Point(48, 2);
            CropWlabel.Name = "CropWlabel";
            CropWlabel.Size = new System.Drawing.Size(19, 16);
            CropWlabel.TabIndex = 1;
            CropWlabel.Text = "W";
            CropWlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel27
            // 
            tableLayoutPanel27.ColumnCount = 2;
            tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel27.Controls.Add(cropHnum, 0, 0);
            tableLayoutPanel27.Controls.Add(CropHlabel, 1, 0);
            tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel27.Location = new System.Drawing.Point(78, 29);
            tableLayoutPanel27.Name = "tableLayoutPanel27";
            tableLayoutPanel27.RowCount = 1;
            tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel27.Size = new System.Drawing.Size(70, 21);
            tableLayoutPanel27.TabIndex = 4;
            // 
            // cropHnum
            // 
            cropHnum.Dock = System.Windows.Forms.DockStyle.Fill;
            cropHnum.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            cropHnum.Location = new System.Drawing.Point(3, 3);
            cropHnum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            cropHnum.Name = "cropHnum";
            cropHnum.Size = new System.Drawing.Size(39, 22);
            cropHnum.TabIndex = 3;
            cropHnum.ValueChanged += cropHnum_ValueChanged;
            // 
            // CropHlabel
            // 
            CropHlabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CropHlabel.AutoSize = true;
            CropHlabel.Location = new System.Drawing.Point(48, 2);
            CropHlabel.Name = "CropHlabel";
            CropHlabel.Size = new System.Drawing.Size(19, 16);
            CropHlabel.TabIndex = 1;
            CropHlabel.Text = "H";
            CropHlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel21
            // 
            tableLayoutPanel21.ColumnCount = 2;
            tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.80412F));
            tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.19588F));
            tableLayoutPanel21.Controls.Add(tableLayoutPanel29, 1, 0);
            tableLayoutPanel21.Controls.Add(tableLayoutPanel20, 0, 0);
            tableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel21.Location = new System.Drawing.Point(3, 186);
            tableLayoutPanel21.Name = "tableLayoutPanel21";
            tableLayoutPanel21.RowCount = 1;
            tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel21.Size = new System.Drawing.Size(388, 91);
            tableLayoutPanel21.TabIndex = 33;
            // 
            // tableLayoutPanel29
            // 
            tableLayoutPanel29.ColumnCount = 1;
            tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel29.Controls.Add(tableLayoutPanel16, 0, 0);
            tableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel29.Location = new System.Drawing.Point(203, 3);
            tableLayoutPanel29.Name = "tableLayoutPanel29";
            tableLayoutPanel29.RowCount = 1;
            tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel29.Size = new System.Drawing.Size(182, 85);
            tableLayoutPanel29.TabIndex = 3;
            // 
            // tableLayoutPanel16
            // 
            tableLayoutPanel16.ColumnCount = 1;
            tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel16.Controls.Add(pixelateBar, 0, 1);
            tableLayoutPanel16.Controls.Add(label5, 0, 0);
            tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel16.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel16.Name = "tableLayoutPanel16";
            tableLayoutPanel16.RowCount = 2;
            tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel16.Size = new System.Drawing.Size(176, 79);
            tableLayoutPanel16.TabIndex = 30;
            // 
            // pixelateBar
            // 
            pixelateBar.BackColor = System.Drawing.SystemColors.ControlLight;
            pixelateBar.Dock = System.Windows.Forms.DockStyle.Top;
            pixelateBar.Location = new System.Drawing.Point(3, 23);
            pixelateBar.Minimum = 1;
            pixelateBar.Name = "pixelateBar";
            pixelateBar.Size = new System.Drawing.Size(170, 45);
            pixelateBar.TabIndex = 15;
            pixelateBar.Value = 1;
            pixelateBar.Scroll += pixelateBar_Scroll;
            pixelateBar.MouseCaptureChanged += pixelateBar_MouseCaptureChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = System.Windows.Forms.DockStyle.Fill;
            label5.Location = new System.Drawing.Point(2, 0);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(172, 20);
            label5.TabIndex = 3;
            label5.Text = "Pixelate";
            label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel20
            // 
            tableLayoutPanel20.ColumnCount = 1;
            tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel20.Controls.Add(firstLayerFill, 0, 1);
            tableLayoutPanel20.Controls.Add(tableLayoutPanel17, 0, 0);
            tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel20.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel20.Name = "tableLayoutPanel20";
            tableLayoutPanel20.RowCount = 2;
            tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel20.Size = new System.Drawing.Size(194, 85);
            tableLayoutPanel20.TabIndex = 33;
            // 
            // firstLayerFill
            // 
            firstLayerFill.AutoSize = true;
            firstLayerFill.Dock = System.Windows.Forms.DockStyle.Fill;
            firstLayerFill.Enabled = false;
            firstLayerFill.Location = new System.Drawing.Point(3, 63);
            firstLayerFill.Name = "firstLayerFill";
            firstLayerFill.Size = new System.Drawing.Size(188, 19);
            firstLayerFill.TabIndex = 28;
            firstLayerFill.Text = "Fill Canvas With First Color";
            firstLayerFill.UseVisualStyleBackColor = true;
            firstLayerFill.CheckedChanged += firstLayerFill_CheckedChanged;
            // 
            // tableLayoutPanel17
            // 
            tableLayoutPanel17.ColumnCount = 2;
            tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel17.Controls.Add(tableLayoutPanel18, 0, 0);
            tableLayoutPanel17.Controls.Add(tableLayoutPanel19, 1, 0);
            tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel17.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel17.Name = "tableLayoutPanel17";
            tableLayoutPanel17.RowCount = 1;
            tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            tableLayoutPanel17.Size = new System.Drawing.Size(188, 54);
            tableLayoutPanel17.TabIndex = 32;
            // 
            // tableLayoutPanel18
            // 
            tableLayoutPanel18.ColumnCount = 1;
            tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel18.Controls.Add(label3, 0, 1);
            tableLayoutPanel18.Controls.Add(skipColorBox, 0, 0);
            tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel18.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel18.Name = "tableLayoutPanel18";
            tableLayoutPanel18.RowCount = 2;
            tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel18.Size = new System.Drawing.Size(88, 48);
            tableLayoutPanel18.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(2, 23);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(84, 25);
            label3.TabIndex = 15;
            label3.Text = "Skip Colors";
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // skipColorBox
            // 
            skipColorBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            skipColorBox.Enabled = false;
            skipColorBox.Location = new System.Drawing.Point(2, 2);
            skipColorBox.Margin = new System.Windows.Forms.Padding(2);
            skipColorBox.MaxLength = 10;
            skipColorBox.Name = "skipColorBox";
            skipColorBox.Size = new System.Drawing.Size(84, 22);
            skipColorBox.TabIndex = 15;
            skipColorBox.Text = "0";
            skipColorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            skipColorBox.Leave += skipColorBox_Leave;
            // 
            // tableLayoutPanel19
            // 
            tableLayoutPanel19.ColumnCount = 1;
            tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel19.Controls.Add(label2, 0, 1);
            tableLayoutPanel19.Controls.Add(maxColorsBox, 0, 0);
            tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel19.Location = new System.Drawing.Point(97, 3);
            tableLayoutPanel19.Name = "tableLayoutPanel19";
            tableLayoutPanel19.RowCount = 2;
            tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel19.Size = new System.Drawing.Size(88, 48);
            tableLayoutPanel19.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(2, 27);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(84, 16);
            label2.TabIndex = 3;
            label2.Text = "Max Colors";
            label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // maxColorsBox
            // 
            maxColorsBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            maxColorsBox.Enabled = false;
            maxColorsBox.Location = new System.Drawing.Point(2, 2);
            maxColorsBox.Margin = new System.Windows.Forms.Padding(2);
            maxColorsBox.MaxLength = 10;
            maxColorsBox.Name = "maxColorsBox";
            maxColorsBox.Size = new System.Drawing.Size(84, 22);
            maxColorsBox.TabIndex = 14;
            maxColorsBox.Text = "8";
            maxColorsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            maxColorsBox.Leave += maxColorsBox_Leave;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.ColumnCount = 4;
            tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.92025F));
            tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.07975F));
            tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            tableLayoutPanel13.Controls.Add(randomBox, 3, 0);
            tableLayoutPanel13.Controls.Add(bicubicBox, 1, 0);
            tableLayoutPanel13.Controls.Add(vectorBox, 2, 0);
            tableLayoutPanel13.Controls.Add(directDrawBox, 0, 0);
            tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel13.Location = new System.Drawing.Point(3, 283);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 1;
            tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel13.Size = new System.Drawing.Size(388, 35);
            tableLayoutPanel13.TabIndex = 35;
            // 
            // randomBox
            // 
            randomBox.AutoSize = true;
            randomBox.Dock = System.Windows.Forms.DockStyle.Fill;
            randomBox.Location = new System.Drawing.Point(244, 3);
            randomBox.Name = "randomBox";
            randomBox.Size = new System.Drawing.Size(141, 29);
            randomBox.TabIndex = 43;
            randomBox.Text = "Random Draw";
            randomBox.UseVisualStyleBackColor = true;
            randomBox.CheckedChanged += randomBox_CheckedChanged;
            // 
            // bicubicBox
            // 
            bicubicBox.AutoSize = true;
            bicubicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            bicubicBox.Location = new System.Drawing.Point(86, 3);
            bicubicBox.Name = "bicubicBox";
            bicubicBox.Size = new System.Drawing.Size(74, 29);
            bicubicBox.TabIndex = 42;
            bicubicBox.Text = "Bicubic";
            bicubicBox.UseVisualStyleBackColor = true;
            bicubicBox.CheckedChanged += bicubic_CheckedChanged;
            // 
            // vectorBox
            // 
            vectorBox.AutoSize = true;
            vectorBox.Dock = System.Windows.Forms.DockStyle.Fill;
            vectorBox.Location = new System.Drawing.Point(166, 3);
            vectorBox.Name = "vectorBox";
            vectorBox.Size = new System.Drawing.Size(72, 29);
            vectorBox.TabIndex = 41;
            vectorBox.Text = "Vector";
            vectorBox.UseVisualStyleBackColor = true;
            vectorBox.CheckedChanged += vectorBox_CheckedChanged;
            // 
            // directDrawBox
            // 
            directDrawBox.AutoSize = true;
            directDrawBox.Dock = System.Windows.Forms.DockStyle.Fill;
            directDrawBox.Location = new System.Drawing.Point(3, 3);
            directDrawBox.Name = "directDrawBox";
            directDrawBox.Size = new System.Drawing.Size(77, 29);
            directDrawBox.TabIndex = 34;
            directDrawBox.Text = "D-Draw";
            directDrawBox.UseVisualStyleBackColor = true;
            directDrawBox.CheckedChanged += directDrawBox_CheckedChanged;
            // 
            // tableLayoutPanel14
            // 
            tableLayoutPanel14.ColumnCount = 2;
            tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel14.Controls.Add(tableLayoutPanel30, 1, 0);
            tableLayoutPanel14.Controls.Add(tableLayoutPanel28, 0, 0);
            tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel14.Location = new System.Drawing.Point(3, 324);
            tableLayoutPanel14.Name = "tableLayoutPanel14";
            tableLayoutPanel14.RowCount = 1;
            tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel14.Size = new System.Drawing.Size(388, 37);
            tableLayoutPanel14.TabIndex = 36;
            // 
            // tableLayoutPanel30
            // 
            tableLayoutPanel30.ColumnCount = 2;
            tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel30.Controls.Add(quantBox, 1, 0);
            tableLayoutPanel30.Controls.Add(label10, 0, 0);
            tableLayoutPanel30.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel30.Location = new System.Drawing.Point(197, 3);
            tableLayoutPanel30.Name = "tableLayoutPanel30";
            tableLayoutPanel30.RowCount = 1;
            tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            tableLayoutPanel30.Size = new System.Drawing.Size(188, 31);
            tableLayoutPanel30.TabIndex = 39;
            // 
            // quantBox
            // 
            quantBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            quantBox.Enabled = false;
            quantBox.FormattingEnabled = true;
            quantBox.Items.AddRange(new object[] { "Wu", "MedianCut", "Octree" });
            quantBox.Location = new System.Drawing.Point(53, 3);
            quantBox.Name = "quantBox";
            quantBox.Size = new System.Drawing.Size(132, 24);
            quantBox.TabIndex = 26;
            quantBox.SelectedIndexChanged += quantBox_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(3, 7);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(44, 16);
            label10.TabIndex = 27;
            label10.Text = "Quant";
            // 
            // tableLayoutPanel28
            // 
            tableLayoutPanel28.ColumnCount = 2;
            tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel28.Controls.Add(ditherBox, 1, 0);
            tableLayoutPanel28.Controls.Add(label4, 0, 0);
            tableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel28.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel28.Name = "tableLayoutPanel28";
            tableLayoutPanel28.RowCount = 1;
            tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            tableLayoutPanel28.Size = new System.Drawing.Size(188, 31);
            tableLayoutPanel28.TabIndex = 35;
            // 
            // ditherBox
            // 
            ditherBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ditherBox.Enabled = false;
            ditherBox.FormattingEnabled = true;
            ditherBox.Items.AddRange(new object[] { "None", "Bayer2x2", "Bayer3x3", "Bayer4x4", "Bayer8x8", "BlueNoise", "DottedHalftone", "Atkinson", "Burkes", "FloydSteinberg", "JarvisJudiceNinke", "Sierra2", "Sierra3", "SierraLite", "StevensonArce", "Stucki" });
            ditherBox.Location = new System.Drawing.Point(53, 3);
            ditherBox.Name = "ditherBox";
            ditherBox.Size = new System.Drawing.Size(132, 24);
            ditherBox.TabIndex = 26;
            ditherBox.Text = "None";
            ditherBox.SelectedIndexChanged += ditherBox_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 7);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(44, 16);
            label4.TabIndex = 27;
            label4.Text = "Dither";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(955, 607);
            Controls.Add(tableLayoutPanel1);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(2);
            MinimumSize = new System.Drawing.Size(572, 646);
            Name = "MainForm";
            Text = "Rec Room Painter";
            Activated += MainForm_Activated;
            Enter += MainForm_Enter;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel10.PerformLayout();
            tableLayoutPanel11.ResumeLayout(false);
            tableLayoutPanel11.PerformLayout();
            tableLayoutPanel12.ResumeLayout(false);
            tableLayoutPanel12.PerformLayout();
            tableLayoutPanel22.ResumeLayout(false);
            tableLayoutPanel23.ResumeLayout(false);
            tableLayoutPanel24.ResumeLayout(false);
            tableLayoutPanel24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cropYnum).EndInit();
            tableLayoutPanel25.ResumeLayout(false);
            tableLayoutPanel25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cropXnum).EndInit();
            tableLayoutPanel26.ResumeLayout(false);
            tableLayoutPanel26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cropWnum).EndInit();
            tableLayoutPanel27.ResumeLayout(false);
            tableLayoutPanel27.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cropHnum).EndInit();
            tableLayoutPanel21.ResumeLayout(false);
            tableLayoutPanel29.ResumeLayout(false);
            tableLayoutPanel16.ResumeLayout(false);
            tableLayoutPanel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pixelateBar).EndInit();
            tableLayoutPanel20.ResumeLayout(false);
            tableLayoutPanel20.PerformLayout();
            tableLayoutPanel17.ResumeLayout(false);
            tableLayoutPanel18.ResumeLayout(false);
            tableLayoutPanel18.PerformLayout();
            tableLayoutPanel19.ResumeLayout(false);
            tableLayoutPanel19.PerformLayout();
            tableLayoutPanel13.ResumeLayout(false);
            tableLayoutPanel13.PerformLayout();
            tableLayoutPanel14.ResumeLayout(false);
            tableLayoutPanel30.ResumeLayout(false);
            tableLayoutPanel30.PerformLayout();
            tableLayoutPanel28.ResumeLayout(false);
            tableLayoutPanel28.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button clearButton;
        public System.Windows.Forms.Button uploadButton;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        public System.Windows.Forms.Button DrawPositionButton;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox widthInput;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        public System.Windows.Forms.TextBox XBox;
        public System.Windows.Forms.Label XText;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        public System.Windows.Forms.TextBox YBox;
        public System.Windows.Forms.Label YText;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox heightInput;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        public System.Windows.Forms.TextBox GapXBox;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel22;
        public System.Windows.Forms.Button CropButton;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel24;
        public System.Windows.Forms.Label CropYlabel;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel25;
        public System.Windows.Forms.Label CropXlabel;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel26;
        public System.Windows.Forms.Label CropWlabel;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel27;
        public System.Windows.Forms.Label CropHlabel;
        public System.Windows.Forms.Button startButton;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.Button estButton;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        public System.Windows.Forms.Label estTimeLabel;
        public System.Windows.Forms.Label estTime;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel21;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        public System.Windows.Forms.CheckBox firstLayerFill;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox skipColorBox;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox maxColorsBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.CheckBox bicubicBox;
        private System.Windows.Forms.CheckBox vectorBox;
        private System.Windows.Forms.CheckBox directDrawBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel30;
        public System.Windows.Forms.ComboBox quantBox;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel28;
        public System.Windows.Forms.ComboBox ditherBox;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel29;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        public System.Windows.Forms.TrackBar pixelateBar;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox randomBox;
        private System.Windows.Forms.NumericUpDown cropYnum;
        private System.Windows.Forms.NumericUpDown cropXnum;
        private System.Windows.Forms.NumericUpDown cropWnum;
        private System.Windows.Forms.NumericUpDown cropHnum;
    }
}

