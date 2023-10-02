namespace RecRoomPainter
{
    partial class DrawPreviewForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.RU = new System.Windows.Forms.Button();
            this.buttonLU = new System.Windows.Forms.Button();
            this.buttonLD = new System.Windows.Forms.Button();
            this.buttonRD = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.setButtonTop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(22, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.RU, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonLU, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonLD, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonRD, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.setButton, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.setButtonTop, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 124);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // RU
            // 
            this.RU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RU.BackColor = System.Drawing.Color.Red;
            this.RU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RU.Location = new System.Drawing.Point(224, 0);
            this.RU.Margin = new System.Windows.Forms.Padding(0);
            this.RU.Name = "RU";
            this.RU.Size = new System.Drawing.Size(20, 20);
            this.RU.TabIndex = 4;
            this.RU.UseVisualStyleBackColor = false;
            this.RU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RU_MouseDown);
            this.RU.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RU_MouseMove);
            // 
            // buttonLU
            // 
            this.buttonLU.BackColor = System.Drawing.Color.Red;
            this.buttonLU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonLU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLU.Location = new System.Drawing.Point(0, 0);
            this.buttonLU.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLU.Name = "buttonLU";
            this.buttonLU.Size = new System.Drawing.Size(20, 20);
            this.buttonLU.TabIndex = 3;
            this.buttonLU.UseVisualStyleBackColor = false;
            this.buttonLU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonLU_MouseDown);
            this.buttonLU.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonLU_MouseMove);
            // 
            // buttonLD
            // 
            this.buttonLD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLD.BackColor = System.Drawing.Color.Red;
            this.buttonLD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonLD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLD.Location = new System.Drawing.Point(0, 104);
            this.buttonLD.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLD.Name = "buttonLD";
            this.buttonLD.Size = new System.Drawing.Size(20, 20);
            this.buttonLD.TabIndex = 5;
            this.buttonLD.UseVisualStyleBackColor = false;
            this.buttonLD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonLD_MouseDown);
            this.buttonLD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonLD_MouseMove);
            // 
            // buttonRD
            // 
            this.buttonRD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRD.BackColor = System.Drawing.Color.Red;
            this.buttonRD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonRD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRD.Location = new System.Drawing.Point(224, 104);
            this.buttonRD.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRD.Name = "buttonRD";
            this.buttonRD.Size = new System.Drawing.Size(20, 20);
            this.buttonRD.TabIndex = 6;
            this.buttonRD.UseVisualStyleBackColor = false;
            this.buttonRD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRD_MouseDown_1);
            this.buttonRD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonRD_MouseMove);
            // 
            // setButton
            // 
            this.setButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.setButton.BackColor = System.Drawing.Color.Lime;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("Arial Black", 8F);
            this.setButton.Location = new System.Drawing.Point(106, 107);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(31, 14);
            this.setButton.TabIndex = 2;
            this.setButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // setButtonTop
            // 
            this.setButtonTop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.setButtonTop.BackColor = System.Drawing.Color.Lime;
            this.setButtonTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButtonTop.Font = new System.Drawing.Font("Arial Black", 8F);
            this.setButtonTop.Location = new System.Drawing.Point(106, 3);
            this.setButtonTop.Name = "setButtonTop";
            this.setButtonTop.Size = new System.Drawing.Size(31, 14);
            this.setButtonTop.TabIndex = 7;
            this.setButtonTop.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 124);
            this.panel1.TabIndex = 0;
            // 
            // DrawPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 124);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DrawPreviewForm";
            this.Text = "Image Preview";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button buttonLU;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RU;
        private System.Windows.Forms.Button buttonLD;
        private System.Windows.Forms.Button buttonRD;
        public System.Windows.Forms.Button setButtonTop;
    }
}